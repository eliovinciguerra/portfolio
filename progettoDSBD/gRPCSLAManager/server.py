import grpc
import echo_pb2
import echo_pb2_grpc
#-----
import sys
import ast
import ETLDataPipeline
from prometheus_api_client import PrometheusConnect
import prometheus_api_client

import asyncio

def getAllMetricsFromPrometheus():
    """
    Prende tutte le metriche da prometheus 
    ma solo se esse contengono nel nome 'node_'
    saranno aggiunte nella lista nodeExp, questo 
    perché 'node_' è il prefisso delle metriche 
    di node_exporter (funzione non utilizzata, 
    ma sostituibile alla successiva).

    Abbiamo inoltre implementato una funzione in 
    ETLDataPipeline per recuperare l'URL di Prometheus
    (qualora si volesse utilizzare un prometheus 
    diverso da quello locale)
    """

    try:
        prom = PrometheusConnect(url=ETLDataPipeline.getPromURL(), disable_ssl=True)
        if prom.check_prometheus_connection():
            list=prom.all_metrics()
            if(ETLDataPipeline.getJob()=='node_exporter'):
                nodeExp=[]
                for metric in list:
                        if metric.startswith("node_"):
                            nodeExp.append(metric)
            else:
                nodeExp=list
            return nodeExp
    except prometheus_api_client.exceptions.PrometheusApiClientException as e:
        sys.exit("Prometheus connection failed or data not fetched.. ")

def getAllMetrics():
    """
    Restituisce un set di metriche impostate per 
    default, al momento stiamo usando questa soluzione 
    e non la funzione 'getAllMetricsFromPrometheus()', 
    ma se dovessimo cambiare exporter o utilizzare 
    metriche non presenti in questa lista, potremmo 
    fare qualche modifica alla funzione citata sopra.
    """

    if ETLDataPipeline.getJob()=='node_exporter':
        metricsName=["node_power_supply_time_to_empty_seconds", "node_disk_written_bytes_total", 
                "node_disk_written_sectors_total", "node_disk_read_bytes_total", 
                "node_disk_read_sectors_total", "node_disk_write_errors_total", 
                "node_disk_read_errors_total", "node_filesystem_avail_bytes", 
                "node_filesystem_device_error", "node_filesystem_size_bytes", 
                "node_memory_active_bytes", "node_memory_inactive_bytes", 
                "node_memory_purgeable_bytes", "node_network_receive_packets_total", #Purgeable Memory: https://developer.apple.com/library/archive/documentation/Performance/Conceptual/ManagingMemory/Articles/CachingandPurgeableMemory.html
                "node_memory_free_bytes", "node_network_transmit_multicast_total", 
                "node_network_transmit_packets_total", "node_network_receive_multicast_total"]
    else:
        metricsName=getAllMetricsFromPrometheus()
    return metricsName

class EchoService(echo_pb2_grpc.EchoServiceServicer):
    async def takeAllMetrics(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Chiama una delle due funzioni discusse 
        sopra e restituisce il risultato.
        """

        metricsName=getAllMetrics()
        #metricsName=getAllMetricsFromPrometheus()
        return echo_pb2.Reply(content='%s' % metricsName)
    
    async def takeDefaultRangedValue(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Restituisce al client uno SLASet di default.
        """

        if ETLDataPipeline.getJob()=='node_exporter':
            SLARangedValues={"node_disk_written_bytes_total":{"min": 375734272.0,"max": 5198675968.0 }, 
                        "node_memory_free_bytes":{"min": 1500.0,"max": 0.0 }, #il valore originale scelto di max è: 1934520320, abbiamo messo 0.0 per essere sicuri di avere qualche violazione.
                        "node_filesystem_avail_bytes":{"min": 0.0,"max": 63632191488.0 }, 
                        "node_memory_active_bytes":{"min": 872808448.0,"max": 3386314752.0 }, 
                        "node_network_receive_packets_total":{"min": 0.0,"max": 1842406.0 }
                        }
        else:
            SLARangedValues={}
        return echo_pb2.Reply(content='%s' % SLARangedValues)

    async def callETLDataPipeline(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Prende in input lo SLASet mandato dal client, 
        richiede la lista di tutte le metriche a getAllMetrics() 
        ed avvia ETLDataPipeline.
        """

        try:
            SLASet = ast.literal_eval(request.content)
        except (ValueError, SyntaxError, TypeError):
            return echo_pb2.Reply(content='%s' % "Errore")
            
        metricsName=getAllMetrics()
        ETLDataPipeline.start(metricsName, SLASet)
        return echo_pb2.Reply(content='%s' % "Terminato ETLDataPipeline")

    async def getViolationsForSLAManager(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Prende in input le metriche mandate dal client e
        calcola se vi sono state violazioni del valore 
        minimo o massimo.
        """

        try:
            SLASet = ast.literal_eval(request.content)
        except (ValueError, SyntaxError, TypeError):
            return echo_pb2.Reply(content='%s' % "Errore")

        list=[]

        listType=['1h', '3h', '12h']
        
        list.append(ETLDataPipeline.initialization(listType[0], 5, SLASet))
        
        list.append(ETLDataPipeline.initialization(listType[1], 5, SLASet))
        
        list.append(ETLDataPipeline.initialization(listType[2], 5, SLASet))

        violazioni={}
        type=0
        for listElement in list:
            for name in listElement:
                metric_df = ETLDataPipeline.MetricRangeDataFrame(listElement[name])
                for i in range(len(metric_df['value'])):
                    if metric_df['value'][i]>SLASet[name]["max"]:
                        violazioni[name]={"max":{
                                                "value": metric_df['value'][i]
                                                },
                                        "type":listType[type]
                                        }
                    if metric_df['value'][i] <SLASet[name]["min"]:
                        violazioni[name]={"min":{
                                                "value": metric_df['value'][i]
                                                },
                                        "type":listType[type]
                                        }
            type+=1
        return echo_pb2.Reply(content='%s' % violazioni)

    async def getFutureViolationsForSLAManager(
            self, request: echo_pb2.Request,
            context: grpc.aio.ServicerContext) -> echo_pb2.Reply:
        """
        Prende in input le metriche mandate dal client 
        e calcola se vi saranno violazioni future
        tramite un calcolo della predizione, la cui 
        implementazione è in ETLDataPipeline.
        """
        
        try: 
            SLASet = ast.literal_eval(request.content)
        except (ValueError, SyntaxError, TypeError):
            return echo_pb2.Reply(content='%s' % "Errore")

        metricsPred=ETLDataPipeline.initialization("12h", 5, SLASet)
        pred=ETLDataPipeline.predict(metricsPred)

        violazioni={}

        for name in SLASet:
            if pred[name]["max"]>SLASet[name]["max"]:
                violazioni[name]={"max":{
                                        "value": pred[name]["max"]
                                        }
                                }
            if pred[name]["min"]<SLASet[name]["min"]:
                violazioni[name]={"min":{
                                        "value": pred[name]["min"]
                                        }
                                }
        return echo_pb2.Reply(content='%s' % violazioni)

async def serve() -> None:
    """
    Funzione di avvio del server.
    """
    
    port = '50052'
    server = grpc.aio.server()
    echo_pb2_grpc.add_EchoServiceServicer_to_server(EchoService(), server)
    server.add_insecure_port('[::]:' + port)
    await server.start()
    print("Echo Service started, listening on " + port)
    await server.wait_for_termination()

if __name__ == '__main__':
    asyncio.run(serve())
