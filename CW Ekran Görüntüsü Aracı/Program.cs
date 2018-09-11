using System;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracý
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AnaForm());
        }
    }
}