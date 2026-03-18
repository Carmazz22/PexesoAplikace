using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    public partial class PlayerNames : Form
    {
        string cestaNastaveni = @"..\..\Config\settings.dat";
        string cestaHraci = @"..\..\Config\seznamHracu.dat";

        int pocetHracu;
        public PlayerNames()
        {
            InitializeComponent();
        }

        private void PlayerNames_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            using (FileStream fs = new FileStream(cestaNastaveni, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                pocetHracu = br.ReadByte();

                if (pocetHracu == 1) labelTitle.Text = "Zadejte svoje hráčské jméno";
                int zacatekY = 20;
                int stredX = panelSeznamHracu.Width / 2;

                for (int i = 0; i < pocetHracu; i++)
                {
                    Label labelHrac = new Label();
                    labelHrac.Name = "labelHrac" + i;
                    labelHrac.Text = "Hráč " + (i + 1) + ":";
                    labelHrac.Font = new Font("Roboto", 12, FontStyle.Bold);

                    labelHrac.Size = new Size(80, 25);
                    labelHrac.TextAlign = ContentAlignment.MiddleRight;

                    TextBox textBoxHrac = new TextBox();
                    textBoxHrac.Name = "textBoxHrac" + i;
                    textBoxHrac.Width = 150;
                    textBoxHrac.Font = new Font("Roboto", 12, FontStyle.Regular);
                    textBoxHrac.Text = "Hráč " + (i + 1);

                    panelSeznamHracu.Controls.Add(labelHrac);
                    panelSeznamHracu.Controls.Add(textBoxHrac);

                    int startX = stredX - 120;

                    labelHrac.Location = new Point(startX, zacatekY + 3);
                    textBoxHrac.Location = new Point(startX + 90, zacatekY);

                    zacatekY += 50;
                }

                Button btnPotvrdit = new Button();
                btnPotvrdit.Name = "btnPotvrdit";
                btnPotvrdit.Text = "START HRY";
                btnPotvrdit.Size = new Size(200, 50);
                btnPotvrdit.Font = new Font("Roboto", 14, FontStyle.Bold);
                btnPotvrdit.BackColor = Color.White;
                btnPotvrdit.ForeColor = Color.Black;

                btnPotvrdit.Location = new Point(stredX - (btnPotvrdit.Width / 2), zacatekY + 20);

                btnPotvrdit.Click += new EventHandler(this.btnPotvrdit_Click);

                panelSeznamHracu.Controls.Add(btnPotvrdit);
            }
        }

        private void btnPotvrdit_Click(object sender, EventArgs e)
        {
            bool vsechnyTextBoxyOK = true;
            foreach (Control prvek in panelSeznamHracu.Controls)
            {
                
                if (prvek is TextBox)
                {
                    TextBox txt = (TextBox)prvek;

                    
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        vsechnyTextBoxyOK = false;
                    }
                }
            }
            if (this.Parent is PEXESO main && vsechnyTextBoxyOK)
            {
                main.prehratZvuk(0);
                using (FileStream fs = new FileStream(cestaHraci, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    foreach (Control prvek in panelSeznamHracu.Controls)
                    {
                        if (prvek is TextBox)
                        {
                            bw.Write(prvek.Text);
                        }
                    }
                }
                MessageBox.Show("Hra se spouští!");
                main.OtevreniFormu(new global::PEXESO.Forms.Game());

            }
        }

        private void btnDoMenu_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Menu());
                main.prehratZvuk(0);
            }
        }
    }
}