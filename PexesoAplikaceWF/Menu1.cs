using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;

namespace PexesoAplikaceWF
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        string cesta = @"..\..\Config\settings.json";

        private void button_newGame_Click(object sender, EventArgs e)
        {
            PlayerNames playerNamesForm = new PlayerNames();
            playerNamesForm.Show();
            this.Hide();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            Form settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_score_Click(object sender, EventArgs e)
        {
            Form Score = new Score();
            Score.Show();
            this.Hide();
        }

        private void Menu1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(cesta))
            {
                return;
            }

            string json = File.ReadAllText(cesta);
            JObject data = JObject.Parse(json);
            string barevnyRezim = (string)data["barevny_rezim"];

            if (barevnyRezim == "tmavy")
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.White;
                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    }
                    if (ctrl is Label)
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                }
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = Color.Black;

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.Black;
                    if (ctrl is Button)
                    {
                        ctrl.BackColor = SystemColors.Control;
                    }
                    if (ctrl is Label)
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            string cestaSave = @"..\..\Config\savegame.json";

            // Kontrola, zda soubor vůbec existuje
            if (File.Exists(cestaSave))
            {
                // Místo přímého spuštění hry otevřeme okno se seznamem her
                LoadGame oknoNacitani = new LoadGame();
                oknoNacitani.Show();

                // Skryjeme aktuální menu
                this.Hide();
            }
            else
            {
                MessageBox.Show("Žádná uložená hra nebyla nalezena!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}