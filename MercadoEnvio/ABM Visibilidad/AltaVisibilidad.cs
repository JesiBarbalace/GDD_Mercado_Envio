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

                //INSERT CON ESTOS DATOS, VER VISIBILIDAD_COD Y SI VA A CAMBIAR ENVIOS
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
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Porcentajetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Enviotxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
