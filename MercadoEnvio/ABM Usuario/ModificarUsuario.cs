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

namespace MercadoEnvio.ABM_Usuario
{
    public partial class ModificarUsuario : Form
    {
        public ModificarUsuario()
        {
            InitializeComponent();
        }

       private void dgvBusqEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if ((Convert.ToInt32(dgvBusqEmp.Rows[e.RowIndex].Cells["HABILITADOE"].Value) == 1))
                    ModificarEmpresa(Convert.ToString(dgvBusqEmp.Rows[e.RowIndex].Cells["USERNAME"].Value));
                else
                {
                    MessageBox.Show("El Usuario no se puede eliminar porque ya se encuentra inhabilitado");
                }

            }
        }

       private void dgvBusqCli_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           if (e.ColumnIndex == 0)
           {

               if ((Convert.ToInt32(dgvBusqCli.Rows[e.RowIndex].Cells["HABILITADOCLI"].Value) == 1))
                   ModificarCliente(Convert.ToString(dgvBusqCli.Rows[e.RowIndex].Cells["USERNAMECLI"].Value));
               else
               {
                   MessageBox.Show("El Usuario no se puede eliminar porque ya se encuentra inhabilitado");
               }

           }
       }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDoc.Enabled = false;
            txtMail.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtDocE.Enabled = false;
            txtMailE.Enabled = false;
            dgvBusqCli.Visible = false;
            dgvBusqEmp.Visible = false;
            cmbRoles.DisplayMember = "Seleccionar Rol";
            cmbRoles.Text = "Seleccionar Rol";
        }

        private void cmbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbRoles.Text == "System.Data.DataRowView")
            {
                cmbRoles.Text = "Seleccione un Rol";
                return;
            }
            if (cmbRoles.Text == "Cliente")
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtDoc.Enabled = true;
                txtMail.Enabled = true;
                txtRazonSocial.Enabled = false;
                txtDocE.Enabled = false;
                txtMailE.Enabled = false;
                dgvBusqCli.Visible = false;
                dgvBusqEmp.Visible = false;
                txtRazonSocial.BackColor = SystemColors.ControlLight;
                txtDocE.BackColor = SystemColors.ControlLight;
                txtMailE.BackColor = SystemColors.ControlLight;
                txtNombre.BackColor = SystemColors.HighlightText;
                txtApellido.BackColor = SystemColors.HighlightText;
                txtDoc.BackColor = SystemColors.HighlightText;
                txtMail.BackColor = SystemColors.HighlightText;
                txtRazonSocial.Clear();
                txtDocE.Clear();
                txtMailE.Clear();
            }

            if (cmbRoles.Text == "Empresa")
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDoc.Enabled = false;
                txtMail.Enabled = false;
                txtRazonSocial.Enabled = true;
                txtDocE.Enabled = true;
                txtMailE.Enabled = true;
                dgvBusqCli.Visible = false;
                dgvBusqEmp.Visible = false;
                txtNombre.BackColor = SystemColors.ControlLight;
                txtApellido.BackColor = SystemColors.ControlLight;
                txtDoc.BackColor = SystemColors.ControlLight;
                txtMail.BackColor = SystemColors.ControlLight;
                txtRazonSocial.BackColor = SystemColors.HighlightText;
                txtDocE.BackColor = SystemColors.HighlightText;
                txtMailE.BackColor = SystemColors.HighlightText;
                txtNombre.Clear();
                txtApellido.Clear();
                txtDoc.Clear();
                txtMail.Clear();

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.Text == "Cliente" || cmbRoles.Text == "Empresa")
            {
                if (cmbRoles.Text == "Cliente")
                {
                    ObtenerClientes_DataGridView();
                }
                else
                    ObtenerEmpresa_DataGridView();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Rol para comenzar la búsqueda");

            }
        }

        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDocE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        public void ObtenerClientes_DataGridView()
        {

            dgvBusqCli.Visible = true;
            dgvBusqEmp.Visible = false;
            DataTable dtable;
            string vacio = "";
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            //Validacion por vacio
            int doc;
            string mail = txtMail.Text;

            if (String.Compare(txtNombre.Text, vacio) == 0)
                nombre = null;

            if (String.Compare(txtApellido.Text, vacio) == 0)
                apellido = null;


            if (String.Compare(txtMail.Text, vacio) == 0)
                mail = null;

            if (String.Compare(txtDoc.Text, vacio) == 0)
                doc = 0;
            else
                doc = Int32.Parse(txtDoc.Text);

            dtable = new CliEmp().ObtenerBusqClie(nombre, apellido, doc, mail);
            //limpiamos los renglones de la datagridview
            dgvBusqCli.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand

            if (dtable.Rows.Count == 0)
                MessageBox.Show("No se encuentraron resultados para la búsqueda realizada");
            else
            {
                //el ciclo while se ejecutará mientras lea registros en la tabla
                foreach (DataRow dtRow in dtable.Rows)
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dgvBusqCli.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombredelacelda].valor=
                    // dr.tipodedatosalmacenado(dr.getordinal(nombredelcampo_en_la_base_de_datos)conviertelo_a_string_sino_es_del_tipo_string);
                    dgvBusqCli.Rows[renglon].Cells["APELLIDO"].Value = Convert.ToString(dtRow["CLI_APELLIDO"]);
                    dgvBusqCli.Rows[renglon].Cells["NOMBRE"].Value = Convert.ToString(dtRow["CLI_NOMBRE"]);
                    dgvBusqCli.Rows[renglon].Cells["DNI"].Value = Convert.ToInt32(dtRow["CLI_NRO_DOC"]);
                    dgvBusqCli.Rows[renglon].Cells["HABILITADOCLI"].Value = Convert.ToInt32(dtRow["USUARIO_HABILITADO"]);
                    dgvBusqCli.Rows[renglon].Cells["USERNAMECLI"].Value = Convert.ToInt32(dtRow["USUARIO_USERNAME"]);
                    dgvBusqCli.Rows[renglon].Cells["FECHANACLI"].Value = Convert.ToDateTime(dtRow["CLI_FECHA_NAC"]);
                    dgvBusqCli.Rows[renglon].Cells["CALLECLI"].Value = Convert.ToString(dtRow["USUARIO_CALLE"]);
                    dgvBusqCli.Rows[renglon].Cells["CALLENROCLI"].Value = Convert.ToInt32(dtRow["USUARIO_CALLE_NRO"]);
                    dgvBusqCli.Rows[renglon].Cells["CPCLI"].Value = Convert.ToInt32(dtRow["USUARIO_CP"]);
                    dgvBusqCli.Rows[renglon].Cells["DEPTOCLI"].Value = Convert.ToInt32(dtRow["USUARIO_DEPTO"]);
                    dgvBusqCli.Rows[renglon].Cells["LOCALIDADCLI"].Value = Convert.ToString(dtRow["USUARIO_LOCALIDAD"]);
                    dgvBusqCli.Rows[renglon].Cells["MAILCLI"].Value = Convert.ToString(dtRow["USUARIO_MAIL"]);
                    dgvBusqCli.Rows[renglon].Cells["PASSCLI"].Value = Convert.ToString(dtRow["USUARIO_PASS"]);
                    dgvBusqCli.Rows[renglon].Cells["PISOCLI"].Value = Convert.ToInt32(dtRow["USUARIO_PISO"]);
                    dgvBusqCli.Rows[renglon].Cells["TELCLI"].Value = Convert.ToInt32(dtRow["USUARIO_TELEFONO"]);
                }
            }
        }

        public void ObtenerEmpresa_DataGridView()
        {
            dgvBusqEmp.Visible = true;
            dgvBusqCli.Visible = false;
            DataTable dtable;
            string vacio = "";
            string razonsocial = txtRazonSocial.Text;
            int doc;
            string mail = txtMailE.Text;

            if (String.Compare(txtRazonSocial.Text, vacio) == 0)
                razonsocial = null;

            if (String.Compare(txtMailE.Text, vacio) == 0)
                mail = null;

            if (String.Compare(txtDocE.Text, vacio) == 0)
                doc = 0;
            else
                doc = Int32.Parse(txtDoc.Text);

            dtable = new CliEmp().ObtenerBusqEmp(razonsocial, doc, mail);
            //limpiamos los renglones de la datagridview
            dgvBusqEmp.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand

            if (dtable.Rows.Count == 0)
                MessageBox.Show("No se encuentraron resultados para la búsqueda realizada");
            else
            {
                //el ciclo while se ejecutará mientras lea registros en la tabla
                foreach (DataRow dtRow in dtable.Rows)
                {
                    //variable de tipo entero para ir enumerando los la filas del datagridview
                    int renglon = dgvBusqEmp.Rows.Add();
                    // especificamos en que fila se mostrará cada registro
                    // nombredeldatagrid.filas[numerodefila].celdas[nombredelacelda].valor=
                    // dr.tipodedatosalmacenado(dr.getordinal(nombredelcampo_en_la_base_de_datos)conviertelo_a_string_sino_es_del_tipo_string);
                    dgvBusqEmp.Rows[renglon].Cells["RAZONS"].Value = Convert.ToString(dtRow["EMPRESA_RAZON_SOCIAL"]);
                    dgvBusqEmp.Rows[renglon].Cells["DOC"].Value = Convert.ToString(dtRow["EMPRESA_NRO_CUIT"]);
                    dgvBusqEmp.Rows[renglon].Cells["HABILITADOEMP"].Value = Convert.ToInt32(dtRow["USUARIO_HABILITADO"]);
                    dgvBusqEmp.Rows[renglon].Cells["USERNAMEEMP"].Value = Convert.ToString(dtRow["USUARIO_USERNAME"]);
                    dgvBusqEmp.Rows[renglon].Cells["CALLEEMP"].Value = Convert.ToString(dtRow["USUARIO_CALLE"]);
                    dgvBusqEmp.Rows[renglon].Cells["CALLENROEMP"].Value = Convert.ToInt32(dtRow["USUARIO_CALLE_NRO"]);
                    dgvBusqEmp.Rows[renglon].Cells["CPEMP"].Value = Convert.ToString(dtRow["USUARIO_CP"]);
                    dgvBusqEmp.Rows[renglon].Cells["DEPTOEMP"].Value = Convert.ToString(dtRow["USUARIO_DEPTO"]);
                    dgvBusqEmp.Rows[renglon].Cells["LOCALIDADEMP"].Value = Convert.ToString(dtRow["USUARIO_LOCALIDAD"]);
                    dgvBusqEmp.Rows[renglon].Cells["MAILEMP"].Value = Convert.ToString(dtRow["USUARIO_MAIL"]);
                    dgvBusqEmp.Rows[renglon].Cells["PASSEMP"].Value = Convert.ToString(dtRow["USUARIO_PASS"]);
                    dgvBusqEmp.Rows[renglon].Cells["PISOEMP"].Value = Convert.ToInt32(dtRow["USUARIO_PISO"]);
                    dgvBusqEmp.Rows[renglon].Cells["TELEMP"].Value = Convert.ToInt32(dtRow["USUARIO_TELEFONO"]);
                    dgvBusqEmp.Rows[renglon].Cells["CIUDADEMP"].Value = Convert.ToString(dtRow["EMPRESA_CIUDAD"]);
                    dgvBusqEmp.Rows[renglon].Cells["CONTACTOEMP"].Value = Convert.ToString(dtRow["EMPRESA_CONTACTO"]);
                    dgvBusqEmp.Rows[renglon].Cells["TIPODOCEMP"].Value = Convert.ToString(dtRow["EMPRESA_TIPO_DOC"]);
                    dgvBusqEmp.Rows[renglon].Cells["RUBROCEMP"].Value = Convert.ToString(dtRow["RUBRO_DESC_CORTA"]);  

                }
            }
        }

        public void ModificarCliente (string bla)
        {
        }

        public void ModificarEmpresa(string bla)
        {
        }
    }
}
