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

namespace MercadoEnvio.Calificar
{
    public partial class CalificarForm : Form
    {
        public int usuarioID;

        public CalificarForm(Usuario usuario)
        {
            usuarioID = usuario.usuarioId;
            InitializeComponent();
        }

        private void CalificarForm_Load(object sender, EventArgs e)
        {
            SinCalificar();
            UltimasComprasCalificadas();
            Resumen("inmediatas");
            Resumen("subastas");
        }

        public void Resumen(string tipo) {
            Label comprasTotal;
            Label deEsasCompras;
            Label sinDatos;
            DataGridView grid;

            BasedeDatosForm bd = new BasedeDatosForm();
            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            if (tipo == "inmediatas")  {
                comprasTotal = label8;
                deEsasCompras = label10;
                sinDatos = label20;
                grid = dataGridView3;

                comprasTotal.Text = auxiliar.CantidadCompras(usuarioID, "inmediatas").ToString();
            }
            else  {
                comprasTotal = label17;
                deEsasCompras = label15;
                sinDatos = label21;
                grid = dataGridView4;

                comprasTotal.Text = auxiliar.CantidadCompras(usuarioID, "subastas").ToString();
            }

            if (Convert.ToInt32(comprasTotal.Text) == 0) {
                deEsasCompras.Visible = false;
                sinDatos.Visible = true;
                grid.Visible = false;
            }
            else {
                deEsasCompras.Visible = true;
                sinDatos.Visible = false;
                grid.Visible = true;

                SqlCommand DesgloseCompras_SP;

                if (tipo == "inmediatas") {
                    DesgloseCompras_SP = new SqlCommand("[RECUR].[DesgloseComprasInmediatas]", bd.conexion);
                }
                else {
                    DesgloseCompras_SP = new SqlCommand("[RECUR].[DesgloseSubastas]", bd.conexion);
                }

                DesgloseCompras_SP.CommandType = CommandType.StoredProcedure;

                DataTable tabla = new DataTable();
                try
                {
                    DesgloseCompras_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID;

                    SqlDataAdapter adp = new SqlDataAdapter(DesgloseCompras_SP);

                    adp.Fill(tabla);

                    DesgloseCompras_SP.Dispose();
                    DesgloseCompras_SP = null;

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = tabla;
                    grid.DataSource = bSource;
                    adp.Update(tabla);
                }
                catch (SqlException db)
                {
                    MessageBox.Show(db.Message);
                }
            }
        }

        public void UltimasComprasCalificadas() {
            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            int CantidadComprasCalificadas = auxiliar.CantidadCompras(usuarioID, "inmediatas") + auxiliar.CantidadCompras(usuarioID, "subastas") - SinCalificar();

            if (CantidadComprasCalificadas == 0) {
                dataGridView2.Visible = false;
                label4.Visible = true;
            }
            else {
                dataGridView2.Visible = true;
                label4.Visible = false;

                BasedeDatosForm bd = new BasedeDatosForm();

                SqlCommand UltimasComprasCalificadas_SP = new SqlCommand("[RECUR].[UltimasComprasCalificadas]", bd.conexion);
                UltimasComprasCalificadas_SP.CommandType = CommandType.StoredProcedure;

                DataTable tabla = new DataTable();
                try
                {
                    UltimasComprasCalificadas_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID;

                    SqlDataAdapter adp = new SqlDataAdapter(UltimasComprasCalificadas_SP);

                    adp.Fill(tabla);

                    UltimasComprasCalificadas_SP.Dispose();
                    UltimasComprasCalificadas_SP = null;

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = tabla;
                    dataGridView2.DataSource = bSource;
                    adp.Update(tabla);

                    dataGridView2.Columns["ID de publicación"].Visible = false;
                }
                catch (SqlException db)
                {
                    MessageBox.Show(db.Message);
                }
            }

        }

        public int SinCalificar() {
            BasedeDatosForm bd = new BasedeDatosForm();

            SqlCommand CantidadSinCalificar_F = new SqlCommand();

            CantidadSinCalificar_F.Connection = bd.conexion;
            CantidadSinCalificar_F.CommandText = "SELECT RECUR.CantidadSinCalificar (" + usuarioID.ToString() + ")";
            CantidadSinCalificar_F.CommandType = CommandType.Text;

            bd.openConnection();

            int CantidadSinCalificar = Convert.ToInt32(CantidadSinCalificar_F.ExecuteScalar());

            if (CantidadSinCalificar == 0) {
                dataGridView1.Visible = false;
                label2.Visible = true;
            }

            else {
                if (dataGridView1.Columns.Contains("BotonColumna"))
                {
                    dataGridView1.Columns.Remove("BotonColumna");
                }

                dataGridView1.Visible = true;
                label2.Visible = false;

                SqlCommand SinCalificar_SP = new SqlCommand("[RECUR].[SinCalificar]", bd.conexion);
                SinCalificar_SP.CommandType = CommandType.StoredProcedure;

                DataTable tabla = new DataTable();
                try
                {
                    SinCalificar_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID;

                    SqlDataAdapter adp = new SqlDataAdapter(SinCalificar_SP);

                    adp.Fill(tabla);

                    SinCalificar_SP.Dispose();
                    SinCalificar_SP = null;

                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = tabla;
                    dataGridView1.DataSource = bSource;
                    adp.Update(tabla);

                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "BotonColumna";
                    buttonColumn.HeaderText = "";
                    buttonColumn.Text = "Calificar";
                    buttonColumn.UseColumnTextForButtonValue = true;

                    dataGridView1.Columns.Add(buttonColumn);

                    dataGridView1.Columns["ID de compra"].Visible = false;
                    dataGridView1.Columns["Código de publicación"].Visible = false;
                    dataGridView1.Columns["ID de vendedor"].Visible = false;

                }
                catch (SqlException db)
                {
                    MessageBox.Show(db.Message);
                }
            }

            return CantidadSinCalificar;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int compraID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int empresaID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                String empresa_razon_social = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                String publicacion_desc = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                Decimal publicacion_precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value);
                DateTime compra_fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
                int compra_cantidad = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);

                AgregarCalificacionForm AgregarCalificacion = new AgregarCalificacionForm(this, compraID, empresaID, empresa_razon_social, publicacion_desc, publicacion_precio, compra_fecha, compra_cantidad);
                AgregarCalificacion.Show();
            }
        }
    }
}
