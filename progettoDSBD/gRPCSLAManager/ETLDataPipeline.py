from prometheus_api_client import PrometheusConnect, MetricRangeDataFrame
from prometheus_api_client.utils import parse_datetime
import prometheus_api_client


from statsmodels.tools.sm_exceptions import ConvergenceWarning
from statsmodels.tsa.holtwinters import ExponentialSmoothing
from statsmodels.tsa.seasonal import seasonal_decompose
from statsmodels.tsa.stattools import adfuller
import statsmodels.api as sm

import timeExecution
import Producer

import matplotlib.pyplot as plt
from datetime import timedelta
import time
import sys

import warnings
warnings.filterwarnings("ignore", category=ConvergenceWarning)
"""
Abbiamo messo il filtro per il convergenceWarning poiché tale warning 
non risulta essere legato al nostro codice o ai dati che abbiamo 
raccolto, inoltre online non abbiamo trovato soluzioni applicabili.

A seguire il warning generato:
/Users/elio/Library/Python/3.9/lib/python/site-packages/statsmodels/tsa/holtwinters/model.py:915: 
ConvergenceWarning: Optimization failed to converge. Check mle_retvals.       
warnings.warn(
"""

def getPromURL():
  """
  Restituisce l'url Prometheus.
  """

  return "http://localhost:9090"

def getJob():
  """
  Restituisce il job.
  """

  return 'node_exporter'

def initialization(start, minChunk, metricsName):
  """
  Estrazione dei valori relativi alle metriche di
  prometheus appartenenti al job "node_exporter".
  """

  try:
    prom = PrometheusConnect(url=getPromURL(), disable_ssl=True)
    if prom.check_prometheus_connection():
      start_time = parse_datetime(start)
      end_time = parse_datetime("now")
      chunk_size = timedelta(minutes=minChunk)
      label_config = {'job': getJob()}
      dict={}
      for name in metricsName:
        metric_data = prom.get_metric_range_data( # https://prometheus-api-client-python.readthedocs.io/en/latest/source/prometheus_api_client.html.
          metric_name=name,
          label_config=label_config,              # A dictionary that specifies metric labels and their values.
          start_time=start_time,
          end_time=end_time,
          chunk_size=chunk_size,
        )
        dict[name]=metric_data
      return dict
  except prometheus_api_client.exceptions.PrometheusApiClientException as e:
    sys.exit("Prometheus connection failed or data not fetched.. ")

def stationarity(values):
  """
  Calcolo stazionarietà e inserimento di 
  alcuni parametri dentro un dictionary.
  """

  stationarityTest = adfuller(values,autolag='AIC')
  stationarityTestOut={'ADF test statistic': stationarityTest[0], 
                      'p-value': stationarityTest[1],
                      '# lags used': stationarityTest[2],
                      '# observations': stationarityTest[3]
                      }
  for key,val in stationarityTest[4].items():
    stationarityTestOut[f'critical value ({key})']=val
  return stationarityTestOut

def seasonal(values):
  """
  Calcolo seasonal e inserimento dentro un dictionary.

  Con values molto lunghi, quindi con startime elevati, 
  il dictionary di ritorno assume lunghezze elevate, 
  motivo per il quale abbiamo deciso che, qualora ci 
  fosse un numero sufficiente di valori tale che non 
  viene attivata l'eccezione ValueError, si procede 
  a prendere un campione ogni 5 minuti, ovvero da values 
  viene inserito nel dataframe new_df un campione ogni 60.
  (5 minuti sono 300 secondi, diviso 5secondi -ovvero il 
  tempo di ogni campione per metrica che viene prelevato 
  da prometheus- otteniamo 60).

  Si è resa necessaria la conversione in dictionary, poiché 
  altrimenti la serializzazione non avviene.
  """

  try:
    numero=60
    new_df = values[::numero]
    result= seasonal_decompose(new_df, model='additive', period=5)
    serializable_result = {str(k): v for k, v in result.seasonal.to_dict().items()}
  except:
    result= seasonal_decompose(values, model='additive', period=5) 
    serializable_result = {str(k): v for k, v in result.seasonal.to_dict().items()}
  
  return serializable_result

def autocorr(values):
  """
  Calcolo autocorrelazione.

  Si è resa necessaria la conversione in lista, poiché 
  altrimenti la serializzazione non avviene.
  """

  return sm.tsa.acf(values).tolist()

def valuesCalc(metrics):
  """
  Richiama funzione di autocorrelazione, seasonal e 
  stazionarietà per ogni metrica e inserisce i 
  valori in un dictionary.

  Nota: Nel caso in cui tutti i valori della metrica
        siano pari a zero, i valori delle funzioni 
        non avrebbero senso o risulterebbero NaN, 
        motivo per cui evitiamo il calcolo, 
        restituiendo un dictionary vuoto.
  """

  dictValues={}
  for name in metrics:
    metric_df = MetricRangeDataFrame(metrics[name])

    #fig = tsaplots.plot_acf(autocorr(metric_df['value'], lags=10)
    #fig.savefig(fname=name)

    count=0
    for check in metric_df['value']:
      if check==0.0:            # controlliamo quante volte sono presenti valori 0 e li contiamo 
        count+=1

    if count== len(metric_df['value']):# se tutto il dataframe è composto da values pari a zero non svolgiamo il calcolo dei metadati.
      dictValues[name]={}
    else:
      dictValues[name]={"autocorrelazione": autocorr(metric_df['value']),
                      "stazionarietà": stationarity(metric_df['value']),
                      "stagionalità": seasonal(metric_df['value'])}
  return dictValues

