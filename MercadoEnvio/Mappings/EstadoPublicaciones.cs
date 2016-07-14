using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace MercadoEnvio.Mappings
{
    class EstadoPublicaciones
    {
        public void VerificarPublicaciones()
        {
            DateTime fechaSistema = Properties.Settings.Default.FechaSistema;

            AsignarSubastas(fechaSistema);

            FinalizarPublicaciones(fechaSistema);
        }

        public void FinalizarPublicaciones(DateTime fecha)
        {
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand FinalizarPublicaciones_SP = new SqlCommand("[RECUR].[FinalizarPublicaciones]", bd.conexion);
            FinalizarPublicaciones_SP.CommandType = CommandType.StoredProcedure;
            FinalizarPublicaciones_SP.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
            FinalizarPublicaciones_SP.ExecuteNonQuery();
            FinalizarPublicaciones_SP.Dispose();

            bd.closeConnection();
        }

        public void AsignarSubastas(DateTime fecha)
        {
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand AsignarSubastas_SP = new SqlCommand("[RECUR].[AsignarSubastas]", bd.conexion);
            AsignarSubastas_SP.CommandType = CommandType.StoredProcedure;
            AsignarSubastas_SP.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
            AsignarSubastas_SP.ExecuteNonQuery();
            AsignarSubastas_SP.Dispose();

            bd.closeConnection();
        }
    }
}
