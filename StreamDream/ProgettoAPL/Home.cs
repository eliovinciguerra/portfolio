using System;
using System.Drawing;
using System.Windows.Forms;



namespace ProgettoAPL
{
   

    public partial class Home : Form
    {
      
        private string User;
        private string emailPass;
     
        ToPython py = new ToPython();
     
        public Home(string User, string emailPass)
        {
            InitializeComponent();
            this.User = User;
            this.emailPass = emailPass; 

        }
        private void Home_Load(object sender, EventArgs e)
        {

            int y = 55;
            y = nuovaSezione("imdbAPI.py", "top250TVSeries", "Top 9 Serie TV", y);
            y = nuovaSezione("imdbAPI.py", "top250Movies", "Top 9 Movies", y);
            labelWelcome.Text = "Welcome, " + User + "!";
        }
        private int nuovaSezione(string filePy,string nomeMetodo, string labelTitolo, int y )
        {
            var a = py.callPy(filePy, nomeMetodo);
            int x = 15;
            int size = 0;
            Label labelInfo = new Label();
            labelInfo.Location = new Point(x, y);
            labelInfo.Text = labelTitolo;
            labelInfo.ForeColor = Color.White;
            labelInfo.BackColor = Color.Transparent;
            labelInfo.Font= new Font("STENCIL", 10);
            labelInfo.Size = new Size(170,30);
            this.Controls.Add(labelInfo);
            x = x + 10;
            y = y + 30;
            for (int i = 0; i < 9; i++)
            {
                Label titolo = new Label();
                PictureBox immagine = new PictureBox();
                Button button = new Button();
                
                string[] linkIm = a[i].Split("ç");
                // Titolo serie e film
                titolo.Text = linkIm[3]+"-"+linkIm[0];
                size = titolo.Size.Width;
                titolo.BackColor = Color.Transparent;
                titolo.Location = new Point(x, y);
                //immagini
                immagine.Location = new Point(x, y+30);
                immagine.Size = new Size(125, 150);
                immagine.ImageLocation = linkIm[1];
                immagine.Visible = true;
                immagine.SizeMode = PictureBoxSizeMode.StretchImage;
                //buttoni
                button.Text = "Info";
                button.Click += (sender, e) =>
                {
                    
                    //linkIm[0] è il nome del contenuto, linkIm[2] è l'id del contenuto, linkIm[1] è l'immagine
                    InfoForms Info = new InfoForms(linkIm[0], linkIm[2], linkIm[1], User,emailPass);
                    Info.Show();
                    this.Hide();

                };
                button.Size = new Size(75, 30);
                button.Location = new Point(x + 25, y + 150 + 25);
                x = x + size + 115;
                titolo.Size = new Size(200, 20);
             
                if (x >= 460)
                {
                    x = 25;
                    y = y + 210;
                }
                titolo.Font = new Font("Calibri", 8);
                titolo.ForeColor = Color.White;
               

                this.Controls.Add(button);
                this.Controls.Add(titolo);
                this.Controls.Add(immagine);
            }
            y = y + 30;
            return y;
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

            Profilo profilo = new Profilo(User, emailPass);
            profilo.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            
        
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string cerca = textBoxSearch.Text;
            SearchContent SearchContent = new SearchContent(User,emailPass, cerca);
            SearchContent.Show();
            this.Hide();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {

            VisualAccount vAccount = new VisualAccount(User);
            vAccount.Show();
            this.Hide();
        }

        private void buttonVisulaCatalogue_Click(object sender, EventArgs e)
        {
            MyCatalogue form = new MyCatalogue(User,emailPass);
            form.Show();
            this.Hide();
        }
    }
}
