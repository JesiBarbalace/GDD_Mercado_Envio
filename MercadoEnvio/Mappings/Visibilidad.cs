using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoEnvio.Mappings;

namespace MercadoEnvio.Mappings
{
    class Visibilidad
    {

        public DataTable TraerVisibilidades()
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[getVisibilidades]", bd.conexion);
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

        public int VerificarVisibilidad(string nombreVisibilidad)
        {
            int estado = 0;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ValidarNombreVisibilidad]", bd.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@NombreVisibilidad", SqlDbType.NVarChar).Value = nombreVisibilidad;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                //Si me devolvio al menos un registro, entonces existe una visibilidad con ese nombre
                if (dt.Rows.Count > 0)
                {
                    estado = 1;
                }
            }
            catch (SqlException db)
            {
                estado = 0;
                MessageBox.Show("Elija otro nombre");
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return estado;
        }

        public void modificarVisibilidad(string visiID,string desc, float costoFijo, float porcentaje, float envio)
        {
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand("[RECUR].[ModificarVisi]", bd.conexion);
            cmd.Parameters.Add("@visiID", SqlDbType.NVarChar,30).Value = visiID;
            cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar,30).Value = desc;
            cmd.Parameters.Add("@visiCosto", SqlDbType.Float).Value = costoFijo;
            cmd.Parameters.Add("@visiPorcentaje", SqlDbType.Float).Value = porcentaje;
            cmd.Parameters.Add("@visiEnvio", SqlDbType.Float).Value = envio;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            bd.conexion.Close();
        }



    }
}
