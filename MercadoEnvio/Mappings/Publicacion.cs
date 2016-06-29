using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.Mappings
{
    class Publicacion
    {
        public DataTable getTipoPubli()
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getTipoPubli]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);

            }
            catch (SqlException db)
            {
                throw db;
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
