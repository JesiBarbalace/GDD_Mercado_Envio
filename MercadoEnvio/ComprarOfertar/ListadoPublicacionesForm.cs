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
    public partial class ListadoPublicacionesForm : Form
    {
        public int usuarioID;

        BasedeDatosForm bd = new BasedeDatosForm();

        public int FilaInicio;
        public int FilaFin;
        public string rubros;
        public string descripcion;

        public ListadoPublicacionesForm(Usuario usuario)
        {
            usuarioID = usuario.usuarioId;
            InitializeComponent();
        }

        private void ListadoPublicacionesForm_Load(object sender, EventArgs e)
        {
            FilaInicio = 1;
            FilaFin = 100;
            rubros = "";
            descripcion = "";

            bd.openConnection();

            AgregarRubros();

            int cantidadPublicaciones = CantidadPublicaciones(usuarioID);

            if (cantidadPublicaciones > 0) {
                PaginacionPublicaciones();
            }
            else {
                string sinPublicacionesLabelText;
                sinPublicacionesLabelText = "No hay publicaciones para mostrar";
                Font fuenteEstandar = new Font("Microsoft Sans Serif", 10F);
                Size textSize = TextRenderer.MeasureText(sinPublicacionesLabelText, fuenteEstandar);

                Label sinPublicacionesLabel;
                sinPublicacionesLabel = new Label();
                sinPublicacionesLabel.Name = "sinPublicacionesLabel";
                sinPublicacionesLabel.Location = new System.Drawing.Point(400, 180);
                sinPublicacionesLabel.Size = textSize;
                this.Controls.Add(sinPublicacionesLabel);

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Enabled = false;
                } 
            }

            bd.closeConnection();

        }

        public void AgregarRubros()
        {
            SqlCommand MostrarRubros_SP;

            MostrarRubros_SP = new SqlCommand("[RECUR].[MostrarRubros]", bd.conexion);

            MostrarRubros_SP.CommandType = CommandType.StoredProcedure;

            DataTable tabla = new DataTable();

            SqlDataAdapter adp = new SqlDataAdapter(MostrarRubros_SP);

            adp.Fill(tabla);

            string labelText;
            String checkboxRubro = "checkboxRubro_";

            int i = 1;
            int y = 140;

            CheckBox[] _cb = new CheckBox[30];

            Font fuenteEstandar = new Font("Microsoft Sans Serif", 10F);

            foreach (DataRow row in tabla.Rows)
            {
                labelText = row[0].ToString();
                Size textSize = TextRenderer.MeasureText(labelText, fuenteEstandar);

                _cb[i] = new CheckBox();
                _cb[i].Name = checkboxRubro + i.ToString();
                _cb[i].Location = new System.Drawing.Point(16, y);
                _cb[i].Size = textSize;
                _cb[i].Text = labelText;

                //MessageBox.Show(labelText);

                this.Controls.Add(_cb[i]);

                y = y + 20;
                i++;
            }
        }

        public void PaginacionPublicaciones()
        {
            //MessageBox.Show("FilaInicio: " + FilaInicio.ToString() + ". FilaFin: " + FilaFin.ToString() + ". Cantidad publicaciones: " + CantidadPublicaciones(usuarioID).ToString());
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            if (dataGridView1.Columns.Contains("BotonColumna")) {
                dataGridView1.Columns.Remove("BotonColumna");
            }

            SqlCommand MostrarPublicaciones_SP;
            MostrarPublicaciones_SP = new SqlCommand("[RECUR].[MostrarPublicaciones]", bd.conexion);
            MostrarPublicaciones_SP.CommandType = CommandType.StoredProcedure;

            DataTable tabla = new DataTable();

            try
            {
                MostrarPublicaciones_SP.Parameters.Add("@usuarioID", SqlDbType.Int).Value = usuarioID;
                MostrarPublicaciones_SP.Parameters.Add("@inicio", SqlDbType.Int).Value = FilaInicio;
                MostrarPublicaciones_SP.Parameters.Add("@fin", SqlDbType.Int).Value = FilaFin;
                MostrarPublicaciones_SP.Parameters.Add("@rubros", SqlDbType.VarChar).Value = rubros;
                MostrarPublicaciones_SP.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;

                SqlDataAdapter adp = new SqlDataAdapter(MostrarPublicaciones_SP);

                adp.Fill(tabla);

                MostrarPublicaciones_SP.Dispose();
                MostrarPublicaciones_SP = null;

                BindingSource bSource = new BindingSource();
                bSource.DataSource = tabla;
                dataGridView1.DataSource = bSource;
                adp.Update(tabla);

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "BotonColumna";
                buttonColumn.HeaderText = "";

                int idTipoPublicacionFila;

                //buttonColumn.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(buttonColumn);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    idTipoPublicacionFila = Convert.ToInt32(row.Cells[2].Value);
                    if (idTipoPublicacionFila == 1)
                    {       // compra inmediata
                        row.Cells["BotonColumna"].Value = "Comprar";
                    }
                    else
                    {                              // subasta
                        row.Cells["BotonColumna"].Value = "Ofertar";
                    }
                }

                dataGridView1.Columns["Código"].Visible = false;
                dataGridView1.Columns["ID tipo de publicación"].Visible = false;
                dataGridView1.Columns["Tipo visibilidad"].Visible = false;

                ConfigurarBotones();
            }
            catch (SqlException db)
            {
                MessageBox.Show(db.Message);
            }
        }

        private void ConfigurarBotones() {
            int cantidadPublicaciones = CantidadPublicaciones(usuarioID);

            if (cantidadPublicaciones < 100)
            {
                Primera.Enabled = false;
                Anterior.Enabled = false;
                Siguiente.Enabled = false;
                Ultima.Enabled = false;
            }
            else
            {
                if ((FilaInicio <= 1) & (FilaFin <= 100))
                {
                    Primera.Enabled = false;
                    Anterior.Enabled = false;
                    Siguiente.Enabled = true;
                    Ultima.Enabled = true;
                }
                else
                {
                    if (FilaFin >= cantidadPublicaciones)
                    {
                        Primera.Enabled = true;
                        Anterior.Enabled = true;
                        Siguiente.Enabled = false;
                        Ultima.Enabled = false;
                    }
                    else
                    {
                        Primera.Enabled = true;
                        Anterior.Enabled = true;
                        Siguiente.Enabled = true;
                        Ultima.Enabled = true;
                    }
                }
            }
        }

        public int CantidadPublicaciones(int usuarioID)
        {
            BasedeDatosForm bd = new BasedeDatosForm();

            SqlCommand CantidadPublicaciones_F = new SqlCommand();

            CantidadPublicaciones_F.Connection = bd.conexion;

            CantidadPublicaciones_F.CommandText = "SELECT RECUR.CantidadPublicaciones (" + usuarioID.ToString() + ", '" + descripcion + "', '" + rubros + "')";

            CantidadPublicaciones_F.CommandType = CommandType.Text;

            bd.openConnection();

            int CantidadPublicaciones = Convert.ToInt32(CantidadPublicaciones_F.ExecuteScalar());

            return CantidadPublicaciones;
        }

        private void Primera_Click_1(object sender, EventArgs e)
        {
            bd.openConnection();

            FilaInicio = 1;
            FilaFin = 100;

            PaginacionPublicaciones();

            bd.closeConnection();
        }

        private void Anterior_Click_1(object sender, EventArgs e)
        {
            if (FilaInicio > 0)
            {
                FilaFin = FilaInicio - 1;
                FilaInicio = FilaFin - 100;

                PaginacionPublicaciones();
            }
        }

        private void Siguiente_Click_1(object sender, EventArgs e)
        {
            int CantidadPub = CantidadPublicaciones(usuarioID);

            if (CantidadPub > 100)
            {
                FilaInicio = FilaFin + 1;
                FilaFin = FilaInicio + 100;

                PaginacionPublicaciones();
            }
        }

        private void Ultima_Click_1(object sender, EventArgs e)
        {
            bd.openConnection();

            int cantidadPub = CantidadPublicaciones(usuarioID);

            Decimal CantidadPaginas = cantidadPub / 100;
            Decimal CantidadPublicacionesEntera = Math.Truncate(CantidadPaginas) * 100;

            //MessageBox.Show(CantidadPublicaciones.ToString() + ", " + CantidadPublicacionesEntera.ToString());

            if (cantidadPub == CantidadPublicacionesEntera * 100)
            {/* la cantidad de publicaciones es múltiplo de 100 */
                FilaInicio = Convert.ToInt32(cantidadPub) - 100;
                FilaFin = Convert.ToInt32(cantidadPub);
            }
            else
            {
                int cantidadPublicacionesSobrantes = cantidadPub - Convert.ToInt32(CantidadPublicacionesEntera);
                FilaInicio = Convert.ToInt32(cantidadPub) - cantidadPublicacionesSobrantes;
                FilaFin = Convert.ToInt32(cantidadPub);
            }

            PaginacionPublicaciones();

            bd.closeConnection();
        }

        private void Filtrar_Click(object sender, EventArgs e) {
            descripcion = textBox1.Text;

            int i = 0;

            foreach (var control in this.Controls) {
                if (control is CheckBox) {
                    if (((CheckBox)control).Checked) {
                        if (i > 0) {
                            rubros = rubros + ", " + ((CheckBox)control).Text.Split(' ')[0];
                        }
                        else {
                            rubros = ((CheckBox)control).Text.Split(' ')[0];
                        }

                        i++;
                    }
                }
            }

            //MessageBox.Show(rubros);

            PaginacionPublicaciones();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int codigoPublicacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string rubroPublicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                int idTipoPublicacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                string descripcionTipoPublicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);

                string descripcionPublicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                DateTime fechaInicioPublicacion = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
                DateTime fechaFinPublicacion = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
                Decimal precioPublicacion = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
                int stockPublicacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                string envioPublicacion = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
                int tipoVisibilidadPublicacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);

                ComprarOfertarForm comprarOfertar = new ComprarOfertarForm(usuarioID, this, codigoPublicacion, rubroPublicacion, idTipoPublicacion, descripcionTipoPublicacion, descripcionPublicacion, fechaInicioPublicacion, fechaFinPublicacion, precioPublicacion, stockPublicacion, envioPublicacion, tipoVisibilidadPublicacion);

                comprarOfertar.Show();
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (var control in this.Controls)
            {
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;

                    i++;
                }
            }

            textBox1.Text = "";

            descripcion = "";
            rubros = "";

            PaginacionPublicaciones();
        }
    }
}
