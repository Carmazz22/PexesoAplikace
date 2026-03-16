namespace PEXESO.Forms
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKonec = new System.Windows.Forms.Button();
            this.btnNapoveda = new System.Windows.Forms.Button();
            this.btnNastaveni = new System.Windows.Forms.Button();
            this.btnTabulka = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnKonec);
            this.panel1.Controls.Add(this.btnNapoveda);
            this.panel1.Controls.Add(this.btnNastaveni);
            this.panel1.Controls.Add(this.btnTabulka);
            this.panel1.Controls.Add(this.btnLoadGame);
            this.panel1.Controls.Add(this.btnNewGame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 800);
            this.panel1.TabIndex = 0;
            // 
            // btnKonec
            // 
            this.btnKonec.BackColor = System.Drawing.Color.White;
            this.btnKonec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKonec.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKonec.Location = new System.Drawing.Point(260, 532);
            this.btnKonec.Name = "btnKonec";
            this.btnKonec.Size = new System.Drawing.Size(280, 80);
            this.btnKonec.TabIndex = 6;
            this.btnKonec.Text = "UKONČIT HRU";
            this.btnKonec.UseVisualStyleBackColor = false;
            this.btnKonec.Click += new System.EventHandler(this.btnKonec_Click);
            // 
            // btnNapoveda
            // 
            this.btnNapoveda.BackColor = System.Drawing.Color.White;
            this.btnNapoveda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNapoveda.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNapoveda.Location = new System.Drawing.Point(260, 443);
            this.btnNapoveda.Name = "btnNapoveda";
            this.btnNapoveda.Size = new System.Drawing.Size(280, 80);
            this.btnNapoveda.TabIndex = 5;
            this.btnNapoveda.Text = "NÁPOVĚDA";
            this.btnNapoveda.UseVisualStyleBackColor = false;
            this.btnNapoveda.Click += new System.EventHandler(this.btnNapoveda_Click);
            // 
            // btnNastaveni
            // 
            this.btnNastaveni.BackColor = System.Drawing.Color.White;
            this.btnNastaveni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNastaveni.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNastaveni.Location = new System.Drawing.Point(260, 357);
            this.btnNastaveni.Name = "btnNastaveni";
            this.btnNastaveni.Size = new System.Drawing.Size(280, 80);
            this.btnNastaveni.TabIndex = 4;
            this.btnNastaveni.Text = "NASTAVENÍ";
            this.btnNastaveni.UseVisualStyleBackColor = false;
            this.btnNastaveni.Click += new System.EventHandler(this.btnNastaveni_Click);
            // 
            // btnTabulka
            // 
            this.btnTabulka.BackColor = System.Drawing.Color.White;
            this.btnTabulka.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTabulka.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTabulka.Location = new System.Drawing.Point(260, 271);
            this.btnTabulka.Name = "btnTabulka";
            this.btnTabulka.Size = new System.Drawing.Size(280, 80);
            this.btnTabulka.TabIndex = 3;
            this.btnTabulka.Text = "TABULKA SKÓRE";
            this.btnTabulka.UseVisualStyleBackColor = false;
            this.btnTabulka.Click += new System.EventHandler(this.btnTabulka_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.BackColor = System.Drawing.Color.White;
            this.btnLoadGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadGame.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoadGame.Location = new System.Drawing.Point(260, 185);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(280, 80);
            this.btnLoadGame.TabIndex = 2;
            this.btnLoadGame.Text = "NAČÍST HRU";
            this.btnLoadGame.UseVisualStyleBackColor = false;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.White;
            this.btnNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewGame.Font = new System.Drawing.Font("Carlito", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewGame.Location = new System.Drawing.Point(260, 99);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(280, 80);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "NOVÁ HRA";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "PEXESO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PEXESO.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnNapoveda;
        private System.Windows.Forms.Button btnNastaveni;
        private System.Windows.Forms.Button btnTabulka;
        private System.Windows.Forms.Button btnKonec;
    }
}