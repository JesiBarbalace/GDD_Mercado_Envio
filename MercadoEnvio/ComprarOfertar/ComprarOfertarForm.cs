using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using MercadoEnvio.Mappings;
using MercadoEnvio.Auxiliares;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class ComprarOfertarForm : Form
    {
        ListadoPublicacionesForm _owner;

        public int usuarioID_P;
        int codigoPublicacion_P;
        public int idTipoPublicacion_P;
        String envioPublicacion_P;
        int tipoVisibilidadPublicacion_P;

        public ComprarOfertarForm   (int usuarioID,
                                    ListadoPublicacionesForm owner,
                                    int codigoPublicacion,
                                    String rubroPublicacion,
                                    int idTipoPublicacion,
                                    String descripcionTipoPublicacion, 
                                    String descripcionPublicacion, 
                                    DateTime fechaInicioPublicacion,
                                    DateTime fechaFinPublicacion,
                                    Decimal precioPublicacion,
                                    int stockPublicacion,
                                    String envioPublicacion,
                                    int tipoVisibilidadPublicacion)
        {
            _owner = owner;
            usuarioID_P = usuarioID;
            idTipoPublicacion_P = idTipoPublicacion;
            codigoPublicacion_P = codigoPublicacion;
            tipoVisibilidadPublicacion_P = tipoVisibilidadPublicacion;
            envioPublicacion_P = envioPublicacion;

            InitializeComponent();

            if (envioPublicacion_P == "Opcional")
            {
                CheckBox envioCheckbox;
                string labelCheckboxText;

                labelCheckboxText = "Enviar a domicilio";
                Font fuenteEstandar = new Font("Microsoft Sans Serif", 10F);
                Size textSize = TextRenderer.MeasureText(labelCheckboxText, fuenteEstandar);

                envioCheckbox = new CheckBox();
                envioCheckbox.Name = "envioCheckbox";
                envioCheckbox.Location = new System.Drawing.Point(300, 170);
                envioCheckbox.Size = textSize;
                envioCheckbox.Text = labelCheckboxText;
                this.Controls.Add(envioCheckbox);
            }

            if (idTipoPublicacion_P == 1) {                   // compra inmediata
                this.Text = "Comprar";

                string cantidadLabelText;
                cantidadLabelText = "Cantidad:";
                Font fuenteEstandar = new Font("Microsoft Sans Serif", 10F);
                Size textSize = TextRenderer.MeasureText(cantidadLabelText, fuenteEstandar);

                Label cantidadLabel;
                cantidadLabel = new Label();
                cantidadLabel.Name = "cantidadLabel";
                cantidadLabel.Location = new System.Drawing.Point(13, 170);
                cantidadLabel.Text = cantidadLabelText;
                cantidadLabel.Size = textSize;
                this.Controls.Add(cantidadLabel);

                ComboBox cantidadComboBox;
                cantidadComboBox = new ComboBox();
                cantidadComboBox.Name = "cantidadComboBox";
                cantidadComboBox.Location = new System.Drawing.Point(90, 165);
                cantidadComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Controls.Add(cantidadComboBox);

                for (int i = 1; i <= stockPublicacion; i++) {
                    string[] numbers = { i.ToString() };
                    cantidadComboBox.Items.AddRange(numbers);
                }

                comprarOfertarButton.Text = "Comprar";
            }
            else {                                          // subasta
                this.Text = "Ofertar";

                string ofrecerPrecioLabelText;
                ofrecerPrecioLabelText = "Ofrecer precio:";
                Font fuenteEstandar = new Font("Microsoft Sans Serif", 10F);
                Size textSize = TextRenderer.MeasureText(ofrecerPrecioLabelText, fuenteEstandar);

                Label ofrecerPrecioLabel;
                ofrecerPrecioLabel = new Label();
                ofrecerPrecioLabel.Name = "ofrecerPrecioLabel";
                ofrecerPrecioLabel.Location = new System.Drawing.Point(13, 170);
                ofrecerPrecioLabel.Text = ofrecerPrecioLabelText;
                ofrecerPrecioLabel.Size = textSize;
                this.Controls.Add(ofrecerPrecioLabel);

                TextBox precioTextBox;
                precioTextBox = new TextBox();
                precioTextBox.Name = "precioTextBox";
                precioTextBox.Location = new System.Drawing.Point(120, 165);
                this.Controls.Add(precioTextBox);

                comprarOfertarButton.Text = "Ofertar";
            }

            descripcionLabel.Text = descripcionPublicacion;
            rubroLabel.Text = rubroPublicacion;
            fechaInicioLabel.Text = fechaInicioPublicacion.ToString();
            fechaVencimientoLabel.Text = fechaFinPublicacion.ToString();
            precioLabel.Text = precioPublicacion.ToString();
            stockLabel.Text = stockPublicacion.ToString();
        }

        private void ComprarOfertarForm_Load(object sender, EventArgs e)
        {

        }

        private void ComprarOfertarForm_Load_1(object sender, EventArgs e)
        {

        }

        public void ReducirStock(int cantidad) {
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand ReducirStock_SP = new SqlCommand("[RECUR].[ReducirStock]", bd.conexion);
            ReducirStock_SP.CommandType = CommandType.StoredProcedure;
            ReducirStock_SP.Parameters.Add("@publicacionCodigo", SqlDbType.Int).Value = codigoPublicacion_P;
            ReducirStock_SP.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            ReducirStock_SP.ExecuteNonQuery();
            ReducirStock_SP.Dispose();

            bd.closeConnection();
        }

        public void Comprar(int cantidad)
        {
            DateTime compraFecha = Properties.Settings.Default.FechaSistema;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand Comprar_SP = new SqlCommand("[RECUR].[Comprar]", bd.conexion);
            Comprar_SP.CommandType = CommandType.StoredProcedure;
            Comprar_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID_P;
            Comprar_SP.Parameters.Add("@publicacionCodigo", SqlDbType.Int).Value = codigoPublicacion_P;
            Comprar_SP.Parameters.Add("@compraFecha", SqlDbType.DateTime).Value = compraFecha;
            Comprar_SP.Parameters.Add("@compraCantidad", SqlDbType.Int).Value = cantidad;
            Comprar_SP.ExecuteNonQuery();
            Comprar_SP.Dispose();

            bd.closeConnection();
        }

        public void Facturar(int cantidad, string tipo) {
            DateTime facturaFecha = Properties.Settings.Default.FechaSistema;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand Facturar_SP = new SqlCommand("[RECUR].[Facturar]", bd.conexion);
            Facturar_SP.CommandType = CommandType.StoredProcedure;
            Facturar_SP.Parameters.Add("@publicacionCodigo", SqlDbType.Int).Value = codigoPublicacion_P;
            Facturar_SP.Parameters.Add("@facturaFecha", SqlDbType.DateTime).Value = facturaFecha;
            Facturar_SP.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            Facturar_SP.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
            Facturar_SP.ExecuteNonQuery();
            Facturar_SP.Dispose();

            bd.closeConnection();
        }

        public void Ofertar(Decimal ofertaMonto, bool conEnvio)
        {
            DateTime ofertaFecha = Properties.Settings.Default.FechaSistema;

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            int ofertaEnvio;

            if (conEnvio) {
                ofertaEnvio = 1;
            }
            else {
                ofertaEnvio = 0;
            }

            SqlCommand Ofertar_SP = new SqlCommand("[RECUR].[Ofertar]", bd.conexion);
            Ofertar_SP.CommandType = CommandType.StoredProcedure;
            Ofertar_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID_P;
            Ofertar_SP.Parameters.Add("@publicacionCodigo", SqlDbType.Int).Value = codigoPublicacion_P;
            Ofertar_SP.Parameters.Add("@ofertaFecha", SqlDbType.DateTime).Value = ofertaFecha;
            Ofertar_SP.Parameters.Add("@ofertaMonto", SqlDbType.Decimal).Value = ofertaMonto;
            Ofertar_SP.Parameters.Add("@conEnvio", SqlDbType.Bit).Value = ofertaEnvio;
            Ofertar_SP.ExecuteNonQuery();
            Ofertar_SP.Dispose();

            bd.closeConnection();
        }

        private void comprarOfertarButton_Click(object sender, EventArgs e)
        {
            bool conEnvio = false;

            CheckBox envioCheckbox_R = (CheckBox)Controls["envioCheckbox"];

            if (envioPublicacion_P == "Opcional")
            {
                if (envioCheckbox_R.Checked)
                {
                    conEnvio = true;
                }
            }

            if (idTipoPublicacion_P == 1) {                 // compra inmediata
                ComboBox cantidadComboBox_R = (ComboBox)Controls["cantidadComboBox"];

                if (string.IsNullOrEmpty(cantidadComboBox_R.Text))
                {
                    MessageBox.Show("Debe indicar una cantidad");
                }

                else {

                    int compraCantidad = Convert.ToInt32(cantidadComboBox_R.Text);
                    ReducirStock(compraCantidad);


                    Comprar(compraCantidad);

                    Facturar(compraCantidad, "visibilidad");

                    if (conEnvio) { 
                        Facturar(compraCantidad, "envio");
                    }

                    if (tipoVisibilidadPublicacion_P != 10006) // visibilidad paga
                    {
                        UltimasFacturasForm ultimasFacturas;

                        ultimasFacturas = new UltimasFacturasForm(conEnvio);

                        ultimasFacturas.Show();
                    }
                    else {                                 // visibilidad gratuita
                        MessageBox.Show("El producto ha sido vendido. No se generaron facturas porque la publicación es gratuita");
                    }

                    _owner.PaginacionPublicaciones();
                    this.Close();
                }
            }
            else {
                TextBox precioTextBox_R = (TextBox)Controls["precioTextBox"];

                if (string.IsNullOrEmpty(precioTextBox_R.Text)) {
                    MessageBox.Show("Debe indicar un precio");
                }
                else { 
                    Decimal ofertaPrecio = Convert.ToDecimal(precioTextBox_R.Text);
                    Ofertar(ofertaPrecio, conEnvio);

                    MessageBox.Show("Su oferta ha sido ingresada. Si llegado el vencimiento de la publicación no se ofreció un monto mayor, le será adjudicado el producto.");

                    _owner.PaginacionPublicaciones();
                    this.Close();
                }
            }
        }
    }
}
