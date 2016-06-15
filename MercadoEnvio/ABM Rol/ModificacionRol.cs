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

namespace MercadoEnvio.ABM_Rol
{
    public partial class ModificacionRol : Form
    {
        int agregar0_modif1 = 1;
        public ModificacionRol()
        {
            InitializeComponent();
            LlenarFuncionalidades_DataGridView();
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

        private void cmbRoles_DropDown(object sender, EventArgs e)
        {
            LlenarRoles_ComboBox();
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                row.Cells["Check"].Value = false;
            }
        }

        private void ABMRol_Load_1(object sender, EventArgs e)
        {

            //Deshabilito el txtNombre t el botonGrabar
            txtNombreRol.Enabled = false;
            btnGrabarRol.Enabled = false;

            agregar0_modif1 = 1;
            List<int> Func_chequeadas = new List<int>();
            //Cargo el txtNombre con el seleccionado del Combobox
            txtNombreRol.Text = cmbRoles.Text;
            //Traigo la listas de las funcionalidades a chequear
            Func_chequeadas = new Rol().TraerFuncionalidadesRol(txtNombreRol.Text);
            int i = 0, j = 1;
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                for (i = 0; i < Func_chequeadas.Count; i++)
                    if (Func_chequeadas[i] == j)
                        row.Cells["Check"].Value = true;
                j++;
            }

        }

        private void cmbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            List<int> Func_chequeadas = new List<int>();

            //if (cmbRoles.Text == "System.Data.DataRowView")
            //{
            //    cmbRoles.Text = "Seleccione un Rol";
            //    return;
            //}



            agregar0_modif1 = 1;
            //Habilito el textboxNombre para que se peuda editar
            txtNombreRol.Enabled = true;
            //llamar  a la rutina para deseleccionar los roles
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {

                if (Convert.ToBoolean(row.Cells["Check"].Value))
                {
                    row.Cells["Check"].Value = false;
                }
            }
            //Debo llamar a un SP para saber si el Rol esta habilitado o no   1=HABILITADO    0=DESHABILITADO
            string NombreRol = cmbRoles.Text;
            int resul = new Rol().ObtenerEstadoRol(NombreRol);
            //Si el rol se encuentra HABILITADO, NO MUESTRO el boton de habilitar y habilito el boton Grabar.
            if (resul == 1)
            {
                btnHab.Visible = false;
                btnGrabarRol.Enabled = true;

            }

