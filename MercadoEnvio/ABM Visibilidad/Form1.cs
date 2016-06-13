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
    public partial class Form1 : Form
    {

        BasedeDatosForm bd = new BasedeDatosForm(); 
        Int32 visiID;
        Single porcentajePubli;
        Single precioComision;
        //ejemplo
        Single precioPublicacion = 555.2F;
        Single costofijo;
        Int32 usuarioID;
        Int32 cantPublicaciones;


        public Form1()
        {
            //this.bd = db;
            //PARA CALCULAR COMI
            // this.precioPublicacion = precio;
            //para calcular si le corresponde publicacion gratuita
            //this.usuarioID = usuario;
            InitializeComponent();
        }

        private Boolean tienePublicacionGratis(int usuarioID)
        {
          /*  bd.conexion.Open();
            if (usuarioID > 95)
            {
                SqlCommand cmd = new SqlCommand("SELECT [RECUR].[cantPublicaciones](@usuarioID)", bd.conexion);
                cmd.Parameters.Add("@usuarioID", SqlDbType.Int);
                cmd.Parameters["@usuarioID"].Value = this.usuarioID;
                cantPublicaciones = (Int32)cmd.ExecuteScalar();
                if (cantPublicaciones > 0)
                    return false;
                else
                    return true;
            }
            else*/
            //return true;
                return false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBox1.SelectedValue.ToString() == "Gratis")
            {
                checkBox1.Enabled = false;
            }
            else
                checkBox1.Enabled = true;

          
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sSql = "SELECT VISIBILIDAD_DESC FROM GD1C2016.RECUR.TIPO_VISIBILIDAD";
            DataTable dt = bd.select_query(sSql);
            comboBox1.DataSource = dt;
            //comboBox1.DisplayMember = "VISIBILIDAD_DESC";
            comboBox1.ValueMember = "VISIBILIDAD_DESC";
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tienePublicacionGratis(usuarioID))
            {
                label2.Text = "´No se cobrará comisión por ser tu primera venta";
                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;

            }
            Object selectedItem = comboBox1.SelectedValue;
            string visi = selectedItem.ToString();
            bd.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT [RECUR].[GetPorcentaje](@visiPorc);", bd.conexion);
            SqlCommand cmd2 = new SqlCommand("SELECT [RECUR].[GetCostoFijo](@visiCostoFijo);", bd.conexion);
            cmd.Parameters.Add("@visiPorc", SqlDbType.NVarChar, 10);
            cmd.Parameters["@visiPorc"].Value = visi;
            cmd2.Parameters.Add("@visiCostofijo", SqlDbType.NVarChar, 10);
            cmd2.Parameters["@visiCostoFIjo"].Value = visi;
            porcentajePubli = Convert.ToSingle(cmd.ExecuteScalar());
            costofijo = Convert.ToSingle(cmd2.ExecuteScalar());
            bd.conexion.Close();
            precioComision = porcentajePubli * precioPublicacion;
            label3.Text = "$" + precioComision.ToString();
            label5.Text = "$" + costofijo.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedValue;
            string visi = selectedItem.ToString();
            bd.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT [RECUR].[getVisi](@visiDesc);", bd.conexion);
            cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 10);
            cmd.Parameters["@visiDesc"].Value = visi;
            visiID = (Int32)cmd.ExecuteScalar();
            bd.conexion.Close();

           // return visiID;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
    
}
