using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class Score : Form
    {
        private string cestaHistorie = @"..\..\Config\history.json";
        private string cestaNastaveni = @"..\..\Config\settings.json";

        private DataGridView dgvScore;
        private TextBox txtHledat;
        private Label lblHledat;
        private List<AgregovanyZaznam> vsechnyZaznamy = new List<AgregovanyZaznam>();

        public Score()
        {
            InitializeComponent();
            InicilizujKomponentyUI();
            this.Load += new EventHandler(Score_Load);
        }

        private void InicilizujKomponentyUI()
        {
            lblHledat = new Label();
            lblHledat.Text = "Hledat:";
            lblHledat.Location = new Point(20, 20);
            lblHledat.AutoSize = true;
            this.Controls.Add(lblHledat);

            txtHledat = new TextBox();
            txtHledat.Location = new Point(80, 18);
            txtHledat.Size = new Size(200, 25);
            txtHledat.TextChanged += new EventHandler(TxtHledat_TextChanged);
            this.Controls.Add(txtHledat);

            dgvScore = new DataGridView();
            dgvScore.Location = new Point(20, 60);
            dgvScore.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 150);
            dgvScore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvScore.AllowUserToAddRows = false;
            dgvScore.AllowUserToDeleteRows = false;
            dgvScore.ReadOnly = true;
            dgvScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvScore.Columns.Add("Hrac", "Jméno hráče");
            dgvScore.Columns.Add("PocetHer", "Počet her");
            dgvScore.Columns.Add("Vyhry", "Výhry");
            dgvScore.Columns.Add("Remizy", "Remízy");
            dgvScore.Columns.Add("Prohry", "Prohry");
            dgvScore.Columns.Add("CelkemKaret", "Nasbírané karty celkem");

            this.Controls.Add(dgvScore);

            if (panelScore != null)
            {
                panelScore.Visible = false;
                this.Controls.Remove(panelScore);
            }
        }

        private void Score_Load(object sender, EventArgs e)
        {
            AplikujBarevnyRezim();
            NactiAgregovanouHistorii();
        }

        private void NactiAgregovanouHistorii()
        {
            vsechnyZaznamy.Clear();

            if (File.Exists(cestaHistorie) == false)
            {
                return;
            }

            try
            {
                string json = File.ReadAllText(cestaHistorie);
                List<ScoreRecord> rawData = JsonConvert.DeserializeObject<List<ScoreRecord>>(json);

                if (rawData == null)
                {
                    rawData = new List<ScoreRecord>();
                }

                Dictionary<string, AgregovanyZaznam> seskupeni = new Dictionary<string, AgregovanyZaznam>();

                foreach (ScoreRecord zaznam in rawData)
                {
                    if (seskupeni.ContainsKey(zaznam.Hrac) == false)
                    {
                        AgregovanyZaznam novyZaznam = new AgregovanyZaznam();
                        novyZaznam.Jmeno = zaznam.Hrac;
                        novyZaznam.PocetHer = 0;
                        novyZaznam.Vyhry = 0;
                        novyZaznam.Remizy = 0;
                        novyZaznam.Prohry = 0;
                        novyZaznam.CelkemKaret = 0;
                        seskupeni.Add(zaznam.Hrac, novyZaznam);
                    }

                    AgregovanyZaznam existujici = seskupeni[zaznam.Hrac];
                    existujici.PocetHer = existujici.PocetHer + 1;
                    existujici.CelkemKaret = existujici.CelkemKaret + zaznam.PocetKaret;

                    if (zaznam.Vysledek == "Výhra")
                    {
                        existujici.Vyhry = existujici.Vyhry + 1;
                    }
                    else if (zaznam.Vysledek == "Remíza")
                    {
                        existujici.Remizy = existujici.Remizy + 1;
                    }
                    else if (zaznam.Vysledek == "Prohra")
                    {
                        existujici.Prohry = existujici.Prohry + 1;
                    }
                }

                List<AgregovanyZaznam> vyslednyList = new List<AgregovanyZaznam>();
                foreach (AgregovanyZaznam polozka in seskupeni.Values)
                {
                    vyslednyList.Add(polozka);
                }

                vyslednyList.Sort(PorovnejZaznamy);
                vsechnyZaznamy = vyslednyList;

                FiltrujData("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int PorovnejZaznamy(AgregovanyZaznam a, AgregovanyZaznam b)
        {
            if (a.Vyhry != b.Vyhry)
            {
                return b.Vyhry.CompareTo(a.Vyhry);
            }

            return b.CelkemKaret.CompareTo(a.CelkemKaret);
        }

        private void TxtHledat_TextChanged(object sender, EventArgs e)
        {
            FiltrujData(txtHledat.Text);
        }

        private void FiltrujData(string hledanyText)
        {
            dgvScore.Rows.Clear();
            string lowerText = hledanyText.ToLower();

            List<AgregovanyZaznam> filtrovane = new List<AgregovanyZaznam>();

            foreach (AgregovanyZaznam z in vsechnyZaznamy)
            {
                bool shoda = false;

                if (z.Jmeno.ToLower().Contains(lowerText) == true)
                {
                    shoda = true;
                }
                else if (z.PocetHer.ToString().Contains(lowerText) == true)
                {
                    shoda = true;
                }
                else if (z.Vyhry.ToString().Contains(lowerText) == true)
                {
                    shoda = true;
                }
                else if (z.Remizy.ToString().Contains(lowerText) == true)
                {
                    shoda = true;
                }
                else if (z.Prohry.ToString().Contains(lowerText) == true)
                {
                    shoda = true;
                }
                else if (z.CelkemKaret.ToString().Contains(lowerText) == true)
                {
                    shoda = true;
                }

                if (shoda == true)
                {
                    filtrovane.Add(z);
                }
            }

            foreach (AgregovanyZaznam z in filtrovane)
            {
                dgvScore.Rows.Add(
                    z.Jmeno,
                    z.PocetHer,
                    z.Vyhry,
                    z.Remizy,
                    z.Prohry,
                    z.CelkemKaret
                );
            }
        }

        private void AplikujBarevnyRezim()
        {
            if (File.Exists(cestaNastaveni) == true)
            {
                try
                {
                    string json = File.ReadAllText(cestaNastaveni);
                    JObject data = JObject.Parse(json);
                    string barevnyRezim = (string)data["barevny_rezim"];

                    if (barevnyRezim == "tmavy")
                    {
                        this.BackColor = Color.FromArgb(45, 45, 48);
                        lblHledat.ForeColor = Color.White;
                        txtHledat.BackColor = Color.FromArgb(60, 60, 60);
                        txtHledat.ForeColor = Color.White;

                        dgvScore.BackgroundColor = Color.FromArgb(30, 30, 30);
                        dgvScore.GridColor = Color.Gray;
                        dgvScore.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                        dgvScore.DefaultCellStyle.ForeColor = Color.White;
                        dgvScore.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                        dgvScore.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvScore.EnableHeadersVisualStyles = false;

                        foreach (Control ctrl in this.Controls)
                        {
                            if (ctrl is Button)
                            {
                                ctrl.BackColor = Color.FromArgb(60, 60, 60);
                                ctrl.ForeColor = Color.White;
                            }
                        }
                    }
                    else
                    {
                        this.BackColor = SystemColors.Control;
                        lblHledat.ForeColor = Color.Black;
                    }
                }
                catch
                {
                }
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            Form Game_Singleplayer = new Game_Singleplayer(null);
            Game_Singleplayer.Show();
            this.Hide();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            Form menu = new Menu1();
            menu.Show();
            this.Hide();
        }

        private class ScoreRecord
        {
            public DateTime Datum { get; set; }
            public string Hrac { get; set; }
            public string Vysledek { get; set; }
            public int PocetKaret { get; set; }
            public int CelkemKaretVeHre { get; set; }
        }

        private class AgregovanyZaznam
        {
            public string Jmeno { get; set; }
            public int PocetHer { get; set; }
            public int Vyhry { get; set; }
            public int Remizy { get; set; }
            public int Prohry { get; set; }
            public int CelkemKaret { get; set; }
        }
    }
}