import logging

def sendTimeExe(tempoExe1h, tempoExe3h, tempoExe12h, tempoExePred, tempoExeValori):
    """
    Apre o crea un log e salva a livello informativo i tempi
    in secondi collezionati in ETLDataPipeline.
    """

    logger = logging.getLogger(__name__)
    logger.setLevel(logging.INFO)

    # Crea un handler per il log su file
    file_handler = logging.FileHandler('monitoring.log')
    file_handler.setLevel(logging.INFO)

    # Crea un handler per il log su console
    console_handler = logging.StreamHandler()
    console_handler.setLevel(logging.INFO)

    # Crea il formatter per il log
    formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
    file_handler.setFormatter(formatter)
    console_handler.setFormatter(formatter)

    # Aggiunge gli handler al logger
    logger.addHandler(file_handler)
    logger.addHandler(console_handler)

    # Registra le metriche nel log
    logger.info('Processamento dati ad 1h: %f', tempoExe1h)
    logger.info('Processamento dati a 3h: %f', tempoExe3h)
    logger.info('Processamento dati a 12h: %f', tempoExe12h)
    logger.info('Processamento predizione: %f', tempoExePred)
    logger.info('Processamento metadati: %f', tempoExeValori)

