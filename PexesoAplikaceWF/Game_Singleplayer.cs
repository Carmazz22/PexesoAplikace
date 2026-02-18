using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        private string cestaHistorie = @"..\..\Config\history.json";
        private string cestaAtlas = @"..\..\Resources\PexesoSheet1.png";

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
        private Label lblObtiznostVypis;
        private Timer vyhodnocovaciTimer;
        private Timer aiTimer;
        private Image atlasObrazku;
        private Image zadniStrana = Properties.Resources.menu_tlacitko1;

        private string barevnyRezim = "bily";
        private string nastaveniObtiznosti = "Normalni";
        private string nazevNacitaneHry = null;
        private bool debugRezim = false;

        private AI umelaInteligence;

        public Game_Singleplayer(string nazevHry = null)
        {
            nazevNacitaneHry = nazevHry;
            InitializeComponent();

            this.Size = new Size(1150, 850);
            this.Text = "Pexeso - Trojice";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            this.KeyPreview = true;
            this.KeyDown += Game_Singleplayer_KeyDown;

            vyhodnocovaciTimer = new Timer();
            vyhodnocovaciTimer.Interval = 1000;
            vyhodnocovaciTimer.Tick += VyhodnotKartyEvent;

            aiTimer = new Timer();
            aiTimer.Interval = 1000;
            aiTimer.Tick += ProvedTahAIEvent;
        }

        private void Game_Singleplayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                DebugShowToggle();
            }
            if (e.Shift == true)
            {
                if (e.KeyCode == Keys.D8)
                {
                    DebugShowToggle();
                }
            }
        }

        private void DebugShowToggle()
        {
            if (debugRezim == true)
            {
                debugRezim = false;
            }
            else
            {
                debugRezim = true;
            }

            foreach (Button btn in vsechnyKarty)
            {
                if (debugRezim == true)
                {
                    int index = (int)btn.Tag;
                    btn.BackgroundImage = ZiskejVyrez(index);
                }
                else
                {
                    if (vybraneKarty.Contains(btn) == false)
                    {
                        btn.BackgroundImage = zadniStrana;
                    }
                }
            }
        }

        private void Game_Singleplayer_Load(object sender, EventArgs e)
        {
            NactiData();

            if (File.Exists(cestaAtlas) == true)
            {
                atlasObrazku = Image.FromFile(cestaAtlas);
            }

            InicilizujAI();
            InicilizujBocniPanel();

            if (string.IsNullOrEmpty(nazevNacitaneHry) == false)
            {
                NactiHru(nazevNacitaneHry);
            }
            else
            {
                PripravHru();
            }

            AktualizujVzhled();
        }

        private void NactiData()
        {
            try
            {
                if (File.Exists(cestaNastaveni) == true)
                {
                    string jsonNastaveni = File.ReadAllText(cestaNastaveni);
                    JObject nastaveni = JObject.Parse(jsonNastaveni);

                    if (nastaveni["pocet_hracu"] != null)
                    {
                        pocetHracu = (int)nastaveni["pocet_hracu"];
                    }
                    else
                    {
                        pocetHracu = 1;
                    }

                    if (nastaveni["pocet_karet"] != null)
                    {
                        celkovyPocetKaret = (int)nastaveni["pocet_karet"];
                    }
                    else
                    {
                        celkovyPocetKaret = 30;
                    }

                    if (nastaveni["barevny_rezim"] != null)
                    {
                        barevnyRezim = (string)nastaveni["barevny_rezim"];
                    }

                    if (nastaveni["ai_obt"] != null)
                    {
                        nastaveniObtiznosti = (string)nastaveni["ai_obt"];
                    }
                    else
                    {
                        nastaveniObtiznosti = "Normalni";
                    }

                    if (nastaveni["vzhled_karet"] != null)
                    {
                        int vzhled = (int)nastaveni["vzhled_karet"];
                        if (vzhled == 1)
                        {
                            cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
                        }
                        else if (vzhled == 2)
                        {
                            cestaAtlas = @"..\..\Resources\PexesoSheet2.png";
                        }
                        else if (vzhled == 3)
                        {
                            cestaAtlas = @"..\..\Resources\PexesoSheet3.png";
                        }
                        else
                        {
                            cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
                        }
                    }
                }
                else
                {
                    pocetHracu = 1;
                    celkovyPocetKaret = 30;
                    nastaveniObtiznosti = "Normalni";
                    cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
                }
            }
            catch
            {
                pocetHracu = 1;
                celkovyPocetKaret = 30;
                nastaveniObtiznosti = "Normalni";
                cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
            }

            if (string.IsNullOrEmpty(nazevNacitaneHry) == true)
            {
                try
                {
                    if (File.Exists(cestaHraci) == true)
                    {
                        string jsonHraci = File.ReadAllText(cestaHraci);
                        JObject hraciData = JObject.Parse(jsonHraci);
                        JArray poleJmen = (JArray)hraciData["hraci"];
                        foreach (JToken jmeno in poleJmen)
                        {
                            jmenaHracu.Add(jmeno.ToString());
                        }
                    }
                }
                catch { }

                while (jmenaHracu.Count < pocetHracu)
                {
                    int cislo = jmenaHracu.Count + 1;
                    jmenaHracu.Add("Hráč " + cislo);
                }

                if (pocetHracu == 1)
                {
                    jmenaHracu.Add("AI");
                }

                skoreHracu = new int[jmenaHracu.Count];
            }
        }

        private void InicilizujAI()
        {
            AI.Obtiznost obtiznostEnum = AI.Obtiznost.Normalni;

            if (nastaveniObtiznosti == "lehka")
            {
                obtiznostEnum = AI.Obtiznost.Lehka;
            }
            else if (nastaveniObtiznosti == "tezka")
            {
                obtiznostEnum = AI.Obtiznost.Tezka;
            }
            else
            {
                obtiznostEnum = AI.Obtiznost.Normalni;
            }

            umelaInteligence = new AI(obtiznostEnum);
        }

        private void InicilizujBocniPanel()
        {
            bocniPanel = new Panel();
            bocniPanel.Location = new Point(880, 20);
            bocniPanel.Size = new Size(240, 680);
            bocniPanel.BorderStyle = BorderStyle.None;
            bocniPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(bocniPanel);

            Label nadpis = new Label();
            nadpis.Text = "SKÓRE";
            nadpis.Location = new Point(0, 20);
            nadpis.Size = new Size(240, 40);
            nadpis.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            nadpis.TextAlign = ContentAlignment.MiddleCenter;
            nadpis.ForeColor = Color.FromArgb(64, 64, 64);
            bocniPanel.Controls.Add(nadpis);

            lblObtiznostVypis = new Label();
            lblObtiznostVypis.Text = "Obtížnost AI: " + nastaveniObtiznosti;
            lblObtiznostVypis.Location = new Point(0, 450);
            lblObtiznostVypis.Size = new Size(240, 30);
            lblObtiznostVypis.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblObtiznostVypis.TextAlign = ContentAlignment.MiddleCenter;
            lblObtiznostVypis.ForeColor = Color.Gray;

            if (pocetHracu > 1)
            {
                lblObtiznostVypis.Visible = false;
            }
            else
            {
                lblObtiznostVypis.Visible = true;
            }

            bocniPanel.Controls.Add(lblObtiznostVypis);

            Button btnUlozit = new Button();
            btnUlozit.Text = "ULOŽIT HRU";
            btnUlozit.Location = new Point(20, 520);
            btnUlozit.Size = new Size(200, 45);
            btnUlozit.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnUlozit.BackColor = Color.FromArgb(46, 204, 113);
            btnUlozit.ForeColor = Color.White;
            btnUlozit.FlatStyle = FlatStyle.Flat;
            btnUlozit.FlatAppearance.BorderSize = 0;
            btnUlozit.Cursor = Cursors.Hand;
            btnUlozit.Click += BtnUlozit_Click;
            bocniPanel.Controls.Add(btnUlozit);

            Button btnMenu = new Button();
            btnMenu.Text = "ODEJÍT DO MENU";
            btnMenu.Location = new Point(20, 580);
            btnMenu.Size = new Size(200, 45);
            btnMenu.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnMenu.BackColor = Color.FromArgb(231, 76, 60);
            btnMenu.ForeColor = Color.White;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Click += BtnMenu_Click;
            bocniPanel.Controls.Add(btnMenu);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            DialogResult dotaz = MessageBox.Show("Opravdu chcete odejít do menu?", "Návrat", MessageBoxButtons.YesNo);
            if (dotaz == DialogResult.Yes)
            {
                Menu1 menu = new Menu1();
                menu.Show();
                this.Hide();
            }
        }

        private void VytvorLabelyHracu()
        {
            foreach (Control l in labelyHracu)
            {
                bocniPanel.Controls.Remove(l);
            }
            labelyHracu.Clear();

            int y = 70;
            for (int i = 0; i < jmenaHracu.Count; i++)
            {
                int body = 0;
                if (skoreHracu.Length > i)
                {
                    body = skoreHracu[i];
                }

                Label lbl = new Label();
                lbl.Text = jmenaHracu[i] + ": " + body;
                lbl.Location = new Point(20, y);
                lbl.Size = new Size(200, 40);
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.BorderStyle = BorderStyle.None;
                bocniPanel.Controls.Add(lbl);
                labelyHracu.Add(lbl);
                y += 50;
            }
        }

        private void PripravHru()
        {
            skoreHracu = new int[jmenaHracu.Count];
            VytvorLabelyHracu();
            int pocetUnikatnichKaret = celkovyPocetKaret / 3;
            List<int> hodnoty = new List<int>();
            for (int i = 0; i < pocetUnikatnichKaret; i++)
            {
                hodnoty.Add(i);
                hodnoty.Add(i);
                hodnoty.Add(i);
            }

            Random rng = new Random();
            int n = hodnoty.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = hodnoty[k];
                hodnoty[k] = hodnoty[n];
                hodnoty[n] = value;
            }

            int pocetSloupcu = 6;
            if (celkovyPocetKaret == 45)
            {
                pocetSloupcu = 9;
            }
            if (celkovyPocetKaret == 60)
            {
                pocetSloupcu = 10;
            }
            for (int i = 0; i < celkovyPocetKaret; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(80, 80);
                btn.Left = (i % pocetSloupcu) * 85 + 20;
                btn.Top = (i / pocetSloupcu) * 85 + 20;
                btn.Tag = hodnoty[i];
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.BackgroundImage = zadniStrana;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Click += Karta_Click;
                this.Controls.Add(btn);
                vsechnyKarty.Add(btn);
                herniPoleProSave.Add(btn);
            }
            AktualizujZvyrazneniHrace();
        }

        private Image ZiskejVyrez(int index)
        {
            if (atlasObrazku == null)
            {
                return null;
            }
            Bitmap bmp = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.Clear(Color.Transparent);
                int srcX = index * 256;
                Rectangle zdroj = new Rectangle(srcX, 0, 256, 256);
                Rectangle cil = new Rectangle(0, 0, 256, 256);
                g.DrawImage(atlasObrazku, cil, zdroj, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private void Karta_Click(object sender, EventArgs e)
        {
            if (blokovatVstup == true)
            {
                return;
            }
            if (pocetHracu == 1)
            {
                if (aktualniHracIndex == 1)
                {
                    return;
                }
            }
            ZpracujKliknuti(sender as Button);
        }

        private void ZpracujKliknuti(Button btn)
        {
            if (btn == null)
            {
                return;
            }
            if (vybraneKarty.Contains(btn) == true)
            {
                return;
            }
            if (debugRezim == false)
            {
                if (btn.BackgroundImage != null)
                {
                    if (btn.BackgroundImage != zadniStrana)
                    {
                        return;
                    }
                }
            }
            int indexAtlasu = (int)btn.Tag;
            btn.BackgroundImage = ZiskejVyrez(indexAtlasu);
            umelaInteligence.VidelJsemKartu(btn);
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
                umelaInteligence.OdstranKartyZPameti(vybraneKarty);
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
                    if (debugRezim == true)
                    {
                        int index = (int)btn.Tag;
                        btn.BackgroundImage = ZiskejVyrez(index);
                    }
                    else
                    {
                        btn.BackgroundImage = zadniStrana;
                    }
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

        private void AktualizujVzhled()
        {
            if (barevnyRezim == "tmavy")
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                bocniPanel.BackColor = Color.FromArgb(30, 30, 30);
                foreach (Control ctrl in bocniPanel.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                this.BackColor = Color.White;
                bocniPanel.BackColor = Color.FromArgb(245, 245, 245);
                foreach (Control ctrl in bocniPanel.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.ForeColor = Color.FromArgb(64, 64, 64);
                    }
                }
            }
            AktualizujZvyrazneniHrace();
        }

        private void AktualizujZvyrazneniHrace()
        {
            for (int i = 0; i < labelyHracu.Count; i++)
            {
                if (i == aktualniHracIndex)
                {
                    labelyHracu[i].ForeColor = Color.Red;
                    labelyHracu[i].Font = new Font("Segoe UI", 12, FontStyle.Bold);
                }
                else
                {
                    labelyHracu[i].Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    if (barevnyRezim == "tmavy")
                    {
                        labelyHracu[i].ForeColor = Color.White;
                    }
                    else
                    {
                        labelyHracu[i].ForeColor = Color.FromArgb(64, 64, 64);
                    }
                }
            }
        }

        private void ProvedTahAIEvent(object sender, EventArgs e)
        {
            aiTimer.Stop();
            if (vsechnyKarty.Count < 3)
            {
                return;
            }
            List<Button> kartyProAI = umelaInteligence.NavrhniTah(vsechnyKarty);
            foreach (Button btn in kartyProAI)
            {
                ZpracujKliknuti(btn);
                System.Threading.Thread.Sleep(500);
                Application.DoEvents();
            }
        }

        private void BtnUlozit_Click(object sender, EventArgs e)
        {
            string nazev = ZobrazInputBox("Uložení hry", "Zadejte název pro uložení hry:", "Hra1");
            if (string.IsNullOrWhiteSpace(nazev) == false)
            {
                UlozHru(nazev);
            }
        }

        public static string ZobrazInputBox(string nadpis, string text, string vychoziHodnota)
        {
            Form prompt = new Form();
            prompt.Width = 400;
            prompt.Height = 180;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = nadpis;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;

            Label textLabel = new Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Width = 340;
            textLabel.Text = text;

            TextBox textBox = new TextBox();
            textBox.Left = 20;
            textBox.Top = 50;
            textBox.Width = 340;
            textBox.Text = vychoziHodnota;

            Button confirmation = new Button();
            confirmation.Text = "OK";
            confirmation.Left = 260;
            confirmation.Width = 100;
            confirmation.Top = 90;
            confirmation.DialogResult = DialogResult.OK;
            confirmation.Click += delegate (object s, EventArgs ev) { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }
            else
            {
                return "";
            }
        }

        private void UlozHru(string nazevHry)
        {
            List<object> seznamKaretObjektu = new List<object>();
            foreach (Button b in herniPoleProSave)
            {
                bool aktivni = false;
                if (vsechnyKarty.Contains(b) == true)
                {
                    aktivni = true;
                }
                seznamKaretObjektu.Add(new { Tag = (int)b.Tag, Aktivni = aktivni });
            }

            object novaHraData = new
            {
                Datum = DateTime.Now,
                AktualniHracIndex = aktualniHracIndex,
                Hraci = jmenaHracu,
                Skore = skoreHracu,
                PocetKaret = celkovyPocetKaret,
                Karty = seznamKaretObjektu
            };

            Dictionary<string, object> ulozeneHry = new Dictionary<string, object>();
            if (File.Exists(cestaSave) == true)
            {
                try
                {
                    string json = File.ReadAllText(cestaSave);
                    ulozeneHry = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    if (ulozeneHry == null)
                    {
                        ulozeneHry = new Dictionary<string, object>();
                    }
                }
                catch
                {
                    ulozeneHry = new Dictionary<string, object>();
                }
            }

            if (ulozeneHry.ContainsKey(nazevHry) == true)
            {
                DialogResult vysledek = MessageBox.Show("Hra již existuje. Přepsat?", "Duplikát", MessageBoxButtons.YesNo);
                if (vysledek == DialogResult.No)
                {
                    return;
                }
            }

            ulozeneHry[nazevHry] = novaHraData;
            try
            {
                string vystupniJson = JsonConvert.SerializeObject(ulozeneHry, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(cestaSave, vystupniJson);
                MessageBox.Show("Uloženo pod: " + nazevHry);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        private void NactiHru(string nazevHry)
        {
            if (File.Exists(cestaSave) == false)
            {
                return;
            }
            try
            {
                string json = File.ReadAllText(cestaSave);
                JObject vsechnyHry = JObject.Parse(json);
                if (vsechnyHry.ContainsKey(nazevHry) == false)
                {
                    this.Close();
                    return;
                }
                JToken save = vsechnyHry[nazevHry];
                aktualniHracIndex = (int)save["AktualniHracIndex"];
                celkovyPocetKaret = (int)save["PocetKaret"];
                jmenaHracu = save["Hraci"].ToObject<List<string>>();
                skoreHracu = save["Skore"].ToObject<int[]>();
                VytvorLabelyHracu();
                JArray karty = (JArray)save["Karty"];
                int pocetSloupcu = 6;
                if (celkovyPocetKaret == 45)
                {
                    pocetSloupcu = 9;
                }
                if (celkovyPocetKaret == 60)
                {
                    pocetSloupcu = 10;
                }
                vsechnyKarty.Clear();
                herniPoleProSave.Clear();
                for (int i = 0; i < karty.Count; i++)
                {
                    int tagValue = (int)karty[i]["Tag"];
                    bool jeAktivni = (bool)karty[i]["Aktivni"];
                    Button btn = new Button();
                    btn.Size = new Size(80, 80);
                    btn.Left = (i % pocetSloupcu) * 85 + 20;
                    btn.Top = (i / pocetSloupcu) * 85 + 20;
                    btn.Tag = tagValue;
                    btn.BackColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.LightGray;
                    btn.BackgroundImage = zadniStrana;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Click += Karta_Click;
                    herniPoleProSave.Add(btn);
                    if (jeAktivni == true)
                    {
                        this.Controls.Add(btn);
                        vsechnyKarty.Add(btn);
                    }
                }
                AktualizujUI();
                AktualizujVzhled();
            }
            catch { }
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
            UlozVysledkyDoHistorie(vitez);
            MessageBox.Show("Vítěz: " + vitez, "Konec hry");

            Menu1 menu = new Menu1();
            menu.Show();
            this.Close();
        }

        private void UlozVysledkyDoHistorie(string vitez)
        {
            List<object> historie = new List<object>();
            if (File.Exists(cestaHistorie) == true)
            {
                try
                {
                    string existujiciJson = File.ReadAllText(cestaHistorie);
                    historie = JsonConvert.DeserializeObject<List<object>>(existujiciJson);
                    if (historie == null)
                    {
                        historie = new List<object>();
                    }
                }
                catch
                {
                    historie = new List<object>();
                }
            }
            string idHry = Guid.NewGuid().ToString();
            DateTime datum = DateTime.Now;

            int maxBody = 0;
            foreach (int skore in skoreHracu)
            {
                if (skore > maxBody)
                {
                    maxBody = skore;
                }
            }

            int pocetHracuSMaximem = 0;
            foreach (int skore in skoreHracu)
            {
                if (skore == maxBody)
                {
                    pocetHracuSMaximem++;
                }
            }

            for (int i = 0; i < jmenaHracu.Count; i++)
            {
                string jmeno = jmenaHracu[i];
                int body = skoreHracu[i];

                string vysledek = "";
                if (jmeno == vitez)
                {
                    vysledek = "Výhra";
                }
                else
                {
                    vysledek = "Prohra";
                }

                if (pocetHracuSMaximem > 1)
                {
                    if (body == maxBody)
                    {
                        vysledek = "Remíza";
                    }
                }

                historie.Add(new
                {
                    GameID = idHry,
                    Datum = datum,
                    Hrac = jmeno,
                    Vysledek = vysledek,
                    PocetKaret = body,
                    CelkemKaretVeHre = celkovyPocetKaret
                });
            }
            string finalJson = JsonConvert.SerializeObject(historie, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(cestaHistorie, finalJson);
        }
    }
}