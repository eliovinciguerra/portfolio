using System;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class registrazione : Form
    {
        public registrazione()
        {
            InitializeComponent();
       
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void textConPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelConPassword_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfermaSignIn_Click(object sender, EventArgs e)
        {

            ToPython py = new ToPython();
            string username = textUsername.Text;
            string email = textemail.Text;
            string password = textPassword.Text;
            string name = textName.Text;
            string surname = textLastName.Text;
            string confPW = textConPassword.Text;
            if (username != "" && surname != ""  && email != ""  && name != "")
            {

                if (password == confPW && password != "")
                {
                    try {
                        var a = py.callPy("gestioneUtente.py", "signin", email, password, name, surname, username);
                        if (a == username)
                        {
                            Home form2 = new Home(username, email);
                            form2.Show();
                            this.Hide();
                        }
                        else if (a == "Usato")
                        {
                            DialogResult log;
                            log = MessageBox.Show("Vuoi andare al login e fare l'accesso?", "login", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (log == DialogResult.Yes)
                            {
                              
                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide();
                            }
                            else
                            {
                                textUsername.Clear();
                                textPassword.Clear();
                                textConPassword.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Stiamo avendo problemi con i server, riprova tra qualche minuto!");
                        }
                    }

                    catch (IronPython.Runtime.Exceptions.ConnectionRefusedException)
                    {
                        MessageBox.Show( "Server not available!", "Server");
                    }
                   

                }
                else
                {
                    MessageBox.Show("Errore le due password inserite non coincidono!");
                    textPassword.Clear();
                    textConPassword.Clear();
                }
            }
            else
            {
                labelError.Text = "Compila tutti i campi!";
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textUsername.Clear();
            textPassword.Clear();
            textConPassword.Clear();
            textName.Clear();
            textLastName.Clear();
            textemail.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void linkLabelUNICT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            try
            {
                linkLabelUNICT.LinkVisited = true;
                string url = "http://www.unict.it";
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = url;
                System.Diagnostics.Process.Start(psi);

            }
            catch (Exception)
            {
                MessageBox.Show("Si è verificato un errore, riprovare più tardi!.");
            }
        }

        private void buttonAutoGenUser_Click(object sender, EventArgs e)
        {
            string nome=textName.Text;
            string cognome = textLastName.Text;
            ToPython py = new ToPython();
            if(nome!="" || cognome != "")
            {
                var username = py.callPy("gestioneUtente.py", "generate_User", nome,cognome);
                textUsername.Text = username;
            }
            else
            {
                labelError.Text = "Insersci il nome/cognome!";
            }
        }
    }
}
