from confluent_kafka import Producer
import json

def acked(err, msg):
    if err is not None:
        print("Failed to deliver message: %s: %s" % (str(msg), str(err)))
    else:
        print("Message produced: %s" % (str(msg)))

def sendKafka(msg):
    """
    Manda il messaggio al topic 'promethuesdata' 
    e richiama la funzione di ack.
    """

    conf = {'bootstrap.servers': "localhost:29092"}
    producer = Producer(conf)
    try:
        producer.produce("promethuesdata", key="Elementi", value=json.dumps(msg), callback=acked)
    except TypeError as e:
        print("Failed to deliver message: {}".format(e))
    producer.flush()