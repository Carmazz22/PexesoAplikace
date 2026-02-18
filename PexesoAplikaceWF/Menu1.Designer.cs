namespace PexesoAplikaceWF
{
    partial class Menu1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_newGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.button_score = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_newGame
            // 
            this.button_newGame.BackColor = System.Drawing.Color.SteelBlue;
            this.button_newGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_newGame.Font = new System.Drawing.Font("OpenSymbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_newGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_newGame.Location = new System.Drawing.Point(263, 74);
            this.button_newGame.Name = "button_newGame";
            this.button_newGame.Size = new System.Drawing.Size(250, 74);
            this.button_newGame.TabIndex = 0;
            this.button_newGame.Text = "Nová hra";
            this.button_newGame.UseVisualStyleBackColor = false;
            this.button_newGame.Click += new System.EventHandler(this.button_newGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("OpenSymbol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "PEXESO";
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.Color.SteelBlue;
            this.button_load.Font = new System.Drawing.Font("OpenSymbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_load.Location = new System.Drawing.Point(263, 154);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(250, 74);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "Otevřít hru";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_score
            // 
            this.button_score.BackColor = System.Drawing.Color.SteelBlue;
            this.button_score.Font = new System.Drawing.Font("OpenSymbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_score.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_score.Location = new System.Drawing.Point(263, 234);
            this.button_score.Name = "button_score";
            this.button_score.Size = new System.Drawing.Size(250, 74);
            this.button_score.TabIndex = 3;
            this.button_score.Text = "Skóre";
            this.button_score.UseVisualStyleBackColor = false;
            this.button_score.Click += new System.EventHandler(this.button_score_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.SteelBlue;
            this.button_exit.Font = new System.Drawing.Font("OpenSymbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_exit.Location = new System.Drawing.Point(263, 387);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(250, 74);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Konec";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_settings
            // 
            this.button_settings.BackColor = System.Drawing.Color.SteelBlue;
            this.button_settings.Font = new System.Drawing.Font("OpenSymbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_settings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_settings.Location = new System.Drawing.Point(263, 313);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(250, 74);
            this.button_settings.TabIndex = 5;
            this.button_settings.Text = "Nastavení";
            this.button_settings.UseVisualStyleBackColor = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::PexesoAplikaceWF.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_score);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_newGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu1";
            this.Text = "PEXESO";
            this.Load += new System.EventHandler(this.Menu1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_newGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_score;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_settings;
    }
}

