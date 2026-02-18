using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class Settings : Form
    {
        string cesta = @"..\..\Config\settings.json";

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (!File.Exists(cesta))
            {
                VytvorVychoziSettings();
            }

            try
            {
                string json = File.ReadAllText(cesta);
                JObject data = JObject.Parse(json);

                // 1. Pocet hracu
                if (data["pocet_hracu"] != null)
                {
                    int pocet_hracu = (int)data["pocet_hracu"];
                    if (pocet_hracu > 0 && combo_pocet_hracu.Items.Count >= pocet_hracu)
                    {
                        combo_pocet_hracu.SelectedIndex = pocet_hracu - 1;
                    }
                    else
                    {
                        combo_pocet_hracu.SelectedIndex = 0;
                    }
                }

                // 2. Zvuk
                if (data["zvuk"] != null)
                {
                    int zvuk = (int)data["zvuk"];
                    if (zvuk == 1)
                    {
                        combo_zvuk.SelectedIndex = 0;
                    }
                    else
                    {
                        combo_zvuk.SelectedIndex = 1;
                    }
                }

                // 3. Obtiznost AI
                if (data["ai_obt"] != null)
                {
                    string ai_obt = (string)data["ai_obt"];
                    if (ai_obt == "lehka")
                    {
                        combo_dif.SelectedIndex = 0;
                    }
                    else if (ai_obt == "tezka")
                    {
                        combo_dif.SelectedIndex = 2;
                    }
                    else
                    {
                        combo_dif.SelectedIndex = 1;
                    }
                }

                // 4. Pocet karet
                if (data["pocet_karet"] != null)
                {
                    string pocetKaretStr = data["pocet_karet"].ToString();
                    if (pocetKaretStr == "30")
                    {
                        combo_pocet.SelectedIndex = 0;
                    }
                    else if (pocetKaretStr == "45")
                    {
                        combo_pocet.SelectedIndex = 1;
                    }
                    else if (pocetKaretStr == "51")
                    {
                        combo_pocet.SelectedIndex = 2;
                    }
                    else
                    {
                        combo_pocet.SelectedIndex = 0;
                    }
                }

                // 5. Vzhled karet
                if (data["vzhled_karet"] != null)
                {
                    int vzhled = (int)data["vzhled_karet"];
                    if (vzhled >= 1 && vzhled <= 3)
                    {
                        combo_vzhled.SelectedIndex = vzhled - 1;
                    }
                    else
                    {
                        combo_vzhled.SelectedIndex = 0;
                    }
                }
                else
                {
                    combo_vzhled.SelectedIndex = 0;
                }

                // 6. Barevny rezim
                if (data["barevny_rezim"] != null)
                {
                    string barevnyRezim = (string)data["barevny_rezim"];
                    if (barevnyRezim == "bily")
                    {
                        comboBarvy.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBarvy.SelectedIndex = 1;
                    }
                    AktualizujVzhled(barevnyRezim);
                }
                else
                {
                    AktualizujVzhled("bily");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání nastavení: " + ex.Message);
            }
        }

        private void combo_pocet_hracu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pocet = combo_pocet_hracu.SelectedIndex + 1;
            UlozDoJsonu("pocet_hracu", pocet);
        }

        private void combo_zvuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hodnota;
            if (combo_zvuk.SelectedIndex == 0)
            {
                hodnota = 1;
            }
            else
            {
                hodnota = 2;
            }
            UlozDoJsonu("zvuk", hodnota);
        }

        private void combo_dif_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hodnota = "normalni";

            if (combo_dif.SelectedIndex == 0)
            {
                hodnota = "lehka";
            }
            else if (combo_dif.SelectedIndex == 2)
            {
                hodnota = "tezka";
            }
            else
            {
                hodnota = "normalni";
            }

            UlozDoJsonu("ai_obt", hodnota);
        }

        private void combo_pocet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_pocet.SelectedItem != null)
            {
                UlozDoJsonu("pocet_karet", combo_pocet.SelectedItem.ToString());
            }
        }

        private void combo_vzhled_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ulozi 1, 2 nebo 3 podle indexu (0, 1, 2)
            UlozDoJsonu("vzhled_karet", combo_vzhled.SelectedIndex + 1);
        }

        private void comboBarvy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rezim;
            if (comboBarvy.SelectedIndex == 0)
            {
                rezim = "bily";
            }
            else
            {
                rezim = "tmavy";
            }

            UlozDoJsonu("barevny_rezim", rezim);
            AktualizujVzhled(rezim);
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            this.Hide();
        }

        private void UlozDoJsonu(string klic, object hodnota)
        {
            try
            {
                string json = "";
                JObject data;

                if (File.Exists(cesta))
                {
                    json = File.ReadAllText(cesta);
                    data = JObject.Parse(json);
                }
                else
                {
                    data = new JObject();
                }

                data[klic] = JToken.FromObject(hodnota);
                File.WriteAllText(cesta, data.ToString(Formatting.Indented));
            }
            catch
            {
            }
        }

        private void AktualizujVzhled(string rezim)
        {
            Color pozadi;
            Color text;

            if (rezim == "tmavy")
            {
                pozadi = Color.FromArgb(45, 45, 48);
                text = Color.White;
            }
            else
            {
                pozadi = Color.White;
                text = Color.Black;
            }

            this.BackColor = pozadi;
            this.ForeColor = text;

            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.ForeColor = text;
                }

                if (c is Button)
                {
                    if (rezim == "tmavy")
                    {
                        c.BackColor = Color.FromArgb(60, 60, 60);
                    }
                    else
                    {
                        c.BackColor = Color.White;
                    }
                    c.ForeColor = text;
                }

                if (c is ComboBox)
                {
                    if (rezim == "tmavy")
                    {
                        c.BackColor = Color.FromArgb(60, 60, 60);
                    }
                    else
                    {
                        c.BackColor = Color.White;
                    }
                    c.ForeColor = text;
                }
            }
        }

        private void VytvorVychoziSettings()
        {
            var data = new
            {
                pocet_hracu = 1,
                zvuk = 1,
                ai_obt = "normalni",
                pocet_karet = "30",
                vzhled_karet = 1,
                barevny_rezim = "bily"
            };
            File.WriteAllText(cesta, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}