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
    public partial class Game_Settings : Form
    {
        public Game_Settings()
        {
            InitializeComponent();
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            bool muzuSpustit = true;
            if(muzuSpustit)
            {
                Form Game_Singleplayer = new Game_Singleplayer();
                Game_Singleplayer.Show();
                this.Hide();
            }
        }
    }
}
