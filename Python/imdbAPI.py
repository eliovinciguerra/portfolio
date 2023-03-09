import http.client
import json
import numpy as np
import plots as plt

def connection(query):
    conn = http.client.HTTPSConnection("imdb-api.com", 443)
    print("Connessione effettuata.")
    conn.request("GET", query)
    print("Richiesta effettuata.")
    res = conn.getresponse().read()
    return json.loads(res.decode())

def searchEverything(thing, key):
    data=connection("/it/API/SearchAll/"+key+"/"+thing)
    
    i=0
    while i<len(data["results"]):
        print(str(i+1)+"- "+data["results"][i]["title"]+": "+data["results"][i]["description"]+ " id: "+ data["results"][i]["id"])
        i+=1

def top250Movies(key):
    data=connection("/it/API/Top250Movies/"+key)
    i=0
    while i<len(data["items"]):
        print(data["items"][i]["rank"] +"-"+ data["items"][i]["fullTitle"])
        i+=1

def top250TVSeries(key):
    data=connection("/it/API/Top250TVs/"+key)
    i=0
    while i<len(data["items"]):
        print(data["items"][i]["rank"] +"-"+ data["items"][i]["fullTitle"])
        i+=1

def showWiki(key, id):
    data=connection("/it/API/Wikipedia/"+key+"/"+id)
    print(data["plotShort"]["plainText"])

def stats(key, id):
    data=connection("/it/API/UserRatings/"+key+"/"+id)
    rat=[]
    nvotes=[]
    res=np.array(data["ratings"])
    i=0
    while i<len(res):
        rat.append(res[i]["rating"])
        nvotes.append(int(res[i]["votes"]))
        i+=1
    plt.barPlot(rat, nvotes, "ratings")

def showCast(key, id):
    data=connection("/it/API/FullCast/"+key+"/"+id)
    for i in range (len(data["actors"])):
        print(data["actors"][i]["name"]+" nel ruolo di "+ data["actors"][i]["asCharacter"])

if __name__ == '__main__':
    key= "k_a3cpy60j"

    # se vuoi fare prove veloci, id Avatar (2009): tt0499549

#Fa spuntare tutti i film o le serie tv che somigliano:
    # print("Digita il contenuto che vuoi cercare: ")
    # nameMovie= input()
    # searchEverything(nameMovie, key)          #searchEverything("Avatar", key)

#Restituiscono i top 250 di film e serie tv, rispettivamente
    #top250Movies(key)
    #top250TVSeries(key)

#Se unito alla prima funzione, posso cercare su wikipedia la trama di un film
    # print("Inserisci l'id del contenuto ricercato: ")
    # idMovie= input()
    # showWiki(key, idMovie)                #showWiki(key, "tt0499549")

# Statistiche sui ratings di un film o serie tv, dato il codice, da combinare con la prima funzione
    #stats(key, idMovie)                #stats(key, "tt0499549")

# Mostra tutti gli attori che fanno parte del cast di un film o serie passati come parametro.
    #showCast(key, idMovie)                #showCast(key, "tt0499549")