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
using MercadoEnvio.Auxiliares;

//using AerolineaFrba.Registro_Llegada_Destino;
using MercadoEnvio.ABM_Rol;
//using AerolineaFrba.Generacion_Viaje;


namespace MercadoEnvio.Menu
{
    public partial class MenuPpal : Form
    {
        Int32 idRol;
        public MenuPpal(Usuario usu)
        {
            InitializeComponent();
            idRol = usu.rolId;
        }
        FuncionesAuxiliares func = new FuncionesAuxiliares();


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Alta Rol"))
            {
                ABM_Rol.AltaRol alta = new ABM_Rol.AltaRol();
                alta.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

       
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Baja Rol"))
            {
                ABM_Rol.BajaRol baja = new ABM_Rol.BajaRol();
                baja.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Modificación Rol"))
            {
                ABM_Rol.ModificacionRol modif = new ABM_Rol.ModificacionRol();
                modif.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Listado Estadístico"))
            {
                Listado_Estadistico.Listado listado = new Listado_Estadistico.Listado();
                listado.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

            
    }
}