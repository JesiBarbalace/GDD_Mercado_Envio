using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MercadoEnvio.Mappings
{
    class Rol
    {
        public Int32 rolId = 0;
        public String nombre = "";
        public Boolean estado = true;
        public Int32 idRol = 0;

        public Int32 getIdRol(String nombreRol)
        {
            int idRol = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getIdRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = nombreRol;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow dtRow in dt.Rows)
                {
                    idRol = (Convert.ToInt32(dtRow["ROL_ID"]));
                }

            }
            catch (SqlException db)
            {
                idRol = 0;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return idRol;
        }

        public List<Rol> getRolesUsuario(Int32 usuarioId)
        {
            List<Rol> roles = new List<Rol>();

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getRolesUsuario]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@UsuarioId", SqlDbType.NVarChar).Value = usuarioId;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow dtRow in dt.Rows)
                {
                    Rol rol = new Rol();
                    rol.rolId = Convert.ToInt32(dtRow["ID"]);
                    rol.nombre = Convert.ToString(dtRow["ROL"]);

                    roles.Add(rol);
                }

            }

            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return roles;
        }

        public int VerificarAgregarRol(List<int> Func_chequeadas)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ObtenerRolFuncionalidad]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //cmd.ExecuteNonQuery();  //Ejecuto SP que me trae la tabla con todas los roles y sus respectivas funcionalidades

                //Debo recorrer el datatable por fila, por columna y tambien recorrer la lista.
                int r = 0, i = 0, j = 0;
                int aux_rol = 0;
                int dist = 0;
                int count = 0, count_j = 0;

                while (r < dt.Rows.Count)
                {
                    count = 0; count_j = 0;
                    aux_rol = Convert.ToInt32(dt.Rows[r]["ROL_ID"].ToString());
                    dist = 0;
                    while (aux_rol == Convert.ToInt32(dt.Rows[r]["ROL_ID"].ToString()))
                    {
                        if (Convert.ToInt32(dt.Rows[i]["FUNC_ID"].ToString()) == Func_chequeadas[j])
                        {
                            count++;
                            r++;
                            if (r >= dt.Rows.Count - 1)
                            {
                                if (j < Func_chequeadas.Count)
                                {
                                    return 0;   // Tiene funcionalidades distintas, debo agregarlo a la BD

                                }
                                else
                                    return 1;   //PRUEBA
                                //{ retorno = 1; }  // Tiene funcionalidades iguales, NO debo agregarlo a la BD

                                break;  //salgo del while 
                            }
                            i++;
                            if (j < (Func_chequeadas.Count - 1))
                            {
                                j++;

                            }
                            else j = 0;

                        }
                        else
                        {
                            r++;
                            if (r >= (dt.Rows.Count - 1))
                            {
                                return 0;
                                break;
                            }
                            i++;
                            dist = 1;

                        }
                    }
                    if (dist == 0 && r <= dt.Rows.Count - 1)
                    {
                        retorno = 1;  // Tiene funcionalidades iguales, NO debo agregarlo a la BD
                        break;
                    }
                    else j = 0;

                }



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

        public int AgregarNombreRol(string NombreRol)
        {
            int id_rol = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InsertarRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException db)
            {
                id_rol = 0;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return id_rol;
        }

        public int AgregarFuncionalidad(string NombreRol, int Funcionalidad)
        {
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InsertarFuncionalidad]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;
                cmd.Parameters.Add("@IdFunc", SqlDbType.Int).Value = Funcionalidad;

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
        public List<int> TraerFuncionalidadesRol(string NombreRol)
        {
            List<int> Func_chequeadas = new List<int>();
            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ObtenerFuncionalidadXRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow dtRow in dt.Rows)
                {
                    Func_chequeadas.Add(Convert.ToInt32(dtRow["FUNC_ID"].ToString()));
                }


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
            return Func_chequeadas;
        }
        public int EliminarFuncRol(string NombreRol)
        {
            int id_rol = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[EliminarFuncRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                cmd.ExecuteNonQuery();

            }
            catch (SqlException db)
            {
                id_rol = 0;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return id_rol;
        }
        public int ObtenerEstadoRol(string NombreRol)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[EstadoRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow dtRow in dt.Rows)
                {
                    estado = (Convert.ToInt32(dtRow["ROL_HABILITADO"]));
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
        public int InhabilitarRol(string NombreRol)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[InhabilitarRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                cmd.ExecuteNonQuery();

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
        public int HabilitarRol(string NombreRol)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[HabilitarRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                cmd.ExecuteNonQuery();

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

        public int VerificarRol(string NombreRol)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ValidarNombreRol]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreRol", SqlDbType.NVarChar).Value = NombreRol;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //Si me devolvio al menos un registro, entonces existe un rol con ese nombre
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

        public DataTable TraerFuncionalidades()
        {
            
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getFuncionalidades]", bd.conexion);
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

        public DataTable getRoles()
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getRoles]", bd.conexion);
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
