from __future__ import print_function

import grpc
import echo_pb2
import echo_pb2_grpc

import ast
import sys

def viewResp(resp, case):
    """
    Questa funzione permette di impostare l'output dei dati restituiti dal server.

    La prima operazione riguarda la conversione da stringa a dictionary o lista, 
    successivamente viene controllato il valore 'case' passato come parametro, 
    se corrisponde ad 1 si tratta di metadati, se 2 si tratta di Massimo, 
    minimo, media e deviazione standard, se 3 si tratta della predizione.
    """

    try:
        list = ast.literal_eval(resp)
    except (ValueError, SyntaxError, TypeError):
        sys.exit("Errore nel formato della risposta.")

    print("\n")
    
    if case ==1: #quando è uguale a 1 si visualizzano i metadati 
        print("Metadati:")
        names=["Autocorrelazione", "Seasonability", "Stazionarietà"]
        count=0
    
        for res in list:
            print("\n", names[count])
            primaIterazioneAutocorrESeason=True
            for value in res:
                if names[count]=="Stazionarietà":
                    #print("Aggiornamento del", value[0],":",value[1:])
                    print("Aggiornamento del", value[0],":\nADF Test:",value[1], "       pValue:",value[2], "       nLagsUsed:",value[3], "       nObs:",value[4], "       CriticalValue 1%:",value[5], "       CriticalValue 5%:",value[6], "       CriticalValue 10%:",value[7],"\n")
                    
                elif names[count]=="Autocorrelazione" or names[count]=="Seasonability":
                    if primaIterazioneAutocorrESeason==True:
                        dataPrec=res[0][0][:16]
                        print("\nAggiornamento del", dataPrec, ":\n[", end="")
                        primaIterazioneAutocorrESeason=False
                    
                    if value[0][:16]== dataPrec:
                        print(value[1:][0], " ", end="")
                    else:
                        dataPrec=value[0][:16]
                        print("]\n\nAggiornamento del", dataPrec,":\n[",value[1:][0], " ", end="")

            if names[count]=="Autocorrelazione" or names[count]=="Seasonability":
                print("]")
            count+=1
    if case==2: #quando è uguale a 2 si visualizza massimo, minimo, media e deviazione standard
        print("Max, min ed avg, dev std:")
        for res in list:
            print("Aggiornamento del",res[2],"di", res[3], ": ", "Max: ",  res[4], "       Min: ", res[5], "       Avg: ", res[6], "       Dev std: ", res[7])
    if case==3: #quando è uguale a 3 si visualizzano le predizioni nel caso siano presenti (il controllo viene fatto nel run)
        print("\nPredizioni:")
        for res in list:
            print("Aggiornamento del",res[2], ": ", "Max: ",  res[3], "       Min: ", res[4], "       Avg: ", res[5])


def run():
    """
    Questa funzione permette di interfacciarsi con 
    l'utente e visualizzare i dati desiderati.
    """

    with grpc.insecure_channel('localhost:50051') as channel:
        stub = echo_pb2_grpc.EchoServiceStub(channel)

        response = stub.takeAllMetrics(echo_pb2.Request())

        try:
            listMetrics = ast.literal_eval(response.content)
        except (ValueError, SyntaxError, TypeError):
            sys.exit("Errore nel formato della risposta o nella risposta stessa.")

        metrics=[]
        for name in listMetrics:
            metrics.append(name[0])             #la response restituisce una lista di liste
        cond= True
        while cond:
            print("Scegli una metrica: \n")
            for name in metrics: #visualizzazione di tutti i nomi delle metriche 
                print(name)


            nameMetric=input("Inserisci il nome: ")
            #dopo la scelta della metrica si chiama la funzione viewResp per visualizzare il risultato
            if nameMetric in metrics:
            #caso 1 e 2 
                response = stub.takeMetadata(echo_pb2.Request(content=nameMetric))
                viewResp(response.content, 1)

                response = stub.takeValues(echo_pb2.Request(content=nameMetric))
                viewResp(response.content, 2)

                response = stub.takePred(echo_pb2.Request(content=nameMetric))
                
                #caso 3 
                if response.content=="[]":
                    print("\nPredizione:\nMetrica senza predizione.")
                else:
                    viewResp(response.content, 3)
                
                risp= input("\nVuoi informazioni su altre metriche?(s/n) ")
                if (risp.__contains__("n")):
                    cond=False
            else:
                print("\n\nMetrica non presente, riprova.\n\n")

if __name__ == '__main__':
    run()
