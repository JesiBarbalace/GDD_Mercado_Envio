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
using System.Data.SqlClient;

namespace MercadoEnvio.ABM_Rol
{
    public partial class BajaRol : Form
    {
        public BajaRol()
        {
            InitializeComponent();
            txtNombreRol.Enabled = false;
            txtNombreRol.Clear();
            LlenarFuncionalidades_DataGridView();
           // LlenarRoles_ComboBox();
            btnGrabarRol.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BajaRol_Load(object sender, EventArgs e)
        {

            // TODO: esta línea de código carga datos en la tabla 'gD2C2015DataSetRol.ROL' Puede moverla o quitarla según sea necesario.
            //            this.rOLTableAdapter.Fill(this.gD2C2015DataSetRol.ROL);


        }

        
        public void LlenarRoles_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Rol().getRoles();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbRoles.Text = "Seleccionar Rol";
            cmbRoles.DataSource = dtable;
            cmbRoles.ValueMember = "ROL_NOMBRE";
            cmbRoles.DisplayMember = "Seleccionar Rol";
            cmbRoles.Text = "Seleccionar Rol";
        }

        public void LlenarFuncionalidades_DataGridView()
        {
            DataTable dtable;

            dtable = new Rol().TraerFuncionalidades();
            //limpiamos los renglones de la datagridview
            dgvTotalFunc.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand

            //el ciclo while se ejecutará mientras lea registros en la tabla
            foreach (DataRow dtRow in dtable.Rows)
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dgvTotalFunc.Rows.Add();
                // especificamos en que fila se mostrará cada registro
                // nombredeldatagrid.filas[numerodefila].celdas[nombredelacelda].valor=
                // dr.tipodedatosalmacenado(dr.getordinal(nombredelcampo_en_la_base_de_datos)conviertelo_a_string_sino_es_del_tipo_string);
                dgvTotalFunc.Rows[renglon].Cells["FUNC_ID"].Value = (Convert.ToInt32(dtRow["FUNC_ID"]));
                dgvTotalFunc.Rows[renglon].Cells["FUNCIONALIDADES"].Value = Convert.ToString(dtRow["FUNC_DESCRIPCION"]);
            }

        }

        private void btnGrabarRol_Click(object sender, EventArgs e)
        {

            
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BajaRol_Load_1(object sender, EventArgs e)
        {
            txtNombreRol.Enabled = false;
            txtNombreRol.Clear();
            LlenarFuncionalidades_DataGridView();
            //cmbRoles.Text = "Seleccionar Rol";
            //LlenarRoles_ComboBox();
            btnGrabarRol.Enabled = false;
        }

        private void cmbRoles_DropDown(object sender, EventArgs e)
        {
            LlenarRoles_ComboBox();
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                row.Cells["CheckFunc"].Value = false;
            }
        }

        private void cmbRoles_Click(object sender, EventArgs e)
        {
            //LlenarRoles_ComboBox();
        }

        private void cmbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            List<int> Func_chequeadas = new List<int>();

            if (cmbRoles.Text == "System.Data.DataRowView")
            {
                cmbRoles.Text = "Seleccione un Rol";
                return;
            }
            //llamar  a la rutina para deseleccionar los roles
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {

                if (Convert.ToBoolean(row.Cells["CheckFunc"].Value))
                {
                    row.Cells["CheckFunc"].Value = false;
                }
            }
            //Debo llamar a un SP para saber si el Rol esta habilitado o no   1=HABILITADO    2=DESHABILITADO
            string NombreRol = cmbRoles.Text;
            int resul = new Rol().ObtenerEstadoRol(NombreRol);

            //Si el rol se encuentra DESHAILITADO, 
            if (resul == 0)
            {
                MessageBox.Show("El rol ya se encuentra inhabilitado, no se puede eliminar.");
                //Cargo el txtNombre con el seleccionado del Combobox
                txtNombreRol.Text = cmbRoles.Text;
                //Bloqueo el nombre para que no se pueda modificar, si quiero cambiar el nombre tengo que eliminar el rol y crear otro
                txtNombreRol.Enabled = false;
                //Lleno el datagridview con todas las funcionalidades


                //Traigo la listas de las funcionalidades a chequear
                Func_chequeadas = new Rol().TraerFuncionalidadesRol(txtNombreRol.Text);
                int i1 = 0, j1 = 1;
                foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                {
                    for (i1 = 0; i1 < Func_chequeadas.Count; i1++)
                        if (Func_chequeadas[i1] == j1)
                            row.Cells["CheckFunc"].Value = true;
                    j1++;
                }

                btnGrabarRol.Enabled = false;
                return;

            }

            //Si el rol de encuentra HABILITADO

            //Cargo el txtNombre con el seleccionado del Combobox
            txtNombreRol.Text = cmbRoles.Text;
            //Bloqueo el nombre para que no se pueda modificar, si quiero cambiar el nombre tengo que eliminar el rol y crear otro
            txtNombreRol.Enabled = false;
            //Lleno el datagridview con todas las funcionalidades


            //Traigo la listas de las funcionalidades a chequear
            Func_chequeadas = new Rol().TraerFuncionalidadesRol(txtNombreRol.Text);
            int i = 0, j = 1;
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                for (i = 0; i < Func_chequeadas.Count; i++)
                    if (Func_chequeadas[i] == j)
                        row.Cells["CheckFunc"].Value = true;
                j++;
            }

            btnGrabarRol.Enabled = true;
        }

        private void btnGrabarRol_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Usted está a punto de inhabilitar el Rol.", "¿Desea continuar?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //Llamo a SP InhabilitarRol para cambiar el estado del rol a INHABILITADO(0), le paso el nombre del rol
            string NombreRol = cmbRoles.Text;
            int resul = new Rol().InhabilitarRol(NombreRol);

            LlenarRoles_ComboBox();

            //Blanqueo el textbox
            txtNombreRol.Text = "";


            //llamar  a la rutina para deseleccionar los roles
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {

                if (Convert.ToBoolean(row.Cells["CheckFunc"].Value))
                {
                    row.Cells["CheckFunc"].Value = false;
                }
            }
        }

    }
}
