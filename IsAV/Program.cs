using IsAV.Presentacion;
using IsAV.Presentacion.AsistenteInstalacion;
using IsAV.Presentacion.Compras;
using IsAV.Presentacion.Menu;
using IsAV.Sunat;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
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
           /* Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);   */
            var wi = WindowsIdentity.GetCurrent() ;
            var wp = new WindowsPrincipal(wi);
            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

            if (!runAsAdmin)
            {
                // It is not possible to launch a ClickOnce app as administrator directly,
                // so instead we launch the app as administrator in a new process.
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);

                // The following properties run the new process as administrator
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";

                // Start the new process
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception)
                {
                    // The user did not allow the application to run as administrator
                    MessageBox.Show("Sorry, but I don't seem to be able to start " +
                       "this program in mode administrator!");
                }

                // Shut down the current process
                Application.Exit();

            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frm = new LOGIN();
                frm.FormClosed += Frm_FormClosed;
                frm.ShowDialog();
                Application.Run();
            }

        }

        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
