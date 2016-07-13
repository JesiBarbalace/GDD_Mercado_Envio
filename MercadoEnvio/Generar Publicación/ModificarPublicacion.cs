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


namespace MercadoEnvio.Generar_Publicación
{
    public partial class ModificarPublicacion : Form
    {
        public string estado_ant = "";

        public ModificarPublicacion()
        {
            InitializeComponent();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Debe completar el Código de Publicación para iniciar la búsqueda");
            else
            {
                ObtenerPublicacion();
            }
        }

        public void ObtenerPublicacion()
        {
            DataTable dtable;
            decimal codigo = decimal.Parse(txtCodigo.Text);
            dtable = new Publicacion().getCodPubli(codigo);

            if (dtable.Rows.Count == 0)
                MessageBox.Show("No se encuentraron resultados para la búsqueda realizada");
            else
            {
                //el ciclo while se ejecutará mientras lea registros en la tabla
                foreach (DataRow dtRow in dtable.Rows)
                {
                    groupBox1.Visible = true;
                    btnGrabar.Visible = true;
                    txtCodigo.ReadOnly = true;
                    btnBuscar.Visible = false;
                    btnLimpiar.Visible = true;

                  
                    LlenarVisibilidad_ComboBox();
                    LlenarRubro_ComboBox();

                    cmbPubli.Text = Convert.ToString(dtRow["PUBLI_TIPO_DESC"]);
                    txtDescripcion.Text = Convert.ToString(dtRow["PUBLICACION_DESC"]);
                    txtStock.Text = Convert.ToString(dtRow["PUBLICACION_STOCK"]);
                    dpInicio.Value = Convert.ToDateTime(dtRow["PUBLICACION_FECHA_INICIO"]);
                    dpVencimiento.Value = Convert.ToDateTime(dtRow["PUBLICACION_FECHA_VENC"]);
                    txtPrecio.Text = Convert.ToString(dtRow["PUBLICACION_PRECIO"]);
                    cmbRubro.Text = Convert.ToString(dtRow["RUBRO_DESC_CORTA"]);
                    cmbVisibilidad.Text = Convert.ToString(dtRow["VISIBILIDAD_DESC"]);
                    txtCosto.Text = Convert.ToString(dtRow["VISIBILIDAD_COSTO_FIJO"]);
                    txtUsuario.Text = Convert.ToString(dtRow["USUARIO_USERNAME"]);
                    cmbEstado.Text = Convert.ToString(dtRow["ESTADO_DESC"]);
                    estado_ant = Convert.ToString(dtRow["ESTADO_DESC"]);
                    string envio = Convert.ToString(dtRow["PUBLICACION_ENVIO"]);
                    string preguntas = Convert.ToString(dtRow["PUBLICACION_PREGUNTA"]);


                    if (envio == "False")
                        cbEnvio.Checked = false;
                    else
                        cbEnvio.Checked = true;
                    if (preguntas == "False")
                        cbPreguntas.Checked = false;
                    else
                        cbPreguntas.Checked = true;

                    cmbPubli.Enabled = false;
                    dpInicio.Enabled = false;

                    if (cmbEstado.Text == "Borrador")
                    {
                        cmbEstado.Items.Add("Borrador");
                        cmbEstado.Items.Add("Activa");
                        txtUsuario.Enabled = false;
                        txtCosto.Enabled = false;

                    }

                    if (cmbEstado.Text == "Activa" || cmbEstado.Text == "Pausada")
                    {
                        cmbEstado.Items.Add("Pausada");
                        cmbEstado.Items.Add("Activa");
                        cmbEstado.Items.Add("Finalizada");
                        txtDescripcion.ReadOnly = true;
                        txtStock.ReadOnly = true;
                        dpInicio.Enabled = false;
                        dpVencimiento.Enabled = false;
                        txtPrecio.ReadOnly = true;
                        cmbRubro.Enabled = false;
                        cmbVisibilidad.Enabled = false;
                        txtCosto.ReadOnly = true;
                        txtUsuario.ReadOnly = true;
                        cbPreguntas.Enabled = false;
                        cbEnvio.Enabled = false;

                    }

                    if (cmbEstado.Text == "Finalizada")
                    {
                        cmbEstado.Enabled = false;
                        txtDescripcion.Enabled = false;
                        txtStock.Enabled = false;
                        dpInicio.Enabled = false;
                        dpVencimiento.Enabled = false;
                        txtPrecio.Enabled = false;
                        cmbRubro.Enabled = false;
                        cmbVisibilidad.Enabled = false;
                        txtCosto.Enabled = false;
                        txtUsuario.Enabled = false;
                        cbPreguntas.Enabled = false;
                        cbEnvio.Enabled = false;
                        btnGrabar.Visible = false;
                    }

                    if (cmbPubli.Text == "Subasta")
                    {
                        txtStock.Enabled = false;

                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea limpiar los datos para iniciar una nueva búsqueda?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                groupBox1.Visible = false;
                txtDescripcion.Clear();
                txtStock.Clear();
                txtPrecio.Clear();
                txtCosto.Clear();
                txtUsuario.Clear();
                cbPreguntas.Checked = false;
                cbEnvio.Checked = false;
                btnGrabar.Visible = false;
                btnLimpiar.Visible = false;
                btnBuscar.Visible = true;
                txtCodigo.ReadOnly = false;
                txtCodigo.Clear();
                cmbEstado.Items.Clear();

            }


        }

        public void LlenarVisibilidad_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Publicacion().getVisibilidad();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbVisibilidad.Text = "Seleccionar Visibilidad";
            cmbVisibilidad.DataSource = dtable;
            cmbVisibilidad.ValueMember = "VISIBILIDAD_DESC";
            cmbVisibilidad.DisplayMember = "Seleccionar Visibilidad";
            cmbVisibilidad.Text = "Seleccionar Visibilidad";
        }


        public void LlenarRubro_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new CliEmp().getRubros();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbRubro.Text = "Seleccionar Rubro";
            cmbRubro.DataSource = dtable;
            cmbRubro.ValueMember = "RUBRO_DESC_CORTA";
            cmbRubro.DisplayMember = "Seleccionar Rubro";
            cmbRubro.Text = "Seleccionar Rubro";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            DateTime fecha = Properties.Settings.Default.FechaSistema;
            Int64 codigo = Int64.Parse(txtCodigo.Text);
            bool envio = cbEnvio.Checked;
            string visibilidad = cmbVisibilidad.Text;
            string estado_actual = cmbEstado.Text;

            if (estado_ant == "Borrador" && cmbEstado.Text == "Activa")
            {
                resultado = new Publicacion().GenerarFactura(codigo, fecha, envio, visibilidad);

                if (resultado == 1)
                {
                    MessageBox.Show("La publicación se modificó correctamente");

                     groupBox1.Visible = false;
                txtDescripcion.Clear();
                txtStock.Clear();
                txtPrecio.Clear();
                txtCosto.Clear();
                txtUsuario.Clear();
                cbPreguntas.Checked = false;
                cbEnvio.Checked = false;
                btnGrabar.Visible = false;
                btnLimpiar.Visible = false;
                btnBuscar.Visible = true;
                txtCodigo.ReadOnly = false;
                txtCodigo.Clear();
                cmbEstado.Items.Clear();


                }
                else

                    MessageBox.Show("Hubo un problema al modificar la publicación, intente nuevamente");
            }
            else
            {
                resultado = new Publicacion().ModifEstadoPublic(codigo, estado_actual);

                if (resultado == 1)
                {
                    MessageBox.Show("La publicación se modificó correctamente");

                  groupBox1.Visible = false;
                txtDescripcion.Clear();
                txtStock.Clear();
                txtPrecio.Clear();
                txtCosto.Clear();
                txtUsuario.Clear();
                cbPreguntas.Checked = false;
                cbEnvio.Checked = false;
                btnGrabar.Visible = false;
                btnLimpiar.Visible = false;
                btnBuscar.Visible = true;
                txtCodigo.ReadOnly = false;
                txtCodigo.Clear();
                cmbEstado.Items.Clear();


                }
                else

                    MessageBox.Show("Hubo un problema al modificar la publicación, intente nuevamente");
            }

        }
    }
    }

