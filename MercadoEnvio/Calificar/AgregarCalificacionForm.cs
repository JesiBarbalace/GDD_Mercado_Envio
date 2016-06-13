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

namespace MercadoEnvio.Calificar
{
    public partial class AgregarCalificacionForm : Form
    {
        CalificarForm _owner;

        public int compra_ID_P;

        public AgregarCalificacionForm  (CalificarForm owner,
                                        int compra_ID,
                                        int empresaID,
                                        String empresa_razon_social,
                                        String publicacion_desc,
                                        Decimal publicacion_precio,
                                        DateTime compra_fecha,
                                        int compra_cantidad)
        {
            _owner = owner;
            compra_ID_P = compra_ID;

            InitializeComponent();

            label9.Text = empresa_razon_social;
            label10.Text = ReputacionVendedor(empresaID).ToString() + "/100";
            label11.Text = publicacion_desc;
            label12.Text = "$" + publicacion_precio.ToString();
            label13.Text = compra_fecha.ToString();
            label14.Text = compra_cantidad.ToString();

            for (int i = 1; i <= 5; i++)
            {
                string[] numbers = { i.ToString() };
                comboBox1.Items.AddRange(numbers);
            }
        }

        private void AgregarCalificacionForm_Load(object sender, EventArgs e)
        {

        }

        private int ReputacionVendedor(int empresaID)
        {
            BasedeDatosForm bd = new BasedeDatosForm();

            SqlCommand ReputacionVendedor_F = new SqlCommand();

            ReputacionVendedor_F.Connection = bd.conexion;
            ReputacionVendedor_F.CommandText = "SELECT RECUR.ReputacionVendedor (" + empresaID.ToString() + ")";
            ReputacionVendedor_F.CommandType = CommandType.Text;

            bd.openConnection();

            int CantidadSinCalificar = Convert.ToInt32(ReputacionVendedor_F.ExecuteScalar());
            return CantidadSinCalificar;
        }

        private void button1_Click  (object sender,
                                    EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text)) {
                MessageBox.Show("Debe indicar un puntaje.");
            }
            else {
                int puntaje = Convert.ToInt32(comboBox1.Text);
                string comentario = textBox1.Text;
                int compra_ID = compra_ID_P;

                BasedeDatosForm bd = new BasedeDatosForm();
                bd.openConnection();

                SqlCommand Calificar_SP = new SqlCommand("[RECUR].[Calificar]", bd.conexion);
                Calificar_SP.CommandType = CommandType.StoredProcedure;

                Calificar_SP.Parameters.Add("@compraID", SqlDbType.NVarChar).Value = compra_ID;
                Calificar_SP.Parameters.Add("@estrellas", SqlDbType.NVarChar).Value = puntaje;

                Calificar_SP.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = comentario;

                Calificar_SP.ExecuteNonQuery();

                Calificar_SP.Dispose();

                bd.closeConnection();

                _owner.SinCalificar();
                _owner.UltimasComprasCalificadas();
                _owner.Resumen("inmediatas");
                _owner.Resumen("subastas");

                this.Close();

            }
        }
    }
}
