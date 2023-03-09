import http.client
import json

#chiave=k_a3cpy60j
#chiave_riserva=k_nx24wnw9
#chiave_doppia_riserva=k_2beox20p

def connection(query):
    conn = http.client.HTTPSConnection("imdb-api.com", 443)
    conn.request("GET", query)
    res=json.loads(conn.getresponse().read().decode())
    conn.close()
    return res
    
def ratings(pr):
    id=pr[0]
    data=connection("/it/API/UserRatings/k_a3cpy60j/"+id)["ratings"]
    nvotes=[]    
    for element in data:
        nvotes.append(element["votes"])
    return nvotes[::-1]

def searchEverything(pr):
    list=[]
    thing=pr[0].replace(" ", "%20")
    data=connection("/it/API/SearchSeries/k_a3cpy60j/"+thing)  
    for element in data["results"]:
        list.append(element["title"]+" "+"ç"+" "+element["image"]+" "+"ç"+element["id"])
    data=connection("/it/API/SearchMovie/k_a3cpy60j/"+thing)  
    for element in data["results"]:
        list.append(element["title"]+" "+"ç"+" "+element["image"]+" "+"ç"+element["id"])
    if not list:    
        list.append("Failure")
    return list
    
def top250Movies():
    list=[]
    data=connection("/it/API/Top250Movies/k_a3cpy60j")["items"]
    for element in data:
        list.append(element["fullTitle"]+" "+"ç"+element["image"]+" "+"ç"+element["id"]+"ç"+element["rank"])
    return list    
    
def top250TVSeries():
    list=[]
    data=connection("/it/API/Top250TVs/k_a3cpy60j")["items"]
    for element in data:
        list.append(element["fullTitle"]+" "+"ç"+element["image"]+" "+"ç"+element["id"]+"ç"+element["rank"])
    return list

def showWiki(pr):
    id=pr[0]
    data=connection("/it/API/Wikipedia/k_a3cpy60j/"+id)
    return data["plotShort"]["plainText"]

def showCast(pr):
    id=pr[0]
    list=[]
    data=connection("/it/API/FullCast/k_a3cpy60j/"+id)["actors"]
    for element in data:
        list.append(element["image"]+"ç"+element["name"]+"ç"+ element["asCharacter"])
    return list

