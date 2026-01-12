using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PexesoAplikaceWF
{
    internal static class Program
    {
        /// <summary>  
        /// Hlavní vstupní bod aplikace.  
        /// </summary>  
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
            // Cleanup logic if needed before application exits  
        }

        private static void CheckFormsVisibility(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}

