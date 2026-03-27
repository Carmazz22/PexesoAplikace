namespace PEXESO.Forms
{
    partial class PlayerNames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerNames));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSeznamHracu = new System.Windows.Forms.Panel();
            this.btnDoMenu = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panelSeznamHracu);
            this.panel1.Controls.Add(this.btnDoMenu);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 550);
            this.panel1.TabIndex = 1;
            // 
            // panelSeznamHracu
            // 
            this.panelSeznamHracu.BackColor = System.Drawing.Color.Transparent;
            this.panelSeznamHracu.Location = new System.Drawing.Point(250, 139);
            this.panelSeznamHracu.Name = "panelSeznamHracu";
            this.panelSeznamHracu.Size = new System.Drawing.Size(300, 400);
            this.panelSeznamHracu.TabIndex = 15;
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
            this.btnDoMenu.TabIndex = 14;
            this.btnDoMenu.Tag = "A";
            this.btnDoMenu.UseVisualStyleBackColor = false;
            this.btnDoMenu.Click += new System.EventHandler(this.btnDoMenu_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.Font = new System.Drawing.Font("Roboto Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(200, 96);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitle.Size = new System.Drawing.Size(400, 40);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "zadejte hráčská jména";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(200, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 78);
            this.label1.TabIndex = 4;
            this.label1.Text = "PEXESO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PEXESO.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayerNames";
            this.Text = "Jména hráčů";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PlayerNames_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoMenu;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSeznamHracu;
    }
}