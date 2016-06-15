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
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();


            txtNombreRol.Enabled = true;
            txtNombreRol.Clear();
            LlenarFuncionalidades_DataGridView();

            btnGrabarRol.Enabled = true;
        }


        public void LlenarFuncionalidades_DataGridView()
        {
            DataTable dtable;

            dtable=new Rol().TraerFuncionalidades();
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
                dgvTotalFunc.Rows[renglon].Cells["FUNC_DESCRIPCION"].Value = Convert.ToString(dtRow["FUNC_DESCRIPCION"]);
            }
            
        }


        private void btnGrabarRol_Click_1(object sender, EventArgs e)
        {
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
                if (Convert.ToBoolean(row.Cells["CheckFunc"].Value))
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                MessageBox.Show("Debe completar los datos requeridos del rol para poder grabarlo");
                return;
            }

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
                if (Convert.ToBoolean(row.Cells["CheckFunc"].Value))
                {
                    Func_chequeadas.Add(Convert.ToInt32(row.Cells["FUNC_ID"].Value.ToString()));
                }
            }
            int resultado = 0;
            //resultado = new Rol().VerificarAgregarRol(Func_chequeadas);
            string sfuncionalidades = string.Empty;
            Func_chequeadas = OrderFunciones(Func_chequeadas);
            foreach(int f in Func_chequeadas)
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

                    //destildo las funciones tildadas
                    foreach (DataGridViewRow row in dgvTotalFunc.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells["CheckFunc"].Value))
                        {
                            row.Cells["CheckFunc"].Value = false;
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

        private void AltaRol_Load_1(object sender, EventArgs e)
        {
            txtNombreRol.Enabled = true;
            txtNombreRol.Clear();
            LlenarFuncionalidades_DataGridView();
            btnGrabarRol.Enabled = true;

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
