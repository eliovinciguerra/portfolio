using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class SearchContent : Form
    {
        ToPython py = new ToPython();
        private string search;
        private string emailPass;
        private string User;
        public SearchContent(string User, string emailPass,string search)
        {
            InitializeComponent();
            this.emailPass = emailPass;
            this.search = search;
            this.User = User;
        }

        private void SearchContent_Load(object sender, EventArgs e)
        {
            
            labelTitolo.Text = "Cerco i risultati per "+search;
            labelTitolo.BackColor = Color.Transparent;
            labelTitolo.Font = new Font("Showcard Gothic", 13);
            labelTitolo.ForeColor = Color.White;
            var a = py.callPy("imdbAPI.py", "searchEverything",search);
            int x = 25;
            int y = 50;
            int size = 0;
            if (a[0] != "Failure")
            {

                for (int i = 0; i < a.Count; i++)
                {
                    Label titolo = new Label();
                    PictureBox immagine = new PictureBox();
                    Button button = new Button();

                    string[] linkIm = a[i].Split("ç");
                    // Titolo serie e film
                    titolo.Text = linkIm[0];
                    titolo.ForeColor = Color.White;
                    titolo.BackColor = Color.Transparent;
                    size = titolo.Size.Width;
                    titolo.Font = new Font("Calibri", 8);
                    titolo.Location = new Point(x, y);
                    //immagini

                    immagine.Location = new Point(x, y + 30);
                    immagine.Size = new Size(125, 150);
                    immagine.ImageLocation = linkIm[1];
                    immagine.Visible = true;
                    immagine.SizeMode = PictureBoxSizeMode.StretchImage;
                    //buttoni
                    button.Text = "Info";
                    button.Click += (sender, e) =>
                    {
                        
                        //linkIm[0] è il nome del contenuto, linkIm[2] è l'id, linkIm[1] è l'immagine
                        InfoForms Info = new InfoForms(linkIm[0], linkIm[2], linkIm[1], User, emailPass);
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
                labelV.Text = "Nessun contenuto trovato!";
                labelV.ForeColor = Color.White;
                labelV.BackColor = Color.Transparent;
                labelV.Font = new Font("STENCIL", 10);
                labelV.Size = new Size(400, 30);
                this.Controls.Add(labelV);
            }
        }

        private void labelTitolo_Click(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Home form2 = new Home(User, emailPass);
            form2.Show();
            this.Hide();
        }

        private void buttonProfilo_Click(object sender, EventArgs e)
        {
            Profilo profilo = new Profilo(User,emailPass);
            profilo.Show();
            this.Hide();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            VisualAccount vAccount = new VisualAccount(User);
            vAccount.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult uscire;
            uscire = MessageBox.Show("Do u want to exit," + User + "?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uscire == DialogResult.Yes)
            {

                Application.Exit();


            }
          
        }

        private void buttonVisulaCatalogue_Click(object sender, EventArgs e)
        {
            MyCatalogue form = new MyCatalogue(User, emailPass);
            form.Show();
            this.Hide();
        }
    }
}
