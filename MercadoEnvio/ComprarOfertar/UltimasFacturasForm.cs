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
    public partial class UltimasFacturasForm : Form
    {
        public UltimasFacturasForm(bool facturarEnvio)
        {
            InitializeComponent();

            envioNroFactura.Visible = false;
            envioFechaFactura.Visible = false;
            envioConceptoFactura.Visible = false;
            envioFormaPagoFactura.Visible = false;
            envioCantidadFactura.Visible = false;
            envioMontoFactura.Visible = false;
            envioNroFacturaValor.Visible = false;
            envioFechaFacturaValor.Visible = false;
            envioConceptoFacturaValor.Visible = false;
            envioFormaPagoFacturaValor.Visible = false;
            envioCantidadFacturaValor.Visible = false;
            envioMontoFacturaValor.Visible = false;

            MostrarUltimaFactura("visibilidad");

            if (facturarEnvio) {
                MostrarUltimaFactura("envio");
            }
        }

        private void MostrarUltimaFactura(string tipo) {
            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();

            SqlCommand MostrarUltimaFactura_SP = new SqlCommand("[RECUR].[MostrarUltimaFactura]", bd.conexion);
            MostrarUltimaFactura_SP.CommandType = CommandType.StoredProcedure;
            MostrarUltimaFactura_SP.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

            DataTable tabla = new DataTable();

            SqlDataAdapter adp = new SqlDataAdapter(MostrarUltimaFactura_SP);

            adp.Fill(tabla);

            MostrarUltimaFactura_SP.Dispose();
            MostrarUltimaFactura_SP = null;

            if (tipo == "visibilidad") {
                ventaNroFacturaValor.Text = tabla.Rows[0]["Número"].ToString();
                ventaFechaFacturaValor.Text = tabla.Rows[0]["Fecha"].ToString();
                ventaConceptoFacturaValor.Text = tabla.Rows[0]["Concepto"].ToString();
                ventaFormaPagoFacturaValor.Text = "Efectivo";
                ventaCantidadFacturaValor.Text = tabla.Rows[0]["Cantidad"].ToString();
                ventaMontoFacturaValor.Text = tabla.Rows[0]["Monto"].ToString();
            }
            else {
                envioNroFactura.Visible = true;
                envioFechaFactura.Visible = true;
                envioConceptoFactura.Visible = true;
                envioFormaPagoFactura.Visible = true;
                envioCantidadFactura.Visible = true;
                envioMontoFactura.Visible = true;
                envioNroFacturaValor.Visible = true;
                envioFechaFacturaValor.Visible = true;
                envioConceptoFacturaValor.Visible = true;
                envioFormaPagoFacturaValor.Visible = true;
                envioCantidadFacturaValor.Visible = true;
                envioMontoFacturaValor.Visible = true;


                envioNroFacturaValor.Text = tabla.Rows[0]["Número"].ToString();
                envioFechaFacturaValor.Text = tabla.Rows[0]["Fecha"].ToString();
                envioConceptoFacturaValor.Text = tabla.Rows[0]["Concepto"].ToString();
                envioFormaPagoFacturaValor.Text = "Efectivo";
                envioCantidadFacturaValor.Text = tabla.Rows[0]["Cantidad"].ToString();
                envioMontoFacturaValor.Text = tabla.Rows[0]["Monto"].ToString();
            }

            bd.closeConnection();
        }

        private void UltimasFacturasForm_Load(object sender, EventArgs e)
        {

        }
    }
}
