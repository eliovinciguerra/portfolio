using System;
using System.Windows.Forms;


namespace ProgettoAPL
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();        
        }
        ToPython py = new ToPython();
       
        private void Form1_Load(object sender, EventArgs e)
        { }


        private void label2_Click(object sender, EventArgs e)
        { }


        //sign in button
        private void SignIn_Click(object sender, EventArgs e)
        {
            registrazione form3 = new registrazione();
            form3.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { }
        //login button

        private void Login_Click(object sender, EventArgs e)
        {

            
            string email = textemail.Text;
            string password = textPassword.Text;
          
            
            try
            {
                var username = py.callPy("gestioneUtente.py", "login", email, password);
                if (textemail.Text == "")
                {
                    //aggiungere pw
                    labelPwUser.Text = "Inserire tutti i campi!";
                }
                else
                {

                    if (username != "failure")
                    {
                        Home form2 = new Home(username, email);
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (username == "Errore")
                        {
                            MessageBox.Show("C'è stato un problema con la connessione, riprova!");
                        }
                        else
                        {
                            labelPwUser.Text = "Email o Password errate";
                        }

                        textemail.Clear();
                        textPassword.Clear();

                    }
                }

            }
            catch (IronPython.Runtime.Exceptions.ConnectionRefusedException)
            {
                MessageBox.Show("Server not available!", "Server");          
            }
        }

        private void labelUser_Click(object sender, EventArgs e)
        {
        }

        private void labelPass_Click(object sender, EventArgs e)
        {
        }



        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textemail.Clear();
            textPassword.Clear();

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
    }
}
