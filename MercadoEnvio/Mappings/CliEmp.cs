using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MercadoEnvio.Mappings
{
    class CliEmp
    {

        public DataTable ObtenerBusqClie(string Nombre, string Apellido, Int64 DNI, string Mail)
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
                {
                    //cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Nombre", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                }

                if (Apellido == null)
                {
                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Apellido", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = Apellido;
                }

                if (DNI == 0)
                {

                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Documento", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.Add("@Documento", SqlDbType.Decimal).Value = DNI;
                }

                if (Mail == null)
                {
                    //cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Mail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;
                }


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
                retorno = 1;

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


        public int HabilitarUsuario(string username)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[HabilitarUsuario]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = username;
                cmd.ExecuteNonQuery();
                retorno = 1;

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

        public DataTable ObtenerBusqEmp(string razos, string doc, string Mail)
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

                if (doc == null)
                    //cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@Documento", DBNull.Value);
                else
                    cmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = doc;

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


        public int ModificarCliente(string apellido, string nombre, Int64 dni, string pass, string fechanac, string calle, Int64 nrocalle, string depto, Int64 piso, string cp, string localidad, Int64 tel, string mail)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ModificarCliente]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = apellido;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@Dni", SqlDbType.Decimal).Value = dni;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = fechanac;
                cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = calle;
                cmd.Parameters.Add("@NroCalle", SqlDbType.Decimal).Value = nrocalle;
                cmd.Parameters.Add("@Depto", SqlDbType.NVarChar).Value = depto;
                cmd.Parameters.Add("@Piso", SqlDbType.Decimal).Value = piso;
                cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = cp;
                cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = localidad;
                cmd.Parameters.Add("@Tel", SqlDbType.Decimal).Value = tel;
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;

                cmd.ExecuteNonQuery();
                retorno = 1;

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

        public int ModificarEmpresa(string razons, string contacto, string pass, string cuit, string calle, Int64 nrocalle, string depto, Int64 piso, string cp, string localidad, Int64 tel, string mail, string ciudad, string rubro)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ModificarEmpresa]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@RazonSoc", SqlDbType.NVarChar).Value = razons;
                cmd.Parameters.Add("@Contacto", SqlDbType.NVarChar).Value = contacto;
                cmd.Parameters.Add("@CUIT", SqlDbType.NVarChar).Value = cuit;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = calle;
                cmd.Parameters.Add("@NroCalle", SqlDbType.Decimal).Value = nrocalle;
                cmd.Parameters.Add("@Depto", SqlDbType.NVarChar).Value = depto;
                cmd.Parameters.Add("@Piso", SqlDbType.Decimal).Value = piso;
                cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = cp;
                cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = localidad;
                cmd.Parameters.Add("@Tel", SqlDbType.Decimal).Value = tel;
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;
                cmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = ciudad;
                cmd.Parameters.Add("@Rubro", SqlDbType.NVarChar).Value = rubro;

                cmd.ExecuteNonQuery();
                retorno = 1;

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

        public DataTable getRubros()
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getRubros]", bd.conexion);
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


        public int ValidarDocumento(string username)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ValidarDocumento]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = username;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    estado = 1;
                }



            }
            catch (SqlException db)
            {
                estado = 0;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return estado;
        }


        public int InsertarCliente(string apellido, string nombre, Int64 dni, string pass, string fechanac, string calle, Int64 nrocalle, string depto, Int64 piso, string cp, string localidad, Int64 tel, string mail)
        {

            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InsertarCliente]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = apellido;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@Dni", SqlDbType.Decimal).Value = dni;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = fechanac;
                cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = calle;
                cmd.Parameters.Add("@NroCalle", SqlDbType.Decimal).Value = nrocalle;
                cmd.Parameters.Add("@Depto", SqlDbType.NVarChar).Value = depto;
                cmd.Parameters.Add("@Piso", SqlDbType.Decimal).Value = piso;
                cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = cp;
                cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = localidad;
                cmd.Parameters.Add("@Tel", SqlDbType.Decimal).Value = tel;
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;

                cmd.ExecuteNonQuery();
                retorno = 1;

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

        public int InsertarEmpresa(string razonsoc, string username, string doc, string pass, string contacto, string rubro, string calle, Int64 nrocalle, string depto, Int64 piso, string cp, string localidad, Int64 tel, string mail, string ciudad)
        {

            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InsertarEmpresa]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@RazonSoc", SqlDbType.NVarChar).Value = razonsoc;
                cmd.Parameters.Add("@User", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@Doc", SqlDbType.NVarChar).Value = doc;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pass;
                cmd.Parameters.Add("@Contacto", SqlDbType.NVarChar).Value = contacto;
                cmd.Parameters.Add("@Rubro", SqlDbType.NVarChar).Value = rubro;
                cmd.Parameters.Add("@Calle", SqlDbType.NVarChar).Value = calle;
                cmd.Parameters.Add("@NroCalle", SqlDbType.Decimal).Value = nrocalle;
                cmd.Parameters.Add("@Depto", SqlDbType.NVarChar).Value = depto;
                cmd.Parameters.Add("@Piso", SqlDbType.Decimal).Value = piso;
                cmd.Parameters.Add("@CP", SqlDbType.NVarChar).Value = cp;
                cmd.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = localidad;
                cmd.Parameters.Add("@Tel", SqlDbType.Decimal).Value = tel;
                cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;
                cmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = ciudad;

                cmd.ExecuteNonQuery();
                retorno = 1;

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


    }
}
