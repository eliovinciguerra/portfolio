import grpc
import echo_pb2
import echo_pb2_grpc
#-----
import mysql.connector
import datetime

import asyncio

#in questo modo arriva una richiesta e la serve, gli altri si mettono in coda, non importa quanto il job sia lungo.

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
        return "error"

def takeData(query):
    """
    Questa funzione preleva i dati dal database, 
    il paramentro query contiene il formato "SELECT 
    elemento FROM tabella WHERE condizione", questa 
    funzione è chiamata in EchoService, takeMetadata(), 
    takeValues(), takePred().

    In generale restituisce tutto sotto forma di lista 
    annidata ([[elemento1], [elemento2], [elemento3]]).
    """

    db=connDb()
    if db== "error":
        return db

    cursor = db.cursor()
    cursor.execute(query)
    list=[]
    for data in cursor:
        listElements=[]
        for elements in data:
            if isinstance(elements, datetime.datetime):
                elements= str(elements)
            listElements.append(elements)     #È una tupla, prendo il nome solamente
        list.append(listElements)

    cursor.close()
    db.close()
    return list

class EchoService(echo_pb2_grpc.EchoServiceServicer):
    async def takeAllMetrics(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Preleva dal database tutte le metriche contenute in metricsStats.
        Questo poiché proprio in quella tabella abbiamo tutti i valori di 
        min e max per tutte le metriche, quindi conterrà un elenco di tutte 
        le metriche disponibili.
        """

        data=takeData("SELECT DISTINCT metric FROM metricsStats;")
        return echo_pb2.Reply(content='%s' % data)

    async def takeMetadata(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Preleva dal database tutte le metriche divise 
        per valori relativi ai metadati (seasonal, 
        autocorrelazione e stazionarietà).
        """

        data=[]
        data.append(takeData("SELECT tempoInserimento, a FROM autocorrelation WHERE metric='"+request.content+"';"))
        data.append(takeData("SELECT tempoInserimento, valore FROM seasonability WHERE metric='"+request.content+"';"))
        data.append(takeData("SELECT tempoInserimento, ADFTest, pValue, nLagsUsed, nObs, CriticalValue1, CriticalValue5, CriticalValue10 FROM stationarity WHERE metric='"+request.content+"';"))
        return echo_pb2.Reply(content='%s' % data)

    async def takeValues(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Preleva dal database tutti i dati correlati alla metrica inserita 
        dall'utente divisi per valori relativi alle misurazioni con startime 
        a 1, 3 e 12 ore.
        """

        data=takeData("SELECT * FROM metricsStats WHERE metric='"+request.content+"';")
        return echo_pb2.Reply(content='%s' % data)

    async def takePred(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Preleva dal database tutte le previsioni di una data metrica
        che viene passata dal client.
        """

        data=takeData("SELECT * FROM predStats WHERE metric='"+request.content+"';")
        return echo_pb2.Reply(content='%s' % data)

async def serve() -> None:
    """
    Funzione di avvio del server.
    """

    port = '50051'
    server = grpc.aio.server()
    echo_pb2_grpc.add_EchoServiceServicer_to_server(EchoService(), server)
    server.add_insecure_port('[::]:' + port)
    await server.start()
    print("Echo Service started, listening on " + port)
    await server.wait_for_termination()

if __name__ == '__main__':
    asyncio.run(serve())
