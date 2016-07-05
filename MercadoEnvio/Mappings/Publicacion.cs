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

        public DataTable getVisibilidad()
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getVisibilidad]", bd.conexion);
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


        public decimal MaxPubli()
        {
            decimal retorno = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[MaxPubli]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        retorno = dr.GetDecimal(0);
                    }
                }

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
            return retorno;
        }


        public decimal ObtenerCostoVisi(string tipoVisi)
        {
            decimal retorno = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ObtenerCostoVisi]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CostoVisi", SqlDbType.NVarChar).Value = tipoVisi;

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        retorno = dr.GetDecimal(0);
                    }
                }

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
            return retorno;
        }

        public int AltaPublicacion(Int64 codigo, string descrip, int stock, DateTime inicio, DateTime venc, Decimal precio, string rubroguarda, string visiguarda, Decimal costo, string user, string estado, bool preg, bool envio, string tipopubli)
        {

            int retorno = 0;
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[AltaPublicacion]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            try
            {
                cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;
                cmd.Parameters.Add("@Descrip", SqlDbType.NVarChar).Value = descrip;
                cmd.Parameters.Add("@Stock", SqlDbType.Decimal).Value = stock;
                cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = inicio;
                cmd.Parameters.Add("@Venc", SqlDbType.DateTime).Value = venc;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@Rubro", SqlDbType.NVarChar).Value = rubroguarda;
                cmd.Parameters.Add("@Visi", SqlDbType.NVarChar).Value = visiguarda;
                cmd.Parameters.Add("@Costo", SqlDbType.Decimal).Value = costo;
                cmd.Parameters.Add("@User", SqlDbType.NVarChar).Value = user;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = estado;
                cmd.Parameters.Add("@Preg", SqlDbType.Bit).Value = preg;
                cmd.Parameters.Add("@Envio", SqlDbType.Bit).Value = envio;
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar).Value = tipopubli;

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
