using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoEnvio.Mappings;
using System.IO;

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

            //La fecha del sistema se debe modificar desde acá-
            //Properties.Settings.Default.FechaSistema = DateTime.Now;
            BasedeDatos bd = new BasedeDatos();

            string a = bd.GetConnectionString("conexion");
            bd.SaveConnectionString("MercadoEnvio.Properties.Settings.GD1C2016ConnectionString", a);
            bd.SaveConnectionString("MercadoEnvio.Properties.Settings.GD1C2016ConnectionStringJ", a);

            Properties.Settings.Default.FechaSistema = Convert.ToDateTime("2017-01-31");
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
