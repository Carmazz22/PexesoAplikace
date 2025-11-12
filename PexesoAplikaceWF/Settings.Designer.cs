namespace PexesoAplikaceWF
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
            this.label1 = new System.Windows.Forms.Label();
            this.combo_pocet_hracu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_zvuk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_dif = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_pocet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_vzhled = new System.Windows.Forms.ComboBox();
            this.button_return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Počet hráčů";
            // 
            // combo_pocet_hracu
            // 
            this.combo_pocet_hracu.ForeColor = System.Drawing.Color.Black;
            this.combo_pocet_hracu.FormattingEnabled = true;
            this.combo_pocet_hracu.Items.AddRange(new object[] {
            "1 hráč(proti AI)",
            "2 hráči",
            "3 hráči",
            "4 hráči ",
            "5 hráčů",
            "6 hráčů"});
            this.combo_pocet_hracu.Location = new System.Drawing.Point(80, 6);
            this.combo_pocet_hracu.Name = "combo_pocet_hracu";
            this.combo_pocet_hracu.Size = new System.Drawing.Size(121, 21);
            this.combo_pocet_hracu.TabIndex = 3;
            this.combo_pocet_hracu.Text = "1 hráč (proti AI)";
            this.combo_pocet_hracu.SelectedIndexChanged += new System.EventHandler(this.combo_pocet_hracu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zvuk";
            // 
            // combo_zvuk
            // 
            this.combo_zvuk.ForeColor = System.Drawing.Color.Black;
            this.combo_zvuk.FormattingEnabled = true;
            this.combo_zvuk.Items.AddRange(new object[] {
            "zapnuto",
            "vypnuto"});
            this.combo_zvuk.Location = new System.Drawing.Point(80, 33);
            this.combo_zvuk.Name = "combo_zvuk";
            this.combo_zvuk.Size = new System.Drawing.Size(121, 21);
            this.combo_zvuk.TabIndex = 7;
            this.combo_zvuk.Text = "zapnuto";
            this.combo_zvuk.SelectedIndexChanged += new System.EventHandler(this.combo_zvuk_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Obtížnost AI";
            // 
            // combo_dif
            // 
            this.combo_dif.ForeColor = System.Drawing.Color.Black;
            this.combo_dif.FormattingEnabled = true;
            this.combo_dif.Items.AddRange(new object[] {
            "lehká",
            "normální",
            "těžká"});
            this.combo_dif.Location = new System.Drawing.Point(84, 60);
            this.combo_dif.Name = "combo_dif";
            this.combo_dif.Size = new System.Drawing.Size(121, 21);
            this.combo_dif.TabIndex = 9;
            this.combo_dif.Text = "lehká";
            this.combo_dif.SelectedIndexChanged += new System.EventHandler(this.combo_dif_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(11, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Počet karet";
            // 
            // combo_pocet
            // 
            this.combo_pocet.ForeColor = System.Drawing.Color.Black;
            this.combo_pocet.FormattingEnabled = true;
            this.combo_pocet.Items.AddRange(new object[] {
            "30",
            "45",
            "51"});
            this.combo_pocet.Location = new System.Drawing.Point(84, 92);
            this.combo_pocet.Name = "combo_pocet";
            this.combo_pocet.Size = new System.Drawing.Size(121, 21);
            this.combo_pocet.TabIndex = 11;
            this.combo_pocet.Text = "30";
            this.combo_pocet.SelectedIndexChanged += new System.EventHandler(this.combo_pocet_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vzhled kartiček";
            // 
            // combo_vzhled
            // 
            this.combo_vzhled.ForeColor = System.Drawing.Color.Black;
            this.combo_vzhled.FormattingEnabled = true;
            this.combo_vzhled.Items.AddRange(new object[] {
            "tmp_1",
            "tmp_2",
            "tmp_3"});
            this.combo_vzhled.Location = new System.Drawing.Point(97, 123);
            this.combo_vzhled.Name = "combo_vzhled";
            this.combo_vzhled.Size = new System.Drawing.Size(121, 21);
            this.combo_vzhled.TabIndex = 13;
            this.combo_vzhled.Text = "tmp_1";
            this.combo_vzhled.SelectedIndexChanged += new System.EventHandler(this.combo_vzhled_SelectedIndexChanged);
            // 
            // button_return
            // 
            this.button_return.ForeColor = System.Drawing.Color.Black;
            this.button_return.Location = new System.Drawing.Point(713, 415);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(75, 23);
            this.button_return.TabIndex = 14;
            this.button_return.Text = "Zpátky do menu";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.button_return_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_return);
            this.Controls.Add(this.combo_vzhled);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_pocet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combo_dif);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_zvuk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_pocet_hracu);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_pocet_hracu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_zvuk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_dif;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_pocet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_vzhled;
        private System.Windows.Forms.Button button_return;
    }
}