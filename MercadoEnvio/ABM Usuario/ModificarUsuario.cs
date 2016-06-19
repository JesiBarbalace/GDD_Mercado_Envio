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
                ModificarEmpresa(e.RowIndex);

                if ((Convert.ToInt32(dgvBusqEmp.Rows[e.RowIndex].Cells["HABILITADOEMP"].Value) == 0))
                {
                    btnHabilitar.Enabled = true;
                    btnHabilitar.Visible = true;
                }
               

            }
        }

       private void dgvBusqCli_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           if (e.ColumnIndex == 0)
           {
               ModificarCliente(e.RowIndex);

               if ((Convert.ToInt32(dgvBusqCli.Rows[e.RowIndex].Cells["HABILITADOCLI"].Value) == 0))
               {
                   btnHabilitar.Enabled = true;
                   btnHabilitar.Visible = true;
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
            btnHabilitar.Enabled = true;
            btnHabilitar.Visible = true;
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
            txtNombre.Clear();
            txtApellido.Clear();
            txtDoc.Clear();
            txtMail.Clear();
            txtRazonSocial.Clear();
            txtDocE.Clear();
            txtMailE.Clear();
            btnHabilitar.Enabled = true;
            btnHabilitar.Visible = true;
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
                    dgvBusqCli.Rows[renglon].Cells["FECHANAC"].Value = Convert.ToDateTime(dtRow["CLI_FECHA_NAC"]);
                    if (dtRow["USUARIO_CALLE"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["CALLECLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["CALLECLI"].Value = Convert.ToString(dtRow["USUARIO_CALLE"]);
                    if (dtRow["USUARIO_CALLE_NRO"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["CALLENROCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["CALLENROCLI"].Value = Convert.ToInt32(dtRow["USUARIO_CALLE_NRO"]);
                    if (dtRow["USUARIO_CP"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["CPCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["CPCLI"].Value = Convert.ToInt32(dtRow["USUARIO_CP"]);
                    if (dtRow["USUARIO_DEPTO"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["DEPTOCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["DEPTOCLI"].Value = Convert.ToString(dtRow["USUARIO_DEPTO"]);
                    if (dtRow["USUARIO_LOCALIDAD"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["LOCALIDADCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["LOCALIDADCLI"].Value = Convert.ToString(dtRow["USUARIO_LOCALIDAD"]);
                    if (dtRow["USUARIO_MAIL"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["MAILCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["MAILCLI"].Value = Convert.ToString(dtRow["USUARIO_MAIL"]);
                    if (dtRow["USUARIO_PASS"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["PASSCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["PASSCLI"].Value = Convert.ToString(dtRow["USUARIO_PASS"]);
                    if (dtRow["USUARIO_PISO"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["PISOCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["PISOCLI"].Value = Convert.ToInt32(dtRow["USUARIO_PISO"]);
                    if (dtRow["USUARIO_TELEFONO"] == DBNull.Value)
                        dgvBusqCli.Rows[renglon].Cells["TELCLI"].Value = "";
                    else
                    dgvBusqCli.Rows[renglon].Cells["TELCLI"].Value = Convert.ToString(dtRow["USUARIO_TELEFONO"]);
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
                    if (dtRow["USUARIO_CALLE_NRO"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["CALLENROEMP"].Value = "";
                    else
                        dgvBusqEmp.Rows[renglon].Cells["CALLENROEMP"].Value = Convert.ToInt32(dtRow["USUARIO_CALLE_NRO"]);
                    if (dtRow["USUARIO_CP"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["CPEMP"].Value = "";
                    else
                    dgvBusqEmp.Rows[renglon].Cells["CPEMP"].Value = Convert.ToString(dtRow["USUARIO_CP"]);
                    if (dtRow["USUARIO_DEPTO"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["DEPTOEMP"].Value = "";
                    else
                    dgvBusqEmp.Rows[renglon].Cells["DEPTOEMP"].Value = Convert.ToString(dtRow["USUARIO_DEPTO"]);
                    if (dtRow["USUARIO_LOCALIDAD"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["LOCALIDADEMP"].Value = "";
                    else
                    dgvBusqEmp.Rows[renglon].Cells["LOCALIDADEMP"].Value = Convert.ToString(dtRow["USUARIO_LOCALIDAD"]);

                    dgvBusqEmp.Rows[renglon].Cells["MAILEMP"].Value = Convert.ToString(dtRow["USUARIO_MAIL"]);
                    dgvBusqEmp.Rows[renglon].Cells["PASSEMP"].Value = Convert.ToString(dtRow["USUARIO_PASS"]);
                    dgvBusqEmp.Rows[renglon].Cells["PISOEMP"].Value = Convert.ToInt32(dtRow["USUARIO_PISO"]);
                    if (dtRow["USUARIO_TELEFONO"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["TELEMP"].Value = "";
                    else
                        dgvBusqEmp.Rows[renglon].Cells["TELEMP"].Value = Convert.ToInt32(dtRow["USUARIO_TELEFONO"]);
                    if (dtRow["EMPRESA_CIUDAD"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["CIUDADEMP"].Value = "";
                    else
                        dgvBusqEmp.Rows[renglon].Cells["CIUDADEMP"].Value = Convert.ToString(dtRow["EMPRESA_CIUDAD"]);
                    if (dtRow["EMPRESA_CONTACTO"] == DBNull.Value)
                        dgvBusqEmp.Rows[renglon].Cells["CONTACTOEMP"].Value = "";
                    else
                    dgvBusqEmp.Rows[renglon].Cells["CONTACTOEMP"].Value = Convert.ToString(dtRow["EMPRESA_CONTACTO"]);
                    dgvBusqEmp.Rows[renglon].Cells["TIPODOCEMP"].Value = Convert.ToString(dtRow["EMPRESA_TIPO_DOC"]);
                    dgvBusqEmp.Rows[renglon].Cells["RUBROEMP"].Value = Convert.ToString(dtRow["Column1"]);  

                }
            }
        }

        public void ModificarEmpresa (int fila)
        {
            groupBoxDatosPersonales.Visible = true;
            groupBoxDireccion.Visible = true;
            txtRazonEmp.Visible = true;
            txtDocE1.Visible = true;
            txtDocE2.Visible = true;
            txtDocE3.Visible = true;
            txtContacto.Visible = true;
            txtPassE.Visible = true;
            cmbRubros.Visible = true;
            txtCalle.Visible = true;
            txtNroCalle.Visible = true;
            txtPiso.Visible = true;
            txtDepto.Visible = true;
            txtLocalidad.Visible = true;
            txtCP.Visible = true;
            txtCiudad.Visible = true;
            txtTelefono.Visible = true;
            txtMailB.Visible = true;

            txtRazonEmp.Enabled = true;
            txtDocE1.Enabled = false;
            txtDocE2.Enabled = false;
            txtDocE3.Enabled = false;
            txtContacto.Enabled = true;
            txtPassE.Enabled = true;
            cmbRubros.Enabled = true;
            txtCalle.Enabled = true;
            txtNroCalle.Enabled = true;
            txtPiso.Enabled = true;
            txtDepto.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            txtCiudad.Enabled = true;
            txtTelefono.Enabled = true;
            txtMailB.Enabled = true;

            txtRazonEmp.BackColor = SystemColors.HighlightText;
            txtDocE1.BackColor = SystemColors.ControlLight;
            txtDocE2.BackColor = SystemColors.ControlLight; ;
            txtDocE3.BackColor = SystemColors.ControlLight; ;
            txtContacto.BackColor = SystemColors.HighlightText;
            txtPassE.BackColor = SystemColors.HighlightText;
            txtCalle.BackColor = SystemColors.HighlightText;
            txtNroCalle.BackColor = SystemColors.HighlightText;
            txtPiso.BackColor = SystemColors.HighlightText;
            txtDepto.BackColor = SystemColors.HighlightText;
            txtLocalidad.BackColor = SystemColors.HighlightText;
            txtCP.BackColor = SystemColors.HighlightText;
            txtCiudad.BackColor = SystemColors.HighlightText;
            txtTelefono.BackColor = SystemColors.HighlightText;
            txtMailB.BackColor = SystemColors.HighlightText;


            txtRazonEmp.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["RAZONS"].Value);
            txtDocE1.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["DOC"].Value).Substring(0, 2);
            txtDocE2.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["DOC"].Value).Substring(3, 8);
            txtDocE3.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["DOC"].Value).Substring(9, 2);
            txtContacto.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["CONTACTOEMP"].Value);
            txtPassE.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["PASSEMP"].Value);
            cmbRubros.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["RUBROEMP"].Value);
            txtCalle.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["CALLEEMP"].Value);
            txtNroCalle.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["CALLENROEMP"].Value);
            txtPiso.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["PISOEMP"].Value);
            txtDepto.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["DEPTOEMP"].Value);
            txtLocalidad.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["LOCALIDADEMP"].Value);
            txtCP.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["CPEMP"].Value);
            txtCiudad.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["CIUDADEMP"].Value);
            txtTelefono.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["TELEMP"].Value);
            txtMailB.Text = Convert.ToString(dgvBusqEmp.Rows[fila].Cells["MAILEMP"].Value);
        }

        public void ModificarCliente(int fila)
        {
            groupBoxDatosPersonales.Visible = true;
            groupBoxDireccion.Visible = true;
            txtApeCli.Visible = true;
            txtNombreCli.Visible = true;
            txtDoc1.Visible = true;
            txtPassCli.Visible = true;
            txtFechNac.Visible = true;
            txtCalle.Visible = true;
            txtNroCalle.Visible = true;
            txtPiso.Visible = true;
            txtDepto.Visible = true;
            txtLocalidad.Visible = true;
            txtCP.Visible = true;
            txtTelefono.Visible = true;
            txtMailB.Visible = true;

            txtApeCli.Enabled = true;
            txtNombreCli.Enabled = true;
            txtDoc1.Enabled = true;
            txtPassCli.Enabled = true;
            txtFechNac.Enabled = true;
            txtCalle.Enabled = true;
            txtNroCalle.Enabled = true;
            txtPiso.Enabled = true;
            txtDepto.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            txtTelefono.Enabled = true;
            txtMailB.Enabled = true;

            txtApeCli.BackColor = SystemColors.HighlightText;
            txtNombreCli.BackColor = SystemColors.HighlightText;
            txtDoc1.BackColor = SystemColors.ControlLight;
            txtFechNac.BackColor = SystemColors.HighlightText;
            txtPassCli.BackColor = SystemColors.HighlightText;
            txtCalle.BackColor = SystemColors.HighlightText;
            txtNroCalle.BackColor = SystemColors.HighlightText;
            txtPiso.BackColor = SystemColors.HighlightText;
            txtDepto.BackColor = SystemColors.HighlightText;
            txtLocalidad.BackColor = SystemColors.HighlightText;
            txtCP.BackColor = SystemColors.HighlightText;
            txtTelefono.BackColor = SystemColors.HighlightText;
            txtMailB.BackColor = SystemColors.HighlightText;


            txtApeCli.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["APELLIDO"].Value);
            txtNombreCli.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["NOMBRE"].Value);
            txtDoc1.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["DNI"].Value).Substring(0, 2);
            txtPassCli.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["PASSCLI"].Value);
            txtCalle.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["CALLECLI"].Value);
            txtNroCalle.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["CALLENROCLI"].Value);
            txtPiso.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["PISOCLI"].Value);
            txtDepto.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["DEPTOCLI"].Value);
            txtLocalidad.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["LOCALIDADCLI"].Value);
            txtCP.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["CPCLI"].Value);
            txtTelefono.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["TELCLI"].Value);
            txtMailB.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["MAILCLI"].Value);
            txtFechNac.Text = Convert.ToString(dgvBusqCli.Rows[fila].Cells["FECHANAC"].Value);
            

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            txtApeCli.Clear();
            txtNombreCli.Clear();
            txtDoc1.Clear();
            txtPassCli.Clear();
            txtFechNac.Clear();
            txtCalle.Clear();
            txtNroCalle.Clear();
            txtPiso.Clear();
            txtDepto.Clear();
            txtLocalidad.Clear();
            txtCP.Clear();
            txtTelefono.Clear();
            txtMailB.Clear();


            txtRazonEmp.Clear();
            txtDocE1.Clear();
            txtDocE2.Clear();
            txtDocE3.Clear();
            txtContacto.Clear();
            txtPassE.Clear();
            cmbRubros.Text = "";
            txtCalle.Clear();
            txtNroCalle.Clear();
            txtPiso.Clear();
            txtDepto.Clear();
            txtLocalidad.Clear();
            txtCP.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtMailB.Clear();
            groupBoxDatosPersonales.Visible = false;
            groupBoxDireccion.Visible = false;
        }
    }
}
