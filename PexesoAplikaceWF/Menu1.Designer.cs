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
            this.button_multi = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_newGame
            // 
            this.button_newGame.Location = new System.Drawing.Point(275, 51);
            this.button_newGame.Name = "button_newGame";
            this.button_newGame.Size = new System.Drawing.Size(161, 74);
            this.button_newGame.TabIndex = 0;
            this.button_newGame.Text = "Nová hra";
            this.button_newGame.UseVisualStyleBackColor = true;
            this.button_newGame.Click += new System.EventHandler(this.button_newGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "PEXESO";
            // 
            // button_multi
            // 
            this.button_multi.Location = new System.Drawing.Point(275, 131);
            this.button_multi.Name = "button_multi";
            this.button_multi.Size = new System.Drawing.Size(161, 74);
            this.button_multi.TabIndex = 2;
            this.button_multi.Text = "Otevřít hru";
            this.button_multi.UseVisualStyleBackColor = true;
            // 
            // button_settings
            // 
            this.button_settings.Location = new System.Drawing.Point(275, 211);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(161, 74);
            this.button_settings.TabIndex = 3;
            this.button_settings.Text = "Skóre";
            this.button_settings.UseVisualStyleBackColor = true;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(275, 364);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(161, 74);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Konec";
            this.button_exit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 74);
            this.button1.TabIndex = 5;
            this.button1.Text = "Nastavení";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.button_multi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_newGame);
            this.Name = "Menu1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_newGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_multi;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button1;
    }
}

