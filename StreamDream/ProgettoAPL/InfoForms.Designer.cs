
namespace ProgettoAPL
{
    partial class InfoForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForms));
            this.pictureBoxImageContent = new System.Windows.Forms.PictureBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.labelCast = new System.Windows.Forms.Label();
            this.panelCommenti = new System.Windows.Forms.Panel();
            this.panelCommentiRead = new System.Windows.Forms.Panel();
            this.buttonAddCommento = new System.Windows.Forms.Button();
            this.textBoxCommento = new System.Windows.Forms.TextBox();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonProfilo = new System.Windows.Forms.Button();
            this.buttonVisulaCatalogue = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Voto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nutenti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageContent)).BeginInit();
            this.panelDescription.SuspendLayout();
            this.panelCommenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImageContent
            // 
            this.pictureBoxImageContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxImageContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImageContent.Location = new System.Drawing.Point(12, 9);
            this.pictureBoxImageContent.Name = "pictureBoxImageContent";
            this.pictureBoxImageContent.Size = new System.Drawing.Size(125, 150);
            this.pictureBoxImageContent.TabIndex = 2;
            this.pictureBoxImageContent.TabStop = false;
            this.pictureBoxImageContent.Click += new System.EventHandler(this.pictureBoxImageContent_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 10);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(88, 20);
            this.labelDescription.TabIndex = 7;
            this.labelDescription.Text = "Description:";
            this.labelDescription.Click += new System.EventHandler(this.labelDescription_Click);
            // 
            // panelDescription
            // 
            this.panelDescription.AutoScroll = true;
            this.panelDescription.BackColor = System.Drawing.SystemColors.Info;
            this.panelDescription.Controls.Add(this.textBoxDescription);
            this.panelDescription.Controls.Add(this.labelDescription);
            this.panelDescription.Location = new System.Drawing.Point(173, 46);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(308, 144);
            this.panelDescription.TabIndex = 8;
            this.panelDescription.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Location = new System.Drawing.Point(3, 33);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(270, 108);
            this.textBoxDescription.TabIndex = 8;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(515, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(131, 29);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Add Catalogue";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoSize = true;
            this.labelTitolo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitolo.CausesValidation = false;
            this.labelTitolo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(173, 15);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(51, 20);
            this.labelTitolo.TabIndex = 12;
            this.labelTitolo.Text = "label1";
            this.labelTitolo.Click += new System.EventHandler(this.labelTitolo_Click);
            // 
            // labelCast
            // 
            this.labelCast.AutoSize = true;
            this.labelCast.BackColor = System.Drawing.Color.Transparent;
            this.labelCast.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCast.Location = new System.Drawing.Point(13, 188);
            this.labelCast.Name = "labelCast";
            this.labelCast.Size = new System.Drawing.Size(40, 20);
            this.labelCast.TabIndex = 13;
            this.labelCast.Text = "Cast:";
            // 
            // panelCommenti
            // 
            this.panelCommenti.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommenti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCommenti.Controls.Add(this.panelCommentiRead);
            this.panelCommenti.Controls.Add(this.buttonAddCommento);
            this.panelCommenti.Controls.Add(this.textBoxCommento);
            this.panelCommenti.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelCommenti.Location = new System.Drawing.Point(12, 273);
            this.panelCommenti.Name = "panelCommenti";
            this.panelCommenti.Size = new System.Drawing.Size(740, 234);
            this.panelCommenti.TabIndex = 15;
            this.panelCommenti.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCommenti_Paint);
            // 
            // panelCommentiRead
            // 
            this.panelCommentiRead.AutoScroll = true;
            this.panelCommentiRead.BackColor = System.Drawing.SystemColors.Control;
            this.panelCommentiRead.Location = new System.Drawing.Point(-1, -1);
            this.panelCommentiRead.Name = "panelCommentiRead";
            this.panelCommentiRead.Size = new System.Drawing.Size(740, 195);
            this.panelCommentiRead.TabIndex = 2;
            // 
            // buttonAddCommento
            // 
            this.buttonAddCommento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddCommento.Location = new System.Drawing.Point(639, 200);
            this.buttonAddCommento.Name = "buttonAddCommento";
            this.buttonAddCommento.Size = new System.Drawing.Size(94, 29);
            this.buttonAddCommento.TabIndex = 1;
            this.buttonAddCommento.Text = "Pubblica";
            this.buttonAddCommento.UseVisualStyleBackColor = true;
            this.buttonAddCommento.Click += new System.EventHandler(this.buttonAddCommento_Click);
            // 
            // textBoxCommento
            // 
            this.textBoxCommento.Location = new System.Drawing.Point(3, 202);
            this.textBoxCommento.Name = "textBoxCommento";
            this.textBoxCommento.PlaceholderText = "Lascia un commento...";
            this.textBoxCommento.Size = new System.Drawing.Size(630, 27);
            this.textBoxCommento.TabIndex = 0;
            this.textBoxCommento.TextChanged += new System.EventHandler(this.textBoxCommento_TextChanged);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(694, 5);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(94, 29);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(694, 179);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.Location = new System.Drawing.Point(694, 44);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(94, 29);
            this.buttonAccount.TabIndex = 17;
            this.buttonAccount.Text = "Account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonProfilo
            // 
            this.buttonProfilo.Location = new System.Drawing.Point(694, 142);
            this.buttonProfilo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProfilo.Name = "buttonProfilo";
            this.buttonProfilo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonProfilo.Size = new System.Drawing.Size(94, 29);
            this.buttonProfilo.TabIndex = 18;
            this.buttonProfilo.Text = "Settings";
            this.buttonProfilo.UseVisualStyleBackColor = true;
            this.buttonProfilo.Click += new System.EventHandler(this.buttonProfilo_Click_1);
            // 
            // buttonVisulaCatalogue
            // 
            this.buttonVisulaCatalogue.Location = new System.Drawing.Point(694, 79);
            this.buttonVisulaCatalogue.Name = "buttonVisulaCatalogue";
            this.buttonVisulaCatalogue.Size = new System.Drawing.Size(94, 57);
            this.buttonVisulaCatalogue.TabIndex = 19;
            this.buttonVisulaCatalogue.Text = "My Catalogue";
            this.buttonVisulaCatalogue.UseVisualStyleBackColor = true;
            this.buttonVisulaCatalogue.Click += new System.EventHandler(this.buttonVisulaCatalogue_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Voto,
            this.Nutenti});
            this.dataGridView1.Location = new System.Drawing.Point(487, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(198, 146);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Voto
            // 
            this.Voto.HeaderText = "Voto";
            this.Voto.MinimumWidth = 6;
            this.Voto.Name = "Voto";
            this.Voto.ReadOnly = true;
            this.Voto.Width = 45;
            // 
            // Nutenti
            // 
            this.Nutenti.HeaderText = "N utenti";
            this.Nutenti.MinimumWidth = 6;
            this.Nutenti.Name = "Nutenti";
            this.Nutenti.ReadOnly = true;
            this.Nutenti.Width = 72;
            // 
            // InfoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(810, 519);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonVisulaCatalogue);
            this.Controls.Add(this.buttonProfilo);
            this.Controls.Add(this.buttonAccount);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelCommenti);
            this.Controls.Add(this.labelCast);
            this.Controls.Add(this.labelTitolo);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panelDescription);
            this.Controls.Add(this.pictureBoxImageContent);
            this.Controls.Add(this.buttonHome);
            this.DoubleBuffered = true;
            this.Name = "InfoForms";
            this.Text = "InfoForms";
            this.Load += new System.EventHandler(this.InfoForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageContent)).EndInit();
            this.panelDescription.ResumeLayout(false);
            this.panelDescription.PerformLayout();
            this.panelCommenti.ResumeLayout(false);
            this.panelCommenti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxImageContent;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelCast;
        private System.Windows.Forms.Panel panelCommenti;
        private System.Windows.Forms.Panel panelCommentiRead;
        private System.Windows.Forms.Button buttonAddCommento;
        private System.Windows.Forms.TextBox textBoxCommento;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonProfilo;
        private System.Windows.Forms.Button buttonVisulaCatalogue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nutenti;
    }
}