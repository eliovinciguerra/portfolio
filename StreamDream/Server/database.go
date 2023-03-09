package main

import (
	"context"

	"fmt"
	"log"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

func connessione_db(collection string) (context.Context, *mongo.Collection, *mongo.Client) {
	ctx := context.TODO()

	// opzioni per il set del client
	clientOptions := options.Client().ApplyURI("mongodb://localhost:27017/")

	// connessione a MongoDB
	client, err := mongo.Connect(ctx, clientOptions)
	if err != nil {
		log.Fatal(err)
	}

	// cerca dati
	coll := client.Database("ProgettoAPL").Collection(collection)
	_, err = coll.Find(ctx, bson.D{}) //controllo di corretto funzionamento
	if err != nil {
		log.Fatal(err)
	}
	return ctx, coll, client
}

// chiusura db
func close_db(collection string) {
	ctx, _, client := connessione_db(collection)
	if client == nil {
		return
	}
	err := client.Disconnect(ctx)
	if err != nil {
		log.Fatal(err)
	}
}

func unregister(email string, password string, username string, unreg chan<- bool) {
	ctx, coll, _ := connessione_db("Users") //apertura db
	result, err := coll.DeleteOne(ctx, bson.D{{"email", email}, {"password", password}})
	if err != nil {
		panic(err)
	}
	if result.DeletedCount != 1 {
		unreg <- false
	} else {

		//cancellazione del catalogo dell'utente
		ctxC, collCatalogue, _ := connessione_db("Catalogue")
		results, err := collCatalogue.DeleteMany(ctxC, bson.D{{"email", email}})
		if err != nil {
			fmt.Println("Remove failed catalogo", results)
		}

		close_db("Catalogue") //chiusuradb

		//cancellazione commenti
		ctxCo, collComm, _ := connessione_db("Comments")
		resul, err := collComm.DeleteMany(ctxCo, bson.D{{"user", username}})
		if err != nil {
			fmt.Println("Remove failed commento", resul)
		}
		close_db("Comments") //chiusuradb
		mail(email, "Disiscrizione", "Dis-iscrizione avvenuta con successo.")
		unreg <- true
	}
	close_db("Users") //chiusuradb
}

// ricerca righe e ritrno a stringa
func login(emailOrUsername string, password string, username chan<- string) { //Posso far tornare anche la mail, così da visualizzarla se esiste l'utente
	ctx, coll, _ := connessione_db("Users")
	var result bson.D
	var err error
	if (strings.Contains(emailOrUsername, ".com") || strings.Contains(emailOrUsername, ".it")) && strings.Contains(emailOrUsername, "@") { //se sono vere
		err = coll.FindOne(ctx, bson.D{{"email", emailOrUsername}, {"password", password}}).Decode(&result)
	} else {
		err = coll.FindOne(ctx, bson.D{{"username", emailOrUsername}, {"password", password}}).Decode(&result)
	}
	//L'email è unica, ne cerco solo una e la decodifico.
	if err != nil {
		username <- "failure"
	} else {
		doc, err := bson.Marshal(result) //Operazione di Marshal
		if err != nil {
			username <- "failure"
		} else {
			var record map[string]interface{}

			err = bson.Unmarshal(doc, &record) //Inserisco il risultato nel record e faccio demarshal
			if err != nil {
				username <- "failure"
			} else {
				username <- fmt.Sprintf("%s", record["username"])
			}
		}
	}
	close_db("Users") //chiusura db dopo l'utilizzo
}

// controlli per vedere se tutti i dati sono conformi alla registrazione
func controlloUser(username string, done chan<- bool) {
	var usernameUnico bson.D
	ctx, coll, _ := connessione_db("Users") //apertura db
	coll.FindOne(ctx, bson.D{{"username", username}}).Decode(&usernameUnico)
	if usernameUnico == nil {
		done <- true
	} else {
		done <- false
	}
}

func controlli_singIn(email string, username string) bool {
	ctx, coll, _ := connessione_db("Users") //apertura db
	var emailUnica bson.D
	coll.FindOne(ctx, bson.D{{"email", email}}).Decode(&emailUnica)
	done := make(chan bool)
	go controlloUser(username, done)
	close_db("Users")
	if strings.Contains(email, "@") || emailUnica == nil || <-done {
		return true
	}
	return false
}

func SignIN(email string, username string, name string, lastName string, password string, done chan<- bool) {
	risultato := controlli_singIn(email, username)
	if risultato {
		docs := []interface{}{
			bson.D{{"first", name}, {"last", lastName}, {"email", email}, {"password", password}, {"username", username}},
		}
		ctx, coll, _ := connessione_db("Users") //apertura db
		coll.InsertMany(ctx, docs)
		mail(email, "Registrazione", "Registrazione avvenuta con successo.")
		done <- true
	} else {
		done <- false
	}
	close_db("Users")
}

// gestione Account e Profilo utente
func infoUser(username string, done chan<- bool, info chan<- []byte) {
	ctx, coll, _ := connessione_db("Users") //apertura db
	var result bson.D
	err := coll.FindOne(ctx, bson.D{{"username", username}}).Decode(&result)
	if err != nil {
		done <- false
	}
	documentBytes, err := bson.MarshalExtJSON(result, false, true)
	if err != nil {
		log.Fatal(err)
	}
	done <- true
	info <- documentBytes
	close_db("Users") //chiusura db dopo l'utilizzo
}

func changePW(email string, passwordnew string, passwordold string, done chan<- bool) {
	ctx, coll, _ := connessione_db("Users") //apertura db
	filter := bson.M{"email": email, "password": passwordold}
	var err bson.D
	coll.FindOne(ctx, filter).Decode(&err) //err contiene l'elemento corrispondente al filtro, se trovato, altrimenti nil
	if err == nil {
		done <- false
	} else {
		risult, _ := coll.UpdateOne(ctx, bson.M{"email": email}, bson.D{{"$set", bson.D{{"password", passwordnew}}}})
		if risult == nil {
			done <- false
		}
		done <- true
	}
	close_db("Users")
}

func changeNameSurname(email string, name string, surname string, done chan<- bool) {
	ctx, coll, _ := connessione_db("Users") //apertura db
	filter := bson.M{"email": email}
	var err bson.D
	//evitiamo il controllo a catena facendolo solo una volta inizialmente in caso non lo trova esce diretto non prosegue
	coll.FindOne(ctx, filter).Decode(&err)
	if err == nil {
		done <- false
	} else {
		if name != "" && surname != "" {
			risult, _ := coll.UpdateOne(ctx, bson.M{"email": email}, bson.D{{"$set", bson.D{{"first", name}, {"last", surname}}}})
			if risult == nil {
				done <- false
			}
			done <- true
		} else if name == "" && surname != "" {
			risult, _ := coll.UpdateOne(ctx, bson.M{"email": email}, bson.D{{"$set", bson.D{{"last", surname}}}})
			if risult == nil {
				done <- false
			}
			done <- true
		} else {
			risult, _ := coll.UpdateOne(ctx, bson.M{"email": email}, bson.D{{"$set", bson.D{{"first", name}}}})
			if risult == nil {
				done <- false
			}
			done <- true
		}
	}
	close_db("Users")
}

func changeEmail(emailnew string, emailold string, done chan<- bool, username chan<- string) {
	ctx, coll, _ := connessione_db("Users") //apertura db
	risult, _ := coll.UpdateOne(ctx, bson.M{"email": emailold}, bson.D{{"$set", bson.D{{"email", emailnew}}}})
	if risult == nil {
		done <- false
		username <- ""
	} else {
		var result bson.D
		err := coll.FindOne(ctx, bson.D{{"email", emailnew}}).Decode(&result) //L'email è unica, ne cerco solo una e la decodifico.
		if err != nil {
			done <- false
			username <- ""
		}

		doc, err := bson.Marshal(result) //Operazione di Marshal
		if err != nil {
			done <- false
			username <- ""
		}
		var record map[string]interface{}

		err = bson.Unmarshal(doc, &record) //Inserisco il risultato nel record e faccio demarshal
		if err != nil {
			done <- false
			username <- ""
		}
		mail(emailold, "Change Email", "Email modificata con successo. Da questo momento il tuo account sarà referenziato con "+emailnew+".")

		done <- true
		username <- fmt.Sprintf("%s", record["username"])
		close_db("Users") //chiusura db dopo l'utilizzo
	}
}

// funzioni per accesso al catalogo personale
func addContent(email string, idContent string, nameContent string, image string, done chan<- bool) {
	ctx, coll, _ := connessione_db("Catalogue")
	var err bson.D
	coll.FindOne(ctx, bson.M{"email": email, "idContent": idContent}).Decode(&err) //err contiene l'elemento corrispondente al filtro, se trovato, altrimenti nil
	if err != nil {
		done <- false
		close_db("Catalogue")
	} else {
		docs := []interface{}{
			bson.D{{"email", email}, {"idContent", idContent}, {"nameContent", nameContent}, {"image", image}}}
		//apertura db
		coll.InsertMany(ctx, docs)
		//close_db() //chiusuradb
		done <- true
		close_db("Catalogue")
	}
}

// funzione per stampare bson
func jsonConv(cur *mongo.Cursor, key string) []byte {
	// Creare una slice di byte per contenere il risultato
	var results []byte
	defer cur.Close(context.Background()) //questa istruzione viene eseguita prima della return
	var flag = false
	var str string
	// Scorrere i risultati e aggiungere ogni documento alla slice
	results = append(results, []byte("{")...)
	for cur.Next(context.Background()) {
		document := bson.M{}
		err := cur.Decode(&document)
		if err != nil {
			log.Fatal(err)
		}

		documentBytes, err := bson.MarshalExtJSON(document, false, true)
		if err != nil {
			log.Fatal(err)
		}

		if flag {
			results = append(results, []byte(",")...)
		}
		if key == "_id" { //lo devo convertire in stringa(è un objectid)
			str = fmt.Sprintf("\"%s\":", document["_id"].(primitive.ObjectID).Hex())
		} else {

			str = fmt.Sprintf("\"%s\":", document[key].(string))

		}

		results = append(results, []byte(str)...)
		results = append(results, documentBytes...)
		flag = true
	}
	results = append(results, []byte("}")...)

	return results
}

func getCatalogo(email string, done chan<- bool, info chan<- []byte) {
	_, coll, _ := connessione_db("Catalogue") //apertura db
	cur, err := coll.Find(context.Background(), bson.D{{"email", email}})
	if err != nil {
		done <- false
	}
	results := jsonConv(cur, "idContent")
	done <- true
	info <- results

	close_db("Catalogue") //chiusura db dopo l'utilizzo
}

func addComment(user string, idContent string, nameContent string, content string, done chan<- bool) {
	//controllare da errore
	ctx, coll, _ := connessione_db("Comments")

	docs := []interface{}{
		bson.D{{"user", user}, {"idContent", idContent}, {"nameContent", nameContent}, {"content", content}}}
	//apertura db
	coll.InsertMany(ctx, docs)
	done <- true
	close_db("Comments")
}

func getComment(id string, done chan<- bool, info chan<- []byte) {
	_, coll, _ := connessione_db("Comments")
	cur, err := coll.Find(context.Background(), bson.D{{"idContent", id}})
	if err != nil {
		done <- false
	}
	results := jsonConv(cur, "_id")

	done <- true
	info <- results
	close_db("Comments")
}

func deleteComment(idContent string, done chan<- bool) {
	ctx, coll, _ := connessione_db("Comments") //apertura db
	//conversione in objectID
	objID, err := primitive.ObjectIDFromHex(idContent)
	if err != nil {
		panic(err)
	}
	result, err := coll.DeleteOne(ctx, bson.M{"_id": objID}, options.Delete().SetCollation(&options.Collation{}))
	if err != nil {
		panic(err)
	} else {
		if result.DeletedCount != 1 {
			done <- false
		} else {
			close_db("Comments") //chiusuradb
			done <- true
		}
	}
}

func deleteContentCat(idContent string, done chan<- bool) {
	ctx, coll, _ := connessione_db("Catalogue") //apertura db
	//conversione in objectID
	objID, err := primitive.ObjectIDFromHex(idContent)
	if err != nil {
		panic(err)
	}
	result, err := coll.DeleteOne(ctx, bson.M{"_id": objID}, options.Delete().SetCollation(&options.Collation{}))
	if err != nil {
		panic(err)
	} else {
		if result.DeletedCount != 1 {
			done <- false
		} else {
			close_db("Catalogue") //chiusuradb
			done <- true
		}
	}
}
