using IsAV.Presentacion;
using IsAV.Presentacion.AsistenteInstalacion;
using IsAV.Presentacion.Compras;
using IsAV.Presentacion.Menu;
using IsAV.Sunat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace IsAV
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frm = new LOGIN();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            Application.Run();

        }

        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
