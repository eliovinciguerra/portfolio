package main

import (
	"fmt"
	"net/smtp"
)

// smtpServer data to smtp server
type smtpServer struct {
	host string
	port string
}

// Address URI to smtp server
func (s *smtpServer) Address() string {
	return s.host + ":" + s.port
}

func mail(email string, subject string, text string) {
	// Sender data.
	from := "email@test.com"
	password := "emailpassword"
	// Receiver email address.
	to := []string{
		email,
	}
	// smtp server configuration.
	smtpServer := smtpServer{host: "smtp.gmail.com", port: "587"}
	// Message.
	message := []byte("Subject: " + subject + "\r\n\r\n" + text)
	// Authentication.
	auth := smtp.PlainAuth("", from, password, smtpServer.host)
	// Sending email.
	err := smtp.SendMail(smtpServer.Address(), auth, from, to, message)
	if err != nil {
		fmt.Println(err)
		return
	}
	fmt.Println("Email Sent!")
}
