using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class PlayerNames : Form
    {
        string cestaHraci = @"..\..\Config\hraci.json";
        string cestaNastaveni = @"..\..\Config\settings.json";
        List<TextBox> hraciTextBoxy = new List<TextBox>();

        public PlayerNames()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void PlayerNames_Load(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(cestaNastaveni);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            if (!File.Exists(cestaNastaveni))
            {
                JObject defaultSettings = new JObject
                {
                    ["pocet_hracu"] = 1,
                    ["ai_obt"] = "lehka"
                };
                File.WriteAllText(cestaNastaveni, defaultSettings.ToString());
            }

            JObject nastaveni = JObject.Parse(File.ReadAllText(cestaNastaveni));
            int pocet_hracu = nastaveni["pocet_hracu"] != null ? (int)nastaveni["pocet_hracu"] : 1;

            JArray existujiciJmena = new JArray();
            if (File.Exists(cestaHraci))
            {
                existujiciJmena = (JArray)JObject.Parse(File.ReadAllText(cestaHraci))["hraci"];
            }

            int y = 30;
            for (int i = 0; i < pocet_hracu; i++)
            {
                Label lbl = new Label { Text = $"Hráč {i + 1}:", Location = new Point(20, y + 5), AutoSize = true };
                TextBox txt = new TextBox { Name = "textBox" + i, Location = new Point(120, y), Width = 150 };

                txt.Text = (i < existujiciJmena.Count) ? existujiciJmena[i].ToString() : $"Hráč {i + 1}";

                this.Controls.Add(lbl);
                this.Controls.Add(txt);
                hraciTextBoxy.Add(txt);
                y += 35;
            }

            Button btnPotvrdit = new Button { Text = "Potvrdit", Location = new Point(120, y + 10), Size = new Size(100, 30) };
            btnPotvrdit.Click += BtnPotvrdit_Click;
            this.Controls.Add(btnPotvrdit);
        }

        private void BtnPotvrdit_Click(object sender, EventArgs e)
        {
            JArray jmena = new JArray();
            foreach (var txt in hraciTextBoxy)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Vyplňte všechna jména!");
                    return;
                }
                jmena.Add(txt.Text.Trim());
            }

            File.WriteAllText(cestaHraci, new JObject { ["hraci"] = jmena }.ToString());

            this.Hide();
            using (Game_Singleplayer hra = new Game_Singleplayer())
            {
                hra.ShowDialog();
            }
            this.Close();
        }
    }
}