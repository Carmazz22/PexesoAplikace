using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    public partial class Score : Form
    {
        string cestaHistorie = @"..\..\Config\history.dat";
        List<ZaznamHrace> hraciSkore = new List<ZaznamHrace>();

        public Score()
        {
            InitializeComponent();
        }

        private void Score_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            comboBoxFiltr.Items.Add("Jméno");
            comboBoxFiltr.Items.Add("Výhry");
            comboBoxFiltr.Items.Add("Prohry");
            comboBoxFiltr.Items.Add("Nasbírané karty");

            comboBoxFiltr.SelectedIndex = 0;

            NactiHistorii();
            AktualizujTabulku();
        }

        private void NactiHistorii()
        {
            if (File.Exists(cestaHistorie))
            {
                FileStream fs = new FileStream(cestaHistorie, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                if (fs.Length > 0)
                {
                    int pocetZaznamu = br.ReadInt32();

                    for (int i = 0; i < pocetZaznamu; i++)
                    {
                        ZaznamHrace hrac = new ZaznamHrace();
                        hrac.Jmeno = br.ReadString();
                        hrac.Vyhry = br.ReadInt32();
                        hrac.Prohry = br.ReadInt32();
                        hrac.NasbiraneKarty = br.ReadInt32();

                        hraciSkore.Add(hrac);
                    }
                }

                br.Close();
                fs.Close();
            }
        }

        private void textBoxHledat_TextChanged(object sender, EventArgs e)
        {
            AktualizujTabulku();
        }

        private void comboBoxFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizujTabulku();
        }

        private void AktualizujTabulku()
        {
            dataGridViewSkore.Rows.Clear();

            string hledanyText = "";
            if (textBoxHledat != null && textBoxHledat.Text != null)
            {
                hledanyText = textBoxHledat.Text.ToLower();
            }

            string zvolenyFiltr = "";
            if (comboBoxFiltr.SelectedItem != null)
            {
                zvolenyFiltr = comboBoxFiltr.SelectedItem.ToString();
            }

            for (int i = 0; i < hraciSkore.Count; i++)
            {
                bool shoda = false;

                if (hledanyText == "")
                {
                    shoda = true;
                }
                else
                {
                    if (zvolenyFiltr == "Jméno")
                    {
                        if (hraciSkore[i].Jmeno.ToLower().Contains(hledanyText))
                        {
                            shoda = true;
                        }
                    }
                    else if (zvolenyFiltr == "Výhry")
                    {
                        if (hraciSkore[i].Vyhry.ToString().Contains(hledanyText))
                        {
                            shoda = true;
                        }
                    }
                    else if (zvolenyFiltr == "Prohry")
                    {
                        if (hraciSkore[i].Prohry.ToString().Contains(hledanyText))
                        {
                            shoda = true;
                        }
                    }
                    else if (zvolenyFiltr == "Nasbírané karty")
                    {
                        if (hraciSkore[i].NasbiraneKarty.ToString().Contains(hledanyText))
                        {
                            shoda = true;
                        }
                    }
                }

                if (shoda)
                {
                    dataGridViewSkore.Rows.Add(
                        hraciSkore[i].Jmeno,
                        hraciSkore[i].Vyhry,
                        hraciSkore[i].Prohry,
                        hraciSkore[i].NasbiraneKarty
                    );
                }
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

    public class ZaznamHrace
    {
        public string Jmeno;
        public int Vyhry;
        public int Prohry;
        public int NasbiraneKarty;
    }
}