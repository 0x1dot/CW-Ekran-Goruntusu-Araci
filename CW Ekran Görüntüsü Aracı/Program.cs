using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracý
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlPanel());
        }
    }
}