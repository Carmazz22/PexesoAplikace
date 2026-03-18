using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    // Třída pro uložení dat jednoho hráče načteného z databáze
    public class ZaznamHrace
    {
        public string Jmeno;
        public int Vyhry;
        public int Prohry;
        public int NasbiraneKarty;
    }

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
            // Vycentrování hlavního panelu na střed obrazovky
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            // Příprava možností do výběru filtru
            comboBoxFiltr.Items.Add("Jméno");
            comboBoxFiltr.Items.Add("Výhry");
            comboBoxFiltr.Items.Add("Prohry");
            comboBoxFiltr.Items.Add("Nasbírané karty");

            // Nastavení výchozí hodnoty pro combobox
            comboBoxFiltr.SelectedIndex = 1;

            NactiHistorii();
            AktualizujTabulku();
        }

        private void NactiHistorii()
        {
            // Zkontrolujeme, jestli databáze vůbec existuje
            if (File.Exists(cestaHistorie))
            {
                FileStream fs = new FileStream(cestaHistorie, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                // Zkontrolujeme, jestli soubor není prázdný
                if (fs.Length > 0)
                {
                    // Přečteme celkový počet uložených profilů hráčů
                    int pocetZaznamu = br.ReadInt32();

                    // V cyklu načteme všechny hráče přesně v tom pořadí, v jakém se zapsali v Game.cs
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

            // Klasický Bubble Sort pro seřazení bez použití zakázaného LINQu
            for (int i = 0; i < hraciSkore.Count - 1; i++)
            {
                for (int j = 0; j < hraciSkore.Count - i - 1; j++)
                {
                    bool prohodit = false;

                    // Rozhodování podle vybraného filtru
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

                    // Fyzické prohození prvků v seznamu
                    if (prohodit)
                    {
                        ZaznamHrace docasny = hraciSkore[j];
                        hraciSkore[j] = hraciSkore[j + 1];
                        hraciSkore[j + 1] = docasny;
                    }
                }
            }

            // Aplikování nového pořadí do tabulky na obrazovce
            AktualizujTabulku();
        }

        private void AktualizujTabulku()
        {
            // Promažeme staré zobrazení
            dataGridViewSkore.Rows.Clear();

            // Vypíšeme celý seznam znovu v aktuálním pořadí
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
            if (this.Parent is Main main)
            {
                main.OtevreniFormu(new PEXESO.Forms.Menu());
                main.prehratZvuk(0);
            }
        }
    }
}