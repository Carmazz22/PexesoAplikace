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
        //napodobit ostatní formy

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFiltr = new System.Windows.Forms.Label();
            this.btnFiltrovat = new System.Windows.Forms.Button();
            this.checkBoxRazeni = new System.Windows.Forms.CheckBox();
            this.comboBoxFiltr = new System.Windows.Forms.ComboBox();
            this.dataGridViewSkore = new System.Windows.Forms.DataGridView();
            this.SloupecJmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecVyhry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecProhry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SloupecKarty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoMenu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkore)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelFiltr);
            this.panel1.Controls.Add(this.btnFiltrovat);
            this.panel1.Controls.Add(this.checkBoxRazeni);
            this.panel1.Controls.Add(this.comboBoxFiltr);
            this.panel1.Controls.Add(this.dataGridViewSkore);
            this.panel1.Controls.Add(this.btnDoMenu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 800);
            this.panel1.TabIndex = 0;
            // 
            // labelFiltr
            // 
            this.labelFiltr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFiltr.ForeColor = System.Drawing.Color.White;
            this.labelFiltr.Location = new System.Drawing.Point(100, 170);
            this.labelFiltr.Name = "labelFiltr";
            this.labelFiltr.Size = new System.Drawing.Size(120, 30);
            this.labelFiltr.TabIndex = 3;
            this.labelFiltr.Text = "Filtrovat podle:";
            this.labelFiltr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrovat
            // 
            this.btnFiltrovat.BackColor = System.Drawing.Color.White;
            this.btnFiltrovat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrovat.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFiltrovat.Location = new System.Drawing.Point(710, 165);
            this.btnFiltrovat.Name = "btnFiltrovat";
            this.btnFiltrovat.Size = new System.Drawing.Size(190, 40);
            this.btnFiltrovat.TabIndex = 6;
            this.btnFiltrovat.Text = "APLIKOVAT FILTR";
            this.btnFiltrovat.UseVisualStyleBackColor = false;
            this.btnFiltrovat.Click += new System.EventHandler(this.btnFiltrovat_Click);
            // 
            // checkBoxRazeni
            // 
            this.checkBoxRazeni.Checked = true;
            this.checkBoxRazeni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRazeni.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxRazeni.ForeColor = System.Drawing.Color.White;
            this.checkBoxRazeni.Location = new System.Drawing.Point(440, 170);
            this.checkBoxRazeni.Name = "checkBoxRazeni";
            this.checkBoxRazeni.Size = new System.Drawing.Size(260, 30);
            this.checkBoxRazeni.TabIndex = 5;
            this.checkBoxRazeni.Text = "Od nejmenšího po největší";
            this.checkBoxRazeni.UseVisualStyleBackColor = true;
            // 
            // comboBoxFiltr
            // 
            this.comboBoxFiltr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltr.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxFiltr.FormattingEnabled = true;
            this.comboBoxFiltr.Location = new System.Drawing.Point(220, 170);
            this.comboBoxFiltr.Name = "comboBoxFiltr";
            this.comboBoxFiltr.Size = new System.Drawing.Size(200, 27);
            this.comboBoxFiltr.TabIndex = 4;
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
            this.dataGridViewSkore.Location = new System.Drawing.Point(100, 220);
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
            this.btnDoMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoMenu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDoMenu.Location = new System.Drawing.Point(350, 650);
            this.btnDoMenu.Name = "btnDoMenu";
            this.btnDoMenu.Size = new System.Drawing.Size(300, 50);
            this.btnDoMenu.TabIndex = 8;
            this.btnDoMenu.Text = "ZPĚT DO MENU";
            this.btnDoMenu.UseVisualStyleBackColor = false;
            this.btnDoMenu.Click += new System.EventHandler(this.btnDoMenu_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(350, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "SKÓRE HRÁČŮ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(350, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "PEXESO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Text = "Score";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Score_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSkore;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecJmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecVyhry;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecProhry;
        private System.Windows.Forms.DataGridViewTextBoxColumn SloupecKarty;
        private System.Windows.Forms.ComboBox comboBoxFiltr;
        private System.Windows.Forms.CheckBox checkBoxRazeni;
        private System.Windows.Forms.Button btnFiltrovat;
        private System.Windows.Forms.Label labelFiltr;
    }
}