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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        string cestaNastaveni = @"..\..\Config\settings.dat";
        private void Menu_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);
            
           
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

        }
        



        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.PlayerNames());
                main.prehratZvuk(0);
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.LoadGame());
                main.prehratZvuk(0);
            }
        }

        private void btnTabulka_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Score());
                main.prehratZvuk(0);
            }
        }

        private void btnNastaveni_Click(object sender, EventArgs e)
        {
            
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Settings());
                main.prehratZvuk(0);
            }
        }

        private void btnNapoveda_Click(object sender, EventArgs e)
        {

            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Tutorial());
                main.prehratZvuk(0);
            }
        }

        private void btnKonec_Click(object sender, EventArgs e)
        {
            DialogResult dotazUkonceni = MessageBox.Show("Opravdu si přejete ukončit hru?", "Konec hry?", MessageBoxButtons.YesNo);
            if (dotazUkonceni == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
