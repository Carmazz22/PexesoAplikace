namespace PEXESO.Forms
{
    partial class Score
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
            this.labelHledat = new System.Windows.Forms.Label();
            this.textBoxHledat = new System.Windows.Forms.TextBox();
            this.labelFiltr = new System.Windows.Forms.Label();
            this.comboBoxFiltr = new System.Windows.Forms.ComboBox();
            this.dataGridViewSkore = new System.Windows.Forms.DataGridView();
            this.SloupecJmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecVyhry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecProhry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecKarty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkore)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelHledat);
            this.panel1.Controls.Add(this.textBoxHledat);
            this.panel1.Controls.Add(this.labelFiltr);
            this.panel1.Controls.Add(this.comboBoxFiltr);
            this.panel1.Controls.Add(this.dataGridViewSkore);
            this.panel1.Controls.Add(this.btnDoMenu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 800);
            this.panel1.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.Font = new System.Drawing.Font("Roboto Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(300, 96);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitle.Size = new System.Drawing.Size(400, 40);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Skóre";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(300, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 78);
            this.label2.TabIndex = 9;
            this.label2.Text = "PEXESO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHledat
            // 
            this.labelHledat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHledat.ForeColor = System.Drawing.Color.Black;
            this.labelHledat.Location = new System.Drawing.Point(100, 150);
            this.labelHledat.Name = "labelHledat";
            this.labelHledat.Size = new System.Drawing.Size(120, 30);
            this.labelHledat.TabIndex = 11;
            this.labelHledat.Text = "Vyhledat:";
            this.labelHledat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxHledat
            // 
            this.textBoxHledat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHledat.Location = new System.Drawing.Point(220, 150);
            this.textBoxHledat.Name = "textBoxHledat";
            this.textBoxHledat.Size = new System.Drawing.Size(200, 27);
            this.textBoxHledat.TabIndex = 12;
            this.textBoxHledat.TextChanged += new System.EventHandler(this.textBoxHledat_TextChanged);
            // 
            // labelFiltr
            // 
            this.labelFiltr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFiltr.ForeColor = System.Drawing.Color.Black;
            this.labelFiltr.Location = new System.Drawing.Point(100, 190);
            this.labelFiltr.Name = "labelFiltr";
            this.labelFiltr.Size = new System.Drawing.Size(120, 30);
            this.labelFiltr.TabIndex = 3;
            this.labelFiltr.Text = "Filtrovat podle:";
            this.labelFiltr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFiltr
            // 
            this.comboBoxFiltr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxFiltr.FormattingEnabled = true;
            this.comboBoxFiltr.Location = new System.Drawing.Point(220, 190);
            this.comboBoxFiltr.Name = "comboBoxFiltr";
            this.comboBoxFiltr.Size = new System.Drawing.Size(200, 27);
            this.comboBoxFiltr.TabIndex = 4;
            this.comboBoxFiltr.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltr_SelectedIndexChanged);
            // 
            // dataGridViewSkore
            // 
            this.dataGridViewSkore.AllowUserToAddRows = false;
            this.dataGridViewSkore.AllowUserToDeleteRows = false;
            this.dataGridViewSkore.AllowUserToResizeColumns = false;
            this.dataGridViewSkore.AllowUserToResizeRows = false;
            this.dataGridViewSkore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSkore.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSkore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SloupecJmeno,
            this.SloupecVyhry,
            this.SloupecProhry,
            this.SloupecKarty});
            this.dataGridViewSkore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSkore.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridViewSkore.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewSkore.Location = new System.Drawing.Point(100, 240);
            this.dataGridViewSkore.Name = "dataGridViewSkore";
            this.dataGridViewSkore.ReadOnly = true;
            this.dataGridViewSkore.RowHeadersVisible = false;
            this.dataGridViewSkore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSkore.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewSkore.TabIndex = 7;
            // 
            // SloupecJmeno
            // 
            this.SloupecJmeno.HeaderText = "Jméno hráče";
            this.SloupecJmeno.Name = "SloupecJmeno";
            this.SloupecJmeno.ReadOnly = true;
            // 
            // SloupecVyhry
            // 
            this.SloupecVyhry.HeaderText = "Počet výher";
            this.SloupecVyhry.Name = "SloupecVyhry";
            this.SloupecVyhry.ReadOnly = true;
            // 
            // SloupecProhry
            // 
            this.SloupecProhry.HeaderText = "Počet proher";
            this.SloupecProhry.Name = "SloupecProhry";
            this.SloupecProhry.ReadOnly = true;
            // 
            // SloupecKarty
            // 
            this.SloupecKarty.HeaderText = "Nasbírané karty";
            this.SloupecKarty.Name = "SloupecKarty";
            this.SloupecKarty.ReadOnly = true;
            // 
            // btnDoMenu
            // 
            this.btnDoMenu.BackColor = System.Drawing.Color.White;
            this.btnDoMenu.BackgroundImage = global::PEXESO.Properties.Resources.menu_sipka;
            this.btnDoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoMenu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDoMenu.Location = new System.Drawing.Point(900, 0);
            this.btnDoMenu.Name = "btnDoMenu";
            this.btnDoMenu.Size = new System.Drawing.Size(100, 100);
            this.btnDoMenu.TabIndex = 8;
            this.btnDoMenu.Tag = "A";
            this.btnDoMenu.UseVisualStyleBackColor = false;
            this.btnDoMenu.Click += new System.EventHandler(this.btnDoMenu_Click);
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PEXESO.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Name = "Score";
            this.Text = "á";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Score_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoMenu;
        private System.Windows.Forms.DataGridView dataGridViewSkore;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecJmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecVyhry;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecProhry;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecKarty;
        private System.Windows.Forms.ComboBox comboBoxFiltr;
        private System.Windows.Forms.Label labelFiltr;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHledat;
        private System.Windows.Forms.TextBox textBoxHledat;
    }
}