            //Si el rol se encuentra DESHAILITADO, muestro el boton de Habilitar y deshabilito al boton Grabar
            else if (resul == 0)
            {
                btnHab.Visible = true;
                btnGrabarRol.Enabled = false;

            }
            //Cargo el txtNombre con el seleccionado del Combobox
            txtNombreRol.Text = cmbRoles.Text;
            //Traigo la listas de las funcionalidades a chequear
            Func_chequeadas = new Rol().TraerFuncionalidadesRol(txtNombreRol.Text);
            int i1 = 0, j1 = 1;
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                for (i1 = 0; i1 < Func_chequeadas.Count; i1++)
                    if (Func_chequeadas[i1] == j1)
                        row.Cells["Check"].Value = true;
                j1++;
            }
        }



        private void btnGrabarRol_Click(object sender, EventArgs e)
        {
            //VERIFICO SI CAMBIO O NO EL NOMBRE
            if (txtNombreRol.Text == cmbRoles.Text)
            {
                //Flag que me indica que debo MODIFICR EL ROL
                agregar0_modif1 = 1;
                btnGrabarRol.Enabled = true;
            }
            else
            {  //FLAG QUE ME INDICA QUE DEBO DAR DE ALTA AL ROL, POR QUE CAMBIO EL NOMBRE
                agregar0_modif1 = 1;
            }
            //Verifico que haya algo en el nombre del rol
            if (txtNombreRol.Text == "")
            {
                MessageBox.Show("Debe completar los datos requeridos del rol para poder grabarlo");
                return;
            }
            //Verifico que haya alguna funcionalidad chequeada
            int contador = 0;
            foreach (DataGridViewRow row in dgvTotalFunc.Rows)
            {
                //En cada fila que este chequeado el CheckedBox aumento el contador en 1
                if (Convert.ToBoolean(row.Cells["Check"].Value))
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                MessageBox.Show("Debe completar los datos requeridos del rol para poder grabarlo");
                return;
            }


            if (agregar0_modif1 == 0)   //Si Tengo que agregar un nuevo rol, debo hacer un ALTA
            {


                #region Verifico si ya esta el nombre del Rol en la lista
                int rol_existe = 0;
                //Verifico si ya está el nombre del Rol en la lista (Lo hago con sp, si me devuelve un registro es que ya hay un rol con ese nombre)
                string nombre = txtNombreRol.Text;
                nombre = nombre.ToUpper();
                rol_existe = new Rol().VerificarRol(nombre);
                if (rol_existe != 0)
                {
                    MessageBox.Show("Ya existe un rol con ese nombre. Intente con otro");
                    return;
                }

                #endregion

                //Agrego a la lista las funcionalidades chequeadas
                List<int> Func_chequeadas = new List<int>();
                foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                {
                    //En cada fila que este chequeado el CheckedBox tengo que guardar en la lista de funcionalidades chequeadas
                    if (Convert.ToBoolean(row.Cells["Check"].Value))
                    {
                        Func_chequeadas.Add(Convert.ToInt32(row.Cells["FUNC_ID"].Value.ToString()));
                    }
                }
                int resultado = 0;
                resultado = new Rol().VerificarAgregarRol(Func_chequeadas);
                string sfuncionalidades = string.Empty;
                Func_chequeadas = OrderFunciones(Func_chequeadas);
                foreach (int f in Func_chequeadas)
                {
                    sfuncionalidades += f.ToString() + ",";
                }
                resultado = new Rol().ExisteRol(sfuncionalidades);
                if (resultado == 0)
                {
                    //El nuevo rol tiene funcionalidades distintas, es decir que lo tengo que agregar
                    int res = new Rol().AgregarNombreRol(nombre);
                    int i = 0;
                    int count = 0;
                    int suma = 0;
                    //Recorro la lista de funcionalidades para insertarlas de a una
                    for (i = 0; i < Func_chequeadas.Count; i++)
                    {
                        count = new Rol().AgregarFuncionalidad(nombre, Func_chequeadas[i]);
                        suma += count;
                    }
                    //Si inserto correctamente todas las funcionalidades, el rol se genero correctamente
                    if (suma == Func_chequeadas.Count)
                    {
                        MessageBox.Show("El rol se generó correctamente.");
                        //this.rOLTableAdapter.Fill(this.gD2C2015DataSetRoles.ROL);
                        //destildo las funciones tildadas
                        foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                        {

                            if (Convert.ToBoolean(row.Cells["Check"].Value))
                            {
                                row.Cells["Seleccion"].Value = false;
                            }
                        }
                        //Limpio el txtNombreROl
                        txtNombreRol.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Estas funcionalidades ya estan asignadas en otro rol");
                    return;
                }

            }
            else if (agregar0_modif1 == 1)  //Si Tengo que modificar el rol existente
            {
                string nombre = txtNombreRol.Text;
                nombre = nombre.ToUpper();
                //Agrego a la lista las funcionalidades chequeadas
                List<int> Func_chequeadas = new List<int>();
                foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                {
                    //En cada fila que este chequeado el CheckedBox tengo que guardar en la lista de funcionalidades chequeadas
                    if (Convert.ToBoolean(row.Cells["Check"].Value))
                    {
                        Func_chequeadas.Add(Convert.ToInt32(row.Cells["FUNC_ID"].Value.ToString()));
                    }
                }
                int resultado = 0;
                resultado = new Rol().VerificarAgregarRol(Func_chequeadas);
                if (resultado == 0)
                {

                    //El nuevo rol tiene funcionalidades distintas, es decir que lo tengo que agregar
                    int res = new Rol().EliminarFuncRol(nombre);
                    int i = 0;
                    int count = 0;
                    int suma = 0;
                    //Recorro la lista de funcionalidades para insertarlas de a una
                    for (i = 0; i < Func_chequeadas.Count; i++)
                    {
                        count = new Rol().AgregarFuncionalidad(nombre, Func_chequeadas[i]);
                        suma += count;
                    }
                    //Si inserto correctamente todas las funcionalidades, el rol se genero correctamente
                    if (suma == Func_chequeadas.Count)
                    {
                        MessageBox.Show("El rol se modificó correctamente.");
                        //this.rOLTableAdapter.Fill(this.gD2C2015DataSetRoles.ROL);
                        //destildo las funciones tildadas
                        foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                        {

                            if (Convert.ToBoolean(row.Cells["Check"].Value))
                            {
                                row.Cells["Check"].Value = false;
                            }
                        }
                        //Vuelvo el flag al default que es Modificar
                        agregar0_modif1 = 1;
                        //Limpio el txtNombreROl
                        txtNombreRol.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Estas funcionalidades ya estan asignadas en otro rol");
                    return;
                }
            }
            
        }


        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
        private List<int> OrderFunciones(List<int> lista)
        {
            bool NoEstabaOrdenado = true;
            while (NoEstabaOrdenado)
            {
                NoEstabaOrdenado = false;
                for (int i = 0; i < lista.Count; i++)
                {
                    for (int j = i + 1; j < lista.Count; j++)
                    {
                        if (lista[i] > lista[j])
                        {
                            int funcionI = lista[i];
                            int funcionJ = lista[j];
                            lista[i] = funcionJ;
                            lista[j] = funcionI;
                            NoEstabaOrdenado = true;
                        }
                    }
                }
            }
            return lista;
        }
    }
}
