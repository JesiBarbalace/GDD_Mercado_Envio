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
    public partial class AltaUsuario : Form
    {
        public string documento;

        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            gbDatosPersonales.Visible = false;
            gbDireccion.Visible = false;
            btnAlta.Visible = false;
        }
        private void cmbRolUsu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbRolUsu.Text == "System.Data.DataRowView")
            {
                cmbRolUsu.Text = "Seleccione un Rol";
                return;
            }
            if (cmbRolUsu.Text == "Cliente")
            {
                gbDatosPersonales.Visible = true;
                gbDireccion.Visible = true;
                btnAlta.Visible = true;

                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtDoc1.Enabled = true;
                txtFechNac.Enabled = true;

                txtNombre.Visible = true;
                txtApellido.Visible = true;
                txtDoc1.Visible = true;
                txtFechNac.Visible = true;

                txtNombre.BackColor = SystemColors.HighlightText;
                txtApellido.BackColor = SystemColors.HighlightText;
                txtDoc1.BackColor = SystemColors.HighlightText;
                txtFechNac.BackColor = SystemColors.HighlightText;

                txtRazonSocial.Enabled = false;
                txtDocE1.Enabled = false;
                txtDocE2.Enabled = false;
                txtDocE3.Enabled = false;
                txtContacto.Enabled = false;
                cmbRubros.Enabled = false;
                txtCiudad.Enabled = false;

                txtRazonSocial.Visible = true;
                txtDocE1.Visible = true;
                txtDocE2.Visible = true;
                txtDocE3.Visible = true;
                txtContacto.Visible = true;
                cmbRubros.Visible = true;

                txtRazonSocial.BackColor = SystemColors.ControlLight;
                txtDocE1.BackColor = SystemColors.ControlLight;
                txtDocE2.BackColor = SystemColors.ControlLight;
                txtDocE3.BackColor = SystemColors.ControlLight;
                txtContacto.BackColor = SystemColors.ControlLight;
                cmbRubros.BackColor = SystemColors.ControlLight;
                txtCiudad.BackColor = SystemColors.ControlLight;

                txtCalle.Visible = true;
                txtNroCalle.Visible = true;
                txtPiso.Visible = true;
                txtDepto.Visible = true;
                txtLocalidad.Visible = true;
                txtCP.Visible = true;
                txtCiudad.Visible = true;
                txtTelefono.Visible = true;
                txtMail.Visible = true;

                txtCalle.Enabled = true;
                txtNroCalle.Enabled = true;
                txtPiso.Enabled = true;
                txtDepto.Enabled = true;
                txtLocalidad.Enabled = true;
                txtCP.Enabled = true;
                txtCiudad.Enabled = false;
                txtTelefono.Enabled = true;
                txtMail.Enabled = true;

                txtCalle.BackColor = SystemColors.HighlightText;
                txtNroCalle.BackColor = SystemColors.HighlightText;
                txtPiso.BackColor = SystemColors.HighlightText;
                txtDepto.BackColor = SystemColors.HighlightText;
                txtLocalidad.BackColor = SystemColors.HighlightText;
                txtCP.BackColor = SystemColors.HighlightText;
                txtTelefono.BackColor = SystemColors.HighlightText;
                txtMail.BackColor = SystemColors.HighlightText;


                txtCalle.Clear();
                txtNroCalle.Clear();
                txtPiso.Clear();
                txtDepto.Clear();
                txtLocalidad.Clear();
                txtCP.Clear();
                txtCiudad.Clear();
                txtTelefono.Clear();
                txtMail.Clear();

                txtRazonSocial.Clear();
                txtDocE1.Clear();
                txtDocE2.Clear();
                txtDocE3.Clear();
                txtContacto.Clear();


            }

            if (cmbRolUsu.Text == "Empresa")
            {
                gbDatosPersonales.Visible = true;
                gbDireccion.Visible = true;
                btnAlta.Visible = true;

                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDoc1.Enabled = false;
                txtFechNac.Enabled = false;

                txtNombre.Visible = true;
                txtApellido.Visible = true;
                txtDoc1.Visible = true;
                txtFechNac.Visible = true;

                txtNombre.BackColor = SystemColors.ControlLight;
                txtApellido.BackColor = SystemColors.ControlLight;
                txtDoc1.BackColor = SystemColors.ControlLight;
                txtFechNac.BackColor = SystemColors.ControlLight;

                txtRazonSocial.Enabled = true;
                txtDocE1.Enabled = true;
                txtDocE2.Enabled = true;
                txtDocE3.Enabled = true;
                txtContacto.Enabled = true;
                cmbRubros.Enabled = true;

                txtRazonSocial.Visible = true;
                txtDocE1.Visible = true;
                txtDocE2.Visible = true;
                txtDocE3.Visible = true;
                txtContacto.Visible = true;
                cmbRubros.Visible = true;

                txtRazonSocial.BackColor = SystemColors.HighlightText;
                txtDocE1.BackColor = SystemColors.HighlightText;
                txtDocE2.BackColor = SystemColors.HighlightText;
                txtDocE3.BackColor = SystemColors.HighlightText;
                txtContacto.BackColor = SystemColors.HighlightText;
                cmbRubros.BackColor = SystemColors.HighlightText;

                txtCalle.Visible = true;
                txtNroCalle.Visible = true;
                txtPiso.Visible = true;
                txtDepto.Visible = true;
                txtLocalidad.Visible = true;
                txtCP.Visible = true;
                txtCiudad.Visible = true;
                txtTelefono.Visible = true;
                txtMail.Visible = true;

                txtCalle.Enabled = true;
                txtNroCalle.Enabled = true;
                txtPiso.Enabled = true;
                txtDepto.Enabled = true;
                txtLocalidad.Enabled = true;
                txtCP.Enabled = true;
                txtCiudad.Enabled = true;
                txtTelefono.Enabled = true;
                txtMail.Enabled = true;

                txtCalle.BackColor = SystemColors.HighlightText;
                txtNroCalle.BackColor = SystemColors.HighlightText;
                txtPiso.BackColor = SystemColors.HighlightText;
                txtDepto.BackColor = SystemColors.HighlightText;
                txtLocalidad.BackColor = SystemColors.HighlightText;
                txtCP.BackColor = SystemColors.HighlightText;
                txtCiudad.BackColor = SystemColors.HighlightText;
                txtTelefono.BackColor = SystemColors.HighlightText;
                txtMail.BackColor = SystemColors.HighlightText;


                txtCalle.Clear();
                txtNroCalle.Clear();
                txtPiso.Clear();
                txtDepto.Clear();
                txtLocalidad.Clear();
                txtCP.Clear();
                txtCiudad.Clear();
                txtTelefono.Clear();
                txtMail.Clear();

                txtRazonSocial.Clear();
                txtDocE1.Clear();
                txtDocE2.Clear();
                txtDocE3.Clear();
                txtContacto.Clear();

                LlenarRubros_ComboBox();

            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoc1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDocE3_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtDocE1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDocE2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDocE3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public void LlenarRubros_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new CliEmp().getRubros();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbRubros.Text = "Seleccionar Rubro";
            cmbRubros.DataSource = dtable;
            cmbRubros.ValueMember = "RUBRO_DESC_CORTA";
            cmbRubros.DisplayMember = "Seleccionar Rubro";
            cmbRubros.Text = "Seleccionar Rubro";
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            string vacio = "";

            if (cmbRolUsu.Text == "Cliente")
            {
                if ((String.Compare(txtApellido.Text, vacio) == 0) || (String.Compare(txtNombre.Text, vacio) == 0) || (String.Compare(txtDoc1.Text, vacio) == 0) || (String.Compare(txtFechNac.Text, vacio) == 0) || (String.Compare(txtCalle.Text, vacio) == 0) || (String.Compare(txtNroCalle.Text, vacio) == 0) || (String.Compare(txtDepto.Text, vacio) == 0) || (String.Compare(txtPiso.Text, vacio) == 0) || (String.Compare(txtCP.Text, vacio) == 0) || (String.Compare(txtLocalidad.Text, vacio) == 0) || (String.Compare(txtTelefono.Text, vacio) == 0) || (String.Compare(txtMail.Text, vacio) == 0))
                {
                    MessageBox.Show("Faltan completar algunos campos obligatorios. Revise los campos en rojo.");
                    gbDatosPersonales.Visible = true;
                    gbDireccion.Visible = true;
                    label2.ForeColor = Color.Red;

                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;

                    label15.ForeColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label22.ForeColor = Color.Red;
                    label18.ForeColor = Color.Red;
                    label19.ForeColor = Color.Red;
                    label20.ForeColor = Color.Red;


                }
                else
                {
                    Usuario usu = new Usuario();
                    string apellido = txtApellido.Text;
                    string nombre = txtNombre.Text;
                    int dni = Int32.Parse(txtDoc1.Text);
                    string pass = usu.SHA256Encripta(txtPass.Text);
                    string fechanac = txtFechNac.Text;
                    string calle = txtCalle.Text;
                    int nrocalle = Int32.Parse(txtNroCalle.Text);
                    int piso = Int32.Parse(txtPiso.Text);
                    string depto = txtDepto.Text;
                    string localidad = txtLocalidad.Text;
                    string cp = txtCP.Text;
                    int tel = Int32.Parse(txtTelefono.Text);
                    string mail = txtMail.Text;

                    resultado = new CliEmp().InsertarCliente(apellido, nombre, dni, pass, fechanac, calle, nrocalle, depto, piso, cp, localidad, tel, mail);

                    if (resultado == 1)
                    {
                        MessageBox.Show("El Usuario fue ingresado correctamente");

                        gbDatosPersonales.Visible = false;
                        gbDireccion.Visible = false;
                        cmbRolUsu.Text = "Seleccione un Rol";

                        label2.ForeColor = SystemColors.ControlText;

                        label4.ForeColor = SystemColors.ControlText;
                        label5.ForeColor = SystemColors.ControlText;
                        label7.ForeColor = SystemColors.ControlText;
                        label8.ForeColor = SystemColors.ControlText;

                        label15.ForeColor = SystemColors.ControlText;
                        label21.ForeColor = SystemColors.ControlText;
                        label17.ForeColor = SystemColors.ControlText;
                        label16.ForeColor = SystemColors.ControlText;
                        label22.ForeColor = SystemColors.ControlText;
                        label18.ForeColor = SystemColors.ControlText;
                        label19.ForeColor = SystemColors.ControlText;
                        label20.ForeColor = SystemColors.ControlText;

                        txtApellido.Clear();
                        txtNombre.Clear();
                        txtDoc1.Clear();
                        txtPass.Clear();
                        txtFechNac.Clear();
                        txtCalle.Clear();
                        txtNroCalle.Clear();
                        txtPiso.Clear();
                        txtDepto.Clear();
                        txtLocalidad.Clear();
                        txtCP.Clear();
                        txtTelefono.Clear();
                        txtMail.Clear();
                        txtUser.Clear();

                        btnAlta.Visible = false;

                    }
                    else
                        MessageBox.Show("Hubo un problema al querer dar de alta el Usuario, intente nuevamente");

                }
            }

            if (cmbRolUsu.Text == "Empresa")
            {
                if ((String.Compare(txtPass.Text, vacio) == 0) || (String.Compare(txtRazonSocial.Text, vacio) == 0) || (String.Compare(txtDocE1.Text, vacio) == 0) || (String.Compare(txtDocE2.Text, vacio) == 0) || (String.Compare(txtDocE3.Text, vacio) == 0) || (String.Compare(txtContacto.Text, vacio) == 0) || (String.Compare(cmbRubros.Text, vacio) == 0) || (String.Compare(txtCalle.Text, vacio) == 0) || (String.Compare(txtNroCalle.Text, vacio) == 0) || (String.Compare(txtDepto.Text, vacio) == 0) || (String.Compare(txtPiso.Text, vacio) == 0) || (String.Compare(txtCP.Text, vacio) == 0) || (String.Compare(txtLocalidad.Text, vacio) == 0) || (String.Compare(txtTelefono.Text, vacio) == 0) || (String.Compare(txtMail.Text, vacio) == 0) || (String.Compare(txtCiudad.Text, vacio) == 0))
                {
                    MessageBox.Show("Faltan completar algunos campos obligatorios. Revise los campos en rojo.");
                    gbDatosPersonales.Visible = true;
                    gbDireccion.Visible = true;

                    label2.ForeColor = Color.Red;

                    label9.ForeColor = Color.Red;
                    label13.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                    label14.ForeColor = Color.Red;

                    label15.ForeColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label22.ForeColor = Color.Red;
                    label18.ForeColor = Color.Red;
                    label19.ForeColor = Color.Red;
                    label20.ForeColor = Color.Red;
                    label23.ForeColor = Color.Red;


                }
                else
                {
                    Usuario usu = new Usuario();
                    string razonsoc = txtRazonSocial.Text;
                    string username = documento;
                    string doc;
                    if (txtDocE1.TextLength == 1)
                        doc = "0" + txtDocE1.Text + "-" + txtDocE2.Text + "-" + txtDocE3.Text;
                    else
                    {
                        doc = txtDocE1.Text + "-" + txtDocE2.Text + "-" + txtDocE3.Text;
                    }
                    string pass = usu.SHA256Encripta(txtPass.Text);
                    string contacto = txtContacto.Text;
                    string rubro = cmbRubros.Text;
                    string calle = txtCalle.Text;
                    int nrocalle = Int32.Parse(txtNroCalle.Text);
                    int piso = Int32.Parse(txtPiso.Text);
                    string depto = txtDepto.Text;
                    string localidad = txtLocalidad.Text;
                    string cp = txtCP.Text;
                    int tel = Int32.Parse(txtTelefono.Text);
                    string mail = txtMail.Text;
                    string ciudad = txtCiudad.Text;

                    resultado = new CliEmp().InsertarEmpresa(razonsoc, username, doc, pass, contacto, rubro, calle, nrocalle, depto, piso, cp, localidad, tel, mail, ciudad);

                    if (resultado == 1)
                    {
                        MessageBox.Show("El Usuario fue ingresado correctamente");

                        gbDatosPersonales.Visible = false;
                        gbDireccion.Visible = false;
                        cmbRolUsu.Text = "Seleccione un Rol";

                        label2.ForeColor = SystemColors.ControlText;

                        label9.ForeColor = SystemColors.ControlText;
                        label13.ForeColor = SystemColors.ControlText;
                        label12.ForeColor = SystemColors.ControlText;
                        label14.ForeColor = SystemColors.ControlText;

                        label15.ForeColor = SystemColors.ControlText;
                        label21.ForeColor = SystemColors.ControlText;
                        label17.ForeColor = SystemColors.ControlText;
                        label16.ForeColor = SystemColors.ControlText;
                        label22.ForeColor = SystemColors.ControlText;
                        label18.ForeColor = SystemColors.ControlText;
                        label19.ForeColor = SystemColors.ControlText;
                        label20.ForeColor = SystemColors.ControlText;
                        label23.ForeColor = SystemColors.ControlText;


                        txtRazonSocial.Clear();
                        txtDocE2.Clear();
                        txtDocE1.Clear();
                        txtDocE3.Clear();
                        txtPass.Clear();
                        txtContacto.Clear();
                        cmbRubros.Text = "";
                        txtCalle.Clear();
                        txtNroCalle.Clear();
                        txtPiso.Clear();
                        txtDepto.Clear();
                        txtLocalidad.Clear();
                        txtCP.Clear();
                        txtTelefono.Clear();
                        txtMail.Clear();
                        txtUser.Clear();
                        txtCiudad.Clear();

                        btnAlta.Visible = false;

                    }
                    else
                        MessageBox.Show("Hubo un problema al querer dar de alta el Usuario, intente nuevamente");

                }
            }

        }

        private void txtDoc1_Leave(object sender, EventArgs e)
        {
            int resultado = 0;
            string documento;

            if (cmbRolUsu.Text == "Cliente")
            {
                documento = txtDoc1.Text;

                if ((documento.Length < 7) || (documento.Length > 8))
                {
                    MessageBox.Show("El documento tiene una cantidad de caracteres no válido");
                    txtDoc1.Clear();
                }

                //if (documento.Length == 7)
                //    documento = "0" + txtDoc1.Text;

                resultado = new CliEmp().ValidarDocumento(documento);

                if (resultado == 1)
                {
                    MessageBox.Show("Este usuario ya se encuentra creado. Cambie el número de documento.");
                    txtDoc1.Clear();
                }

                txtUser.Text = documento;

            }
        }

        private void txtDocE3_Leave(object sender, EventArgs e)
        {
            int resultado = 0;
            string doc1;
            string doc2;
            string doc3;
            string vacio = "";

            if (cmbRolUsu.Text == "Empresa")
            {

                if ((String.Compare(txtDocE1.Text, vacio) == 0) || (String.Compare(txtDocE2.Text, vacio) == 0) || (String.Compare(txtDocE3.Text, vacio) == 0))
                {
                    MessageBox.Show("El documento no está completo, por favor, ingrese todos los números.");
                    return;
                }

                doc1 = txtDocE1.Text;
                doc2 = txtDocE2.Text;
                doc3 = txtDocE3.Text;


                if ((doc1.Length < 2) || (doc1.Length > 2))
                {
                    if (doc1.Length == 1)
                    {
                        doc1 = "0" + txtDocE1.Text;
                    }
                    else
                    {
                        MessageBox.Show("El documento tiene una cantidad de caracteres no válido");
                        txtDocE1.Clear();
                        return;
                    }
                }

                if ((doc2.Length < 7) || (doc2.Length > 8))
                {
                    MessageBox.Show("El documento tiene una cantidad de caracteres no válido");
                    txtDocE2.Clear();
                    return;
                }

                if ((doc3.Length < 2) || (doc3.Length > 2))
                {
                    MessageBox.Show("El documento tiene una cantidad de caracteres no válido");
                    txtDocE3.Clear();
                    return;
                }

                documento = doc1 + doc2 + doc3;

                resultado = new CliEmp().ValidarDocumento(documento);

                if (resultado == 1)
                {
                    MessageBox.Show("Este usuario ya se encuentra creado. Cambie el número de documento.");
                    txtDocE1.Clear();
                    txtDocE2.Clear();
                    txtDocE3.Clear();
                }

                txtUser.Text = documento;

            }
        }

    }
}
