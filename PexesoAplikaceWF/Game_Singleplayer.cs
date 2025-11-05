using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace PexesoAplikaceWF
{
   
    public partial class Game_Singleplayer : Form
    {
        string cesta = @"..\..\Config\settings.json"; //cesta k settings
        private List<Button> vybraneKarty = new List<Button>();
        private bool blokovatKliky = false;
        private int pocet_hracu = 1; //zatim fixni, pozdeji volba mezi 1 vice hraci, podle cteni z JSON
        private int aktualniHrac = 1;
        private Label label_Player;
        private List<Button> vsechnyTlacitka = new List<Button>();

        public Game_Singleplayer()
        {
            InitializeComponent();

            label_Player = new Label();
            label_Player.AutoSize = true;
            label_Player.Location = new Point(10, 320);
            label_Player.Font = new Font("Comis Sans Ms", 12, FontStyle.Bold);
            this.Controls.Add(label_Player);
        }

        private void Game_Singleplayer_Load(object sender, EventArgs e)
        {

            //nacteni veci z JSONu
            string json = File.ReadAllText(cesta);
            JObject data = JObject.Parse(json);

            int pocet_hracu = (int)data["pocet_hracu"];
            int zvuk = (int)data["zvuk"];
            string ai_obt = (string)data["ai_obt"];
            int pocet_karet = (int)data["pocet_karet"];
            int vzhled_karet = (int)data["vzhled_karet"];

            int pocetKaret = 30;

            List<int> cislaKaret = new List<int>();
            for (int i = 1; i <= pocetKaret / 3; i++)
            {
                cislaKaret.Add(i);
                cislaKaret.Add(i);
                cislaKaret.Add(i);
            }

            Random random = new Random();
            cislaKaret = cislaKaret.OrderBy(x => random.Next()).ToList();

            int pocetRadku = 5;
            int pocetSloupcu = 6;
            int sirkaTlacitka = 60;
            int vyskaTlacitka = 60;
            int mezera = 10;

            for (int radek = 0; radek < pocetRadku; radek++)
            {
                for (int sloupec = 0; sloupec < pocetSloupcu; sloupec++)
                {
                    Button tlacitko = new Button();
                    tlacitko.Width = sirkaTlacitka;
                    tlacitko.Height = vyskaTlacitka;
                    tlacitko.Left = sloupec * (sirkaTlacitka + mezera);
                    tlacitko.Top = radek * (vyskaTlacitka + mezera);
                    tlacitko.Tag = cislaKaret[radek * pocetSloupcu + sloupec];
                    tlacitko.Text = "";
                    tlacitko.Click += Tlacitko_Click;
                    this.Controls.Add(tlacitko);
                    vsechnyTlacitka.Add(tlacitko);
                }
            }

            AktualizujLabel();
        }

        private void Tlacitko_Click(object sender, EventArgs e)
        {
            if (blokovatKliky || aktualniHrac == 2)
                return;

            ZpracujTah(sender as Button);
        }

        private void ZpracujTah(Button tlacitko)
        {
            if (tlacitko != null && tlacitko.Text == "")
            {
                tlacitko.Text = tlacitko.Tag.ToString();
                vybraneKarty.Add(tlacitko);

                if (vybraneKarty.Count == 3)
                {
                    blokovatKliky = true;

                    Timer timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += (s, args) =>
                    {
                        if (vybraneKarty[0].Tag.ToString() == vybraneKarty[1].Tag.ToString() &&
                            vybraneKarty[1].Tag.ToString() == vybraneKarty[2].Tag.ToString())
                        {
                            foreach (var karta in vybraneKarty)
                            {
                                this.Controls.Remove(karta);
                                vsechnyTlacitka.Remove(karta);
                            }
                        }
                        else
                        {
                            foreach (var karta in vybraneKarty)
                                karta.Text = "";
                        }

                        vybraneKarty.Clear();
                        blokovatKliky = false;

                        
                        aktualniHrac = (aktualniHrac == 1) ? 2 : 1;
                        AktualizujLabel();

                        if (aktualniHrac == 2)
                            AI_Tah();

                        timer.Stop();
                    };
                    timer.Start();
                }
            }
        }

        private void AktualizujLabel()
        {
            label_Player.Text = (aktualniHrac == 1) ? "Hraje hráč" : "Hraje AI";
        }

        private void AI_Tah()
        {
            blokovatKliky = true;
            Random random = new Random();

            Timer aiTimer = new Timer();
            aiTimer.Interval = 800;
            aiTimer.Tick += (s, args) =>
            {
                aiTimer.Stop();

                List<Button> dostupne = vsechnyTlacitka.Where(b => b.Text == "").ToList();
                if (dostupne.Count < 3)
                {
                    blokovatKliky = false;
                    aktualniHrac = 1;
                    AktualizujLabel();
                    return;
                }

                List<Button> aiVybrane = new List<Button>();
                for (int i = 0; i < 3; i++)
                {
                    Button vybrana = dostupne[random.Next(dostupne.Count)];
                    dostupne.Remove(vybrana);
                    aiVybrane.Add(vybrana);
                    vybrana.Text = vybrana.Tag.ToString();
                }

                vybraneKarty = new List<Button>(aiVybrane);

                Timer checkTimer = new Timer();
                checkTimer.Interval = 1000;
                checkTimer.Tick += (s2, args2) =>
                {
                    if (vybraneKarty[0].Tag.ToString() == vybraneKarty[1].Tag.ToString() &&
                        vybraneKarty[1].Tag.ToString() == vybraneKarty[2].Tag.ToString())
                    {
                        foreach (var karta in vybraneKarty)
                        {
                            this.Controls.Remove(karta);
                            vsechnyTlacitka.Remove(karta);
                        }
                        // AI může pokračovat
                        AI_Tah();
                    }
                    else
                    {
                        foreach (var karta in vybraneKarty)
                            karta.Text = "";
                        aktualniHrac = 1;
                        AktualizujLabel();
                        blokovatKliky = false;
                    }

                    vybraneKarty.Clear();
                    checkTimer.Stop();
                };
                checkTimer.Start();
            };
            aiTimer.Start();
        }
    }
}
