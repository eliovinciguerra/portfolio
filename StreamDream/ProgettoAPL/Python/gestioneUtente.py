import http.client
import json
import random
import string

def generate_User(pr):
    nome,cognome=pr
    conn = http.client.HTTPConnection("localhost", 8081)
    if len(cognome)>0 and len(nome)>2:
        cognome=cognome[0]  
    flag=True
    while(flag):
        username = nome+cognome
        for i in range(3):
            username += random.choice(string.digits)      
        conn.request("GET", "/generate_User?username="+username)
        response=conn.getresponse()
        if(response.status != 200):
            conn.close()
            return "Failure request"
        else:
            risp=response.read().decode()
            if(risp == "failure"):
                flag=True
            else:
                flag=False
    conn.close()
    return username

def delete(pr): 
    email,password,username=pr 
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("DELETE", "/deleteAccount?email="+email+"&password="+password+"&username="+username)
    response = conn.getresponse()
    if(response.status != 200):
        conn.close()
        return "Error"
    else:
        risp=response.read().decode()
        conn.close()
        if(risp == "failure"):  
            return "failure"
        else:
            return "Success"

def changePW(pr): 
    email,passwordnew,passwordold=pr
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("PUT", "/changePW?email="+email+"&passwordnew="+passwordnew+"&passwordold="+passwordold)
    response = conn.getresponse()
    if(response.status != 200):
        conn.close()
        return "Error"
    else:
        risp=response.read().decode()
        conn.close()
        if(risp == "failure"):
            return "failure"
        else:
            return "Success"
            
def changeEmail(pr):
    emailnew,emailold=pr
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("PUT", "/changeEmail?emailnew="+emailnew+"&emailold="+emailold)
    response= conn.getresponse()
    if(response.status != 200):
        return "Error"
    else:
        risp=response.read().decode() #username
        conn.close()
        if(risp!="Success"):
            return "Failure"
        else:
            return "Success"  
   
def infoUser(pr):
    User=pr[0]
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("GET", "/infoUser?username="+User)
    response= conn.getresponse()
    if(response.status != 200):
        conn.close()
        return "Error"
    else:
        risp=response.read().decode() #username
        conn.close()
        if(risp=="Failure"):
            return "Failure"
        else:
            dict=json.loads(risp)
            return dict
            
def changeNameSurname(pr):
    email,name,surname=pr
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("PUT", "/changeNameSurname?email="+email+"&first="+name+"&last="+surname)
    response= conn.getresponse()
    if(response.status != 200):
        conn.close()
        return "Error"
    else:
        risultato=response.read().decode()
        conn.close()
        if(risultato!="Success"):
            return "Failure"
        else:
            return "Success"
              
def login(pr):
    email,password=pr
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("POST", "/login?email="+email+"&password="+password)
    response = conn.getresponse()
    if(response.status != 200):
        conn.close()
        r= "Errore"
    else:
        usrnm=response.read().decode()
        if(usrnm == "failure"):
            r= "failure"
        else:
            r= usrnm
        conn.close()
    return r
            
def signin(pr):
    email,password,name,surname,username=pr    
    conn = http.client.HTTPConnection("localhost", 8081)
    conn.request("POST", "/signin?email="+email+"&password="+password+"&name="+name+"&surname="+surname+"&username="+username)
    response = conn.getresponse()
    if(response.status != 200):
        conn.close()
        r= "Error"
    else:
        usrnm=response.read().decode()
        if(usrnm == "failure"):
            r= "Usato"
        else:
            r= usrnm
        conn.close()
    return r


