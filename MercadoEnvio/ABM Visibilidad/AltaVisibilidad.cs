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
    public partial class AltaVisibilidad : Form
    {
        public AltaVisibilidad()
        {
            InitializeComponent();


            txtNombreVisi.Enabled = true;
            txtNombreVisi.Clear();
            LlenarVisibilidades_DataGridView();

            btnGrabarVisibilidad.Enabled = true;
        }

        public void LlenarVisibilidades_DataGridView()
        {
            DataTable dtable;
            dtable = new Visibilidad().TraerVisibilidades();
            dgvTotalFunc.Rows.Clear();
            foreach (DataRow dtRow in dtable.Rows)
            {
                int renglon = dgvTotalFunc.Rows.Add();
               // dgvTotalFunc.Rows[renglon].Cells["VISIBILIDAD_ID"].Value = (Convert.ToInt32(dtRow["VISIBILIDAD_ID"]));
                dgvTotalFunc.Rows[renglon].Cells["VISIBILIDAD_DESC"].Value = Convert.ToString(dtRow["VISIBILIDAD_DESC"]);
                
            }



        }

        private void dgvTotalFunc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGrabarVisibilidad_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                
                if (txtNombreVisi.Text == "" || Costotxt.Text == "" || Porcentajetxt.Text == "" || Enviotxt.Text == "")
                {
                    MessageBox.Show("Debe completar los datos requeridos de la visibilidad para poder grabarlo");
                    return;
                }
            }
            else
            {
                if(txtNombreVisi.Text == "" || Costotxt.Text == "" || Porcentajetxt.Text == "")
                {
                    MessageBox.Show("Debe completar los datos requeridos de la visibilidad para poder grabarlo");
                    return;
                }
            }

            //Verifico si ya está el nombre de la visibilidad en la lista (Lo hago con sp, si me devuelve un registro es que ya hay una visi con ese nombre)
            int visibilidad_existe = 0;
            string nombre = txtNombreVisi.Text;
            nombre = nombre.ToUpper();
            visibilidad_existe = new Visibilidad().VerificarVisibilidad(nombre);
            if (visibilidad_existe != 0)
            {
                MessageBox.Show("Ya existe una visibilidad con ese nombre. Intente con otro");
                return;
            }
            else
            {
                if (checkBox1.Checked == true)
                {

                    //insert con envio
                    BasedeDatosForm bd = new BasedeDatosForm();
                    bd.conexion.Open();
                     SqlCommand cmd2 = new SqlCommand("SELECT [RECUR].[GetCodigoVisi]()", bd.conexion);
                    Int32 cod_visi = Convert.ToInt32(cmd2.ExecuteScalar());
                    SqlCommand cmd = new SqlCommand("[RECUR].[AltaVisibilidadConEnvio]", bd.conexion);
                    cmd.Parameters.Add("@visiCod", SqlDbType.Int).Value = cod_visi;
                    cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30).Value = txtNombreVisi.Text;
                    cmd.Parameters.Add("@visiCosto", SqlDbType.Decimal).Value = Convert.ToDecimal(Costotxt.Text);
                    cmd.Parameters.Add("@visiPorcentaje", SqlDbType.Decimal).Value = Convert.ToDecimal(Porcentajetxt.Text);
                    cmd.Parameters.Add("@visiEnvio", SqlDbType.Decimal).Value = Convert.ToDecimal(Enviotxt.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se dio de alta exitosamente");
                    LlenarVisibilidades_DataGridView();
                    bd.conexion.Close();
                    return;
                }
                else
                {

                    //insert envio no disponible
                    BasedeDatosForm bd = new BasedeDatosForm();
                    bd.conexion.Open();
                     SqlCommand cmd2 = new SqlCommand("SELECT [RECUR].[GetCodigoVisi]()", bd.conexion);
                    Int32 cod_visi = Convert.ToInt32(cmd2.ExecuteScalar());
                    SqlCommand cmd = new SqlCommand("[RECUR].[AltaVisibilidadSinEnvio]", bd.conexion);
                    cmd.Parameters.Add("@visiCod", SqlDbType.Int).Value = cod_visi;
                    cmd.Parameters.Add("@visiDesc", SqlDbType.NVarChar, 30).Value = txtNombreVisi.Text;
                    cmd.Parameters.Add("@visiCosto", SqlDbType.Decimal).Value = Convert.ToDecimal(Costotxt.Text);
                    cmd.Parameters.Add("@visiPorcentaje", SqlDbType.Decimal).Value = Convert.ToDecimal(Porcentajetxt.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se dio de alta exitosamente");
                    bd.conexion.Close();
                    LlenarVisibilidades_DataGridView();
                    return;
                }

               
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
                Enviotxt.Enabled = true;
            else
                Enviotxt.Enabled = false;
        }

        private void AltaVisibilidad_Load(object sender, EventArgs e)
        {

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

        private void Costotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if(Costotxt.Text.Contains("."))
            {
                if ((e.KeyChar == '.') || Costotxt.Text == "")
                 {
                     MessageBox.Show("Ingrese un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     e.Handled = true;
                     return;
                 }
            }

        }

        private void Porcentajetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
           if (Porcentajetxt.Text.Contains("."))
            {     
                 if ((e.KeyChar == '.') || Porcentajetxt.Text == "")
            {
                MessageBox.Show("Ingrese un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
             }
        }

        private void Enviotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (Enviotxt.Text.Contains("."))
            {
                if ((e.KeyChar == '.') || Enviotxt.Text == "")
                {
                    MessageBox.Show("Ingrese un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}
