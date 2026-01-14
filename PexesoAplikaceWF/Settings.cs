using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
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

        private void button_return_Click(object sender, EventArgs e)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            this.Hide();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (!File.Exists(cesta))
            {
                MessageBox.Show("Soubor settings.json nebyl nalezen!");
                return;
            }

            string json = File.ReadAllText(cesta);
            JObject data = JObject.Parse(json);

            int pocet_hracu = (int)data["pocet_hracu"];
            int zvuk = (int)data["zvuk"];
            string ai_obt = (string)data["ai_obt"];
            int pocet_karet = (int)data["pocet_karet"];
            int vzhled_karet = (int)data["vzhled_karet"];
            string barevnyRezim = (string)data["barevny_rezim"];

            switch (pocet_hracu)
            {
                case 1:
                    combo_pocet_hracu.SelectedIndex = 0;
                    break;
                case 2:
                    combo_pocet_hracu.SelectedIndex = 1;
                    break;
                case 3:
                    combo_pocet_hracu.SelectedIndex = 2;
                    break;
                case 4:
                    combo_pocet_hracu.SelectedIndex = 3;
                    break;
                case 5:
                    combo_pocet_hracu.SelectedIndex = 4;
                    break;
                case 6:
                    combo_pocet_hracu.SelectedIndex = 5;
                    break;
                default:
                    combo_pocet_hracu.SelectedIndex = 0;
                    break;
            }

            if (zvuk == 1)
            {
                combo_zvuk.SelectedIndex = 0;
            }
            else
            {
                combo_zvuk.SelectedIndex = 1;
            }

            if (ai_obt == "lehka")
            {
                combo_dif.SelectedIndex = 0;
            }
            else if (ai_obt == "normalni")
            {
                combo_dif.SelectedIndex = 1;
            }
            else if (ai_obt == "tezka")
            {
                combo_dif.SelectedIndex = 2;
            }
            else
            {
                combo_dif.SelectedIndex = 0;
            }

            if (pocet_karet == 30)
            {
                combo_pocet.SelectedIndex = 0;
            }
            else if (pocet_karet == 45)
            {
                combo_pocet.SelectedIndex = 1;
            }
            else if (pocet_karet == 51)
            {
                combo_pocet.SelectedIndex = 2;
            }
            else
            {
                combo_pocet.SelectedIndex = 0;
            }

            combo_vzhled.SelectedIndex = Math.Max(0, Math.Min(vzhled_karet - 1, combo_vzhled.Items.Count - 1));

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

        private void AktualizujVzhled(string rezim)
        {
            if (rezim == "tmavy")
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;

                foreach (Control prvek in this.Controls)
                {
                    prvek.ForeColor = Color.White;
                    if (prvek is Label)
                    {
                        prvek.BackColor = Color.Transparent;
                    }
                    else
                    {
                        prvek.BackColor = Color.FromArgb(30, 30, 30);
                    }
                }
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;

                foreach (Control prvek in this.Controls)
                {
                    prvek.ForeColor = Color.Black;
                    if (prvek is Label)
                    {
                        prvek.BackColor = Color.Transparent;
                    }
                    else
                    {
                        prvek.BackColor = Color.White;
                    }
                }
            }
        }

        private void combo_pocet_hracu_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            data["pocet_hracu"] = 1 + combo_pocet_hracu.SelectedIndex;
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private void combo_zvuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            data["zvuk"] = 1 + combo_zvuk.SelectedIndex;
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private void combo_dif_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            data["ai_obt"] = combo_dif.Items[combo_dif.SelectedIndex].ToString();
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private void combo_pocet_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            data["pocet_karet"] = combo_pocet.Items[combo_pocet.SelectedIndex].ToString();
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private void combo_vzhled_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            data["vzhled_karet"] = combo_vzhled.Items[combo_vzhled.SelectedIndex].ToString();
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private void comboBarvy_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject data = JObject.Parse(File.ReadAllText(cesta));
            string vybranyRezim = "bily";

            if (comboBarvy.SelectedIndex == 0)
            {
                vybranyRezim = "bily";
            }
            else
            {
                vybranyRezim = "tmavy";
            }

            data["barevny_rezim"] = vybranyRezim;
            File.WriteAllText(cesta, data.ToString(Newtonsoft.Json.Formatting.Indented));
            AktualizujVzhled(vybranyRezim);
        }
    }
}