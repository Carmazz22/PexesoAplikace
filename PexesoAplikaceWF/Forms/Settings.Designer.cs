namespace PEXESO.Forms
{
    partial class Settings
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPocetHracu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboZvuky = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboAI = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboVzhled = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboPocetKaret = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBarvy = new System.Windows.Forms.ComboBox();
            this.btnDoMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboPocetHracu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboZvuky);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboAI);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboVzhled);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboPocetKaret);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBarvy);
            this.panel1.Controls.Add(this.btnDoMenu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 800);
            this.panel1.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.Font = new System.Drawing.Font("Roboto Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(200, 96);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitle.Size = new System.Drawing.Size(400, 40);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Nastavení";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.Font = new System.Drawing.Font("Roboto Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(200, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(400, 78);
            this.label10.TabIndex = 15;
            this.label10.Text = "PEXESO";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(220, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "Počet hráčů";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboPocetHracu
            // 
            this.comboPocetHracu.BackColor = System.Drawing.Color.SteelBlue;
            this.comboPocetHracu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPocetHracu.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboPocetHracu.ForeColor = System.Drawing.Color.Black;
            this.comboPocetHracu.FormattingEnabled = true;
            this.comboPocetHracu.Items.AddRange(new object[] {
            "1 hráč (Hra proti AI)",
            "2 hráči",
            "3 hráči",
            "4 hráči",
            "5 hráčů"});
            this.comboPocetHracu.Location = new System.Drawing.Point(390, 186);
            this.comboPocetHracu.Name = "comboPocetHracu";
            this.comboPocetHracu.Size = new System.Drawing.Size(151, 23);
            this.comboPocetHracu.TabIndex = 2;
            this.comboPocetHracu.SelectedIndexChanged += new System.EventHandler(this.comboPocetHracu_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(220, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "Zvuky";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboZvuky
            // 
            this.comboZvuky.BackColor = System.Drawing.Color.SteelBlue;
            this.comboZvuky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboZvuky.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboZvuky.ForeColor = System.Drawing.Color.Black;
            this.comboZvuky.FormattingEnabled = true;
            this.comboZvuky.Items.AddRange(new object[] {
            "Ano",
            "Ne"});
            this.comboZvuky.Location = new System.Drawing.Point(390, 236);
            this.comboZvuky.Name = "comboZvuky";
            this.comboZvuky.Size = new System.Drawing.Size(151, 23);
            this.comboZvuky.TabIndex = 4;
            this.comboZvuky.SelectedIndexChanged += new System.EventHandler(this.comboZvuky_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(220, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 34);
            this.label6.TabIndex = 7;
            this.label6.Text = "Obtížnost AI";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboAI
            // 
            this.comboAI.BackColor = System.Drawing.Color.SteelBlue;
            this.comboAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAI.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboAI.ForeColor = System.Drawing.Color.Black;
            this.comboAI.FormattingEnabled = true;
            this.comboAI.Items.AddRange(new object[] {
            "Lehká",
            "Normální",
            "Těžká"});
            this.comboAI.Location = new System.Drawing.Point(390, 286);
            this.comboAI.Name = "comboAI";
            this.comboAI.Size = new System.Drawing.Size(151, 23);
            this.comboAI.TabIndex = 6;
            this.comboAI.SelectedIndexChanged += new System.EventHandler(this.comboAI_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("Carlito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(220, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 34);
            this.label7.TabIndex = 9;
            this.label7.Text = "Vzhled karet";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboVzhled
            // 
            this.comboVzhled.BackColor = System.Drawing.Color.SteelBlue;
            this.comboVzhled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVzhled.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboVzhled.ForeColor = System.Drawing.Color.Black;
            this.comboVzhled.FormattingEnabled = true;
            this.comboVzhled.Items.AddRange(new object[] {
            "Barvy",
            "Zvířata",
            "Geometrické tvary"});
            this.comboVzhled.Location = new System.Drawing.Point(390, 336);
            this.comboVzhled.Name = "comboVzhled";
            this.comboVzhled.Size = new System.Drawing.Size(151, 23);
            this.comboVzhled.TabIndex = 8;
            this.comboVzhled.SelectedIndexChanged += new System.EventHandler(this.comboVzhled_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(220, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 34);
            this.label9.TabIndex = 14;
            this.label9.Text = "Počet karet";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboPocetKaret
            // 
            this.comboPocetKaret.BackColor = System.Drawing.Color.SteelBlue;
            this.comboPocetKaret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPocetKaret.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboPocetKaret.ForeColor = System.Drawing.Color.Black;
            this.comboPocetKaret.FormattingEnabled = true;
            this.comboPocetKaret.Items.AddRange(new object[] {
            "30",
            "45",
            "60"});
            this.comboPocetKaret.Location = new System.Drawing.Point(390, 386);
            this.comboPocetKaret.Name = "comboPocetKaret";
            this.comboPocetKaret.Size = new System.Drawing.Size(151, 23);
            this.comboPocetKaret.TabIndex = 13;
            this.comboPocetKaret.SelectedIndexChanged += new System.EventHandler(this.comboPocetKaret_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(220, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 34);
            this.label8.TabIndex = 11;
            this.label8.Text = "Barevný režim";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBarvy
            // 
            this.comboBarvy.BackColor = System.Drawing.Color.SteelBlue;
            this.comboBarvy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBarvy.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBarvy.ForeColor = System.Drawing.Color.Black;
            this.comboBarvy.FormattingEnabled = true;
            this.comboBarvy.Items.AddRange(new object[] {
            "Světlý",
            "Tmavý"});
            this.comboBarvy.Location = new System.Drawing.Point(390, 436);
            this.comboBarvy.Name = "comboBarvy";
            this.comboBarvy.Size = new System.Drawing.Size(151, 23);
            this.comboBarvy.TabIndex = 10;
            this.comboBarvy.SelectedIndexChanged += new System.EventHandler(this.comboBarvy_SelectedIndexChanged);
            // 
            // btnDoMenu
            // 
            this.btnDoMenu.BackColor = System.Drawing.Color.White;
            this.btnDoMenu.BackgroundImage = global::PEXESO.Properties.Resources.menu_sipka;
            this.btnDoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoMenu.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDoMenu.Location = new System.Drawing.Point(700, 0);
            this.btnDoMenu.Name = "btnDoMenu";
            this.btnDoMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDoMenu.Size = new System.Drawing.Size(100, 100);
            this.btnDoMenu.TabIndex = 12;
            this.btnDoMenu.Tag = "A";
            this.btnDoMenu.UseVisualStyleBackColor = false;
            this.btnDoMenu.Click += new System.EventHandler(this.btnDoMenu_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PEXESO.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Settings";
            this.Text = "Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboPocetHracu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBarvy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboVzhled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboAI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboZvuky;
        private System.Windows.Forms.Button btnDoMenu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboPocetKaret;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTitle;
    }
}