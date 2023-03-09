
namespace ProgettoAPL
{
    partial class MyCatalogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyCatalogue));
            this.buttonProfilo = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProfilo
            // 
            this.buttonProfilo.Location = new System.Drawing.Point(16, 157);
            this.buttonProfilo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProfilo.Name = "buttonProfilo";
            this.buttonProfilo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonProfilo.Size = new System.Drawing.Size(94, 29);
            this.buttonProfilo.TabIndex = 25;
            this.buttonProfilo.Text = "Settings";
            this.buttonProfilo.UseVisualStyleBackColor = true;
            this.buttonProfilo.Click += new System.EventHandler(this.buttonProfilo_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.Location = new System.Drawing.Point(16, 94);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(94, 29);
            this.buttonAccount.TabIndex = 24;
            this.buttonAccount.Text = "Account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(16, 211);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 29);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(16, 30);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(94, 29);
            this.buttonHome.TabIndex = 22;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonHome);
            this.panel1.Controls.Add(this.buttonAccount);
            this.panel1.Controls.Add(this.buttonProfilo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(671, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 485);
            this.panel1.TabIndex = 26;
            // 
            // MyCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 485);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MyCatalogue";
            this.Text = "MyCatalogue";
            this.Load += new System.EventHandler(this.MyCatalogue_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProfilo;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel1;
    }
}