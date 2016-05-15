using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MercadoEnvio.Mappings;

namespace MercadoEnvio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //La fecha del sistema está en el archivo de configuración (MercadoEnvio/Properties/Settings.settings), y se accede así:
            //Properties.Settings.Default.FechaSistema;

            // Estos métodos hay que llamarlos en primer lugar porque, si no, tira excepción:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mappings.BasedeDatosForm bd = new BasedeDatosForm();

            string a = bd.GetConnectionString("conexion");
            bd.SaveConnectionString("MercadoEnvio.Properties.Settings.GD1C2016ConnectionString", a);
            bd.SaveConnectionString("MercadoEnvio.Properties.Settings.GD1C2016ConnectionStringJ", a);

            Application.Run(new Form1());
        }
    }
}
