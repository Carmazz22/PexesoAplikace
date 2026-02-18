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
    public partial class LoadGame : Form
    {
        private string cestaSave = @"..\..\Config\savegame.json";
        private string cestaNastaveni = @"..\..\Config\settings.json";

        private DataGridView dgvUlozeneHry;
        private Button btnNacist;
        private Button btnZpet;
        private Label lblNadpis;

        public LoadGame()
        {
            InitializeComponent();
            InicilizujUI();
            NactiSeznamHer();
            AplikujBarevnyRezim();
        }

        private void InicilizujUI()
        {
            this.Size = new Size(600, 500);
            this.Text = "Načíst uloženou hru";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblNadpis = new Label();
            lblNadpis.Text = "VYBERTE HRU K NAČTENÍ";
            lblNadpis.Location = new Point(20, 20);
            lblNadpis.Size = new Size(560, 30);
            lblNadpis.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblNadpis.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblNadpis);

            dgvUlozeneHry = new DataGridView();
            dgvUlozeneHry.Location = new Point(20, 70);
            dgvUlozeneHry.Size = new Size(540, 300);
            dgvUlozeneHry.AllowUserToAddRows = false;
            dgvUlozeneHry.AllowUserToDeleteRows = false;
            dgvUlozeneHry.ReadOnly = true;
            dgvUlozeneHry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUlozeneHry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUlozeneHry.RowHeadersVisible = false;
            dgvUlozeneHry.MultiSelect = false;

            dgvUlozeneHry.Columns.Add("Nazev", "Název uložení");
            dgvUlozeneHry.Columns.Add("Datum", "Datum");
            dgvUlozeneHry.Columns.Add("Hraci", "Hráči");

            this.Controls.Add(dgvUlozeneHry);

            btnNacist = new Button();
            btnNacist.Text = "NAČÍST VYBRANOU HRU";
            btnNacist.Location = new Point(360, 390);
            btnNacist.Size = new Size(200, 40);
            btnNacist.BackColor = Color.LightGreen;
            btnNacist.Click += BtnNacist_Click;
            this.Controls.Add(btnNacist);

            btnZpet = new Button();
            btnZpet.Text = "ZPĚT";
            btnZpet.Location = new Point(20, 390);
            btnZpet.Size = new Size(100, 40);
            btnZpet.Click += BtnZpet_Click;
            this.Controls.Add(btnZpet);
        }

        private void NactiSeznamHer()
        {
            dgvUlozeneHry.Rows.Clear();
            if (!File.Exists(cestaSave)) return;

            try
            {
                string json = File.ReadAllText(cestaSave);
                // Očekáváme Dictionary, kde klíč je název a hodnota je objekt hry
                var ulozeneHry = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);

                if (ulozeneHry != null)
                {
                    foreach (var zaznam in ulozeneHry)
                    {
                        string nazev = zaznam.Key;
                        var data = zaznam.Value;
                        DateTime datum = (DateTime)data["Datum"];
                        JArray hraciArray = (JArray)data["Hraci"];
                        string hraciStr = string.Join(", ", hraciArray.ToObject<List<string>>());

                        dgvUlozeneHry.Rows.Add(nazev, datum.ToString("g"), hraciStr);
                    }
                }
            }
            catch (Exception ex)
            {
                // Pokud je soubor prázdný nebo má špatný formát
                MessageBox.Show("Nepodařilo se načíst seznam her. Soubor může být poškozen.\n" + ex.Message);
            }
        }

        private void BtnNacist_Click(object sender, EventArgs e)
        {
            if (dgvUlozeneHry.SelectedRows.Count > 0)
            {
                string nazevHry = dgvUlozeneHry.SelectedRows[0].Cells["Nazev"].Value.ToString();

                // Spustíme hru a předáme jí název savu
                Game_Singleplayer hra = new Game_Singleplayer(nazevHry);
                hra.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vyberte hru ze seznamu.");
            }
        }

        private void BtnZpet_Click(object sender, EventArgs e)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            this.Close();
        }

        private void AplikujBarevnyRezim()
        {
            if (File.Exists(cestaNastaveni))
            {
                try
                {
                    string json = File.ReadAllText(cestaNastaveni);
                    JObject data = JObject.Parse(json);
                    string barevnyRezim = (string)data["barevny_rezim"];

                    if (barevnyRezim == "tmavy")
                    {
                        this.BackColor = Color.FromArgb(45, 45, 48);
                        lblNadpis.ForeColor = Color.White;
                        dgvUlozeneHry.BackgroundColor = Color.FromArgb(30, 30, 30);
                        dgvUlozeneHry.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                        dgvUlozeneHry.DefaultCellStyle.ForeColor = Color.White;
                        dgvUlozeneHry.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                        dgvUlozeneHry.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                        btnZpet.BackColor = Color.FromArgb(60, 60, 60);
                        btnZpet.ForeColor = Color.White;
                    }
                }
                catch { }
            }
        }
    }
}