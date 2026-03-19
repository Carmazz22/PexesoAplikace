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

            
            comboBoxFiltr.SelectedIndex = 1;

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

        private void btnFiltrovat_Click(object sender, EventArgs e)
        {
            string zvolenyFiltr = comboBoxFiltr.SelectedItem.ToString();
            bool nejmensiPoNejvetsi = checkBoxRazeni.Checked;

            
            for (int i = 0; i < hraciSkore.Count - 1; i++)
            {
                for (int j = 0; j < hraciSkore.Count - i - 1; j++)
                {
                    bool prohodit = false;

                    
                    if (zvolenyFiltr == "Jméno")
                    {
                        int porovnani = string.Compare(hraciSkore[j].Jmeno, hraciSkore[j + 1].Jmeno);
                        if (nejmensiPoNejvetsi)
                        {
                            if (porovnani > 0) prohodit = true;
                        }
                        else
                        {
                            if (porovnani < 0) prohodit = true;
                        }
                    }
                    else if (zvolenyFiltr == "Výhry")
                    {
                        if (nejmensiPoNejvetsi)
                        {
                            if (hraciSkore[j].Vyhry > hraciSkore[j + 1].Vyhry) prohodit = true;
                        }
                        else
                        {
                            if (hraciSkore[j].Vyhry < hraciSkore[j + 1].Vyhry) prohodit = true;
                        }
                    }
                    else if (zvolenyFiltr == "Prohry")
                    {
                        if (nejmensiPoNejvetsi)
                        {
                            if (hraciSkore[j].Prohry > hraciSkore[j + 1].Prohry) prohodit = true;
                        }
                        else
                        {
                            if (hraciSkore[j].Prohry < hraciSkore[j + 1].Prohry) prohodit = true;
                        }
                    }
                    else if (zvolenyFiltr == "Nasbírané karty")
                    {
                        if (nejmensiPoNejvetsi)
                        {
                            if (hraciSkore[j].NasbiraneKarty > hraciSkore[j + 1].NasbiraneKarty) prohodit = true;
                        }
                        else
                        {
                            if (hraciSkore[j].NasbiraneKarty < hraciSkore[j + 1].NasbiraneKarty) prohodit = true;
                        }
                    }

                    
                    if (prohodit)
                    {
                        ZaznamHrace docasny = hraciSkore[j];
                        hraciSkore[j] = hraciSkore[j + 1];
                        hraciSkore[j + 1] = docasny;
                    }
                }
            }

            
            AktualizujTabulku();
        }

        private void AktualizujTabulku()
        {
            
            dataGridViewSkore.Rows.Clear();

            
            for (int i = 0; i < hraciSkore.Count; i++)
            {
                dataGridViewSkore.Rows.Add(
                    hraciSkore[i].Jmeno,
                    hraciSkore[i].Vyhry,
                    hraciSkore[i].Prohry,
                    hraciSkore[i].NasbiraneKarty
                );
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