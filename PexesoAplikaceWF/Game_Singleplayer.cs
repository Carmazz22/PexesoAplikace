using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class Game_Singleplayer : Form
    {
        private string cestaHraci = @"..\..\Config\hraci.json";
        private string cestaNastaveni = @"..\..\Config\settings.json";
        private string cestaSave = @"..\..\Config\savegame.json";
        private string cestaAtlas = @"..\..\Resources\testPexesoSheet.png";

        private List<Button> vybraneKarty = new List<Button>();
        private List<Button> vsechnyKarty = new List<Button>();
        private List<Label> labelyHracu = new List<Label>();
        private List<string> jmenaHracu = new List<string>();
        private List<Button> herniPoleProSave = new List<Button>();

        private int[] skoreHracu;
        private int pocetHracu;
        private int celkovyPocetKaret;
        private int aktualniHracIndex = 0;
        private bool blokovatVstup = false;

        private Panel bocniPanel;
        private Timer vyhodnocovaciTimer;
        private Timer aiTimer;
        private Image atlasObrazku;

        public Game_Singleplayer()
        {
            InitializeComponent();
            this.Size = new Size(1150, 850);
            this.Text = "Pexeso - Trojice";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            vyhodnocovaciTimer = new Timer();
            vyhodnocovaciTimer.Interval = 1000;
            vyhodnocovaciTimer.Tick += VyhodnotKartyEvent;

            aiTimer = new Timer();
            aiTimer.Interval = 1000;
            aiTimer.Tick += ProvedTahAIEvent;

            if (File.Exists(cestaAtlas))
            {
                atlasObrazku = Image.FromFile(cestaAtlas);
            }
        }

        private void Game_Singleplayer_Load(object sender, EventArgs e)
        {
            NactiData();
            InicilizujBocniPanel();
            PripravHru();
        }

        private void NactiData()
        {
            try
            {
                if (File.Exists(cestaNastaveni))
                {
                    string jsonNastaveni = File.ReadAllText(cestaNastaveni);
                    JObject nastaveni = JObject.Parse(jsonNastaveni);
                    pocetHracu = (int)nastaveni["pocet_hracu"];
                    if (nastaveni["pocet_karet"] != null)
                        celkovyPocetKaret = (int)nastaveni["pocet_karet"];
                    else
                        celkovyPocetKaret = 30;
                }
                else
                {
                    pocetHracu = 1;
                    celkovyPocetKaret = 30;
                }
            }
            catch
            {
                pocetHracu = 1;
                celkovyPocetKaret = 30;
            }

            try
            {
                if (File.Exists(cestaHraci))
                {
                    string jsonHraci = File.ReadAllText(cestaHraci);
                    JObject hraciData = JObject.Parse(jsonHraci);
                    JArray poleJmen = (JArray)hraciData["hraci"];
                    foreach (var jmeno in poleJmen)
                    {
                        jmenaHracu.Add(jmeno.ToString());
                    }
                }
            }
            catch { }

            while (jmenaHracu.Count < pocetHracu)
            {
                jmenaHracu.Add("Hráč " + (jmenaHracu.Count + 1));
            }

            if (pocetHracu == 1)
            {
                jmenaHracu.Add("AI");
            }

            skoreHracu = new int[jmenaHracu.Count];
        }

        private void InicilizujBocniPanel()
        {
            bocniPanel = new Panel();
            bocniPanel.Location = new Point(880, 20);
            bocniPanel.Size = new Size(240, 600);
            bocniPanel.BorderStyle = BorderStyle.FixedSingle;
            bocniPanel.BackColor = Color.WhiteSmoke;
            this.Controls.Add(bocniPanel);

            Label nadpis = new Label();
            nadpis.Text = "SKÓRE";
            nadpis.Location = new Point(10, 10);
            nadpis.Size = new Size(220, 30);
            nadpis.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
            nadpis.TextAlign = ContentAlignment.MiddleCenter;
            bocniPanel.Controls.Add(nadpis);

            int y = 50;
            for (int i = 0; i < jmenaHracu.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = jmenaHracu[i] + ": 0";
                lbl.Location = new Point(10, y);
                lbl.Size = new Size(220, 35);
                lbl.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.BorderStyle = BorderStyle.Fixed3D;
                bocniPanel.Controls.Add(lbl);
                labelyHracu.Add(lbl);
                y += 45;
            }

            Button btnUlozit = new Button();
            btnUlozit.Text = "ULOŽIT HRU";
            btnUlozit.Location = new Point(10, y + 20);
            btnUlozit.Size = new Size(220, 40);
            btnUlozit.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            btnUlozit.BackColor = Color.LightGreen;
            btnUlozit.Click += BtnUlozit_Click;
            bocniPanel.Controls.Add(btnUlozit);
        }

        private void PripravHru()
        {
            int pocetUnikatnichKaret = celkovyPocetKaret / 3;
            List<int> hodnoty = new List<int>();
            for (int i = 0; i < pocetUnikatnichKaret; i++)
            {
                hodnoty.Add(i);
                hodnoty.Add(i);
                hodnoty.Add(i);
            }

            Random rng = new Random();
            hodnoty = hodnoty.OrderBy(x => rng.Next()).ToList();

            int pocetSloupcu = 6;
            if (celkovyPocetKaret == 45) pocetSloupcu = 9;
            if (celkovyPocetKaret == 60) pocetSloupcu = 10;

            for (int i = 0; i < celkovyPocetKaret; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(80, 80);
                btn.Left = (i % pocetSloupcu) * 85 + 20;
                btn.Top = (i / pocetSloupcu) * 85 + 20;
                btn.Tag = hodnoty[i];
                btn.BackColor = Color.LightSkyBlue;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Click += Karta_Click;

                this.Controls.Add(btn);
                vsechnyKarty.Add(btn);
                herniPoleProSave.Add(btn);
            }
            AktualizujZvyrazneniHrace();
        }

        private Image ZiskejVyrez(int index)
        {
            if (atlasObrazku == null) return null;

            Bitmap bmp = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                // VODOROVNÝ POSUN: X se mění podle indexu, Y je vždy 0
                int srcX = index * 256;
                Rectangle zdroj = new Rectangle(srcX, 0, 256, 256);
                Rectangle cil = new Rectangle(0, 0, 256, 256);
                g.DrawImage(atlasObrazku, cil, zdroj, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private void Karta_Click(object sender, EventArgs e)
        {
            if (blokovatVstup == true) return;
            if (pocetHracu == 1)
            {
                if (aktualniHracIndex == 1) return;
            }

            ZpracujKliknuti(sender as Button);
        }

        private void ZpracujKliknuti(Button btn)
        {
            if (btn == null) return;
            if (vybraneKarty.Contains(btn)) return;
            if (btn.BackgroundImage != null) return;

            int indexAtlasu = (int)btn.Tag;
            btn.BackgroundImage = ZiskejVyrez(indexAtlasu);

            // Okamžité překreslení
            btn.Refresh();

            vybraneKarty.Add(btn);

            if (vybraneKarty.Count == 3)
            {
                blokovatVstup = true;
                vyhodnocovaciTimer.Start();
            }
        }

        private void VyhodnotKartyEvent(object sender, EventArgs e)
        {
            vyhodnocovaciTimer.Stop();

            bool shoda = false;
            if (vybraneKarty[0].Tag.ToString() == vybraneKarty[1].Tag.ToString())
            {
                if (vybraneKarty[1].Tag.ToString() == vybraneKarty[2].Tag.ToString())
                {
                    shoda = true;
                }
            }

            if (shoda == true)
            {
                skoreHracu[aktualniHracIndex]++;
                foreach (Button btn in vybraneKarty)
                {
                    vsechnyKarty.Remove(btn);
                    this.Controls.Remove(btn);
                }
            }
            else
            {
                foreach (Button btn in vybraneKarty)
                {
                    btn.BackgroundImage = null;
                }
                aktualniHracIndex = (aktualniHracIndex + 1) % jmenaHracu.Count;
            }

            vybraneKarty.Clear();
            blokovatVstup = false;
            AktualizujUI();

            if (vsechnyKarty.Count == 0)
            {
                KonecHry();
            }
            else
            {
                if (pocetHracu == 1)
                {
                    if (aktualniHracIndex == 1)
                    {
                        aiTimer.Start();
                    }
                }
            }
        }

        private void AktualizujUI()
        {
            for (int i = 0; i < labelyHracu.Count; i++)
            {
                labelyHracu[i].Text = jmenaHracu[i] + ": " + skoreHracu[i];
            }
            AktualizujZvyrazneniHrace();
        }

        private void AktualizujZvyrazneniHrace()
        {
            for (int i = 0; i < labelyHracu.Count; i++)
            {
                if (i == aktualniHracIndex)
                {
                    labelyHracu[i].BackColor = Color.Yellow;
                    labelyHracu[i].ForeColor = Color.Red;
                }
                else
                {
                    labelyHracu[i].BackColor = Color.Transparent;
                    labelyHracu[i].ForeColor = Color.Black;
                }
            }
        }

        private void ProvedTahAIEvent(object sender, EventArgs e)
        {
            aiTimer.Stop();
            if (vsechnyKarty.Count < 3) return;

            Random rng = new Random();
            var kartyProAI = vsechnyKarty.OrderBy(x => rng.Next()).Take(3).ToList();

            foreach (Button btn in kartyProAI)
            {
                ZpracujKliknuti(btn);
            }
        }

        private void BtnUlozit_Click(object sender, EventArgs e)
        {
            UlozHru();
        }

        private void UlozHru()
        {
            var saveObjekt = new
            {
                AktualniHracIndex = aktualniHracIndex,
                Hraci = jmenaHracu,
                Skore = skoreHracu,
                PocetKaret = celkovyPocetKaret
            };

            try
            {
                string json = JsonConvert.SerializeObject(saveObjekt, Formatting.Indented);
                File.WriteAllText(cestaSave, json);
                MessageBox.Show("Hra byla uložena!", "Uložení");
            }
            catch
            {
                MessageBox.Show("Chyba při ukládání.", "Chyba");
            }
        }

        private void KonecHry()
        {
            int maxSkore = skoreHracu[0];
            string vitez = jmenaHracu[0];

            for (int i = 1; i < skoreHracu.Length; i++)
            {
                if (skoreHracu[i] > maxSkore)
                {
                    maxSkore = skoreHracu[i];
                    vitez = jmenaHracu[i];
                }
            }

            MessageBox.Show("Vítěz: " + vitez, "Konec hry");
            this.Close();
        }
    }
}   