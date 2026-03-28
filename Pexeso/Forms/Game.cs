using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PEXESO.Resources;
using System.Drawing.Drawing2D;

namespace PEXESO.Forms
{
    public partial class Game : Form
    {
        #region Proměnné a Inicializace
        string cestaHraci = @"..\..\Config\seznamHracu.dat";
        string cestaNastaveni = @"..\..\Config\settings.dat";
        string cestaHistorie = @"..\..\Config\history.dat";
        string cestaAtlas = @"..\..\Resources\PexesoSheet1.png";

        List<Button> vybraneKarty = new List<Button>();
        List<Button> vsechnyKarty = new List<Button>();
        List<Label> labelyHracu = new List<Label>();
        List<string> jmenaHracu = new List<string>();
        List<Button> herniPoleProSave = new List<Button>();

        int[] skoreHracu;
        int aktualniHracIndex = 0;
        bool blokovatVstup = false;

        Panel bocniPanel;
        Label labelObtiznost;
        Timer TimerVyhodnoceni;
        Timer aiTimer;
        Image atlasObrazku;

        byte rezimBarev = 0;
        byte obtiznostAI = 1;
        byte zvuk;
        byte vzhled;
        byte pocetHracu;
        byte celkovyPocetKaret;

        string nazevNacitaneHry = null;
        bool debugRezim = false;

        private AI AI;

        public Game(string nazevHry = null)
        {
            nazevNacitaneHry = nazevHry;
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Game_KeyDown;

            TimerVyhodnoceni = new Timer();
            TimerVyhodnoceni.Interval = 1000;
            TimerVyhodnoceni.Tick += VyhodnoceniKaret;

            aiTimer = new Timer();
            aiTimer.Interval = 1000;
            aiTimer.Tick += AI_tah;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            NactiData();

            if (File.Exists(cestaAtlas))
            {
                atlasObrazku = Image.FromFile(cestaAtlas);
            }

            if (!string.IsNullOrEmpty(nazevNacitaneHry))
            {
                NactiHru(nazevNacitaneHry);
            }
            else
            {
                PripravaHry();
            }

            VytvoritBocniPanel();
            VytvoreniLabeluHracu();
            AktualizujZvyrazneniHrace();

            if (pocetHracu == 1)
            {
                Inicializace_AI();
            }
        }
        #endregion

