using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class MyCatalogue : Form
    {
        private string emailPass;
        private string User;
     
        ToPython py = new ToPython();
        public MyCatalogue(string User, string emailPass)
        {
            InitializeComponent();
         
            this.User = User;
            this.emailPass = emailPass;
         
        }
        
        private void MyCatalogue_Load(object sender, EventArgs e)
        {
            
            var a = py.callPy("gestioneCatalogo.py", "getCatalogo", emailPass);
            int x = 15, y=20;
            int size = 0;
            Label labelInfo = new Label();
            labelInfo.Location = new Point(x, y);
            labelInfo.Text = "Il mio catalogo!";
            labelInfo.ForeColor = Color.Black;
            labelInfo.BackColor = Color.Transparent;
            labelInfo.Font = new Font("STENCIL", 10);
            labelInfo.Size = new Size(170, 30);
            this.Controls.Add(labelInfo);

            if (a[0] != "Failure" )
            {
                x = x + 10;
                y = y + 30;
                for (int i = 0; i < a.Count; i++)
                {
                    Label titolo = new Label();
                    PictureBox immagine = new PictureBox();
                    Button button = new Button();
                    Button buttonRemove = new Button();

                    string[] linkIm = a[i].Split("ç");
                    // Titolo serie e film
                    titolo.Text = linkIm[1];
                    size = titolo.Size.Width;
                    titolo.BackColor = Color.Transparent;
                    titolo.Location = new Point(x, y);
                    //immagini

                    immagine.Location = new Point(x, y + 30);
                    immagine.Size = new Size(125, 150);
                    immagine.ImageLocation = linkIm[2];
                    immagine.Visible = true;
                    immagine.SizeMode = PictureBoxSizeMode.StretchImage;
                    //buttoni
                    button.Text = "Info";
                    button.Click += (sender, e) =>
                    {
                        string nomeContent = linkIm[1];
                        string id = linkIm[0];
                        string image = linkIm[2];
                        InfoForms Info = new InfoForms(nomeContent, id, image, User, emailPass);
                        Info.Show();
                        this.Hide();

                    };
                    button.Size = new Size(75, 30);
                    button.Location = new Point(x - 15, y + 150 + 25);
                    buttonRemove.Text = "Remove";
                    buttonRemove.Click += (sender, e) =>
                    {
                        
                        //linkIm[3] è l'id del film
                        
                        var a = py.callPy("gestioneCatalogo.py", "deleteContentCat", linkIm[3]);
                        MyCatalogue mC = new MyCatalogue(User, emailPass);
                        mC.Show();
                        this.Hide();

                    };
                    buttonRemove.Size = new Size(75, 30);
                    buttonRemove.Location = new Point(x + button.Size.Width + 2, y + 150 + 25);
                    x = x + size + 115;
                    titolo.Size = new Size(200, 20);
                    
                    if (x >= 460)
                    {
                        x = 25;
                        y = y + 210;
                    }
                    titolo.Font = new Font("Calibri", 8);
                    titolo.ForeColor = Color.White;

                    this.Controls.Add(buttonRemove);
                    this.Controls.Add(button);
                    this.Controls.Add(titolo);
                    this.Controls.Add(immagine);
                }
                y = y + 30;


            }
            else
            {
                
                Label labelV = new Label();
                labelV.Location = new Point(25, 100);
                labelV.Text = "Nessun elemento aggiunto o si è verificato un errore!";
                labelV.ForeColor = Color.Black;
                labelV.BackColor = Color.Transparent;
                labelV.Font = new Font("STENCIL", 10);
                labelV.Size = new Size(600, 30);
                this.Controls.Add(labelV);
            }


        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Home form2 = new Home(User,emailPass);
            form2.Show();
            this.Hide();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            VisualAccount vAccount = new VisualAccount(User);
            vAccount.Show();
            this.Hide();
        }

        private void buttonProfilo_Click(object sender, EventArgs e)
        {
            Profilo profilo = new Profilo(User, emailPass);
            profilo.Show();
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

       
    }
}
