
# Monitoraggio delle metriche di un nodo darwin

Il progetto verte intorno allo studio di metriche estratte da un nodo (dispositivo macOS) ed esposte tramite node exporter, per essere rese disponibili su server Prometheus, previa configurazione.
Le condizioni sufficienti all’avvio dell’attività, è che il node exporter e Prometheus siano già avviati per il tempo richiesto (es. 12h di attività corrispondono a 12h di metriche da analizzare).
Il lavoro che è stato svolto in questo progetto riguarda la creazione di microservizi per il calcolo, l’immagazzinamento e l’analisi di tutte le metriche rese disponibili da Prometheus o per un set di metriche scelte dall’utente finale.
In particolare viene data possibilità all’utente (client.py, il client gRPC del microservizio SLAManager) di selezionare 5 metriche da un elenco proposto e operare sui dati che mette a disposizione prometheus, non solo per capire quale metrica ha violato o violerà il range dello SLASet e di quanto, ma anche informazione in riferimento a massimi, minimi, media, deviazione standard, e metadati (autocorrelazione, stazionarietà e stagionalità) di tutte le metriche e previsione dei prossimi 10 minuti dei valori che potrebbero assumere le metriche dello SLASet. Successivamente tali informazioni saranno mandate tramite un producer ad un topic kafka, il consumer leggerà tali informazioni e le memorizzerà in un database mysql.
L’ultimo microservizio parte proprio da tale presupposto, utilizzare il contenuto del database mysql per rendere disponibile ad un client gRPC i dati disponibili in riferimento ad una metrica selezionata.
Nel codice abbiamo aggiunto una descrizione dei compiti di ogni funzione nei microservizi e incluso alcune note, tali commenti sono riportati dopo la definizione dell’intestazione della funzione in questione.
## Documentazione

