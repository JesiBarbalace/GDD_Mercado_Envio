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
    public partial class ModificacionVisibilidad : Form
    {

        Decimal costoFijo;
        Decimal costoPorcentaje;
        Object costoEnvio;

        public ModificacionVisibilidad()
        {
            InitializeComponent();
            llenarCombo_visi();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHab_Click(object sender, EventArgs e)
        {

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
                costoFijo = Convert.ToDecimal(cmd.ExecuteScalar());
                cmd2.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd2.Parameters["@visiDesc"].Value = visi;
                costoPorcentaje = Convert.ToDecimal(cmd2.ExecuteScalar());
                cmd3.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30);
                cmd3.Parameters["@visiDesc"].Value = visi;
                costoEnvio =cmd3.ExecuteScalar();
                bd.conexion.Close();
                btnGrabarVisi.Enabled = true;
                txtNombreVisi.Enabled = true;
                txtNombreVisi.Text = visi;
                textCostoVisi.Enabled = true;
                textCostoVisi.Text = costoFijo.ToString();
                textGradoVisi.Enabled = true;
                textGradoVisi.Text = costoPorcentaje.ToString();
                if (costoEnvio == DBNull.Value)
                {
                    textEnvioVisi.Clear();
                    textEnvioVisi.Enabled = false;

                }
                else
                {
                    Convert.ToDecimal(costoEnvio);
                    textEnvioVisi.Enabled = true;
                    textEnvioVisi.Text = costoEnvio.ToString();
                }

            }
        }


       private void comboVisi_SelectionChangeCommitted(object sender, EventArgs e)
       {

 
       }


        private void llenarCombo_visi()
        {
            comboVisi.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNombreVisi.Enabled = false;
            textCostoVisi.Enabled = false;
            textGradoVisi.Enabled = false;
            textEnvioVisi.Enabled = false;
            btnGrabarVisi.Enabled = false;
            
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Visibilidad().TraerVisibilidades();
            myDataSet.Tables.Add(dtable);
            comboVisi.DataSource = dtable;
            comboVisi.ValueMember = "VISIBILIDAD_DESC";
            comboVisi.Text = "Seleccionar Visibilidad";
            comboVisi.DisplayMember = "Seleccionar Visi";
            textEnvioVisi.Clear();
            textCostoVisi.Clear();
            textGradoVisi.Clear();
            txtNombreVisi.Clear();

        }

        private void btnGrabarVisi_Click(object sender, EventArgs e)
        {
            int visi_existe = 0;
            string nombre = txtNombreVisi.Text;
            Object selectedItem = comboVisi.SelectedValue;
            string visi = selectedItem.ToString();
            if (nombre.ToUpper() != visi.ToUpper())
            {
               visi_existe = new Visibilidad().VerificarVisibilidad(nombre);
               if (visi_existe != 0)
               {
                   MessageBox.Show("Ya existe una visibilidad con ese nombre. Intente con otro");
                   return;
               }
               else
               {
                   BasedeDatosForm bd = new BasedeDatosForm();
                   bd.openConnection();
                   SqlCommand cmd = new SqlCommand("[RECUR].[ModificarVisi]", bd.conexion);
                   cmd.Parameters.Add("@visiID", SqlDbType.NVarChar,30).Value =visi;
                   cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar,30).Value = nombre;
                   cmd.Parameters.Add("@visiCosto", SqlDbType.Float).Value = textCostoVisi.Text;
                   cmd.Parameters.Add("@visiPorcentaje", SqlDbType.Float).Value = textGradoVisi.Text;
                   if (textEnvioVisi.Enabled == true)
                   {
                       cmd.Parameters.Add("@visiEnvio", SqlDbType.Float).Value = textEnvioVisi.Text;
                   }
                   else
                   {
                       cmd.Parameters.Add("@visiEnvio", SqlDbType.Float).Value = null;
                   }
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.ExecuteNonQuery();
                   bd.conexion.Close();
                   // Visibilidad.modificarVisibilidad(visi, nombre, textCostoVisi.Text, textGradoVisi.Text, textEnvioVisi.Text);
                   MessageBox.Show("Se modificó correctamente");
                   llenarCombo_visi();
               }
            }
            else
            {
                    BasedeDatosForm bd = new BasedeDatosForm();
                    bd.openConnection();
                    SqlCommand cmd = new SqlCommand("[RECUR].[ModificarVisi]", bd.conexion);
                    cmd.Parameters.Add("@visiID", SqlDbType.NVarChar, 30).Value = visi;
                    cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30).Value = nombre;
                    cmd.Parameters.Add("@visiCosto", SqlDbType.Float).Value = textCostoVisi.Text;
                    cmd.Parameters.Add("@visiPorcentaje", SqlDbType.Float).Value = textGradoVisi.Text;
                    if (textEnvioVisi.Enabled == true)
                    {
                        cmd.Parameters.Add("@visiEnvio", SqlDbType.Float).Value = textEnvioVisi.Text;
                        if (txtNombreVisi.Text == "" || textCostoVisi.Text == "" || textGradoVisi.Text == "" || textEnvioVisi.Text == "")
                        {
                            MessageBox.Show("Debe completar todos los campos");
                            return;
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@visiEnvio", SqlDbType.Float).Value = DBNull.Value;
                        if (txtNombreVisi.Text == "" || textCostoVisi.Text == "" || textGradoVisi.Text == "")
                        {
                            MessageBox.Show("Debe completar todos los campos");
                            return;
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    bd.conexion.Close();
                    //Visibilidad.modificarVisibilidad(visi, nombre, textCostoVisi.Text, textGradoVisi.Text, textEnvioVisi.Text);
                    MessageBox.Show("Se modificó correctamente");
                    llenarCombo_visi();
                
            }
        }

        private void textEnvioVisi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCostoVisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textEnvioVisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textGradoVisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombreVisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.') && !(char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras y numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


    }
}
