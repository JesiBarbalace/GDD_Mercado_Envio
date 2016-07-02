using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Mappings
{
    class Rubro
    {
        public int ID {get;set;}
        public string Descripcion { get; set; }

        public Rubro()
        { }

        public DataTable GetRubros()
        {
            List<Rubro> Rubros = new List<Rubro>();

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [RECUR].[VW_RUBROS]", bd.conexion);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }

            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return dt;
        }

    }
}
