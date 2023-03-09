from __future__ import print_function

import grpc
import echo_pb2
import echo_pb2_grpc

import ast
import json
import sys

def run():
    """
    Funzione di avvio del client (implementazione del menù per le 
    funzionalità richieste).
    
    Nel caso in cui l'utente scelga di lanciare il microservizio 
    ETLDataPipeline verrà eseguito asincronamente, per permettere 
    all'utente di fare altre operazioni, in quanto l'esecuzione, i 
    risultati e la terminazione di ETLDataPipeline non interferiscono 
    col client, ne forniscono informazioni aggiuntive (a fine esecuzione 
    viene solamente ricevuto un messaggio di avvenuta terminazione 
    dell'operazione).
    """
    def process_response(call_future):

        print(call_future.result().content)
    
    with grpc.insecure_channel('localhost:50052') as channel:   # potrebbe generare errore in 2 casi o la porta è occupata oppure manca questo 
                                                                #python -m grpc_tools.protoc -I../../protos --python_out=. --grpc_python_out=. ../../protos/route_guide.proto
        
        stub = echo_pb2_grpc.EchoServiceStub(channel)
        response = stub.takeAllMetrics(echo_pb2.Request())

        try:
            metricsName = ast.literal_eval(response.content)
        except (ValueError, SyntaxError, TypeError):
            sys.exit("Errore nel formato della risposta o nella risposta stessa.")

        response = stub.takeDefaultRangedValue(echo_pb2.Request())

        try:
            SLARangedValues = ast.literal_eval(response.content)
        except (ValueError, SyntaxError, TypeError):
            sys.exit("Errore nel formato della risposta o nella risposta stessa.")
        
        risp='s'                                # se non c'è uno SLASet di default, l'utente deve inserirlo (caso in cui si sceglie un altro job)
        if SLARangedValues:
            metricsNamePrediction=[]
            for name in SLARangedValues:
                metricsNamePrediction.append(name)
            #scelta utente se usare un set di metriche di default con relativi valori di default 
            risp=input("Abbiamo già impostato uno SLA Set di default con range di default, vuoi visualizzarlo? (s/n) ")
            if (risp.__contains__("s")):
                print("Ok, ecco l'elenco: ", metricsNamePrediction)
            
            risp=input("Vuoi modificare l'SLA Set? (s/n) ")
        #scelta utente se usare un set di metriche di default o sceglierle lui da una lista che gli verrà formita in seguito alla scelta s
        if (risp.__contains__("s")):
            print("Scegli 5 metriche da questo elenco: ", metricsName)
            
            metricsNamePrediction=[]
            SLARangedValues={}
            i=0
            #itera finché non saranno inserite correttamente 5 metriche diverse tra loro 
            while i<5:
                metricaScelta=input("Scelta numero "+str(i+1)+": ")
                if metricaScelta in metricsNamePrediction:
                    print("Metrica già scelta.")
                elif metricaScelta not in metricsName:
                    print("Metrica non valida.")
                else:
                    print("Ok, imposta il range dei valori ammissibili per questa metrica: ")
                    min= input("Valore minimo: ")
                    max= input("Valore massimo: ")
                    if(min<max):
                        SLARangedValues[metricaScelta]={"min": min,
                                                        "max": max }
                        metricsNamePrediction.append(metricaScelta)
                        i+=1
                    else:
                        print("Errato, inserisci nuovamente.")

        flag=True
        #dopo aver inserito le metriche o aver scelto il set di default verrà mostrato un menù di scelta in cui l'utente avrà diverse possibilità di uso delle metriche
        while flag:
            risp=input("Cosa desideri fare?\n1- Lancia ETLDataPipeline e manda i risultati al topic Kafka.\n2-Query Stato SLA.\n3-Numero di violazioni delle ultime 1, 3 e 12 ore sull'SLA Set.\n4-Query su possibili violazioni future dello SLA Set.\nRisposta: ")
            #le scelte fatte saranno inoltrate a ETL DATA PIPELINE che si occuperà di calcolare e restituire i risultati 
            if risp=='1':
                print("Ok, mentre eseguo puoi fare altre azioni, mostrerò l'avvenuta terminazione successivamente, se non chiudi l'applicazione.")
                call_future = stub.callETLDataPipeline.future(echo_pb2.Request(content=json.dumps(SLARangedValues)))
                call_future.add_done_callback(process_response)
                
            elif risp=='2':
                print("Eseguo la richiesta.\n")

                print("Ti mostro le violazioni dello SLA Set.\n")
                response=stub.getViolationsForSLAManager(echo_pb2.Request(content=json.dumps(SLARangedValues)))
                try: 
                    violazioni = ast.literal_eval(response.content)
                except (ValueError, SyntaxError, TypeError):
                    sys.exit("Errore nel formato della risposta o nella risposta stessa.")

                if violazioni=={}:
                    print("Nessuna metrica ha violato il range.")
                else:
                    for name in violazioni:
                        if "max" in violazioni[name]:
                            print("La metrica", name, "ha violato il massimo, con un valore di",violazioni[name]["max"]["value"],", tale valore è stato rilevato nelle misurazioni avvenute meno di",violazioni[name]['type'], "fa.")
                        if "min" in violazioni[name]:
                            print("La metrica", name, "ha violato il minimo, con un valore di",violazioni[name]["min"]["value"],", tale valore è stato rilevato nelle misurazioni avvenute meno di",violazioni[name]['type'], "fa.")

                print("Ti mostro le possibili violazioni future dello SLA Set.\n")
                response=stub.getFutureViolationsForSLAManager(echo_pb2.Request(content=json.dumps(SLARangedValues)))

                try:
                    violazioni = ast.literal_eval(response.content)
                except (ValueError, SyntaxError, TypeError):
                    sys.exit("Errore nel formato della risposta o nella risposta stessa.")

                if violazioni=={}:
                    print("Nessuna metrica dovrebbe violare il range.")
                else:
                    for name in violazioni:
                        if "max" in violazioni[name]:
                            print("La metrica", name, "potrebbe violare il massimo, con un valore di",violazioni[name]["max"]["value"])
                        if "min" in violazioni[name]:
                            print("La metrica", name, "potrebbe violare il minimo, con un valore di",violazioni[name]["min"]["value"])
            elif risp =='3':
                print("Eseguo la richiesta.\n")
                response=stub.getViolationsForSLAManager(echo_pb2.Request(content=json.dumps(SLARangedValues)))
                try: 
                    violazioni = ast.literal_eval(response.content)
                except (ValueError, SyntaxError, TypeError):
                    sys.exit("Errore nel formato della risposta o nella risposta stessa.")

                if violazioni=={}:
                    print("Nessuna metrica ha violato il range.")
                else:
                    for name in violazioni:
                        countMax=0
                        countMin=0
                        if "max" in violazioni[name]:
                            countMax+=1
                        if "min" in violazioni[name]:
                            countMin+=1

                        if countMax != 0:
                            print("La metrica", name, "ha violato il massimo", countMax, "volte")
                        if countMin != 0:
                            print("La metrica", name, "ha violato il minimo", countMin, "volte")
            elif risp=='4':
                print("Eseguo la richiesta.\n")
                response=stub.getFutureViolationsForSLAManager(echo_pb2.Request(content=json.dumps(SLARangedValues)))

                try:
                    violazioni = ast.literal_eval(response.content)
                except (ValueError, SyntaxError, TypeError):
                    sys.exit("Errore nel formato della risposta o nella risposta stessa.")

                if violazioni=={}:
                    print("Nessuna metrica dovrebbe violare il range.")
                else:
                    for name in violazioni:
                        if "max" in violazioni[name]:
                            print("La metrica", name, "potrebbe violare il massimo, con un valore di",violazioni[name]["max"]["value"])
                        if "min" in violazioni[name]:
                            print("La metrica", name, "potrebbe violare il minimo, con un valore di",violazioni[name]["min"]["value"])
            decisione=input("Desideri fare altro? (s/n) ")
            if (decisione.__contains__("n")):
                flag=False

if __name__ == '__main__':
    run()
