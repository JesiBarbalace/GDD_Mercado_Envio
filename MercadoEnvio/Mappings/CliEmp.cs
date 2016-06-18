using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MercadoEnvio.Mappings
{
    class CliEmp
    {
        
        public DataTable ObtenerBusqClie(string Nombre, string Apellido, int DNI, string Mail)
        {
            
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ObtenerBusqClie]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            try
            {
                if (Nombre == null)
                    //cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Nombre", DBNull.Value);
                else
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;

                if (Apellido == null)
                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Apellido", DBNull.Value);
                else
                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = Nombre;
                
                if (DNI == 0)
                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Documento", DBNull.Value);
                else
                    cmd.Parameters.Add("@Documento", SqlDbType.Int).Value = DNI;

                if (Mail == null)
                    //cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Mail", DBNull.Value);
                else
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;

                
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

        public int InhabilitarUsuario(string username)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InhabilitarUsuario]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            
            try
            {
                cmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = username;
                cmd.ExecuteNonQuery();
                retorno=1;

            }
            catch (SqlException db)
            {
                retorno = 0;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return retorno;
        }


        public DataTable ObtenerBusqEmp(string razos, int Doc, string Mail)
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ObtenerBusqEmp]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                if (razos == null)
                    //cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@RazonS", DBNull.Value);
                else
                    cmd.Parameters.Add("@RazonS", SqlDbType.NVarChar).Value = razos;

               if (Doc == 0)
                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Documento", DBNull.Value);
                else
                    cmd.Parameters.Add("@Documento", SqlDbType.Int).Value = Doc;

                if (Mail == null)
                    //cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Mail", DBNull.Value);
                else
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;


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
