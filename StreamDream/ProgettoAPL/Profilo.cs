using System;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class Profilo : Form
    {

        private string User;
        private string emailPass;
        public Profilo(string User, string emailPass)
        {
            InitializeComponent();
            this.User = User;
            this.emailPass = emailPass;
        }
        private void Profilo_Load(object sender, EventArgs e)
        {}

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Home form2 = new Home(User, emailPass);
            form2.Show();
            this.Hide();
        }


        private void labelDescrizione_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ToPython py = new ToPython();
            string Pw = textBoxAccDelete.Text;
            if (Pw != "")
            {
                DialogResult eliminare;
                eliminare = MessageBox.Show("Do u want to delete account, " + User + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eliminare == DialogResult.Yes)
                {
                    var a = py.callPy("gestioneUtente.py", "delete", emailPass, Pw,User);
                    if (a == "Success")
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Qualcosa è andato storto, riprova!");
                    }
                }
                else
                {
                    MessageBox.Show("Siamo Lieti che tu voglia restare con noi, buona permanenza!");
                }

            }
            else
            {
                MessageBox.Show("Ricordati di inserire la Password!");
            }


        }


        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonSalvaEmail_Click(object sender, EventArgs e)
        {
            ToPython py = new ToPython();
            string emailChange = textBoxEmail.Text;
            if (emailChange != "" && emailChange!=emailPass)
            {
                var a = py.callPy("gestioneUtente.py", "changeEmail", emailChange, emailPass);
                if (a == "Success")
                {
                    emailPass = emailChange;
                    MessageBox.Show("Le modifiche sono avvenute con successo. La tua nuova email è:  "+emailChange);
                }
                else
                {
                    MessageBox.Show("C'è stato un problema riprova");
                }
            }
            else
            {
                MessageBox.Show("Riempi il campo o inserisci un'email diversa da quella già inserita in precedente!");
            }
            
        }
        private void buttonSalvaModifiche_Click(object sender, EventArgs e)
        {

            //salva
            ToPython py = new ToPython();
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text; 
            var a = py.callPy("gestioneUtente.py", "changeNameSurname", emailPass,name, surname);
            if(a=="Success")
            {
                MessageBox.Show("Le modifiche sono avvenute con successo");
            }
            else 
            {
                MessageBox.Show("C'è stato un problema riprova");
            }
            

        }

        private void labelChangePw_Click(object sender, EventArgs e)
        {

        }

        private void labelProfloPrivato_Click(object sender, EventArgs e)
        {

        }

        private void labelProfiloPubblico_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBoxVecchiaPW_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxNewPw_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxConfPW_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttonConfermaPw_Click(object sender, EventArgs e)
        {

            string nuovaPW = maskedTextBoxNewPw.Text;
            string oldPW = maskedTextBoxVecchiaPW.Text;
            string confNuovaPW = maskedTextBoxConfPW.Text;
            if (nuovaPW == confNuovaPW)
            {
                ToPython py = new ToPython();
                var a = py.callPy("gestioneUtente.py", "changePW", emailPass, nuovaPW, oldPW);
                if (a == "Success")
                {
                    MessageBox.Show("Password cambiata con Successo!");
                }
                else
                {
                    MessageBox.Show("C'è stato un problema, riprova!");
                }
            }
            else
            {
                MessageBox.Show("Le password non coincidono!");
            }
        }

        private void labelDescrizionePW_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult uscire;
            uscire = MessageBox.Show("Do u want to exit, " + User + "?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uscire == DialogResult.Yes)
            {
                Application.Exit();

            }
         
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            VisualAccount vAccount = new VisualAccount(User);
            vAccount.Show();
            this.Hide();
        }

        private void buttonVisulaCatalogue_Click(object sender, EventArgs e)
        {
            MyCatalogue form = new MyCatalogue(User, emailPass);
            form.Show();
            this.Hide();
        }
    }
}
