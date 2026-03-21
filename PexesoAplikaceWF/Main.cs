using System;
using System.Windows.Forms;
using PEXESO.Forms;
using System.Media;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace PEXESO
{
    public partial class PEXESO : Form
    {
        private Form aktivniForm = null;
        SoundPlayer prehravacZvuku;

        string cestaNastaveni = @"..\..\Config\settings.dat";

        byte zvuk;
        byte rezim;

        public PEXESO()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AktualizacePreferenci();
            OtevreniFormu(new global::PEXESO.Forms.Menu());
        }

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
            else if (rezim == 1)
            {
                AplikujTmavyRezim(aktivniForm);
                AplikujTmavyRezim(this);
            }

            this.Controls.Add(aktivniForm);
            aktivniForm.Show();

            this.ResumeLayout();
        }
        #region Metoda pro přehrání zvuku
        public void prehratZvuk(int cisloZvuku)
        {
            if (zvuk == 1)
            {
                if (cisloZvuku == 0)
                {
                    prehravacZvuku = new SoundPlayer(Properties.Resources.click);
                }
                else if (cisloZvuku == 1)
                {
                    prehravacZvuku = new SoundPlayer(Properties.Resources.flip);
                }
                else if (cisloZvuku == 2)
                {
                    prehravacZvuku = new SoundPlayer(Properties.Resources.shoda);
                }
                else if (cisloZvuku == 3)
                {
                    prehravacZvuku = new SoundPlayer(Properties.Resources.neshoda);
                }

                if (prehravacZvuku != null)
                {
                    prehravacZvuku.Play();
                }
            }
            
        }
        #endregion
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #region Tmavý režim
        public void AplikujTmavyRezim(Form formular)
        {
            formular.BackColor = Color.Black;
            formular.ForeColor = Color.White;

            formular.BackgroundImage = global::PEXESO.Properties.Resources.background1;
            formular.BackgroundImageLayout = ImageLayout.Stretch;

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
                        else if (podPrvek is Button btn)
                        {
                            btn.BackColor = Color.Black;
                            btn.ForeColor = Color.White;

                            if (btn.Tag != null && btn.Tag.ToString() == "A")
                            {
                                btn.BackgroundImage = global::PEXESO.Properties.Resources.menu_sipka_bila;
                            }
                        }
                        else if (podPrvek is TextBox)
                        {
                            podPrvek.BackColor = Color.Black;
                            podPrvek.ForeColor = Color.White;
                        }
                        else if (podPrvek is ComboBox cb)
                        {
                            cb.BackColor = Color.Black;
                            cb.ForeColor = Color.White;
                            cb.FlatStyle = FlatStyle.Flat;
                        }
                        else if (podPrvek is CheckBox check)
                        {
                            check.ForeColor = Color.White;
                            check.BackColor = Color.Transparent;
                        }
                        else if (podPrvek is DataGridView tabulka)
                        {
                            tabulka.BackgroundColor = Color.Black;
                            tabulka.GridColor = Color.White;
                            tabulka.DefaultCellStyle.BackColor = Color.Black;
                            tabulka.DefaultCellStyle.ForeColor = Color.White;
                            tabulka.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
                            tabulka.DefaultCellStyle.SelectionForeColor = Color.White;
                            tabulka.EnableHeadersVisualStyles = false;
                            tabulka.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                            tabulka.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            tabulka.BorderStyle = BorderStyle.FixedSingle;
                            tabulka.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        }
                    }
                }
            }
        }
        #endregion
        #region Světlý režim barev
        public void AplikujSvetlyRezim(Form formular)
        {
            formular.BackColor = Color.White;
            formular.ForeColor = Color.Black;

            formular.BackgroundImage = global::PEXESO.Properties.Resources.background;

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
                        else if (podPrvek is Button btn)
                        {
                            btn.BackColor = Color.White;
                            btn.ForeColor = Color.Black;

                            if (btn.Tag != null && btn.Tag.ToString() == "A")
                            {
                                btn.BackgroundImage = global::PEXESO.Properties.Resources.menu_sipka;
                            }
                        }
                        else if (podPrvek is TextBox)
                        {
                            podPrvek.BackColor = Color.White;
                            podPrvek.ForeColor = Color.Black;
                        }
                        else if (podPrvek is ComboBox cb)
                        {
                            cb.BackColor = Color.White;
                            cb.ForeColor = Color.Black;
                            cb.FlatStyle = FlatStyle.Standard;
                        }
                        else if (podPrvek is CheckBox check)
                        {
                            check.ForeColor = Color.Black;
                            check.BackColor = Color.Transparent;
                        }
                        else if (podPrvek is DataGridView tabulka)
                        {
                            tabulka.BackgroundColor = Color.White;
                            tabulka.GridColor = Color.Black;
                            tabulka.DefaultCellStyle.BackColor = Color.White;
                            tabulka.DefaultCellStyle.ForeColor = Color.Black;
                            tabulka.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                            tabulka.DefaultCellStyle.SelectionForeColor = Color.Black;
                            tabulka.EnableHeadersVisualStyles = false;
                            tabulka.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                            tabulka.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                            tabulka.BorderStyle = BorderStyle.FixedSingle;
                            tabulka.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        }
                    }
                }
                
            }
        }
        #endregion
    }
}
