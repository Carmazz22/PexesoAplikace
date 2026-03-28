using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    public partial class Endgame : Form
    {
        int[] poleProSkoreHracu;
        List<string> listHracu;
        byte barvy;

        public Endgame(List<string> Hraci, int[] skoreHracu, byte rezimBarev)
        {
            this.poleProSkoreHracu = skoreHracu;
            this.listHracu = Hraci;
            this.barvy = rezimBarev;
            InitializeComponent();
        }

        private void Endgame_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            if (barvy == 0)
            {
                this.BackColor = Color.White;
                this.BackgroundImage = null;
                labelTitle.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
            else if (barvy == 1)
            {
                this.BackColor = Color.Black;
                this.BackgroundImage = null;
                labelTitle.ForeColor = Color.White;
                label2.ForeColor = Color.White;
            }

            int maxSkore = -1;
            for (int i = 0; i < poleProSkoreHracu.Length; i++)
            {
                if (poleProSkoreHracu[i] > maxSkore)
                {
                    maxSkore = poleProSkoreHracu[i];
                }
            }

            int poziceY = 20;

            for (int i = 0; i < listHracu.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Hráč: " + listHracu[i] + "; skóre: " + poleProSkoreHracu[i];
                lbl.Font = new Font("Roboto", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Location = new Point(20, poziceY);

                if (poleProSkoreHracu[i] == maxSkore)
                {
                    lbl.ForeColor = Color.Green;
                }
                else if (barvy == 0)
                {
                    lbl.ForeColor = Color.Black;
                }
                else if (barvy == 1)
                {
                    lbl.ForeColor = Color.White;
                }

                panelVysledky.Controls.Add(lbl);

                poziceY = poziceY + 40;
            }

            Button btnMenu = new Button();
            btnMenu.Text = "Odejít do menu";
            btnMenu.Size = new Size(240, 50);

            int poziceX = (panelVysledky.Width - btnMenu.Width) / 2;
            btnMenu.Location = new Point(poziceX, poziceY + 20);

            btnMenu.Font = new Font("Roboto", 12, FontStyle.Bold);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 2;
            btnMenu.DialogResult = DialogResult.OK;

            if (barvy == 0)
            {
                btnMenu.BackColor = Color.FromArgb(245, 245, 245);
                btnMenu.ForeColor = Color.Black;
                btnMenu.FlatAppearance.BorderColor = Color.Black;
            }
            else if (barvy == 1)
            {
                btnMenu.BackColor = Color.Black;
                btnMenu.ForeColor = Color.White;
                btnMenu.FlatAppearance.BorderColor = Color.White;
            }

            panelVysledky.Controls.Add(btnMenu);
        }
    }
}