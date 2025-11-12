using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PexesoAplikaceWF
{
    public partial class PlayerNames : Form
    {
        string cesta = @"..\..\Config\settings.json";
        List<TextBox> hraciTextBoxy = new List<TextBox>();

        public PlayerNames()
        {
            InitializeComponent();
        }

        private void PlayerNames_Load(object sender, EventArgs e)
        {
            string json = File.ReadAllText(cesta);
            JObject data = JObject.Parse(json);
            int pocet_hracu = (int)data["pocet_hracu"];

            int y = 30;
            for (int i = 0; i < pocet_hracu; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Hráč: "+(i+1);
                lbl.Location = new System.Drawing.Point(20, y + 5);
                lbl.AutoSize = true;
                Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Name = "textBox"+(i+1);
                txt.Location = new System.Drawing.Point(100, y);
                txt.Width = 150;
                Controls.Add(txt);

                hraciTextBoxy.Add(txt);
                y += 35;
            }

            Button btnPotvrdit = new Button();
            btnPotvrdit.Text = "Potvrdit";
            btnPotvrdit.Location = new System.Drawing.Point(100, y + 10);
            btnPotvrdit.Click += BtnPotvrdit_Click;
            Controls.Add(btnPotvrdit);
        }

        private void BtnPotvrdit_Click(object sender, EventArgs e)
        {
            foreach (var txt in hraciTextBoxy)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Je potreba vyplnit jmena vsech hracu");
                    return;
                }
            }

            string json = File.ReadAllText(cesta);
            JObject data = JObject.Parse(json);

            JArray jmena = new JArray();
            foreach (var txt in hraciTextBoxy)
                jmena.Add(txt.Text);

            data["hraci"] = jmena;

            File.WriteAllText(cesta, data.ToString());
            Close();
        }
    }
}
