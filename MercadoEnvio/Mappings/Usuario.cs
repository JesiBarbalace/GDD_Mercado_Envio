using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace MercadoEnvio.Mappings
{
    public class Usuario
    {
        public Int32 usuarioId = 0;
        public String username = "";
        public String pass = "";
        public Int32 rolId = 0;
        public int usuarioIntentos;
        public int usuarioHabilitado;
        public int usuarioIngresado;
        


          public Usuario getUser(String login, String pass)
            {
		
			//string valorEncriptado = SHA256Encripta(pass);

            #region ValidarUsuarioyPass Contra la base

            BasedeDatosForm bd = new BasedeDatosForm();

            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getUser]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = login;
                //cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = valorEncriptado;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //cmd.ExecuteNonQuery();
                adp.Fill(dt);
                
				
				if (dt.Rows.Count > 1)
				{
					throw new Exception("Se produjo un problema al intentar iniciar sesión, por favor contáctese con el administrador");
				}
				else
				{
					if (dt.Rows.Count == 0)
					{
						throw new Exception("El usuario ingresado es inexistente");
					}
					else
					{

						foreach (DataRow row in dt.Rows)
						{
							this.username = Convert.ToString(row["USUARIO_USERNAME"]);
							this.usuarioId = Convert.ToInt32(row["USUARIO_ID"]);
							this.pass = Convert.ToString(row["USUARIO_PASS"]);
                            this.usuarioIntentos = Convert.ToInt32(row["USUARIO_INTENTOS"]);
							this.usuarioHabilitado = Convert.ToInt32(row["USUARIO_HABILITADO"]);
                            this.usuarioIngresado = Convert.ToInt32(row["USUARIO_INGRESADO"]);

						}
					}
				}

                return this;

            #endregion
		}
               
            catch (SqlException db)
            {
                
                return null;
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
                              
            }
            
        }	

        public Usuario ModificarIntento(string Msg, string pass)
        {
                  #region ModificarValor en base a lo procesado
                    BasedeDatosForm bd = new BasedeDatosForm();

                    bd.openConnection();
                    SqlCommand cmd2 = new SqlCommand("[RECUR].[ModificarIntentos]", bd.conexion);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    try
                    {
                      
                        cmd2.Parameters.Add("@Intentos", SqlDbType.NVarChar).Value = this.usuarioIntentos;
                        cmd2.Parameters.Add("@Habilitado", SqlDbType.Int).Value = this.usuarioHabilitado;
                        cmd2.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = this.usuarioId;
                        cmd2.Parameters.Add("@Ingresado", SqlDbType.Int).Value = this.usuarioIngresado;
                        cmd2.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = pass;

                        cmd2.ExecuteNonQuery();

                        #endregion

                  }
                  catch (SqlException db)
                  {
                
                       return null;
                       throw db;
                  }
                  finally
                  {
                      bd.closeConnection();
                      cmd2.Dispose();
                              
                  }
                  if (Msg == "ERR")
                      return null;
                  else
                      return this;
        }

        public string SHA256Encripta(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

    }
}
