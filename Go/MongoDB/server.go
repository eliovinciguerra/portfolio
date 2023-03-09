package main

//network
import (
	"fmt"
	"log"
	"net/http"
	"time"
)

//db
//https://medium.com/@pkbhowmick007/user-registration-and-login-template-using-golang-mongodb-and-jwt-d85f09f1295e

func main() {
	// API routes
	connessione_db()
	//removeLineDB()
	mux := http.NewServeMux()
	corretto := make(chan bool)
	usrnm := make(chan string)
	mux.HandleFunc("/login", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		md5 := req.FormValue("md5")
		var s string

		go login(email, md5, corretto, usrnm) //Poi l'md5 verrà passato in automatico dal client
		if <-corretto {

			s = fmt.Sprintf("%s", <-usrnm)
			//fmt.Fprintf(w, "Benvenuto %s, la tua email è presente nel database e la password coincide.", usrnm)
		} else {
			s = fmt.Sprintf("failure")
			//fmt.Fprintf(w, "Accesso fallito, email non presente o password errata.")
		}

		w.Write([]byte(s))
	})
	time.Sleep(50 * time.Millisecond)

	mux.HandleFunc("/signin", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		md5 := req.FormValue("md5")
		first := req.FormValue("name")
		last := req.FormValue("surname")
		username := req.FormValue("username")
		var s string
		done := make(chan bool)
		go SignIN(email, username, first, last, md5, done)
		if <-done {
			s = fmt.Sprintf("%s", username)
		} else {
			s = fmt.Sprintf("failure")
		}

		w.Write([]byte(s))
	})

	time.Sleep(50 * time.Millisecond)

	mux.HandleFunc("/deleteAccount", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		md5 := req.FormValue("md5")
		var s string

		unreg := unregister(email, md5)
		if unreg == true {
			s = fmt.Sprintf("success")
		} else {
			s = fmt.Sprintf("failure")
		}
		w.Write([]byte(s))
	})

	port := ":8081"
	fmt.Println("Server is running on port" + port)

	// Start server on port specified above
	log.Fatal(http.ListenAndServe(port, mux))
}
