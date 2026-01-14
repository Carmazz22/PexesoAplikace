using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class Score : Form
    {
        // Cesty k souborům
        private string cestaSave = @"..\..\Config\savegame.json";
        private string cestaNastaveni = @"..\..\Config\settings.json";

        public Score()
        {
            InitializeComponent();
            this.Load += new EventHandler(Score_Load);
        }

        private void Score_Load(object sender, EventArgs e)
        {
            AplikujBarevnyRezim();
            NactiStavHry();
        }

        private void NactiStavHry()
        {
            if (panelScore == null) return;

            panelScore.Controls.Clear();
            panelScore.AutoScroll = true;

            if (!File.Exists(cestaSave))
            {
                Label lblInfo = new Label
                {
                    Text = "Žádná uložená hra nebyla nalezena.",
                    AutoSize = true,
                    Location = new Point(10, 10),
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic)
                };
                panelScore.Controls.Add(lblInfo);
                return;
            }

            try
            {
                string json = File.ReadAllText(cestaSave);
                JObject data = JObject.Parse(json);

                JArray hraci = (JArray)data["Hraci"];
                JArray skore = (JArray)data["Skore"];
                int indexNaRade = (int)data["AktualniHracIndex"];

                int y = 15;
                for (int i = 0; i < hraci.Count; i++)
                {
                    Label lbl = new Label();
                    lbl.Text = $"{hraci[i]}: {skore[i]} bodů";
                    lbl.Location = new Point(10, y);
                    lbl.AutoSize = true;
                    lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                    if (i == indexNaRade)
                    {
                        lbl.Text += " - na řadě";
                        lbl.ForeColor = Color.SteelBlue;
                    }
                    else
                    {
                        lbl.ForeColor = (this.BackColor.R < 100) ? Color.White : Color.Black;
                    }

                    panelScore.Controls.Add(lbl);
                    y += 40;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
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
                        panelScore.BackColor = Color.FromArgb(30, 30, 30);

                        // Přebarvíme i tlačítka na formu
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
                        panelScore.BackColor = Color.WhiteSmoke;
                    }
                }
                catch { /* Ignorovat chyby v nastavení */ }
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            // Spustí úplně novou hru (false = nenačítat save)
            Form Game_Singleplayer = new Game_Singleplayer(false);
            Game_Singleplayer.Show();
            this.Hide();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            Form menu = new Menu1();
            menu.Show();
            this.Hide();
        }
    }
}