using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoAPL
{
    public partial class InfoForms : Form
    {
        ToPython py = new ToPython();
        private string image;
        private string emailPass;
        private string name;
        private string id;
        private string User;
        public InfoForms(string name, string id, string image, string User, string emailPass)
        {
            InitializeComponent();
            this.User = User;
            this.name = name;
            this.image = image;
            this.id = id;
            this.emailPass = emailPass;


        }
     
        private void InfoForms_Load(object sender, EventArgs e)
        {
           
           

            labelTitolo.Text = name;
            var a = py.callPy("imdbAPI.py", "showWiki", id);

            textBoxDescription.Text = a;
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Multiline = true;
            textBoxDescription.WordWrap = true;
            pictureBoxImageContent.ImageLocation = image;
            pictureBoxImageContent.SizeMode = PictureBoxSizeMode.StretchImage;

            //show cast
            a = py.callPy("imdbAPI.py", "showCast", id);
            
            int x=27, y=223, size,dim;
            if (a.Count>12)
            {
                dim = 12;
            }
            else
            {
                dim = a.Count;
            }

            for (int i = 0; i < dim; i++)
            {
                Label attoreNome = new Label();
                Label attoreRuolo = new Label();
                PictureBox immagine = new PictureBox();
               

                string[] linkIm = a[i].Split("ç");
                // Titolo serie e film
                attoreNome.Text =  linkIm[1];
                attoreNome.BackColor = Color.Transparent;
                attoreNome.Font = new Font("Calibri", 8);
                attoreNome.ForeColor = Color.White;
                size = attoreNome.Size.Width;
                attoreNome.Location = new Point(x, y);
                attoreNome.Size = new Size(88, 20);
                //immagini
                immagine.Location = new Point(x+10, y + 25);
                immagine.Size = new Size(47, 55);
                immagine.ImageLocation = linkIm[0];
                immagine.Visible = true;
                immagine.SizeMode = PictureBoxSizeMode.StretchImage;
                //ruolo attore
                attoreRuolo.Text = linkIm[2];
                attoreRuolo.Size = new Size(88, 20);
                attoreRuolo.Location = new Point(x, y+80);
                attoreRuolo.Font = new Font("Calibri", 8);
                attoreRuolo.ForeColor = Color.White;
                attoreRuolo.BackColor = Color.Transparent;
                x = x + size + 41;
                
        
                if (x >= 460)
                {
                    x = 25;
                    y = y + 120;
                }
               
                this.Controls.Add(attoreRuolo);
                this.Controls.Add(attoreNome);
                this.Controls.Add(immagine);
            }
            y = y + 40;
            Label labelCommenti = new Label();
            labelCommenti.Text = "Commenti:";
            labelCommenti.ForeColor = Color.White;
            labelCommenti.BackColor = Color.Transparent;
            labelCommenti.Location = new Point(13, y);
            this.Controls.Add(labelCommenti);
            y = y + 30;
            //aggiunta commenti
            panelCommenti.Location = new Point(27, y);
            var comment= py.callPy("gestioneCatalogo.py", "getComment", id);
            int yPanelComment = 0;

            if (comment[0] == "Failure")
            {
                Label labelC = new Label();
                labelC.Text = "Nessun commento disponibile...!";
                labelC.ForeColor = Color.Black;
                labelC.Location = new Point(panelCommentiRead.Width/2-180, panelCommentiRead.Height/2);
                labelC.Size = new Size(350, 20);
                panelCommentiRead.Controls.Add(labelC);

            }
            else
            {
                for (int i = 0; i < comment.Count; i++)
                {
                    Label labelComUser = new Label();
                    Label labelCom = new Label();
                    string[] linkIm = comment[i].Split("ç");

                    labelComUser.Text = linkIm[0] + " dice:";
                    labelComUser.ForeColor = Color.Black;
                    labelComUser.Location = new Point(27, yPanelComment);
                    

                    labelCom.Text = linkIm[1];
                    labelCom.Size = new Size(390, 30);
                    labelCom.ForeColor = Color.Black;
                    labelCom.Location = new Point(40, yPanelComment + 30);

                    if (User == linkIm[0])
                    {
                        Button button = new Button();
                        button.Text = "Delete";
                        button.ForeColor = Color.Black;
                        button.Click += (sender, e) =>
                        {
                            
                            //linkIm[2] è l'id del commento
                            var comment = py.callPy("gestioneCatalogo.py", "deleteComment", linkIm[2]);

                            InfoForms InfoForm = new InfoForms(name, id, image, User, emailPass);
                            InfoForm.Show();
                            this.Hide();



                        };
                        button.Size = new Size(75, 30);
                        button.Location = new Point(panelCommentiRead.Width-50-75, yPanelComment);
                        panelCommentiRead.Controls.Add(button);
                    }
                    yPanelComment = yPanelComment + 75;
                    panelCommentiRead.Controls.Add(labelComUser);
                    panelCommentiRead.Controls.Add(labelCom);

                }

            }

            //rating view
            
            var rating = py.callPy("imdbAPI.py", "ratings",id);
            for(int i=0; i<rating.Count; i++)
            {
                dataGridView1.Rows.Add(i+1,rating[i]);
            }
          

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Home form2 = new Home(User,emailPass);
            form2.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCommentiRatings_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBoxImageContent_Click(object sender, EventArgs e)
        {

        }

        private void panelPlot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            var addC = py.callPy("gestioneCatalogo.py", "addContent",emailPass,id, image,name);
            MessageBox.Show(addC);
            
        }

        private void labelDescription_Click(object sender, EventArgs e)
        {

        }

        private void labelTitolo_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelCommenti_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxCommento_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddCommento_Click(object sender, EventArgs e)
        {
            
            var content = textBoxCommento.Text;
            var a = py.callPy("gestioneCatalogo.py", "addComment", User ,id, name, content);
            InfoForms InfoForm = new InfoForms(name, id, image, User, emailPass);
            InfoForm.Show();
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

            Profilo profilo = new Profilo(User, emailPass);
            profilo.Show();
            this.Dispose();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            VisualAccount vAccount = new VisualAccount(User);
            vAccount.Show();
            this.Dispose();
        }

        private void buttonProfilo_Click_1(object sender, EventArgs e)
        {
            Profilo profilo = new Profilo(User,emailPass);
            profilo.Show();
            this.Dispose();
        }

        private void buttonVisulaCatalogue_Click(object sender, EventArgs e)
        {
            MyCatalogue form = new MyCatalogue(User,emailPass);
            form.Show();
            this.Hide();
        }

        private void panelRating_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