def parameters(metrics):
  """
  Dall'elenco di metriche passate come input
  vengono processate tutte singolarmente per
  ottenere i valori di massimo, minimo, media 
  e deviazione standard.
  """

  dict={}
  for name in metrics:
    metric_df = MetricRangeDataFrame(metrics[name])
    dict[name]={"max": metric_df['value'].max(),
                "min": metric_df['value'].min(),
                "avg": metric_df['value'].mean(),
                "std": metric_df['value'].std()}
  return (dict)

def predict(Metrics):
  """
  Predizione dello SLASet ristretto 
  composto da 5 metriche.
  Ogni metrica viene convertita in un dataframe, successivamente 
  viene fatto resampling a 5s e vengono passati i value alla 
  funzione ExponentialSmoothing(), con la funzione .interpolate() 
  siamo in grado di interpolare (di default linearmente) i valori 
  non validi. (Se non avessimo usato questa funzione ma .dropna() 
  avrebbe potuto restituire un ValueWarning).

  Successivamente la predizione viene effettuata con il metodo 
  forecast(), il cui parametro indica la quantità di campioni 
  che deve prevedere, in particolare round((10*60)/5) calcola
  10 minuti in secondi e poi divide per 5sec, ovvero il tempo
  che intercorre tra un campione e l'altro, in modo da avere 
  il numero di campioni necessari per una predizione di 10 minuti.

  Successivamente vengono calcolati massimo, minimo e media e viene
  messo tutto in un dictionary.

  Nota: Abbiamo commentato la parte relativa ai plot, la cui libreria 
  di riferimento è  matplotlib.pyplot.
  """

  dictPred={}
  for name in Metrics:
    metric_df = MetricRangeDataFrame(Metrics[name])

    data= metric_df.resample(rule='5s').mean(numeric_only="True")

    tsmodel = ExponentialSmoothing(data['value'].interpolate(), trend='add', seasonal='add',seasonal_periods=5).fit()
    
    prediction = tsmodel.forecast(steps=round((10*60)/5))

    # plt.figure(figsize=(24,10))
    # plt.ylabel('Values', fontsize=14)
    # plt.xlabel('Time', fontsize=14)
    # plt.title('Values over time', fontsize=16)
    
    # plt.plot(data, "-", label = 'train')
    # plt.plot(prediction,"--",label = 'pred')
    # plt.legend(title='Series')
    # # plt.show()
    # plt.savefig(fname=name)

    dictPred[name]={"max": prediction.max(),
                "min": prediction.min(),
                "avg": prediction.mean()}
  return dictPred

def generateAndSendMsgKakfa(valori1h, valori3h, valori12h, dictValues, pred, metricsName):
  """
  Generazione del messaggio che riceverà il producer kafka, che si trova in Producer.py.
  Abbiamo optato per la divisione del pacchetto intero in più messaggi per evitare che 
  il messaggio non venisse inviato a causa del troppo peso, altra soluzione sarebbe stata 
  quella di modificare il file di configurazione kafka per ampliare il peso massimo di ogni 
  messaggio.
  """
  
  for name in metricsName:
    msg={}                #la seasonality è troppo pesante quando ho tempi elevati, invio un name alla volta a kafka.
    if name in pred:
      msg[name]={"valori1h": valori1h[name], "valori3h":valori3h[name], "valori12h":valori12h[name], "dictValues":dictValues[name], "pred": pred[name]}
    else:
      msg[name]={"valori1h": valori1h[name], "valori3h":valori3h[name], "valori12h":valori12h[name], "dictValues":dictValues[name]}

    Producer.sendKafka(msg)

def start(metricsName, metricsNamePrediction):
  """
  Richiamo alle funzioni per calcolare i dati e uso del timestamp 
  per indicazione temporale sulla quantità di tempo che impiega 
  ogni fase. Tali indicazioni saranno poi inviate alla funzione 
  sendTimeExe(), che risiede in timeExecution.py, essa genera un 
  log.
  """

  timestampInizio=time.time()
  
  metrics1h=initialization("1h", 5, metricsName)
  val1h=parameters(metrics1h)

  timestampMetriche1h=time.time()
  tempoExe1h=timestampMetriche1h-timestampInizio
  
  metrics3h=initialization("3h", 5, metricsName)
  val3h=parameters(metrics3h)
  
  timestampMetriche3h=time.time()
  tempoExe3h=timestampMetriche3h-timestampMetriche1h
  
  metrics12h=initialization("12h", 5, metricsName)
  val12h=parameters(metrics12h)
  
  timestampMetriche12h=time.time()
  tempoExe12h=timestampMetriche12h-timestampMetriche3h

  metricsRestricted=initialization("12h", 5, metricsNamePrediction)
  predizione= predict(metricsRestricted)

  timestampMetrichePredizione=time.time()
  tempoExePred=timestampMetrichePredizione-timestampMetriche12h

  #metadataValue=initialization("12h", 5, metricsName)                 # Attesa troppo elevata, con 24h sono 187.974 secondi di computazione dlla funzione al rigo successivo.
  dictValues=valuesCalc(metrics12h)
  
  timestampValori=time.time()
  tempoExeValori=timestampValori-timestampMetrichePredizione

  timeExecution.sendTimeExe(tempoExe1h, tempoExe3h, tempoExe12h, tempoExePred, tempoExeValori) # i valori temporali verranno mandati al timeExecution.py 

  generateAndSendMsgKakfa(val1h, val3h, val12h, dictValues, predizione, metricsName) #generazione e invio messaggi a kafka