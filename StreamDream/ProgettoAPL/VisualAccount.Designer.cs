
namespace ProgettoAPL
{
    partial class VisualAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualAccount));
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonhome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonProfilo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonVisulaCatalogue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(3, 18);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(63, 25);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "label1";
            this.labelUsername.Click += new System.EventHandler(this.labelUsername_Click);
            // 
            // buttonhome
            // 
            this.buttonhome.Location = new System.Drawing.Point(24, 25);
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.Size = new System.Drawing.Size(94, 29);
            this.buttonhome.TabIndex = 1;
            this.buttonhome.Text = "Home";
            this.buttonhome.UseVisualStyleBackColor = true;
            this.buttonhome.Click += new System.EventHandler(this.buttonhome_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelSurname);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelUsername);
            this.panel1.Location = new System.Drawing.Point(243, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 291);
            this.panel1.TabIndex = 2;
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSurname.Location = new System.Drawing.Point(5, 162);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(63, 25);
            this.labelSurname.TabIndex = 3;
            this.labelSurname.Text = "label1";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(4, 115);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(63, 25);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "label1";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(4, 65);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(63, 25);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "label1";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWelcome.Location = new System.Drawing.Point(29, 26);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(95, 29);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "label1";
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(24, 232);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonProfilo
            // 
            this.buttonProfilo.Location = new System.Drawing.Point(24, 82);
            this.buttonProfilo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProfilo.Name = "buttonProfilo";
            this.buttonProfilo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonProfilo.Size = new System.Drawing.Size(94, 29);
            this.buttonProfilo.TabIndex = 6;
            this.buttonProfilo.Text = "Settings";
            this.buttonProfilo.UseVisualStyleBackColor = true;
            this.buttonProfilo.Click += new System.EventHandler(this.buttonProfilo_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.buttonVisulaCatalogue);
            this.panel2.Controls.Add(this.buttonhome);
            this.panel2.Controls.Add(this.buttonProfilo);
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(658, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 450);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonVisulaCatalogue
            // 
            this.buttonVisulaCatalogue.Location = new System.Drawing.Point(24, 140);
            this.buttonVisulaCatalogue.Name = "buttonVisulaCatalogue";
            this.buttonVisulaCatalogue.Size = new System.Drawing.Size(94, 57);
            this.buttonVisulaCatalogue.TabIndex = 7;
            this.buttonVisulaCatalogue.Text = "My Catalogue";
            this.buttonVisulaCatalogue.UseVisualStyleBackColor = true;
            this.buttonVisulaCatalogue.Click += new System.EventHandler(this.buttonVisulaCatalogue_Click);
            // 
            // VisualAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "VisualAccount";
            this.Text = "VisualAccount";
            this.Load += new System.EventHandler(this.VisualAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonhome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonProfilo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonVisulaCatalogue;
    }
}