package main

//fare una funzione di connessione che poi viene chiamata da tutti che restituisce collezione e context
import (
	"context"
	"fmt"
	"log"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

func connessione_db() (context.Context, *mongo.Collection, *mongo.Client) {
	ctx := context.TODO()

	// Set client options
	clientOptions := options.Client().ApplyURI("mongodb://localhost:27017/")

	// Connect to MongoDB
	client, err := mongo.Connect(ctx, clientOptions)
	if err != nil {
		log.Fatal(err)
	}

	// Find data
	coll := client.Database("ProgettoAPL").Collection("Users")
	_, err = coll.Find(ctx, bson.D{})
	if err != nil {
		log.Fatal(err)
	}
	return ctx, coll, client
}

// chiusura db
func close_db() {
	ctx, _, client := connessione_db()
	if client == nil {
		return
	}
	err := client.Disconnect(ctx)
	if err != nil {
		log.Fatal(err)
	}
	// TODO optional you can log your closed MongoDB client
	//fmt.Println("Connection to MongoDB closed.")
}

// aggiunge riga o righe
// func addLineDB(input string) {
// 	ctx, coll, _ := connessione_db() //apertura db
// 	docs := []interface{}{
// 		bson.D{{"title", input}, {"body", "Hello World"}},
// 		bson.D{{"ciao", "pippo"}, {"ciaoprova", "H"}},
// 	}
// 	coll.InsertMany(ctx, docs)
// 	close_db() //chiusuradb

// }

// rimuovere una singola riga
func unregister(email string, md5 string) bool {
	ctx, coll, _ := connessione_db() //apertura db
	fmt.Println("Remove in progress...")
	result, err := coll.DeleteOne(ctx, bson.D{{"email", email}, {"md5", md5}})
	if err != nil {
		fmt.Println("Remove failed")
		panic(err)
	}
	if result.DeletedCount != 1 {
		fmt.Println("Remove failed")
		return false
	}
	close_db() //chiusuradb
	mail(email, "Disiscrizione", "Dis-iscrizione avvenuta con successo.")

	fmt.Println("Remove successful")
	return true
}

// ricerca righe e ritrno a stringa
func login(email string, md5 string, accesso chan<- bool, username chan<- string) { //Posso far tornare anche la mail, così da visualizzarla se esiste l'utente
	ctx, coll, _ := connessione_db()

	var result bson.D
	err := coll.FindOne(ctx, bson.D{{"email", email}, {"md5", md5}}).Decode(&result) //L'email è unica, ne cerco solo una e la decodifico.
	if err != nil {
		accesso <- false
		username <- ""
	}
	//fmt.Printf("%+v\n", result)	//Fa vedere cosa arriva
	//da vedere meglio le operazioni di marshal e demarshal: https://medium.com/@mbp98k/marshal-unmarshal-in-golang-24baf7c97dac
	doc, err := bson.Marshal(result) //Operazione di Marshal
	if err != nil {
		accesso <- false
		username <- ""
	}
	var record map[string]interface{}

	err = bson.Unmarshal(doc, &record) //Inserisco il risultato nel record e faccio demarshal
	if err != nil {
		accesso <- false
		username <- ""
	}
	//fmt.Printf("%+v\n", record["username"]) //visualizzo lo username trovata

	close_db() //chiusura db dopo l'utilizzo
	accesso <- true
	username <- fmt.Sprintf("%s", record["username"])
}

// controlli per vedere se tutti i dati sono conformi alla registrazione
func controlli_singIn(email string, username string) bool {
	ctx, coll, _ := connessione_db() //apertura db
	var emailUnica bson.D
	ritornoEmail := coll.FindOne(ctx, bson.D{{"email", email}}).Decode(&emailUnica)
	var usernameUnico bson.D
	ritornoUsername := coll.FindOne(ctx, bson.D{{"username", username}}).Decode(&usernameUnico)
	close_db()
	if strings.Contains(email, "@") == false || ritornoEmail == nil || ritornoUsername == nil {
		return false
	}
	return true
}

func SignIN(email string, username string, name string, lastName string, md5 string, done chan<- bool) {
	risultato := controlli_singIn(email, username)
	if risultato == true {
		docs := []interface{}{
			bson.D{{"first", name}, {"last", lastName}, {"email", email}, {"md5", md5}, {"username", username}},
		}
		ctx, coll, _ := connessione_db() //apertura db
		coll.InsertMany(ctx, docs)
		mail(email, "Registrazione", "Registrazione avvenuta con successo.")
		close_db() //chiusuradb
		done <- true
	}
	done <- false
}