        #region Načtení dat + AI
        private void NactiData()
        {
            if (File.Exists(cestaNastaveni))
            {
                FileStream fs = new FileStream(cestaNastaveni, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                if (fs.Length >= 6)
                {
                    pocetHracu = br.ReadByte();
                    zvuk = br.ReadByte();
                    obtiznostAI = br.ReadByte();
                    celkovyPocetKaret = br.ReadByte();
                    vzhled = br.ReadByte();
                    rezimBarev = br.ReadByte();

                    if (vzhled == 0)
                    {
                        cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
                    }
                    else if (vzhled == 1)
                    {
                        cestaAtlas = @"..\..\Resources\PexesoSheet2.png";
                    }
                    else if (vzhled == 2)
                    {
                        cestaAtlas = @"..\..\Resources\PexesoSheet3.png";
                    }
                    else
                    {
                        cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
                    }
                }
                br.Close();
                fs.Close();
            }
            else
            {
                pocetHracu = 1;
                celkovyPocetKaret = 30;
                obtiznostAI = 1;
                rezimBarev = 0;
                cestaAtlas = @"..\..\Resources\PexesoSheet1.png";
            }

            if (string.IsNullOrEmpty(nazevNacitaneHry))
            {
                if (File.Exists(cestaHraci))
                {
                    FileStream fs = new FileStream(cestaHraci, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    while (fs.Position < fs.Length)
                    {
                        jmenaHracu.Add(br.ReadString());
                    }

                    br.Close();
                    fs.Close();
                }

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

        private void Inicializace_AI()
        {
            AI = new AI(obtiznostAI);
        }
        #endregion

        #region UI a Vykreslování
        Color barvaTlacitek = Color.FromArgb(245, 245, 245);
        Color barvaTextu = Color.FromArgb(0, 0, 0);

        private void VytvoritBocniPanel()
        {
            bocniPanel = new Panel();

            int pocetSloupcu = 6;
            if (celkovyPocetKaret == 45)
            {
                pocetSloupcu = 9;
            }
            else if (celkovyPocetKaret == 51)
            {
                pocetSloupcu = 10;
            }
            else if (celkovyPocetKaret == 60)
            {
                pocetSloupcu = 10;
            }

            int maxRight = (pocetSloupcu - 1) * 125 + 120;
            int maxBottom = ((celkovyPocetKaret - 1) / pocetSloupcu) * 125 + 120;

            bocniPanel.Location = new Point(maxRight + 40, 0);
            bocniPanel.Size = new Size(240, 680);
            bocniPanel.BorderStyle = BorderStyle.None;

            if (rezimBarev == 0)
            {
                this.BackColor = Color.White;
                bocniPanel.BackColor = Color.FromArgb(245, 245, 245);
                barvaTlacitek = Color.FromArgb(245, 245, 245);
                barvaTextu = Color.FromArgb(0, 0, 0);
            }
            else
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                bocniPanel.BackColor = Color.FromArgb(0, 0, 0);
                barvaTlacitek = Color.FromArgb(0, 0, 0);
                barvaTextu = Color.FromArgb(255, 255, 255);
            }

            foreach (Button btn in vsechnyKarty)
            {
                btn.BackColor = barvaTlacitek;
                btn.ForeColor = barvaTextu;
                btn.FlatAppearance.BorderColor = barvaTextu;
            }

            panel1.Controls.Add(bocniPanel);

            Label nadpis = new Label();
            nadpis.Text = "SKÓRE";
            nadpis.Location = new Point(0, 20);
            nadpis.Size = new Size(240, 40);
            nadpis.Font = new Font("Roboto", 10, FontStyle.Bold);
            nadpis.TextAlign = ContentAlignment.MiddleCenter;

            if (rezimBarev == 1)
            {
                nadpis.ForeColor = Color.White;
            }
            else
            {
                nadpis.ForeColor = Color.FromArgb(64, 64, 64);
            }

            bocniPanel.Controls.Add(nadpis);

            string nazevObtiznosti = "Neznámá";

            if (obtiznostAI == 0)
            {
                nazevObtiznosti = "Lehká";
            }
            else if (obtiznostAI == 1)
            {
                nazevObtiznosti = "Normální";
            }
            else if (obtiznostAI == 2)
            {
                nazevObtiznosti = "Těžká";
            }

            labelObtiznost = new Label();
            labelObtiznost.Text = "Obtížnost AI: " + nazevObtiznosti;
            labelObtiznost.Location = new Point(0, 450);
            labelObtiznost.Size = new Size(240, 30);
            labelObtiznost.Font = new Font("Roboto", 10, FontStyle.Bold);
            labelObtiznost.TextAlign = ContentAlignment.MiddleCenter;

            if (rezimBarev == 1)
            {
                labelObtiznost.ForeColor = Color.White;
            }
            else
            {
                labelObtiznost.ForeColor = Color.FromArgb(64, 64, 64);
            }

            if (pocetHracu > 1)
            {
                labelObtiznost.Visible = false;
            }
            else
            {
                labelObtiznost.Visible = true;
            }

            bocniPanel.Controls.Add(labelObtiznost);

            Button btnUlozit = new Button();
            btnUlozit.Text = "ULOŽIT HRU";
            btnUlozit.Location = new Point(20, 520);
            btnUlozit.Size = new Size(200, 45);
            btnUlozit.Font = new Font("Roboto", 10, FontStyle.Bold);
            btnUlozit.BackColor = barvaTlacitek;
            btnUlozit.ForeColor = barvaTextu;
            btnUlozit.FlatStyle = FlatStyle.Flat;
            btnUlozit.FlatAppearance.BorderSize = 2;
            btnUlozit.FlatAppearance.BorderColor = barvaTextu;
            btnUlozit.Click += BtnUlozit_Click;
            bocniPanel.Controls.Add(btnUlozit);

            Button btnMenu = new Button();
            btnMenu.Text = "ODEJÍT DO MENU";
            btnMenu.Location = new Point(20, 580);
            btnMenu.Size = new Size(200, 45);
            btnMenu.Font = new Font("Roboto", 10, FontStyle.Bold);
            btnMenu.BackColor = barvaTlacitek;
            btnMenu.ForeColor = barvaTextu;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 2;
            btnMenu.FlatAppearance.BorderColor = barvaTextu;
            btnMenu.Click += BtnMenu_Click;
            bocniPanel.Controls.Add(btnMenu);

            int celkovaVyska = maxBottom;
            if (bocniPanel.Bottom > celkovaVyska)
            {
                celkovaVyska = bocniPanel.Bottom;
            }

            panel1.Width = bocniPanel.Right;
            panel1.Height = celkovaVyska;

            int posX = (this.ClientSize.Width - panel1.Width) / 2;
            int posY = (this.ClientSize.Height - panel1.Height) / 2;

            if (posX < 0)
            {
                posX = 0;
            }
            if (posY < 0)
            {
                posY = 0;
            }

            panel1.Location = new Point(posX, posY);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.prehratZvuk(0);
                DialogResult dotaz = MessageBox.Show("Opravdu chcete odejít do menu?", "Návrat do Menu", MessageBoxButtons.YesNo);
                if (dotaz == DialogResult.Yes)
                {
                    main.OtevreniFormu(new global::PEXESO.Forms.Menu());
                }
            }
        }

        private void BtnUlozit_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.prehratZvuk(0);
            }
            string nazev = ZobrazFormSavegame("Uložit hru", "Název uložené hry: ", "Hra1");
            if (!string.IsNullOrWhiteSpace(nazev))
            {
                UlozHru(nazev);
            }
        }

