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

namespace MercadoEnvio.Historial_Cliente
{
    public partial class HistorialClienteForm : Form
    {
        public int usuarioID;

        BasedeDatosForm bd = new BasedeDatosForm();

        public int FilaInicio;
        public int FilaFin;


        public HistorialClienteForm(Usuario usuario)
        {
            usuarioID = usuario.usuarioId;
            InitializeComponent();
        }

        private void HistorialClienteForm_Load(object sender, EventArgs e)
        {
            FilaInicio = 1;
            FilaFin = 100;

            bd.openConnection();

            ComprasRealizadas();
            CalificacionesRealizadas();

            bd.closeConnection();
        }

        public void ComprasRealizadas()
        {
            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            int CantidadCompras = auxiliar.CantidadCompras(usuarioID, "inmediatas") + auxiliar.CantidadCompras(usuarioID, "subastas");

            label2.Text = CantidadCompras.ToString();

            if (CantidadCompras == 0)
            {
                label8.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                dataGridView1.Visible = false;
                label13.Visible = true;
            }
            else
            {
                label8.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                dataGridView1.Visible = true;
                label13.Visible = false;

                label4.Text = FechaCompra(usuarioID, "primera").ToString();
                label6.Text = FechaCompra(usuarioID, "ultima").ToString();

                PaginacionCompras();
            }
        }

        public void PaginacionCompras() {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            SqlCommand HistorialCompras_SP;

            HistorialCompras_SP = new SqlCommand("[RECUR].[HistorialCompras]", bd.conexion);

            HistorialCompras_SP.CommandType = CommandType.StoredProcedure;

            DataTable tabla = new DataTable();
            try
            {
                HistorialCompras_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID;
                HistorialCompras_SP.Parameters.Add("@inicio", SqlDbType.Int).Value = FilaInicio;

                HistorialCompras_SP.Parameters.Add("@fin", SqlDbType.Int).Value = FilaFin;

                SqlDataAdapter adp = new SqlDataAdapter(HistorialCompras_SP);

                adp.Fill(tabla);

                HistorialCompras_SP.Dispose();
                HistorialCompras_SP = null;

                BindingSource bSource = new BindingSource();
                bSource.DataSource = tabla;
                dataGridView1.DataSource = bSource;
                adp.Update(tabla);
            }
            catch (SqlException db)
            {
                MessageBox.Show(db.Message);
            }
        }

        private DateTime FechaCompra (int usuarioID, string tipo)
        {
            SqlCommand FechaCompra_F = new SqlCommand();
            FechaCompra_F.Connection = bd.conexion;
            FechaCompra_F.CommandType = CommandType.Text;

            if (tipo == "primera") {
                FechaCompra_F.CommandText = "SELECT RECUR.FechaPrimeraCompra (" + usuarioID.ToString() + ")";
            }
            else {
                FechaCompra_F.CommandText = "SELECT RECUR.FechaUltimaCompra (" + usuarioID.ToString() + ")";
            }

            DateTime FechaCompra = Convert.ToDateTime(FechaCompra_F.ExecuteScalar());
            return FechaCompra;
        }

        public void CalificacionesRealizadas() {
            // Cantidad de compras sin calificar.

            SqlCommand CantidadSinCalificar_F = new SqlCommand();

            CantidadSinCalificar_F.Connection = bd.conexion;
            CantidadSinCalificar_F.CommandText = "SELECT RECUR.CantidadSinCalificar (" + usuarioID.ToString() + ")";
            CantidadSinCalificar_F.CommandType = CommandType.Text;

            int CantidadSinCalificar = Convert.ToInt32(CantidadSinCalificar_F.ExecuteScalar());

            label11.Text = CantidadSinCalificar.ToString();

            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            int CantidadComprasCalificadas = auxiliar.CantidadCompras(usuarioID, "inmediatas") + auxiliar.CantidadCompras(usuarioID, "subastas") - CantidadSinCalificar;

            if (CantidadComprasCalificadas == 0) {
                label14.Visible = true;
            }
            else {
                label14.Visible = false;

                // Llenar tabla

                SqlCommand DesgloseCompras_SP = new SqlCommand("[RECUR].[DesgloseCompras]", bd.conexion);
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
                    dataGridView2.DataSource = bSource;
                    adp.Update(tabla);
                }
                catch (SqlException db)
                {
                    MessageBox.Show(db.Message);
                }
            }
        }

        private void Primera_Click(object sender, EventArgs e)
        {
            bd.openConnection();

            FilaInicio = 1;
            FilaFin = 100;

            PaginacionCompras();

            bd.closeConnection();
        }

        private void Ultima_Click(object sender, EventArgs e)
        {
            bd.openConnection();

            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            int CantidadCompras = auxiliar.CantidadCompras(usuarioID, "inmediatas") + auxiliar.CantidadCompras(usuarioID, "subastas");

            Decimal CantidadPaginas = CantidadCompras / 100;
            Decimal CantidadComprasEntera = Math.Truncate(CantidadPaginas)*100;

            //MessageBox.Show(CantidadCompras.ToString() + ", " + CantidadComprasEntera.ToString());

            if (CantidadCompras == CantidadComprasEntera*100) {/* la cantidad de compras es múltiplo de 100 */
                FilaInicio = Convert.ToInt32(CantidadCompras) - 100;
                FilaFin = Convert.ToInt32(CantidadCompras);
            }
            else {
                int cantidadComprasSobrantes = CantidadCompras - Convert.ToInt32(CantidadComprasEntera);
                FilaInicio = Convert.ToInt32(CantidadCompras) - cantidadComprasSobrantes;
                FilaFin = Convert.ToInt32(CantidadCompras);
            }

            PaginacionCompras();

            bd.closeConnection();
        }

        private void Anterior_Click(object sender, EventArgs e)
        {
            if (FilaInicio > 0) {
                FilaFin = FilaInicio - 1;
                FilaInicio = FilaFin - 100;

                PaginacionCompras();
            }
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            FuncionesAuxiliares auxiliar = new FuncionesAuxiliares();

            int CantidadCompras = auxiliar.CantidadCompras(usuarioID, "inmediatas") + auxiliar.CantidadCompras(usuarioID, "subastas");

            if (CantidadCompras > 100) {
                FilaInicio = FilaFin + 1;
                FilaFin = FilaInicio + 100;

                PaginacionCompras();
            }
        }
    }
}
