﻿using System;
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

using MercadoEnvio.ABM_Rol;
using MercadoEnvio.Calificar;
using MercadoEnvio.Historial_Cliente;
using MercadoEnvio.Facturas;


namespace MercadoEnvio.Menu
{
    public partial class MenuPpal : Form
    {
        public Usuario usuario;

        Int32 idRol;
        public MenuPpal(Usuario usu)
        {
            InitializeComponent();
            idRol = usu.rolId;
            usuario = usu;
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

        private void MenuPpal_Load(object sender, EventArgs e)
        {
            Mappings.EstadoPublicaciones estadoPublicaciones = new EstadoPublicaciones();
            estadoPublicaciones.VerificarPublicaciones();
        }

        private void calificarAlVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Calificar al Vendedor"))
            {
                Calificar.CalificarForm calificar = new Calificar.CalificarForm(usuario);
                calificar.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void historialClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Historial del Cliente"))
            {
                Historial_Cliente.HistorialClienteForm historial = new Historial_Cliente.HistorialClienteForm(usuario);
                historial.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void MenuPpal_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Desea desloguarse de la aplicación?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
            }
            else
                e.Cancel = true;

        }
        private void altaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (func.permiso(idRol, "Alta Usuarios"))
            {
                ABM_Usuario.AltaUsuario altausu = new ABM_Usuario.AltaUsuario ();
                altausu.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void modificaciónUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Modificación Usuarios"))
            {
               
             ABM_Usuario.ModificarUsuario modifusu = new ABM_Usuario.ModificarUsuario ();
              modifusu.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void bajaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Baja Usuarios"))
            {

                ABM_Usuario.BajaUsuario bajausu = new ABM_Usuario.BajaUsuario();
                bajausu.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void comprarOfertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Comprar/Ofertar"))
            {
                ComprarOfertar.ListadoPublicacionesForm comprarOfertar = new ComprarOfertar.ListadoPublicacionesForm(usuario);
                comprarOfertar.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void altaDePublicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Generar Publicación"))
            {
                Generar_Publicación.AltaPublicacion altapublic = new  Generar_Publicación.AltaPublicacion(usuario);
                altapublic.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }
        
        private void consultaDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Consulta de Facturas realizadas al Vendedor"))
            {
                Facturas.ConsultaFacturas factura = new Facturas.ConsultaFacturas();
                factura.Show();
            }
            else {
                MessageBox.Show("Permiso inválido para realizar esta operación");
            }
        }

        private void altaVisibilidadPublicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Alta Visibilidad Publicación"))
            {
                ABM_Visibilidad.AltaVisibilidad altaVisibilidad = new ABM_Visibilidad.AltaVisibilidad();
                altaVisibilidad.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void modificaciónVisibilidadPublicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Modificación Visibilidad Publicación"))
            {
                ABM_Visibilidad.ModificacionVisibilidad modificacionVisibilidad = new ABM_Visibilidad.ModificacionVisibilidad();
                modificacionVisibilidad.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void bajaVisibilidadPublicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Baja Visibilidad Publicación"))
            {
                ABM_Visibilidad.BajaVisibilidad bajaVisibilidad = new ABM_Visibilidad.BajaVisibilidad();
                bajaVisibilidad.Show();
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }

        private void modificarPublicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (func.permiso(idRol, "Modificar Publicación"))
            {
                Generar_Publicación.ModificarPublicacion modifPubli = new Generar_Publicación.ModificarPublicacion();
                modifPubli.Show();
         
            }
            else
                MessageBox.Show("Permiso inválido para realizar esta operación");
        }


            
    }
}