        private void VytvoreniLabeluHracu()
        {
            for (int i = labelyHracu.Count - 1; i >= 0; i--)
            {
                bocniPanel.Controls.Remove(labelyHracu[i]);
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
                lbl.Font = new Font("Roboto", 10, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.BorderStyle = BorderStyle.None;
                bocniPanel.Controls.Add(lbl);
                labelyHracu.Add(lbl);
                y += 50;
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
                    labelyHracu[i].ForeColor = Color.Red;
                    labelyHracu[i].Font = new Font("Roboto", 12, FontStyle.Bold);
                }
                else
                {
                    labelyHracu[i].Font = new Font("Roboto", 10, FontStyle.Bold);
                    if (rezimBarev == 1)
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
        #endregion

        #region Klávesové zkratky a Debug
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                OdkrytKarty();
            }
            if (e.Shift)
            {
                if (e.KeyCode == Keys.D8)
                {
                    OdkrytKarty();
                }
            }
        }

        private void OdkrytKarty()
        {
            if (debugRezim)
            {
                debugRezim = false;
            }
            else
            {
                debugRezim = true;
            }

            foreach (Button btn in vsechnyKarty)
            {
                if (debugRezim)
                {
                    int index = (int)btn.Tag;
                    btn.BackgroundImage = kartaZistkatObrazek(index);
                    btn.Text = "";
                }
                else
                {
                    bool vybrana = false;
                    foreach (Button vybraneButtony in vybraneKarty)
                    {
                        if (vybraneButtony == btn)
                        {
                            vybrana = true;
                        }
                    }

                    if (!vybrana)
                    {
                        btn.BackgroundImage = null;
                        int indexKarty = int.Parse(btn.Name.Substring(5));
                        btn.Text = (indexKarty + 1).ToString();
                    }
                    else
                    {
                        btn.BackgroundImage = kartaZistkatObrazek((int)btn.Tag);
                        btn.Text = "";
                    }
                }
            }
        }
        #endregion

        #region Logika Karet a Hry + metoda na generaci karet
        private void VytvorKartu(int i, int tagValue, int pocetSloupcu, bool jeAktivni)
        {
            Button btn = new Button();
            btn.Name = "karta" + i;
            btn.Size = new Size(120, 120);
            btn.Left = (i % pocetSloupcu) * 125;
            btn.Top = (i / pocetSloupcu) * 125;
            btn.Tag = tagValue;
            btn.BackColor = barvaTlacitek;
            btn.FlatAppearance.BorderSize = 3;
            btn.FlatAppearance.BorderColor = barvaTextu;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Font = new Font("Roboto", 10, FontStyle.Bold);
            btn.ForeColor = barvaTextu;

            if (jeAktivni)
            {
                btn.Text = (i + 1).ToString();
            }
            else
            {
                btn.Text = "";
            }

            btn.Click += Karta_Click;

            herniPoleProSave.Add(btn);

            if (jeAktivni)
            {
                panel1.Controls.Add(btn);
                vsechnyKarty.Add(btn);
            }
        }

        private void PripravaHry()
        {
            skoreHracu = new int[jmenaHracu.Count];

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
            else if (celkovyPocetKaret == 51)
            {
                pocetSloupcu = 10;
            }
            else if (celkovyPocetKaret == 60)
            {
                pocetSloupcu = 10;
            }

            for (int i = 0; i < celkovyPocetKaret; i++)
            {
                VytvorKartu(i, hodnoty[i], pocetSloupcu, true);
            }
        }

        private Image kartaZistkatObrazek(int index)
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.Clear(Color.Transparent);
                int srcX = index * 256;
                Rectangle zdroj = new Rectangle(srcX, 0, 256, 256);
                Rectangle cil = new Rectangle(0, 0, 120, 120);
                g.DrawImage(atlasObrazku, cil, zdroj, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private void Karta_Click(object sender, EventArgs e)
        {
            if (blokovatVstup)
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

            bool uzVybrana = false;
            foreach (Button vybrana in vybraneKarty)
            {
                if (vybrana == btn)
                {
                    uzVybrana = true;
                }
            }

            if (uzVybrana)
            {
                return;
            }

            if (!debugRezim)
            {
                if (btn.BackgroundImage != null)
                {
                    return;
                }
            }

            int indexAtlasu = (int)btn.Tag;
            btn.BackgroundImage = kartaZistkatObrazek(indexAtlasu);
            btn.Text = "";

            if (AI != null)
            {
                AI.VidelJsemKartu(btn);
            }

            btn.Refresh();

            if (this.Parent is PEXESO main)
            {
                main.prehratZvuk(1);
            }

            vybraneKarty.Add(btn);

            if (vybraneKarty.Count == 3)
            {
                blokovatVstup = true;
                TimerVyhodnoceni.Start();
            }
        }

        private void VyhodnoceniKaret(object sender, EventArgs e)
        {
            TimerVyhodnoceni.Stop();
            bool shoda = false;

            if (vybraneKarty[0].Tag.ToString() == vybraneKarty[1].Tag.ToString())
            {
                if (vybraneKarty[1].Tag.ToString() == vybraneKarty[2].Tag.ToString())
                {
                    shoda = true;
                }
            }

            if (shoda)
            {
                if (this.Parent is PEXESO main)
                {
                    main.prehratZvuk(2);
                }
                skoreHracu[aktualniHracIndex]++;
                if (AI != null)
                {
                    AI.OdstranKartyZPameti(vybraneKarty);
                }
                foreach (Button btn in vybraneKarty)
                {
                    vsechnyKarty.Remove(btn);
                    panel1.Controls.Remove(btn);
                }
            }
            else
            {
                foreach (Button btn in vybraneKarty)
                {
                    if (debugRezim)
                    {
                        int index = (int)btn.Tag;
                        btn.BackgroundImage = kartaZistkatObrazek(index);
                        btn.Text = "";
                    }
                    else
                    {
                        btn.BackgroundImage = null;
                        int indexKarty = int.Parse(btn.Name.Substring(5));
                        btn.Text = (indexKarty + 1).ToString();
                    }
                }
                if (this.Parent is PEXESO mainFail)
                {
                    mainFail.prehratZvuk(3);
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

        private void AI_tah(object sender, EventArgs e)
        {
            aiTimer.Stop();
            if (vsechnyKarty.Count < 3)
            {
                return;
            }

            if (AI != null)
            {
                List<Button> kartyProAI = AI.NavrhniTah(vsechnyKarty);
                foreach (Button btn in kartyProAI)
                {
                    ZpracujKliknuti(btn);
                    System.Threading.Thread.Sleep(500);
                    Application.DoEvents();
                }
            }
        }

        private void KonecHry()
        {
            
            int maxSkore = skoreHracu[0];
            for (int i = 1; i < skoreHracu.Length; i++)
            {
                if (skoreHracu[i] > maxSkore)
                {
                    maxSkore = skoreHracu[i];
                }
            }

            
            List<string> vitezove = new List<string>();
            for (int i = 0; i < skoreHracu.Length; i++)
            {
                if (skoreHracu[i] == maxSkore)
                {
                    vitezove.Add(jmenaHracu[i]);
                }
            }

            
            UlozVysledkyDoHistorie(vitezove);

            Endgame shrnutiPoHre = new Endgame(jmenaHracu, skoreHracu, rezimBarev);
            panel1.Hide();
            DialogResult otevri = shrnutiPoHre.ShowDialog();
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Menu());
            }
        }
        #endregion

        #region Ukládání a načítání hry
        public static string ZobrazFormSavegame(string nadpis, string text, string temporary)
        {
            Form savegameDialog = new Form();
            savegameDialog.Width = 400;
            savegameDialog.Height = 180;
            savegameDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            savegameDialog.Text = nadpis;
            savegameDialog.StartPosition = FormStartPosition.CenterScreen;
            savegameDialog.MaximizeBox = false;
            savegameDialog.MinimizeBox = false;

            Label textLabel = new Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Width = 340;
            textLabel.Text = text;

            TextBox textBox = new TextBox();
            textBox.Left = 20;
            textBox.Top = 50;
            textBox.Width = 340;
            textBox.Text = temporary;

            Button btn_Ok = new Button();
            btn_Ok.Text = "OK";
            btn_Ok.Left = 260;
            btn_Ok.Width = 100;
            btn_Ok.Top = 90;
            btn_Ok.DialogResult = DialogResult.OK;
            btn_Ok.Click += delegate (object s, EventArgs ev) { savegameDialog.Close(); };

            savegameDialog.Controls.Add(textBox);
            savegameDialog.Controls.Add(btn_Ok);
            savegameDialog.Controls.Add(textLabel);
            savegameDialog.AcceptButton = btn_Ok;

            if (savegameDialog.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }
            else
            {
                return "";
            }
        }

        public static int ZobrazFormPrepsatSave()
        {
            Form prepisDialog = new Form();
            prepisDialog.Width = 300;
            prepisDialog.Height = 180;
            prepisDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            prepisDialog.Text = "Kapacita naplněna";
            prepisDialog.StartPosition = FormStartPosition.CenterScreen;
            prepisDialog.MaximizeBox = false;
            prepisDialog.MinimizeBox = false;

            Label textLabel = new Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Width = 260;
            textLabel.Text = "Dosažen limit 3 her. Vyberte pozici k přepsání:";

            ComboBox combo = new ComboBox();
            combo.Left = 20;
            combo.Top = 50;
            combo.Width = 240;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Items.Add("Pozice 1 (savegame1.dat)");
            combo.Items.Add("Pozice 2 (savegame2.dat)");
            combo.Items.Add("Pozice 3 (savegame3.dat)");
            combo.SelectedIndex = 0;

            Button btnOk = new Button();
            btnOk.Text = "PŘEPSAT";
            btnOk.Left = 20;
            btnOk.Top = 90;
            btnOk.Width = 100;
            btnOk.DialogResult = DialogResult.OK;

            Button btnZrusit = new Button();
            btnZrusit.Text = "ZRUŠIT";
            btnZrusit.Left = 160;
            btnZrusit.Top = 90;
            btnZrusit.Width = 100;
            btnZrusit.DialogResult = DialogResult.Cancel;

            prepisDialog.Controls.Add(textLabel);
            prepisDialog.Controls.Add(combo);
            prepisDialog.Controls.Add(btnOk);
            prepisDialog.Controls.Add(btnZrusit);
            prepisDialog.AcceptButton = btnOk;

            if (prepisDialog.ShowDialog() == DialogResult.OK)
            {
                if (combo.SelectedIndex == 0)
                {
                    return 1;
                }
                else if (combo.SelectedIndex == 1)
                {
                    return 2;
                }
                else if (combo.SelectedIndex == 2)
                {
                    return 3;
                }
            }
            return 0;
        }

        private void UlozHru(string nazevHry)
        {
            string souborKZapisu = "";
            string existujiciSoubor = "";
            string volnySoubor = "";

            for (int i = 1; i <= 3; i++)
            {
                string soubor = @"..\..\Config\savegame" + i + ".dat";
                if (File.Exists(soubor))
                {
                    FileStream fsTest = new FileStream(soubor, FileMode.Open, FileAccess.Read);
                    BinaryReader brTest = new BinaryReader(fsTest);
                    string testNazev = brTest.ReadString();
                    brTest.Close();
                    fsTest.Close();

                    if (testNazev == nazevHry)
                    {
                        existujiciSoubor = soubor;
                        break;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(volnySoubor))
                    {
                        volnySoubor = soubor;
                    }
                }
            }

            if (!string.IsNullOrEmpty(existujiciSoubor))
            {
                DialogResult vysledek = MessageBox.Show("Hra již existuje. Přepsat?", "Duplikát", MessageBoxButtons.YesNo);
                if (vysledek == DialogResult.Yes)
                {
                    souborKZapisu = existujiciSoubor;
                }
                else
                {
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(volnySoubor))
            {
                souborKZapisu = volnySoubor;
            }
            else
            {
                int cisloSouboru = ZobrazFormPrepsatSave();
                if (cisloSouboru > 0)
                {
                    souborKZapisu = @"..\..\Config\savegame" + cisloSouboru + ".dat";
                }
                else
                {
                    return;
                }
            }

            FileStream fsZapis = new FileStream(souborKZapisu, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fsZapis);

            bw.Write(nazevHry);
            bw.Write(aktualniHracIndex);
            bw.Write(celkovyPocetKaret);
            bw.Write((byte)jmenaHracu.Count);

            bw.Write(obtiznostAI);

            for (int i = 0; i < jmenaHracu.Count; i++)
            {
                bw.Write(jmenaHracu[i]);
                bw.Write(skoreHracu[i]);
            }

            bw.Write(herniPoleProSave.Count);
            foreach (Button b in herniPoleProSave)
            {
                bool jeAktivni = false;
                foreach (Button kartaVeHre in vsechnyKarty)
                {
                    if (kartaVeHre == b)
                    {
                        jeAktivni = true;
                    }
                }

                bw.Write(jeAktivni);
                bw.Write((int)b.Tag);
            }

            bw.Close();
            fsZapis.Close();
            MessageBox.Show("Uloženo!");
        }

        private void NactiHru(string nazevHry)
        {
            string spravnySoubor = "";

            for (int i = 1; i <= 3; i++)
            {
                string soubor = @"..\..\Config\savegame" + i + ".dat";
                if (File.Exists(soubor))
                {
                    FileStream fsTest = new FileStream(soubor, FileMode.Open, FileAccess.Read);
                    BinaryReader brTest = new BinaryReader(fsTest);
                    string testNazev = brTest.ReadString();
                    brTest.Close();
                    fsTest.Close();

                    if (testNazev == nazevHry)
                    {
                        spravnySoubor = soubor;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(spravnySoubor))
            {
                this.Close();
                return;
            }

            FileStream fsCteni = new FileStream(spravnySoubor, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fsCteni);

            string nepotrebnyNazev = br.ReadString();
            aktualniHracIndex = br.ReadInt32();
            celkovyPocetKaret = br.ReadByte();
            byte pocetHracuNacteno = br.ReadByte();

            obtiznostAI = br.ReadByte();

            jmenaHracu.Clear();
            skoreHracu = new int[pocetHracuNacteno];

            for (int i = 0; i < pocetHracuNacteno; i++)
            {
                jmenaHracu.Add(br.ReadString());
                skoreHracu[i] = br.ReadInt32();
            }

            int pocetSloupcu = 6;

            if (celkovyPocetKaret == 45)
            {
                pocetSloupcu = 9;
            }
            else if (celkovyPocetKaret == 51)
            {
                pocetSloupcu = 10;
            }
            else if (celkovyPocetKaret == 60)
            {
                pocetSloupcu = 10;
            }

            vsechnyKarty.Clear();
            herniPoleProSave.Clear();

            int pocetKaretUlozeno = br.ReadInt32();

            for (int i = 0; i < pocetKaretUlozeno; i++)
            {
                bool jeAktivni = br.ReadBoolean();
                int tagValue = br.ReadInt32();

                VytvorKartu(i, tagValue, pocetSloupcu, jeAktivni);
            }

            br.Close();
            fsCteni.Close();

            AktualizujUI();
        }

        
        private void UlozVysledkyDoHistorie(List<string> vitezove)
        {
            List<string> dbJmena = new List<string>();
            List<int> dbVyhry = new List<int>();
            List<int> dbProhry = new List<int>();
            List<int> dbKarty = new List<int>();
            List<int> dbKartyPosledniHra = new List<int>();
            List<int> dbCelkemKaretPosledni = new List<int>();

            if (File.Exists(cestaHistorie))
            {
                FileStream fsCteni = new FileStream(cestaHistorie, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fsCteni);

                if (fsCteni.Length > 0)
                {
                    int pocetZaznamu = br.ReadInt32();
                    for (int i = 0; i < pocetZaznamu; i++)
                    {
                        dbJmena.Add(br.ReadString());
                        dbVyhry.Add(br.ReadInt32());
                        dbProhry.Add(br.ReadInt32());
                        dbKarty.Add(br.ReadInt32());
                        dbKartyPosledniHra.Add(br.ReadInt32());
                        dbCelkemKaretPosledni.Add(br.ReadInt32());
                    }
                }

                br.Close();
                fsCteni.Close();
            }

            for (int i = 0; i < jmenaHracu.Count; i++)
            {
                string jmeno = jmenaHracu[i];
                int body = skoreHracu[i];
                string vysledek = "Prohra";

                
                bool jeVitez = false;
                for (int v = 0; v < vitezove.Count; v++)
                {
                    if (jmeno == vitezove[v])
                    {
                        jeVitez = true;
                    }
                }

                if (jeVitez)
                {
                    
                    if (vitezove.Count > 1)
                    {
                        vysledek = "Remíza";
                    }
                    else
                    {
                        vysledek = "Výhra";
                    }
                }

                bool nalezen = false;
                for (int j = 0; j < dbJmena.Count; j++)
                {
                    if (dbJmena[j] == jmeno)
                    {
                        nalezen = true;
                        dbKarty[j] += body;

                        dbKartyPosledniHra[j] = body;
                        dbCelkemKaretPosledni[j] = celkovyPocetKaret;

                        if (vysledek == "Výhra")
                        {
                            dbVyhry[j] += 1;
                        }
                        else if (vysledek == "Prohra")
                        {
                            dbProhry[j] += 1;
                        }
                        
                    }
                }

                if (!nalezen)
                {
                    dbJmena.Add(jmeno);
                    dbKarty.Add(body);
                    dbKartyPosledniHra.Add(body);
                    dbCelkemKaretPosledni.Add(celkovyPocetKaret);

                    if (vysledek == "Výhra")
                    {
                        dbVyhry.Add(1);
                        dbProhry.Add(0);
                    }
                    else if (vysledek == "Prohra")
                    {
                        dbVyhry.Add(0);
                        dbProhry.Add(1);
                    }
                    else 
                    {
                        dbVyhry.Add(0);
                        dbProhry.Add(0);
                    }
                }
            }

            FileStream fsZapis = new FileStream(cestaHistorie, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fsZapis);

            bw.Write(dbJmena.Count);
            for (int i = 0; i < dbJmena.Count; i++)
            {
                bw.Write(dbJmena[i]);
                bw.Write(dbVyhry[i]);
                bw.Write(dbProhry[i]);
                bw.Write(dbKarty[i]);
                bw.Write(dbKartyPosledniHra[i]);
                bw.Write(dbCelkemKaretPosledni[i]);
            }

            bw.Close();
            fsZapis.Close();
        }
        #endregion
    }
}