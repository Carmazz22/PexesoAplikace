namespace PexesoAplikaceWF
{
    partial class Score
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
            this.button_return = new System.Windows.Forms.Button();
            this.panelScore = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_return
            // 
            this.button_return.Location = new System.Drawing.Point(708, 526);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(75, 23);
            this.button_return.TabIndex = 0;
            this.button_return.Text = "Zpět";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.button_return_Click);
            // 
            // panelScore
            // 
            this.panelScore.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelScore.Location = new System.Drawing.Point(12, 12);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(305, 304);
            this.panelScore.TabIndex = 1;
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelScore);
            this.Controls.Add(this.button_return);
            this.MaximizeBox = false;
            this.Name = "Score";
            this.Text = "Skóre";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Panel panelScore;
    }
}