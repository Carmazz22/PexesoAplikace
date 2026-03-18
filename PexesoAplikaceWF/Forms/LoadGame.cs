using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    public partial class LoadGame : Form
    {
        public LoadGame()
        {
            InitializeComponent();
        }

        private void LoadGame_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            VykresliUlozeneHry();
        }

        private void VykresliUlozeneHry()
        {
            int poziceY = 150;
            bool nalezenaHra = false;

            for (int i = 1; i <= 3; i++)
            {
                string cestaSave = @"..\..\Config\savegame" + i + ".dat";

                if (File.Exists(cestaSave))
                {
                    nalezenaHra = true;

                    FileStream fs = new FileStream(cestaSave, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    string nactenyNazev = br.ReadString();

                    int aktualniHracIndex = br.ReadInt32();
                    byte celkovyPocetKaret = br.ReadByte();
                    byte pocetHracu = br.ReadByte();

                    string hraciText = "Hráči: ";
                    for (int j = 0; j < pocetHracu; j++)
                    {
                        string jmeno = br.ReadString();
                        int skore = br.ReadInt32();

                        if (j > 0)
                        {
                            hraciText = hraciText + ", ";
                        }
                        hraciText = hraciText + jmeno;
                    }

                    br.Close();
                    fs.Close();

                    Panel kartaHry = new Panel();
                    kartaHry.Size = new Size(400, 220);
                    kartaHry.Location = new Point((panel1.Width - 400) / 2, poziceY);
                    kartaHry.BackColor = Color.FromArgb(245, 245, 245);
                    kartaHry.BorderStyle = BorderStyle.None;

                    Label lblNazev = new Label();
                    lblNazev.Text = "NÁZEV HRY: " + nactenyNazev;
                    lblNazev.Font = new Font("Roboto", 16, FontStyle.Bold);
                    lblNazev.Size = new Size(400, 40);
                    lblNazev.Location = new Point(0, 20);
                    lblNazev.TextAlign = ContentAlignment.MiddleCenter;
                    lblNazev.ForeColor = Color.Black;
                    kartaHry.Controls.Add(lblNazev);

                    Label lblHraci = new Label();
                    lblHraci.Text = hraciText;
                    lblHraci.Font = new Font("Roboto", 12, FontStyle.Regular);
                    lblHraci.Size = new Size(400, 40);
                    lblHraci.Location = new Point(0, 70);
                    lblHraci.TextAlign = ContentAlignment.MiddleCenter;
                    lblHraci.ForeColor = Color.FromArgb(64, 64, 64);
                    kartaHry.Controls.Add(lblHraci);

                    Button btnNacist = new Button();
                    btnNacist.Text = "HRÁT: " + nactenyNazev;
                    btnNacist.Size = new Size(240, 50);
                    btnNacist.Location = new Point(80, 140);
                    btnNacist.Font = new Font("Roboto", 12, FontStyle.Bold);
                    btnNacist.BackColor = Color.FromArgb(245, 245, 245);
                    btnNacist.FlatStyle = FlatStyle.Flat;
                    btnNacist.FlatAppearance.BorderSize = 2;
                    btnNacist.FlatAppearance.BorderColor = Color.Black;
                    btnNacist.ForeColor = Color.Black;
                    btnNacist.Tag = nactenyNazev;
                    btnNacist.Click += BtnNacist_Click;
                    kartaHry.Controls.Add(btnNacist);

                    panel1.Controls.Add(kartaHry);

                    poziceY = poziceY + 240;
                }
            }

            if (!nalezenaHra)
            {
                Label lblZadna = new Label();
                lblZadna.Text = "Žádná uložená hra nebyla nalezena.";
                lblZadna.Font = new Font("Roboto", 16, FontStyle.Bold);
                lblZadna.Size = new Size(500, 50);
                lblZadna.Location = new Point((panel1.Width - 500) / 2, 200);
                lblZadna.TextAlign = ContentAlignment.MiddleCenter;
                lblZadna.ForeColor = Color.White;
                panel1.Controls.Add(lblZadna);
            }
        }

        private void BtnNacist_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string nazevKNacteni = btn.Tag.ToString();

                if (this.Parent is PEXESO main)
                {
                    Game novaHra = new Game(nazevKNacteni);
                    main.OtevreniFormu(novaHra);
                }
            }
        }

        private void btnDoMenu_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Menu());
                main.prehratZvuk(0);
            }
        }
    }
}