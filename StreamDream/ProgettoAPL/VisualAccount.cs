using System;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class VisualAccount : Form
    {
        private string User;
        private string emailPass;
        ToPython py = new ToPython();


        public VisualAccount(string User)
        {
            InitializeComponent();
            this.User = User;
           
        }

        private void VisualAccount_Load(object sender, EventArgs e)
        {
         
            
            labelUsername.Text = "Username: "+User;
            labelWelcome.Text = "Welcome to your profile:" + User;
            var info = py.callPy("gestioneUtente.py", "infoUser", User);

            emailPass = info["email"];
            labelEmail.Text = "Email: "+ emailPass;
           
            labelName.Text = "Name: "+info["first"];
            labelSurname.Text = "Surname: "+info["last"];

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void buttonhome_Click(object sender, EventArgs e)
        {
            Home form2 = new Home(User,emailPass);
            form2.Show();
            this.Hide();
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

        private void buttonProfilo_Click(object sender, EventArgs e)
        {
            Profilo profilo = new Profilo(User,emailPass);
            profilo.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonVisulaCatalogue_Click(object sender, EventArgs e)
        {
            MyCatalogue form = new MyCatalogue(User,emailPass);
            form.Show();
            this.Hide();
        }
    }
}
