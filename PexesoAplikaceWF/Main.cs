using System;
using System.Windows.Forms;
using PEXESO.Forms;

using System.Media;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace PEXESO
{
    public partial class Main : Form
    {

        private Form aktivniForm = null;
        SoundPlayer prehravacZvuku;

        string cestaNastaveni = @"..\..\Config\settings.dat";

        byte zvuk;
        byte rezim;

        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AktualizacePreferenci();

            OtevreniFormu(new PEXESO.Forms.Menu());
        }

        // Nová veřejná metoda pro aktualizaci proměnné 'zvuk' ze souboru .dat
        public void AktualizacePreferenci()
        {
            if (File.Exists(cestaNastaveni))
            {
                FileStream fs = new FileStream(cestaNastaveni, FileMode.Open, FileAccess.Read);

                fs.Position = 1 * sizeof(byte);
                zvuk = (byte)fs.ReadByte();

                fs.Position = 5 * sizeof(byte);
                rezim = (byte)fs.ReadByte();

                fs.Close();
            }
        }

        public void OtevreniFormu(Form VybranyForm)
        {
            this.SuspendLayout();

            if (aktivniForm != null)
            {
                aktivniForm.Close();
            }
            AktualizacePreferenci();

            aktivniForm = VybranyForm;
            aktivniForm.TopLevel = false;
            aktivniForm.FormBorderStyle = FormBorderStyle.None;
            aktivniForm.Dock = DockStyle.Fill;
            if (rezim == 0) 
            {
                AplikujSvetlyRezim(aktivniForm);
                AplikujSvetlyRezim(this);
            }
            else if (rezim == 1) //tmavy
            {
                AplikujTmavyRezim(aktivniForm);
                AplikujTmavyRezim(this);
            }

            this.Controls.Add(aktivniForm);
            aktivniForm.Show();

            this.ResumeLayout();
        }

        public void prehratZvuk(byte typ)
        {
            AktualizacePreferenci();
            SoundPlayer player;
            string cestaKliknuti = @"..\..\Resources\sounds\click.wav";
            string cestaOtoceni = @"..\..\Resources\sounds\flip.wav";
            string cestaShoda = @"..\..\Resources\sounds\shoda.wav";
            string cestaNeshoda = @"..\..\Resources\sounds\neshoda.wav";
            switch (typ)
            {
                case 0: //kliknutí v menu
                    {
                        if (File.Exists(cestaNastaveni) && zvuk == 1)
                        {
                            player = new SoundPlayer(cestaKliknuti);
                            player.Play();
                        }

                        break;
                    }
                case 1: //otočení kartičky
                    {
                        if (File.Exists(cestaNastaveni) && zvuk == 1)
                        {
                            player = new SoundPlayer(cestaOtoceni);
                            player.Play();
                        }

                        break;
                    }
                case 2:
                    {
                        if (File.Exists(cestaNastaveni) && zvuk == 1)
                        {
                            player = new SoundPlayer(cestaShoda);
                            player.Play();
                        }

                        break;
                    }
                case 3: 
                    {
                        if (File.Exists(cestaNastaveni) && zvuk == 1)
                        {
                            player = new SoundPlayer(cestaNeshoda);
                            player.Play();
                        }

                        break;
                    }


            }

        }

        public void AplikujTmavyRezim(Form formular)
        {
            formular.BackColor = Color.FromArgb(45, 45, 48);
            formular.ForeColor = Color.White;

            // Nastavení tmavého pozadí z Resources
            formular.BackgroundImage = global::PEXESO.Properties.Resources.background1;
            formular.BackgroundImageLayout = ImageLayout.Stretch;

            // Přepsaný switch na klasické if podmínky

            foreach (Control prvek in formular.Controls)
            {
                if (prvek is Panel)
                {
                    prvek.BackColor = Color.Transparent;

                    foreach (Control podPrvek in prvek.Controls)
                    {
                        if (podPrvek is Label)
                        {
                            podPrvek.ForeColor = Color.White;
                        }
                        else if (podPrvek is Button)
                        {
                            podPrvek.BackColor = Color.FromArgb(60, 60, 65);
                            podPrvek.ForeColor = Color.White;
                        }
                        else if (podPrvek is TextBox)
                        {
                            podPrvek.BackColor = Color.FromArgb(70, 70, 75);
                            podPrvek.ForeColor = Color.White;
                        }
                        else if (podPrvek is ComboBox cb) // Přidáno pro jistotu z minula
                        {
                            cb.BackColor = Color.FromArgb(70, 70, 75);
                            cb.ForeColor = Color.White;
                            cb.FlatStyle = FlatStyle.Flat;
                        }
                    }
                }
                else if (prvek is Label)
                {
                    prvek.ForeColor = Color.White;
                }
                else if (prvek is Button)
                {
                    prvek.BackColor = Color.FromArgb(60, 60, 65);
                    prvek.ForeColor = Color.White;
                }
                else if (prvek is TextBox)
                {
                    prvek.BackColor = Color.FromArgb(70, 70, 75);
                    prvek.ForeColor = Color.White;
                }
                else if (prvek is ComboBox cb) // Přidáno pro jistotu z minula
                {
                    cb.BackColor = Color.FromArgb(70, 70, 75);
                    cb.ForeColor = Color.White;
                    cb.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        public void AplikujSvetlyRezim(Form formular)
        {
            formular.BackColor = Color.WhiteSmoke;
            formular.ForeColor = Color.Black;

            // Nastavení světlého pozadí z Resources
            formular.BackgroundImage = global::PEXESO.Properties.Resources.background;
            formular.BackgroundImageLayout = ImageLayout.Stretch;

            // Přepsaný switch na klasické if podmínky
            if (formular is PEXESO.Forms.Menu || formular is PEXESO.Forms.Score)
            {
                // Místo pro specifický kód
            }
            else if (formular is PEXESO.Forms.PlayerNames || formular is PEXESO.Forms.Settings)
            {
                // Místo pro specifický kód
            }

            foreach (Control prvek in formular.Controls)
            {
                if (prvek is Panel)
                {
                    prvek.BackColor = Color.Transparent;

                    foreach (Control podPrvek in prvek.Controls)
                    {
                        if (podPrvek is Label)
                        {
                            podPrvek.ForeColor = Color.Black;
                        }
                        else if (podPrvek is Button)
                        {
                            podPrvek.BackColor = Color.White;
                            podPrvek.ForeColor = Color.Black;
                        }
                        else if (podPrvek is TextBox)
                        {
                            podPrvek.BackColor = Color.White;
                            podPrvek.ForeColor = Color.Black;
                        }
                        else if (podPrvek is ComboBox cb) // Přidáno pro jistotu z minula
                        {
                            cb.BackColor = Color.White;
                            cb.ForeColor = Color.Black;
                            cb.FlatStyle = FlatStyle.Standard;
                        }
                    }
                }
                else if (prvek is Label)
                {
                    prvek.ForeColor = Color.Black;
                }
                else if (prvek is Button)
                {
                    prvek.BackColor = Color.White;
                    prvek.ForeColor = Color.Black;
                }
                else if (prvek is TextBox)
                {
                    prvek.BackColor = Color.White;
                    prvek.ForeColor = Color.Black;
                }
                else if (prvek is ComboBox cb) // Přidáno pro jistotu z minula
                {
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                    cb.FlatStyle = FlatStyle.Standard;
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Zapne WS_EX_COMPOSITED a WS_EX_LAYERED
                // To donutí WinForms vykreslovat všechno do paměti naráz
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

    }
}