La relazione riguardante il funzionamento del progetto e la descrizione delle scelte implementative è reperibile [qui](https://github.com/eliovinciguerra/portfolio/blob/main/progettoDSBD/Relazione%20Roggio-Vinciguerra.pdf) (è il file Relazione Roggio-Vinciguerra).
## Avvio locale

Si avvii XAMPP e si crei il seguente database con le seguenti tabelle

```bash 
CREATE DATABASE PythonDBTest;
```
```bash 
USE PythonDBTest;
```
```bash 
CREATE TABLE metricsStats ( ID INT AUTO_INCREMENT, metric
varchar(255), tempoInserimento timestamp, typeValue varchar(255), max DOUBLE, min DOUBLE, avg DOUBLE, devstd DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE seasonability ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, tempo varchar(255), valore DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE stationarity ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, ADFTest DOUBLE, pValue DOUBLE, nLagsUsed DOUBLE, nObs DOUBLE, CriticalValue1 DOUBLE, CriticalValue5 DOUBLE, CriticalValue10 DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE autocorrelation ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, a DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE predStats ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, max DOUBLE, min DOUBLE, avg DOUBLE, PRIMARY KEY (ID));
```

Controllare nel codice “dataStorage.py” (nella cartella principale del progetto) e “server.py” (nella cartella “gRPCDataRetrieval”) i parametri di accesso.

Dal prompt dei comandi entrare nella cartella Kafka, poi:
- Avviare Zookeeper
```bash
./bin/zookeeper-server-start.sh config/zookeeper.properties
```
- Avviare Kafka
```bash
./bin/kafka-server-start.sh config/server.properties
```
- Creare topic promethuesdata
```bash 
./bin/kafka-topics.sh --bootstrap-server localhost:29092 --topic promethuesdata --create
```

Dal prompt dei comandi entrare nella cartella relativa a node exporter, poi:
- Avviare node exporter
```bash
./node_exporter
```

Dal prompt dei comandi entrare nella cartella prometheus, poi:
- Avviare prometheus
```bash
./prometheus --config.file=prometheus.yml
```

NOTA: Abbiamo modificato il file di configurazione di prometheus, è reperibile nella cartella principale del progetto sotto al nome prometheus.yml

Dal prompt dei comandi entrare nella cartella gRPCSLAManager, poi:
- Avviare proto3
```bash
python3 -m grpc_tools.protoc -I. --python_out=. --pyi_out=.--grpc_python_out=. ./echo.proto
```
- Avviare server
```bash
python3 server.py
```
- Avviare client
```bash
python3 client.py
```

Dal prompt dei comandi entrare nella cartella principale del progetto, dove si trova il file Consumer.py, poi:
- Avvio Consumer
```bash 
python3 Consumer.py
```
Dal prompt dei comandi entrare nella cartella gRPCDataRetrieval, poi: 
- Avviare proto3
```bash
python3 -m grpc_tools.protoc -I. --python_out=. --pyi_out=.--grpc_python_out=. ./echo.proto
```
- Avviare server
```bash
python3 server.py
```
- Avviare client
```bash
python3 client.py
```
## Avvio con docker

Dal prompt dei comandi entrare nella cartella principale del progetto, poi:

- Avviare docker compose:
```bash 
docker compose up
```
Nota: Adesso si avvieranno mysql, zookeeper e kafka, rispettivamente sulle porte 3306, 2181 e 29092.

Creazione database e tabelle:
Per la creazione del database e delle tabelle è possibile installare localmente un client MySQL e successivamente accedere con le seguenti credenziali:
- MYSQL_ROOT_PASSWORD: prova
- MYSQL_DATABASE: PythonDBTest
- MYSQL_USER : progettoDSBD
- MYSQL_PASSWORD: prova

Successivamente eseguire i seguenti comandi:
```bash 
CREATE DATABASE PythonDBTest;
```
```bash 
USE PythonDBTest;
```
```bash 
CREATE TABLE metricsStats ( ID INT AUTO_INCREMENT, metric
varchar(255), tempoInserimento timestamp, typeValue varchar(255), max DOUBLE, min DOUBLE, avg DOUBLE, devstd DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE seasonability ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, tempo varchar(255), valore DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE stationarity ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, ADFTest DOUBLE, pValue DOUBLE, nLagsUsed DOUBLE, nObs DOUBLE, CriticalValue1 DOUBLE, CriticalValue5 DOUBLE, CriticalValue10 DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE autocorrelation ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, a DOUBLE, PRIMARY KEY (ID));
```
```bash 
CREATE TABLE predStats ( ID INT AUTO_INCREMENT, metric varchar(255), tempoInserimento timestamp, max DOUBLE, min DOUBLE, avg DOUBLE, PRIMARY KEY (ID));
```

Controllare nel codice “dataStorage.py” (nella cartella principale del progetto) e “server.py” (nella cartella “gRPCDataRetrieval”) i parametri di accesso.


Dal prompt dei comandi entrare nella cartella relativa a node exporter, poi:
- Avviare node exporter
```bash
./node_exporter
```

Dal prompt dei comandi entrare nella cartella prometheus, poi:
- Avviare prometheus
```bash
./prometheus --config.file=prometheus.yml
```

NOTA: Abbiamo modificato il file di configurazione di prometheus, è reperibile nella cartella principale del progetto sotto al nome prometheus.yml

Dal prompt dei comandi entrare nella cartella gRPCSLAManager, poi:
- Avviare proto3
```bash
python3 -m grpc_tools.protoc -I. --python_out=. --pyi_out=.--grpc_python_out=. ./echo.proto
```
- Avviare server
```bash
python3 server.py
```
- Avviare client
```bash
python3 client.py
```

Dal prompt dei comandi entrare nella cartella principale del progetto, dove si trova il file Consumer.py, poi:
- Avvio Consumer
```bash 
python3 Consumer.py
```
Dal prompt dei comandi entrare nella cartella gRPCDataRetrieval, poi: 
- Avviare proto3
```bash
python3 -m grpc_tools.protoc -I. --python_out=. --pyi_out=.--grpc_python_out=. ./echo.proto
```
- Avviare server
```bash
python3 server.py
```
- Avviare client
```bash
python3 client.py
```
