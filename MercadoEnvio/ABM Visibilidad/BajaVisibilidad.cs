using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Mappings;
using System.Data.SqlClient;

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class BajaVisibilidad : Form
    {
        
        Single costoFijo;
        Single costoPorcentaje;
        Object costoEnvio;
        Int32 visiID;
        Boolean b;

        public BajaVisibilidad()
        {
            InitializeComponent();
            llenarCombo_visi();
        }

        private void llenarCombo_visi()
        {
            comboVisi.DropDownStyle = ComboBoxStyle.DropDownList;

            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Visibilidad().TraerVisibilidades();
            myDataSet.Tables.Add(dtable);
            comboVisi.DataSource = dtable;
            comboVisi.ValueMember = "VISIBILIDAD_DESC";
            comboVisi.DisplayMember = "Seleccionar VisiLI";
            comboVisi.Text = "Seleccionar Visibilidad";
            Visitxt.Text = "";
            Gradotxt.Text = "";
            Costotxt.Text = "";
            Enviotxt.Text = "";
        }

        private void comboVisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVisi.ValueMember == "")
            {
                    //TODAVIA NO SE SELECCIONÓ NADA
            }
            else
            {
                Object selectedItem = comboVisi.SelectedValue;
                string visi = selectedItem.ToString();
                BasedeDatosForm bd = new BasedeDatosForm();
                bd.conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT [RECUR].[getCostoFijo](@visiDesc);", bd.conexion);
                SqlCommand cmd2 = new SqlCommand("SELECT [RECUR].[GetPorcentaje](@visiDesc);", bd.conexion);
                SqlCommand cmd3 = new SqlCommand("SELECT [RECUR].[GetCostoEnvio](@visiDesc);", bd.conexion);
                cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd.Parameters["@visiDesc"].Value = visi;
                costoFijo = Convert.ToSingle(cmd.ExecuteScalar());
                cmd2.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd2.Parameters["@visiDesc"].Value = visi;
                costoPorcentaje = Convert.ToSingle(cmd2.ExecuteScalar());
                cmd3.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd3.Parameters["@visiDesc"].Value = visi;
                costoEnvio =cmd3.ExecuteScalar();
                bd.conexion.Close();
                borrarVisi.Enabled = true;
                Visitxt.Text = visi.ToString();
                Costotxt.Text = costoFijo.ToString();
                Gradotxt.Text = costoPorcentaje.ToString();
                if (costoEnvio == DBNull.Value)
                {
                    Enviotxt.Text = "No posee";

                }
                else
                {
                    Convert.ToSingle(costoEnvio);
                    Enviotxt.Text = costoEnvio.ToString();
                }

            }
        }

        private void borrarVisi_Click(object sender, EventArgs e)
        {
            Object selectedItem = comboVisi.SelectedValue;
            string visi = selectedItem.ToString();

            if (existePublicacion())
            {
                MessageBox.Show("No se puede borrar, existen publicaciones con esta visibilidad activa");

            }
            else
            {
                BasedeDatosForm bd = new BasedeDatosForm();
                bd.conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT [RECUR].[getVisi](@visiDesc);", bd.conexion);
                cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd.Parameters["@visiDesc"].Value = visi;
                visiID = Convert.ToInt32(cmd.ExecuteScalar());
                SqlCommand cmd2 = new SqlCommand("[RECUR].[BorrarVisi]", bd.conexion);
                cmd2.Parameters.Add("@visiID", SqlDbType.Int).Value = visiID;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Borrado exitosamente");
                bd.conexion.Close();
                llenarCombo_visi();



            }
        }

        private bool existePublicacion()
        {

            Object selectedItem = comboVisi.SelectedValue;
            string visi = selectedItem.ToString();
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT [RECUR].[getVisi](@visiDesc);", bd.conexion);
            cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
            cmd.Parameters["@visiDesc"].Value = visi;
            visiID = Convert.ToInt32(cmd.ExecuteScalar());
            SqlCommand cmd2 = new SqlCommand("SELECT [RECUR].[ExistePublicacionConVisi](@visiID);", bd.conexion);
            cmd2.Parameters.Add("@visiID", SqlDbType.Int);
            cmd2.Parameters["@visiID"].Value = visiID;
            bool c = (Boolean)cmd2.ExecuteScalar();
            bd.conexion.Close();
            if(c == true)
            {
                    return true;
            }
            else
            {
                return false;

            }

        }

    }
}


