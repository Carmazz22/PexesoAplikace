using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEXESO.Forms
{
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void Tutorial_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 50);
            label2.Text = "• Hra je určena pro 1 až 6 hráčů.\r\n" +
                               "• Cílem je najít trojici shodných karet.\r\n" +
                               "• Hráč v jednom tahu otáčí 3 karty.\r\n" +
                               "• Pokud jsou všechny 3 stejné, hráč si je bere.\r\n" +
                               "• Po úspěšném nálezu hraje hráč znovu.\r\n" +
                               "• Při neshodě se karty otočí a hraje další hráč.\r\n" +
                               "• Hra končí po rozebrání všech karet z plochy.\r\n" +
                               "• Vítězí hráč s nejvyšším počtem trojic.\r\n" +
                               "• Při stejném počtu bodů nastává remíza.\r\n";
                               
        }

        private void btnDoMenu_Click(object sender, EventArgs e)
        {
            if (this.Parent is Main main)
            {
                main.OtevreniFormu(new PEXESO.Forms.Menu());
                main.prehratZvuk(0);
            }
        }
    }
}
