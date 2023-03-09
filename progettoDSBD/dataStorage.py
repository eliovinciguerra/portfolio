import mysql.connector
import sys
#dataStorage, immagazzinare le metriche nel db mysql
def connDb():
    """
    Tenta di connettersi al database mysql, altrimenti ritorna un errore.
    """
    
    try:
        db = mysql.connector.connect(
        host="127.0.0.1",
        user="progettoDSBD",
        password="prova",
        database="PythonDBTest"
        )
        if db.is_connected():
            return db
    except mysql.connector.Error as e:
        sys.exit("SQL DB connection failed.")

def insertDb(db, query):
    """
    Tenta di inserire dati nel database mysql, 
    altrimenti ritorna un errore. La query 
    viene mandata come parametro.
    """

    try:
        mycursor = db.cursor()
        mycursor.execute(query)
        db.commit()

    except mysql.connector.Error as e:
        sys.exit(e)


def saveData(data):
    """
    Scorre i dati metrica dopo metrica (in realtà il 
    messaggio contiene una sola metrica, per come 
    abbiamo risistemato l'ETLDataPipeline, ma se si 
    volessero mandare più metriche non sarebbe necessario 
    modificare nulla in questa funzione).

    Viene quindi effettuata la connessione al database,
    viene richiamata la funzione per memorizzare nel 
    database i dati relativi ad ogni parametro della 
    metrica, controllando se esistono tali parametri, 
    in quanto non sempre sono disponibili (in metadati 
    potrebbero anche non esserci, come spiegato nella 
    relativa funzione in ETLDataPipeline, inoltre la 
    predizione non viene effettuata su tutte le metriche,
    ma solo su un set ristretto).
    """

    db= connDb()
    #scorre le metriche e le inserisce nel db per nome chiamando la funzione insertDb
    for name in data:
        insertDb(db, "INSERT INTO metricsStats(metric, typeValue, max, min, avg, devstd) VALUES ('"+name+"','valori1h','"+str(data[name]['valori1h']['max'])+"','"+str(data[name]['valori1h']['min'])+"','"+str(data[name]['valori1h']['avg'])+"','"+str(data[name]['valori1h']['std'])+"');")

        insertDb(db, "INSERT INTO metricsStats(metric, typeValue, max, min, avg, devstd) VALUES ('"+name+"','valori3h','"+str(data[name]['valori3h']['max'])+"','"+str(data[name]['valori3h']['min'])+"','"+str(data[name]['valori3h']['avg'])+"','"+str(data[name]['valori3h']['std'])+"');")
        
        insertDb(db, "INSERT INTO metricsStats(metric, typeValue, max, min, avg, devstd) VALUES ('"+name+"','valori12h','"+str(data[name]['valori12h']['max'])+"','"+str(data[name]['valori12h']['min'])+"','"+str(data[name]['valori12h']['avg'])+"','"+str(data[name]['valori12h']['std'])+"');")
        
        #l'inserimento nel db avviene solo in presenza dei nomi "autocorrelazione", "stazionarietà", "pred"
        if "autocorrelazione" in data[name]['dictValues']:
            for a in data[name]['dictValues']['autocorrelazione']:
                insertDb(db, "INSERT INTO autocorrelation (metric, a) VALUES ('"+name+"','"+str(a)+"');")
        
        if "stazionarietà" in data[name]['dictValues']:
            insertDb(db, "INSERT INTO stationarity (metric, ADFTest, pValue, nLagsUsed, nObs, CriticalValue1, CriticalValue5, CriticalValue10) VALUES ('"+name+"','"+str(data[name]['dictValues']['stazionarietà']['ADF test statistic'])+"','"+str(data[name]['dictValues']['stazionarietà']['p-value'])+"','"+str(data[name]['dictValues']['stazionarietà']['# lags used'])+"','"+str(data[name]['dictValues']['stazionarietà']['# observations'])+"','"+str(data[name]['dictValues']['stazionarietà']['critical value (1%)'])+"','"+str(data[name]['dictValues']['stazionarietà']['critical value (5%)'])+"','"+str(data[name]['dictValues']['stazionarietà']['critical value (10%)'])+"');")
        
        if "stagionalità" in data[name]['dictValues']:
            for k, v in data[name]['dictValues']['stagionalità'].items():
                insertDb(db, "INSERT INTO seasonability (metric, tempo, valore) VALUES ('"+name+"','"+str(k)+"','"+str(v)+"');")

        if "pred" in data[name]:
            insertDb(db, "INSERT INTO predStats(metric, max, min, avg) VALUES ('"+name+"','"+str(data[name]['pred']['max'])+"','"+str(data[name]['pred']['min'])+"','"+str(data[name]['pred']['avg'])+"');")

    db.cursor().close()
    db.close()