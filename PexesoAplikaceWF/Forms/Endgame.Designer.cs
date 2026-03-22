namespace PEXESO.Forms
{
    partial class Endgame
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelVysledky = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelVysledky);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 800);
            this.panel1.TabIndex = 0;

            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.Font = new System.Drawing.Font("Roboto Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(150, 96);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitle.Size = new System.Drawing.Size(400, 40);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = "Skóre";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(150, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 78);
            this.label2.TabIndex = 11;
            this.label2.Text = "PEXESO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelVysledky.Location = new System.Drawing.Point(100, 139);
            this.panelVysledky.Name = "panelVysledky";
            this.panelVysledky.Size = new System.Drawing.Size(500, 526);
            this.panelVysledky.TabIndex = 13;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Endgame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Endgame";
            this.Load += new System.EventHandler(this.Endgame_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelVysledky;
    }
}