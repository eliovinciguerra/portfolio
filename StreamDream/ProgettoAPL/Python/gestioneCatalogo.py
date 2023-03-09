import http.client
import json

def addContent(pr):
    email=pr[0]
    idContent=pr[1]
    image=pr[2].replace(' ', '')
    nameContent=pr[3].replace(' ', '%20')
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("POST", "/addContent?email="+email+"&id="+idContent+"&name="+nameContent+"&image="+image)
    response = conn.getresponse()   
    if(response.status != 200):
        conn.close()
        return "Server down: Riprova più tardi!"
    elif (response.read().decode()== "Failure"):
        conn.close()
        return "Contenuto già aggiunto al catalogo!"
    else:
        conn.close()
        return "Aggiunto con successo!"
        
def getCatalogo(pr):
    email=pr[0]
    list=[]
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("GET", "/getCatalogo?email="+email)
    response = conn.getresponse()
    if(response.status != 200):
        return list.append("Failure")
    else:
        risp=response.read().decode()
        if(risp=="{}"):
            list.append("Failure")
        else:
            dict=json.loads(risp)
            for key,element in dict.items():  
                list.append(element['idContent']+"ç"+element['nameContent']+"ç"+element['image']+"ç"+element["_id"]["$oid"])
        conn.close()
        return list
        
#gestione Commenti
def getComment(pr):
    idContent=pr[0]
    list=[]
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("GET", "/getComment?idContent="+idContent)
    response = conn.getresponse()
    if(response.status != 200):
        list.append("Failure")
    else:
        risp=response.read().decode() 
        if(risp=="{}"):
            list.append("Failure")
        else:
            dict=json.loads(risp)
            for key,element in dict.items():  
                list.append(element['user']+"ç"+element['content']+"ç"+key)
    conn.close()
    return list
    
def addComment(pr):
    User=pr[0]
    idContent=pr[1]
    nameContent=pr[2].replace(' ', '%20')
    content=pr[3].replace(' ', '%20')
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("POST", "/addComment?user="+User+"&content="+content+"&name="+nameContent+"&idContent="+idContent)
    response = conn.getresponse()
    risp=response.read().decode()
    if(response.status != 200):
        r= "Server down: Riprova più tardi!"
    elif (risp== "Failure"):
        r= "Commento non aggiunto!"
    else:
        r= "Grazie per il tuo feedback!"
    conn.close()
    return r
        
def deleteComment(pr):
    idContent=pr[0]
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("DELETE", "/deleteComment?idContent="+idContent)
    response = conn.getresponse()   
    if(response.status != 200):
        risp= response.status
    else:
        risp=response.read().decode()
    conn.close()
    return risp

def deleteContentCat(pr):
    idContent=pr[0]
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("DELETE", "/deleteContentCat?idContent="+idContent)
    response = conn.getresponse()  
    if(response.status != 200):
        risp= response.status
    else:
        risp=response.read().decode()
    conn.close()
    return risp
        