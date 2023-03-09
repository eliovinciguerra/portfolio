
namespace ProgettoAPL
{
    partial class Profilo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profilo));
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPW = new System.Windows.Forms.Label();
            this.textBoxAccDelete = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelProfiloPubblico = new System.Windows.Forms.Label();
            this.labelDescrizioneCancellaAcc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSalvaEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNewPw = new System.Windows.Forms.Label();
            this.labelOldPw = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonConfermaPw = new System.Windows.Forms.Button();
            this.maskedTextBoxConfPW = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxNewPw = new System.Windows.Forms.MaskedTextBox();
            this.labelDescrizionePW = new System.Windows.Forms.Label();
            this.maskedTextBoxVecchiaPW = new System.Windows.Forms.MaskedTextBox();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.labelChangePw = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelProfloPrivato = new System.Windows.Forms.Label();
            this.buttonSalvaModifiche = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonVisulaCatalogue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(26, 9);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(94, 29);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelPW);
            this.panel1.Controls.Add(this.textBoxAccDelete);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.labelProfiloPubblico);
            this.panel1.Controls.Add(this.labelDescrizioneCancellaAcc);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 445);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPW.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPW.Location = new System.Drawing.Point(3, 110);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(80, 20);
            this.labelPW.TabIndex = 7;
            this.labelPW.Text = "Password:";
            // 
            // textBoxAccDelete
            // 
            this.textBoxAccDelete.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxAccDelete.Location = new System.Drawing.Point(3, 133);
            this.textBoxAccDelete.Name = "textBoxAccDelete";
            this.textBoxAccDelete.PasswordChar = '*';
            this.textBoxAccDelete.Size = new System.Drawing.Size(125, 27);
            this.textBoxAccDelete.TabIndex = 6;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(15, 166);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 29);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelProfiloPubblico
            // 
            this.labelProfiloPubblico.AutoSize = true;
            this.labelProfiloPubblico.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProfiloPubblico.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProfiloPubblico.Location = new System.Drawing.Point(3, 4);
            this.labelProfiloPubblico.Name = "labelProfiloPubblico";
            this.labelProfiloPubblico.Size = new System.Drawing.Size(164, 18);
            this.labelProfiloPubblico.TabIndex = 2;
            this.labelProfiloPubblico.Text = "Profilo Pubblico";
            this.labelProfiloPubblico.Click += new System.EventHandler(this.labelProfiloPubblico_Click);
            // 
            // labelDescrizioneCancellaAcc
            // 
            this.labelDescrizioneCancellaAcc.AutoSize = true;
            this.labelDescrizioneCancellaAcc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDescrizioneCancellaAcc.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelDescrizioneCancellaAcc.Location = new System.Drawing.Point(-1, 40);
            this.labelDescrizioneCancellaAcc.Name = "labelDescrizioneCancellaAcc";
            this.labelDescrizioneCancellaAcc.Size = new System.Drawing.Size(243, 60);
            this.labelDescrizioneCancellaAcc.TabIndex = 5;
            this.labelDescrizioneCancellaAcc.Text = "Per cancellare il propiro account    \r\nbisogna prima riempire il campo    \r\nsotto" +
    "stante.        ";
            this.labelDescrizioneCancellaAcc.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.buttonSalvaEmail);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelNewPw);
            this.panel2.Controls.Add(this.labelOldPw);
            this.panel2.Controls.Add(this.labelSurname);
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Controls.Add(this.labelEmail);
            this.panel2.Controls.Add(this.buttonConfermaPw);
            this.panel2.Controls.Add(this.maskedTextBoxConfPW);
            this.panel2.Controls.Add(this.maskedTextBoxNewPw);
            this.panel2.Controls.Add(this.labelDescrizionePW);
            this.panel2.Controls.Add(this.maskedTextBoxVecchiaPW);
            this.panel2.Controls.Add(this.labelDescrizione);
            this.panel2.Controls.Add(this.labelChangePw);
            this.panel2.Controls.Add(this.textBoxSurname);
            this.panel2.Controls.Add(this.textBoxName);
            this.panel2.Controls.Add(this.labelProfloPrivato);
            this.panel2.Controls.Add(this.buttonSalvaModifiche);
            this.panel2.Controls.Add(this.textBoxEmail);
            this.panel2.Location = new System.Drawing.Point(267, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 445);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonSalvaEmail
            // 
            this.buttonSalvaEmail.Location = new System.Drawing.Point(179, 137);
            this.buttonSalvaEmail.Name = "buttonSalvaEmail";
            this.buttonSalvaEmail.Size = new System.Drawing.Size(94, 29);
            this.buttonSalvaEmail.TabIndex = 19;
            this.buttonSalvaEmail.Text = "Salva email";
            this.buttonSalvaEmail.UseVisualStyleBackColor = true;
            this.buttonSalvaEmail.Click += new System.EventHandler(this.buttonSalvaEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(282, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Confirm Password:";
            // 
            // labelNewPw
            // 
            this.labelNewPw.AutoSize = true;
            this.labelNewPw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNewPw.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNewPw.Location = new System.Drawing.Point(143, 347);
            this.labelNewPw.Name = "labelNewPw";
            this.labelNewPw.Size = new System.Drawing.Size(116, 20);
            this.labelNewPw.TabIndex = 17;
            this.labelNewPw.Text = "New Password:";
            // 
            // labelOldPw
            // 
            this.labelOldPw.AutoSize = true;
            this.labelOldPw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOldPw.ForeColor = System.Drawing.SystemColors.Control;
            this.labelOldPw.Location = new System.Drawing.Point(5, 348);
            this.labelOldPw.Name = "labelOldPw";
            this.labelOldPw.Size = new System.Drawing.Size(108, 20);
            this.labelOldPw.TabIndex = 16;
            this.labelOldPw.Text = "Old Password:";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSurname.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSurname.Location = new System.Drawing.Point(20, 234);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(75, 20);
            this.labelSurname.TabIndex = 15;
            this.labelSurname.Text = "Surname:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelName.Location = new System.Drawing.Point(21, 187);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Name:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.ForeColor = System.Drawing.SystemColors.Control;
            this.labelEmail.Location = new System.Drawing.Point(21, 107);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(51, 20);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "Email:";
            // 
            // buttonConfermaPw
            // 
            this.buttonConfermaPw.Location = new System.Drawing.Point(156, 403);
            this.buttonConfermaPw.Name = "buttonConfermaPw";
            this.buttonConfermaPw.Size = new System.Drawing.Size(94, 29);
            this.buttonConfermaPw.TabIndex = 12;
            this.buttonConfermaPw.Text = "Conferma";
            this.buttonConfermaPw.UseVisualStyleBackColor = true;
            this.buttonConfermaPw.Click += new System.EventHandler(this.buttonConfermaPw_Click);
            // 
            // maskedTextBoxConfPW
            // 
            this.maskedTextBoxConfPW.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.maskedTextBoxConfPW.Location = new System.Drawing.Point(282, 370);
            this.maskedTextBoxConfPW.Name = "maskedTextBoxConfPW";
            this.maskedTextBoxConfPW.PasswordChar = '*';
            this.maskedTextBoxConfPW.Size = new System.Drawing.Size(125, 27);
            this.maskedTextBoxConfPW.TabIndex = 11;
            this.maskedTextBoxConfPW.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxConfPW_MaskInputRejected);
            // 
            // maskedTextBoxNewPw
            // 
            this.maskedTextBoxNewPw.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.maskedTextBoxNewPw.Location = new System.Drawing.Point(143, 370);
            this.maskedTextBoxNewPw.Name = "maskedTextBoxNewPw";
            this.maskedTextBoxNewPw.PasswordChar = '*';
            this.maskedTextBoxNewPw.Size = new System.Drawing.Size(125, 27);
            this.maskedTextBoxNewPw.TabIndex = 10;
            this.maskedTextBoxNewPw.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxNewPw_MaskInputRejected);
            // 
            // labelDescrizionePW
            // 
            this.labelDescrizionePW.AutoSize = true;
            this.labelDescrizionePW.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDescrizionePW.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelDescrizionePW.Location = new System.Drawing.Point(3, 315);
            this.labelDescrizionePW.Name = "labelDescrizionePW";
            this.labelDescrizionePW.Size = new System.Drawing.Size(414, 20);
            this.labelDescrizionePW.TabIndex = 9;
            this.labelDescrizionePW.Text = "Inserisci nei campi riportati di seguito i dati richiesti.               ";
            this.labelDescrizionePW.Click += new System.EventHandler(this.labelDescrizionePW_Click);
            // 
            // maskedTextBoxVecchiaPW
            // 
            this.maskedTextBoxVecchiaPW.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.maskedTextBoxVecchiaPW.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.maskedTextBoxVecchiaPW.Location = new System.Drawing.Point(5, 371);
            this.maskedTextBoxVecchiaPW.Name = "maskedTextBoxVecchiaPW";
            this.maskedTextBoxVecchiaPW.PasswordChar = '*';
            this.maskedTextBoxVecchiaPW.Size = new System.Drawing.Size(122, 27);
            this.maskedTextBoxVecchiaPW.TabIndex = 8;
            this.maskedTextBoxVecchiaPW.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxVecchiaPW_MaskInputRejected_1);
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.AutoSize = true;
            this.labelDescrizione.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDescrizione.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelDescrizione.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelDescrizione.Location = new System.Drawing.Point(3, 41);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(414, 60);
            this.labelDescrizione.TabIndex = 7;
            this.labelDescrizione.Text = "Benvenuto nella sezione dedicata al tuo profilo, qui potrai \r\nmodificare i tuoi d" +
    "ati personali, basterà solo inserire la nuova\r\ninformazione ove interessa.";
            this.labelDescrizione.Click += new System.EventHandler(this.labelDescrizione_Click);
            // 
            // labelChangePw
            // 
            this.labelChangePw.AutoSize = true;
            this.labelChangePw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelChangePw.ForeColor = System.Drawing.SystemColors.Control;
            this.labelChangePw.Location = new System.Drawing.Point(10, 295);
            this.labelChangePw.Name = "labelChangePw";
            this.labelChangePw.Size = new System.Drawing.Size(132, 20);
            this.labelChangePw.TabIndex = 6;
            this.labelChangePw.Text = "Change Password";
            this.labelChangePw.Click += new System.EventHandler(this.labelChangePw_Click);
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxSurname.Location = new System.Drawing.Point(103, 231);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(233, 27);
            this.textBoxSurname.TabIndex = 5;
            this.textBoxSurname.TextChanged += new System.EventHandler(this.textBoxSurname_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxName.Location = new System.Drawing.Point(103, 180);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(234, 27);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelProfloPrivato
            // 
            this.labelProfloPrivato.AutoSize = true;
            this.labelProfloPrivato.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProfloPrivato.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProfloPrivato.Location = new System.Drawing.Point(10, 9);
            this.labelProfloPrivato.Name = "labelProfloPrivato";
            this.labelProfloPrivato.Size = new System.Drawing.Size(153, 18);
            this.labelProfloPrivato.TabIndex = 2;
            this.labelProfloPrivato.Text = "Profilo Privato";
            this.labelProfloPrivato.Click += new System.EventHandler(this.labelProfloPrivato_Click);
            // 
            // buttonSalvaModifiche
            // 
            this.buttonSalvaModifiche.Location = new System.Drawing.Point(179, 264);
            this.buttonSalvaModifiche.Name = "buttonSalvaModifiche";
            this.buttonSalvaModifiche.Size = new System.Drawing.Size(94, 29);
            this.buttonSalvaModifiche.TabIndex = 1;
            this.buttonSalvaModifiche.Text = "Salva Modifiche";
            this.buttonSalvaModifiche.UseVisualStyleBackColor = true;
            this.buttonSalvaModifiche.Click += new System.EventHandler(this.buttonSalvaModifiche_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxEmail.Location = new System.Drawing.Point(103, 104);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(234, 27);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // buttonAccount
            // 
            this.buttonAccount.Location = new System.Drawing.Point(26, 65);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(94, 29);
            this.buttonAccount.TabIndex = 4;
            this.buttonAccount.Text = "Account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(26, 209);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.buttonVisulaCatalogue);
            this.panel3.Controls.Add(this.buttonHome);
            this.panel3.Controls.Add(this.buttonExit);
            this.panel3.Controls.Add(this.buttonAccount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(697, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(142, 487);
            this.panel3.TabIndex = 6;
            // 
            // buttonVisulaCatalogue
            // 
            this.buttonVisulaCatalogue.Location = new System.Drawing.Point(26, 131);
            this.buttonVisulaCatalogue.Name = "buttonVisulaCatalogue";
            this.buttonVisulaCatalogue.Size = new System.Drawing.Size(94, 57);
            this.buttonVisulaCatalogue.TabIndex = 6;
            this.buttonVisulaCatalogue.Text = "My Catalogue";
            this.buttonVisulaCatalogue.UseVisualStyleBackColor = true;
            this.buttonVisulaCatalogue.Click += new System.EventHandler(this.buttonVisulaCatalogue_Click);
            // 
            // Profilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(839, 487);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Profilo";
            this.Text = "Profilo";
            this.Load += new System.EventHandler(this.Profilo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSalvaModifiche;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelProfiloPubblico;
        private System.Windows.Forms.Label labelProfloPrivato;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelChangePw;
        private System.Windows.Forms.Label labelDescrizione;
        private System.Windows.Forms.Label labelDescrizionePW;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxVecchiaPW;
        private System.Windows.Forms.Button buttonConfermaPw;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxConfPW;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNewPw;
        private System.Windows.Forms.Label labelDescrizioneCancellaAcc;
        private System.Windows.Forms.TextBox textBoxAccDelete;
        private System.Windows.Forms.Label labelOldPw;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNewPw;
        private System.Windows.Forms.Label labelPW;
        private System.Windows.Forms.Button buttonSalvaEmail;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonVisulaCatalogue;
    }
}