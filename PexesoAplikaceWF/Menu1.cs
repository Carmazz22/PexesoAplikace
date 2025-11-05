using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PexesoAplikaceWF
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void button_newGame_Click(object sender, EventArgs e)
        {
            Form Game_Singleplayer = new Game_Singleplayer();
            Game_Singleplayer.Show();
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
            System.Windows.Forms.Application.Exit();
        }

        private void button_score_Click(object sender, EventArgs e)
        {
            Form Score = new Score();
            Score.Show();
            this.Hide();    
        }

        private void Menu1_Load(object sender, EventArgs e)
        {
           
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
