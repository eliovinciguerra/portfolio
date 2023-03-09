
namespace ProgettoAPL
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelPw = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPwUser = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.SignIn = new System.Windows.Forms.Button();
            this.textemail = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.panelCredit = new System.Windows.Forms.Panel();
            this.linkLabelUNICT = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCreate = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelCredit.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Location = new System.Drawing.Point(125, 140);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(0, 20);
            this.labelPw.TabIndex = 4;
            this.labelPw.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelPwUser);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.SignIn);
            this.panel1.Controls.Add(this.textemail);
            this.panel1.Controls.Add(this.labelPass);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.Login);
            this.panel1.Controls.Add(this.labelPw);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(248, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 381);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelPwUser
            // 
            this.labelPwUser.AutoSize = true;
            this.labelPwUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPwUser.ForeColor = System.Drawing.Color.White;
            this.labelPwUser.Location = new System.Drawing.Point(96, 22);
            this.labelPwUser.Name = "labelPwUser";
            this.labelPwUser.Size = new System.Drawing.Size(0, 28);
            this.labelPwUser.TabIndex = 13;
            // 
            // buttonClear
            // 
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClear.Location = new System.Drawing.Point(106, 222);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(89, 40);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textPassword
            // 
            this.textPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textPassword.Location = new System.Drawing.Point(125, 166);
            this.textPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(151, 27);
            this.textPassword.TabIndex = 11;
            // 
            // SignIn
            // 
            this.SignIn.Location = new System.Drawing.Point(36, 314);
            this.SignIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(89, 38);
            this.SignIn.TabIndex = 5;
            this.SignIn.Text = "SignIn";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // textemail
            // 
            this.textemail.Location = new System.Drawing.Point(125, 101);
            this.textemail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textemail.Name = "textemail";
            this.textemail.Size = new System.Drawing.Size(151, 27);
            this.textemail.TabIndex = 10;
            this.textemail.TextChanged += new System.EventHandler(this.textUsername_TextChanged);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.BackColor = System.Drawing.Color.Transparent;
            this.labelPass.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPass.Location = new System.Drawing.Point(122, 140);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(91, 18);
            this.labelPass.TabIndex = 8;
            this.labelPass.Text = "Password";
            this.labelPass.Click += new System.EventHandler(this.labelPass_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelUser.Location = new System.Drawing.Point(125, 75);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(137, 18);
            this.labelUser.TabIndex = 7;
            this.labelUser.Text = "Username/Email";
            this.labelUser.Click += new System.EventHandler(this.labelUser_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(226, 222);
            this.Login.Margin = new System.Windows.Forms.Padding(0);
            this.Login.Name = "Login";
            this.Login.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Login.Size = new System.Drawing.Size(89, 40);
            this.Login.TabIndex = 6;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // panelCredit
            // 
            this.panelCredit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelCredit.Controls.Add(this.linkLabelUNICT);
            this.panelCredit.Controls.Add(this.label1);
            this.panelCredit.Controls.Add(this.labelCreate);
            this.panelCredit.Location = new System.Drawing.Point(0, 570);
            this.panelCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCredit.Name = "panelCredit";
            this.panelCredit.Size = new System.Drawing.Size(862, 149);
            this.panelCredit.TabIndex = 10;
            // 
            // linkLabelUNICT
            // 
            this.linkLabelUNICT.AutoSize = true;
            this.linkLabelUNICT.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabelUNICT.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabelUNICT.LinkVisited = true;
            this.linkLabelUNICT.Location = new System.Drawing.Point(706, 10);
            this.linkLabelUNICT.Name = "linkLabelUNICT";
            this.linkLabelUNICT.Size = new System.Drawing.Size(89, 20);
            this.linkLabelUNICT.TabIndex = 2;
            this.linkLabelUNICT.TabStop = true;
            this.linkLabelUNICT.Text = "www.unict.it";
            this.linkLabelUNICT.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabelUNICT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUNICT_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(699, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.Font = new System.Drawing.Font("Microsoft Yi Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCreate.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCreate.Location = new System.Drawing.Point(17, 10);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(284, 17);
            this.labelCreate.TabIndex = 0;
            this.labelCreate.Text = "Created by: Maria Roggio e Elio Vinciguerra ";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWelcome.Location = new System.Drawing.Point(375, 29);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(162, 37);
            this.labelWelcome.TabIndex = 11;
            this.labelWelcome.Text = "Welcome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 611);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.panelCredit);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCredit.ResumeLayout(false);
            this.panelCredit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textemail;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panelCredit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.LinkLabel linkLabelUNICT;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelPwUser;
    }
}

