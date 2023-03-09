
namespace ProgettoAPL
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelInfoUtente = new System.Windows.Forms.Panel();
            this.buttonVisulaCatalogue = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonProfilo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelInfoUtente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(26, 233);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelInfoUtente
            // 
            this.panelInfoUtente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelInfoUtente.BackgroundImage")));
            this.panelInfoUtente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInfoUtente.Controls.Add(this.buttonVisulaCatalogue);
            this.panelInfoUtente.Controls.Add(this.buttonAccount);
            this.panelInfoUtente.Controls.Add(this.buttonProfilo);
            this.panelInfoUtente.Controls.Add(this.buttonExit);
            this.panelInfoUtente.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInfoUtente.Location = new System.Drawing.Point(690, 0);
            this.panelInfoUtente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelInfoUtente.Name = "panelInfoUtente";
            this.panelInfoUtente.Size = new System.Drawing.Size(146, 572);
            this.panelInfoUtente.TabIndex = 2;
            // 
            // buttonVisulaCatalogue
            // 
            this.buttonVisulaCatalogue.Location = new System.Drawing.Point(26, 134);
            this.buttonVisulaCatalogue.Name = "buttonVisulaCatalogue";
            this.buttonVisulaCatalogue.Size = new System.Drawing.Size(94, 57);
            this.buttonVisulaCatalogue.TabIndex = 4;
            this.buttonVisulaCatalogue.Text = "My Catalogue";
            this.buttonVisulaCatalogue.UseVisualStyleBackColor = true;
            this.buttonVisulaCatalogue.Click += new System.EventHandler(this.buttonVisulaCatalogue_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.Location = new System.Drawing.Point(26, 73);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(94, 29);
            this.buttonAccount.TabIndex = 3;
            this.buttonAccount.Text = "Account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonProfilo
            // 
            this.buttonProfilo.Location = new System.Drawing.Point(26, 17);
            this.buttonProfilo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProfilo.Name = "buttonProfilo";
            this.buttonProfilo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonProfilo.Size = new System.Drawing.Size(94, 29);
            this.buttonProfilo.TabIndex = 2;
            this.buttonProfilo.Text = "Settings";
            this.buttonProfilo.UseVisualStyleBackColor = true;
            this.buttonProfilo.Click += new System.EventHandler(this.buttonProfilo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.pictureBoxSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 54);
            this.panel1.TabIndex = 3;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWelcome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelWelcome.Location = new System.Drawing.Point(16, 13);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(70, 26);
            this.labelWelcome.TabIndex = 6;
            this.labelWelcome.Text = "label";
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(593, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(80, 29);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.BackgroundImage")));
            this.pictureBoxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSearch.InitialImage = null;
            this.pictureBoxSearch.Location = new System.Drawing.Point(358, 5);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(42, 43);
            this.pictureBoxSearch.TabIndex = 4;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBoxSearch.Location = new System.Drawing.Point(406, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(182, 27);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.UseWaitCursor = true;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(836, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelInfoUtente);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelInfoUtente.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelInfoUtente;
        private System.Windows.Forms.Button buttonProfilo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonVisulaCatalogue;
    }
}