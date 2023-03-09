#This script is a part of a bigger project, in particular this script let you manage the 
# users, client side, server side is made with Go, you can find it in Go folder.

import http.client
import pickle

def fileRead ():
    objdump = None
    with open('data.txt', 'rb') as f:
        objdump = pickle.load(f)
        if objdump["username"]=="Null":
            pass
        else:
            return objdump["username"]

def fileWrite(username):
    fw = open("data.txt", 'wb')
    dct={"username":username}
    pickle.dump(dct,fw)
    fw.close()


def delete(email, md5):
    usrnm=fileRead()
    if usrnm == None:
        print("Per accedere qui, devi prima effettuare il login.")
        pass
    else:
        print ("Ciao, "+usrnm+", sei sicuro di volerci lasciare?")
        conferma=input()
        if (conferma.__contains__("s") or conferma.__contains__("S")):
            print("Elimino")
            conn = http.client.HTTPConnection("localhost", 8081)
            conn.request("POST", "/deleteAccount?email="+email+"&md5="+md5)
            response = conn.getresponse()
            if(response.status != 200):
                print(response.reason)
            else:
                risp=response.read().decode()
                if(risp == "failure"):
                    print("Operazione Fallita.")
                else:
                    fileWrite(usrnm)

    #qui magari mostriamo la finestra di login

def login(email, md5):
    usrnm=fileRead()
    if usrnm != None:
        print ("Ciao, "+usrnm+", hai già eseguito l'accesso.")
        pass
    else:
        print("Eseguo accesso")
        conn = http.client.HTTPConnection("localhost", 8081)
        conn.request("POST", "/login?email="+email+"&md5="+md5)
        response = conn.getresponse()
        if(response.status != 200):
            print(response.reason)
        else:
            usrnm=response.read().decode()
            if(usrnm == "failure"):
                print("Operazione Fallita.")
            else:
                print("Accesso eseguito con successo, "+usrnm)
                fileWrite(usrnm)

def signin(email, md5, name, surname, username):
    usrnm=fileRead()
    if usrnm != None:
        print ("Ciao, "+usrnm+", sei già registrato.")
        pass
    else:
        print("Registrazione in corso")
        conn = http.client.HTTPConnection("localhost", 8081)
        conn.request("POST", "/signin?email="+email+"&md5="+md5+"&name="+name+"&surname="+surname+"&username="+username)
        response = conn.getresponse()
        if(response.status != 200):
            print(response.reason)
        else:
            if(response.status != 200):
                print(response.reason)
            else:
                usrnm=response.read().decode()
                if(usrnm == "failure"):
                    print("Operazione Fallita.")
                else:
                    print("Registrazione effettuata con successo, "+usrnm)
                    fileWrite(usrnm)

def logout():
    try:
        usrnm=fileRead()
        print ("Ciao, "+usrnm+", stai per uscire.")
        fileWrite("Null")
    except:
        print ("Errore, riprova più tardi.")

if __name__ == '__main__':
    #delete("eliovinciguerra@me.com", "prova")
    login("eliovinciguerra@me.com", "prova")
    #signin("eliovinciguerra@me.com", "prova", "prova", "prova", "@prova")
    #logout()
