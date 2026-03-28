using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PEXESO.Forms
{
    public partial class Settings : Form
    {
        string cestaNastaveni = @"..\..\Config\settings.dat";
        bool nacitani = true;

        public Settings()
        {
            InitializeComponent();
        }

        byte pocetHracu;
        byte zvuk;
        byte obtiznost;
        byte pocetKaret;
        byte vzhledKaret;
        byte barevnyRezim;

        private void Settings_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);

            if (File.Exists(cestaNastaveni))
            {
                FileStream fs = new FileStream(cestaNastaveni, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                pocetHracu = br.ReadByte();
                zvuk = br.ReadByte();
                obtiznost = br.ReadByte();
                pocetKaret = br.ReadByte();
                vzhledKaret = br.ReadByte();
                barevnyRezim = br.ReadByte();

                fs.Close();
            }
            else
            {
                FileStream _fs = new FileStream(cestaNastaveni, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(_fs);

                pocetHracu = 1;
                zvuk = 1;
                obtiznost = 0;
                pocetKaret = 30;
                vzhledKaret = 0;
                barevnyRezim = 0;

                bw.Write(pocetHracu);
                bw.Write(zvuk);
                bw.Write(obtiznost);
                bw.Write(pocetKaret);
                bw.Write(vzhledKaret);
                bw.Write(barevnyRezim);

                bw.Close();
                _fs.Close();
            }

            VypisDatDoCombo();
            nacitani = false;
        }

        private void btnDoMenu_Click(object sender, EventArgs e)
        {
            if (this.Parent is PEXESO main)
            {
                main.OtevreniFormu(new global::PEXESO.Forms.Menu());
                main.prehratZvuk(0);
            }
        }

        public void VypisDatDoCombo()
        {
            if (pocetHracu > 0)
            {
                comboPocetHracu.SelectedIndex = pocetHracu - 1;
            }
            else
            {
                comboPocetHracu.SelectedIndex = 0;
            }

            if (zvuk == 0)
            {
                comboZvuky.SelectedIndex = 1;
            }
            else
            {
                comboZvuky.SelectedIndex = 0;
            }

            comboAI.SelectedIndex = obtiznost;

            byte[] hodnoty = { 30, 45, 60 };
            bool shoda = false;
            for (int i = 0; i < hodnoty.Length && !shoda; i++)
            {
                if (pocetKaret == hodnoty[i])
                {
                    shoda = true;
                    comboPocetKaret.SelectedIndex = i;
                }
            }

            comboVzhled.SelectedIndex = vzhledKaret;
            comboBarvy.SelectedIndex = barevnyRezim;
        }

        public void AktualizaceDat()
        {
            if (nacitani) return;

            pocetHracu = (byte)(comboPocetHracu.SelectedIndex + 1);

            if (comboZvuky.SelectedIndex == 1)
            {
                zvuk = 0;
            }
            else
            {
                zvuk = 1;
            }

            obtiznost = (byte)comboAI.SelectedIndex;

            byte[] hodnoty = { 30, 45, 60 };
            if (comboPocetKaret.SelectedIndex != -1)
            {
                pocetKaret = hodnoty[comboPocetKaret.SelectedIndex];
            }

            vzhledKaret = (byte)comboVzhled.SelectedIndex;
            barevnyRezim = (byte)comboBarvy.SelectedIndex;

            FileStream fs = new FileStream(cestaNastaveni, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(pocetHracu);
            bw.Write(zvuk);
            bw.Write(obtiznost);
            bw.Write(pocetKaret);
            bw.Write(vzhledKaret);
            bw.Write(barevnyRezim);

            bw.Close();
            fs.Close();
        }

        private void comboPocetHracu_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();
        }

        private void comboZvuky_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();
        }

        private void comboAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();
        }

        private void comboVzhled_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();
        }

        private void comboPocetKaret_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();
        }

        private void comboBarvy_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktualizaceDat();

            if (nacitani == false)
            {
                if (this.Parent is PEXESO main)
                {
                    if (barevnyRezim == 0) // Světlý
                    {
                        main.AplikujSvetlyRezim(this);
                        main.AplikujSvetlyRezim(main);
                    }
                    else if (barevnyRezim == 1) // Tmavý
                    {
                        main.AplikujTmavyRezim(this);
                        main.AplikujTmavyRezim(main);
                    }
                }
            }
        }
    }
}