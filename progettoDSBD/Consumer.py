from confluent_kafka import Consumer
import json
import dataStorage

"""
Preleva i messaggi dal topic 'promethuesdata' dopo essersi sottoscritto,
li converte in dictionary e li stampa, per poi passare tutto come parametro
alla funzione saveData(), contenuta in dataStorage.py.
"""

c = Consumer({
    'bootstrap.servers': 'localhost:29092',
    'group.id': 'alldata',
    'auto.offset.reset': 'earliest'
})

c.subscribe(['promethuesdata'])

while True:
    msg = c.poll(1.0)

    if msg is None:
        continue
    if msg.error():
        print("Consumer error: {}".format(msg.error()))
        continue
    
    try:
        data = json.loads(msg.value().decode('utf-8'))
    except json.decoder.JSONDecodeError as e:
        print("Consumer error: {}".format(e))

    print(data)

    # print("Ho ricevuto dati riguardanti le seguenti metriche:")
    # for name in data:
    #     print(name, "\n", data[name], "\n")

    dataStorage.saveData(data)

c.close()