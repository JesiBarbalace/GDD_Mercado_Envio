using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using MercadoEnvio.Mappings;

namespace MercadoEnvio.Auxiliares
{
    class FuncionesAuxiliares
    {
        private BasedeDatosForm db = new BasedeDatosForm();

        public Boolean permiso(Int32 idRol, String funcionalidad)
        {
            Boolean retorno = false;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[Permisos]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = idRol;
                cmd.Parameters.Add("@Funcionalidad", SqlDbType.NVarChar).Value = funcionalidad;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    retorno = true;
                }

                else
                    retorno = false;

            }

            catch (SqlException db)
            {
                retorno = false;
                throw db;
            }

            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }

            return retorno;



        }

    }
}
