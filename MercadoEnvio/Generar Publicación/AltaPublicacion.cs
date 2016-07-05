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
    public partial class AltaPublicacion : Form
    {
        public string username;

        public AltaPublicacion(Usuario usuario)
        {
            InitializeComponent();
            btnAlta.Visible = false;
            username = usuario.username;
        }

        private void cmbPubli_DropDown(object sender, EventArgs e)
        {
            LlenarTipoPubli_ComboBox();

        }

        public void LlenarTipoPubli_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Publicacion().getTipoPubli();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbPubli.Text = "Seleccionar Tipo de Publicación";
            cmbPubli.DataSource = dtable;
            cmbPubli.ValueMember = "PUBLI_TIPO_DESC";
            cmbPubli.DisplayMember = "Seleccionar Tipo de Publicación";
            cmbPubli.Text = "Seleccionar Tipo de Publicación";
        }

        private void cmbPubli_SelectedValueChanged(object sender, EventArgs e)
        {

            DateTime fechaInicio = Properties.Settings.Default.FechaSistema;
            
            if (cmbPubli.Text == "System.Data.DataRowView")
            {
                cmbPubli.Text = "Seleccione un tipo de Publicación";
                return;
            }
            string texto = "Seleccionar Visibilidad";

                btnAlta.Visible = true;
                txtDescripcion.Enabled = true;
                txtStock.Enabled = true;
                dpInicio.Enabled = true;
                dpVencimiento.Enabled = true;
                txtPrecio.Enabled = true;
                cmbRubro.Enabled = true;
                cmbVisibilidad.Enabled = true;
                txtCosto.ReadOnly = true;
                txtUsuario.ReadOnly = true;
                txtCodigo.ReadOnly = true;
                cbPreguntas.Enabled = true;
                cbEnvio.Enabled = true;
                dpInicio.Enabled = false;

                ObtenerCodPublicacion();
                LlenarRubro_ComboBox();
                LlenarVisibilidad_ComboBox();


                if (String.Compare(cmbVisibilidad.Text, texto) == 0)
                    txtCosto.Text = "0";

                dpInicio.Value = fechaInicio;
                dpVencimiento.Value = fechaInicio;

                cmbEstado.Text = "Borrador";
                cmbEstado.DisplayMember = "Borrador";

                txtUsuario.Text = username;
            
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


        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            
            int resultado = 0;
            string vacio = "";
            string rubro = "Seleccionar Rubro";
            string visi = "Seleccionar Visibilidad";

            if (cmbPubli.Text == "Compra Inmediata")
            {
                if ((String.Compare(txtDescripcion.Text, vacio) == 0) || (String.Compare(txtStock.Text, vacio) == 0) || (String.Compare(txtPrecio.Text, vacio) == 0) || (String.Compare(cmbRubro.Text, vacio) == 0) || (String.Compare(cmbVisibilidad.Text, vacio) == 0) || (String.Compare(txtCosto.Text, vacio) == 0) || (String.Compare(cmbRubro.Text, rubro) == 0) || (String.Compare(cmbVisibilidad.Text, visi) == 0))
                {
                    MessageBox.Show("Faltan completar algunos campos obligatorios. Revise los campos en rojo.");
                    label3.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;

                }
                else
                {
                    if (int.Parse(txtStock.Text) == 0)
                        MessageBox.Show("El stock debe ser mayor a cero.");
                    else
                    {

                        if (decimal.Parse(txtPrecio.Text) == 0)
                            MessageBox.Show("El precio debe ser mayor a cero.");

                        else
                        {
                            Int64 codigo = Int64.Parse(txtCodigo.Text);
                            string descrip = txtDescripcion.Text;
                            int stock = int.Parse(txtStock.Text);
                            DateTime inicio = dpInicio.Value;
                            DateTime venc = dpVencimiento.Value;
                            Decimal precio = decimal.Parse(txtPrecio.Text);
                            string rubroguarda = cmbRubro.Text;
                            string visiguarda = cmbVisibilidad.Text;
                            Decimal costo = Decimal.Parse(txtCosto.Text);
                            string user = txtUsuario.Text;
                            string estado = cmbEstado.Text;
                            bool preg = cbPreguntas.Checked;
                            bool envio = cbEnvio.Checked;
                            string tipopubli = cmbPubli.Text;


                            resultado = new Publicacion().AltaPublicacion(codigo, descrip, stock, inicio, venc, precio, rubroguarda, visiguarda, costo, user, estado, preg, envio, tipopubli);

                            if (resultado == 1)
                            {
                                MessageBox.Show("La publicación se generó correctamente");

                                //    label9.ForeColor = SystemColors.ControlText;
                                //    label12.ForeColor = SystemColors.ControlText;
                                //    label30.ForeColor = SystemColors.ControlText;
                                //    label14.ForeColor = SystemColors.ControlText;


                                //    txtRazonEmp.Clear();
                                //    label10.Visible = false;
                                //    btnGrabar.Visible = false;
                                //    btnHabilitar.Visible = false;
                            }
                            else
                                MessageBox.Show("Hubo un problema al generar la publicación, intente nuevamente");
                        }
                    }
                }
            }
        }

        public void ObtenerCodPublicacion()
        {
            decimal codigo;

            codigo = new Publicacion().MaxPubli();
            codigo= codigo + 1;
            txtCodigo.Text = codigo.ToString();
            
        }

        private void cmbVisibilidad_SelectedValueChanged(object sender, EventArgs e)
        {
            decimal costo;
            string tipoVisi = cmbVisibilidad.Text;
           
            costo = new Publicacion().ObtenerCostoVisi(tipoVisi);
            txtCosto.Text = costo.ToString();
        
        }

    }
}
