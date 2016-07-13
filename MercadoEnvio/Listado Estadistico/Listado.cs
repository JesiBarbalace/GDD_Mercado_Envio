using MercadoEnvio.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class Listado : Form
    {
        List<string> años = new List<string> { "2014", "2015", "2016", "2017" };
        List<Trimestre> trimestres = new List<Trimestre>();
        List<Listados> listados = new List<Listados>();

        public Listado()
        {
            InitializeComponent();
            CargarCombos();
        }

        public void Listado_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatosTops()
        {


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAño.SelectedValue.ToString()) || string.IsNullOrEmpty(cmbTrimestre.SelectedValue.ToString()))
            {
                MessageBox.Show("No hay filtros seleccionados");
                return;
            }
            if (string.IsNullOrEmpty(cmbListados.SelectedValue.ToString()))
            {
                MessageBox.Show("No hay listados seleccionados");
                return;
            }
            string view = string.Empty;
            string where = string.Empty;
            string orderby = string.Empty;
            switch (cmbListados.SelectedValue.ToString())
            {
                case "1":// "Vendedores con Productos No Vendidos":
                    view = "RECUR.VW_VENDEDORES_PRODUCTOS_SIN_VENDER";
                    where = " AND UPPER(GRADO_DE_VISIBILIDAD) = RTRIM(LTRIM('" + cmbVisibilidad.SelectedValue.ToString().ToUpper() + "'))";
                    orderby = "ORDER BY TRIMESTRE DESC, AÑO DESC, GRADO_DE_VISIBILIDAD DESC";
                    break;
                case "2":// "Clientes con Productos Comprados":
                    view = "RECUR.VW_MEJORES_COMPRADORES";
                    where = " AND UPPER(RUBRO) = RTRIM(LTRIM('" + cmbRubro.Text.ToString().ToUpper() + "'))";
                    orderby = " ORDER BY CANTIDAD_DE_PRODUCTOS_COMPRADOS DESC ";
                    break;
                case "3":// "Vendedores con Facturas":
                    view = "RECUR.VW_MEJORES_VENDEDORES";
                    orderby = " ORDER BY CANTIDAD_FACTURAS DESC";
                    break;
                case "4"://"Vendedores con Monto Facturado":
                    view = "RECUR.VW_VENDEDORES_MEJOR_FACTURACION";
                    orderby = "ORDER BY MONTO_FACTURADO DESC";
                    break;
            }

            string sql = string.Empty;
            sql = "SELECT TOP 5 * FROM " + view + " WHERE AÑO = " + cmbAño.SelectedValue.ToString() + " AND TRIMESTRE = " + cmbTrimestre.SelectedValue.ToString() + where + orderby;

            dataGridView1.DataSource = GetDataTableListados(sql);

        }

        private void CargarCombos()
        {

            cmbAño.DataSource = años;
            cmbTrimestre.DataSource = new Trimestre().GetTrimestres();
            cmbTrimestre.ValueMember = "ID";
            cmbTrimestre.DisplayMember = "Descripcion";
            cmbListados.DataSource = new Listados().GetListado();
            cmbListados.ValueMember = "ID";
            cmbListados.DisplayMember = "Descripcion";
            cmbVisibilidad.DataSource = new Visibilidad().TraerVisibilidades();
            cmbVisibilidad.DisplayMember = "VISIBILIDAD_DESC";
            cmbVisibilidad.ValueMember = "VISIBILIDAD_DESC";
            cmbRubro.DataSource = new Rubro().GetRubros();
            cmbRubro.ValueMember = "ID";
            cmbRubro.DisplayMember = "DESCRIPCION";
            cmbRubro.Text = "Seleccionar Rubro";
            cmbListados_SelectedIndexChanged(null, null);
        }


        public DataTable GetDataTableListados(string sql)
        {

            BasedeDatosForm bd = new BasedeDatosForm();
            bd.openConnection();
            SqlCommand cmd = new SqlCommand(sql, bd.conexion);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);

            }
            catch (SqlException db)
            {
                throw db;
            }
            finally
            {
                bd.closeConnection();
                cmd.Dispose();
            }
            return dt;
        }

        private void cmbListados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListados.SelectedValue.ToString() == "2") //Filtro rubro
            {
                cmbRubro.Visible = true;
                lblRubro.Visible = true;
            }
            else
            {
                cmbRubro.Visible = false;
                lblRubro.Visible = false;
            }
            if (cmbListados.SelectedValue.ToString() == "1") //Filtro visibilidad
            {
                cmbVisibilidad.Visible = true;
                lblVisibilidad.Visible = true;
            }
            else
            {
                cmbVisibilidad.Visible = false;
                lblVisibilidad.Visible = false;
            }
        }
    }

    class Listados
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Listados()
        {

        }

        public List<Listados> GetListado()
        {
            List<string> lista = new List<string> { "Vendedores con Productos No Vendidos", "Clientes con Productos Comprados ",
                                                "Vendedores con Facturas","Vendedores con Monto Facturado"};
            List<Listados> listados = new List<Listados>();
            Listados list;
            for (int i = 1; i <= lista.Count; i++)
            {
                list = new Listados();
                list.ID = i;
                list.Descripcion = lista[i - 1];
                listados.Add(list);
            }
            return listados;
        }

    }


    class Trimestre
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Trimestre()
        {

        }

        public List<Trimestre> GetTrimestres()
        {
            List<string> lista = new List<string> { "1er Trimestre", "2do Trimestre", "3er Trimestre", "4to Trimestre" };
            List<Trimestre> listados = new List<Trimestre>();
            Trimestre list;
            for (int i = 1; i <= lista.Count; i++)
            {
                list = new Trimestre();
                list.ID = i;
                list.Descripcion = lista[i - 1];
                listados.Add(list);
            }
            return listados;
        }

    }
}
