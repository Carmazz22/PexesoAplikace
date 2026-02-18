using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PexesoAplikaceWF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += OnApplicationExit;
            Application.Idle += CheckFormsVisibility;

            Application.Run(new Menu1());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
        }

        private static void CheckFormsVisibility(object sender, EventArgs e)
        {
            bool naselSeViditelnyForm = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Visible == true)
                {
                    naselSeViditelnyForm = true;
                }
            }

            if (naselSeViditelnyForm == false)
            {
                Application.Exit();
            }
        }
    }
}