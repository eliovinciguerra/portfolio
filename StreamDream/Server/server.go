package main

import (
	"fmt"
	"log"
	"net/http"
)

func main() {

	mux := http.NewServeMux()

	mux.HandleFunc("/login", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		password := req.FormValue("password")
		usrnm := make(chan string)
		var s string
		go login(email, password, usrnm)
		s = <-usrnm
		w.Write([]byte(s))
	})

	//generazione casuale user e controllo
	mux.HandleFunc("/generate_User", func(w http.ResponseWriter, req *http.Request) {
		user := req.FormValue("username")
		done := make(chan bool)
		go controlloUser(user, done)
		var s string
		if <-done {
			s = "success"
		} else {
			s = "failure"
		}
		w.Write([]byte(s))

	})

	//registrazione
	mux.HandleFunc("/signin", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		password := req.FormValue("password")
		first := req.FormValue("name")
		last := req.FormValue("surname")
		username := req.FormValue("username")
		var s string
		done := make(chan bool)
		go SignIN(email, username, first, last, password, done)
		if <-done {
			s = username
		} else {
			s = "failure"
		}

		w.Write([]byte(s))
	})

	//cancellare account
	mux.HandleFunc("/deleteAccount", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		password := req.FormValue("password")
		username := req.FormValue("username")
		var s string
		unreg := make(chan bool)
		go unregister(email, password, username, unreg)
		if <-unreg {
			s = "success"
		} else {
			s = "failure"
		}
		w.Write([]byte(s))
	})

	//cambiare password
	mux.HandleFunc("/changePW", func(w http.ResponseWriter, r *http.Request) {
		email := r.FormValue("email")
		passwordnew := r.FormValue("passwordnew")
		passwordold := r.FormValue("passwordold")
		var s string
		changePass := make(chan bool)
		go changePW(email, passwordnew, passwordold, changePass)

		if <-changePass {
			s = "success"
		} else {
			s = "failure"
		}
		w.Write([]byte(s))
	})

	//cambiare Name e surname utente
	mux.HandleFunc("/changeNameSurname", func(w http.ResponseWriter, r *http.Request) {
		name := r.FormValue("first")
		email := r.FormValue("email")
		surname := r.FormValue("last")
		var s string
		change := make(chan bool)
		go changeNameSurname(email, name, surname, change)
		if <-change {
			s = "Success"

		} else {
			s = "Failure"
		}
		w.Write([]byte(s))
	})

	//cambiare email utente
	mux.HandleFunc("/changeEmail", func(w http.ResponseWriter, r *http.Request) {
		emailnew := r.FormValue("emailnew")
		emailold := r.FormValue("emailold")
		var s string
		change := make(chan bool)
		username := make(chan string)
		go changeEmail(emailnew, emailold, change, username)
		if <-change {
			s = "Success"
		} else {
			s = "Failure"
		}
		w.Write([]byte(s))
	})

	//info utente
	mux.HandleFunc("/infoUser", func(w http.ResponseWriter, r *http.Request) {
		username := r.FormValue("username")
		done := make(chan bool)
		info := make(chan []byte)
		go infoUser(username, done, info)
		if <-done {

			w.Write(<-info)
		} else {
			w.Write([]byte("Failure"))
		}

	})

	//aggiungiamo un nuovo elemento al catalogo
	mux.HandleFunc("/addContent", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		idContent := req.FormValue("id")
		nameContent := req.FormValue("name")
		image := req.FormValue("image")
		var s string
		done := make(chan bool)
		go addContent(email, idContent, nameContent, image, done)
		if <-done {
			s = "Success"
		} else {
			s = "Failure"
		}

		w.Write([]byte(s))
	})

	//restituisce catalogo personale per l'user
	mux.HandleFunc("/getCatalogo", func(w http.ResponseWriter, req *http.Request) {
		email := req.FormValue("email")
		done := make(chan bool)
		info := make(chan []byte)
		go getCatalogo(email, done, info)
		if <-done {
			w.Write(<-info)
		} else {
			w.Write([]byte("failure"))
		}
	})

	//aggiunge un commento ad un dato elemento
	mux.HandleFunc("/addComment", func(w http.ResponseWriter, req *http.Request) {
		user := req.FormValue("user")
		idContent := req.FormValue("idContent")
		nameContent := req.FormValue("name")
		content := req.FormValue("content")
		var s string
		done := make(chan bool)
		go addComment(user, idContent, nameContent, content, done)
		if <-done {
			s = "Success"
		} else {
			s = "Failure"
		}
		w.Write([]byte(s))
	})

	//legge i commenti di un dato elemento
	mux.HandleFunc("/getComment", func(w http.ResponseWriter, req *http.Request) {
		idContent := req.FormValue("idContent")
		done := make(chan bool)
		info := make(chan []byte)
		go getComment(idContent, done, info)
		if <-done {
			w.Write(<-info)
		} else {
			w.Write([]byte("failure"))
		}
	})

	//cancella i commenti delle persone
	mux.HandleFunc("/deleteComment", func(w http.ResponseWriter, req *http.Request) {
		idContent := req.FormValue("idContent")
		done := make(chan bool)
		var s string
		go deleteComment(idContent, done)
		if <-done {
			s = "success"
		} else {
			s = "failure"
		}
		w.Write([]byte(s))
	})

	//cancella un elemento del catalogo
	mux.HandleFunc("/deleteContentCat", func(w http.ResponseWriter, req *http.Request) {
		idContent := req.FormValue("idContent")

		done := make(chan bool)

		var s string
		go deleteContentCat(idContent, done)
		if <-done {
			s = "success"
		} else {
			s = "failure"
		}
		w.Write([]byte(s))
	})

	port := ":8081"
	fmt.Println("Il Server è reperibile alla porta" + port)
	// Start server sulla porta specificata prima
	log.Fatal(http.ListenAndServe(port, mux))
}
