using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoEnvio.Mappings;
using MercadoEnvio.Menu;
using System.Security.Cryptography;

namespace MercadoEnvio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario();
                String Msg = String.Empty;
                #region ValidarParametros y Usuarios
                if (!validoParametros(txtUsuario, txtPass))
                {
                    MessageBox.Show("Ingrese los valores requeridos para poder ingresar");
                }
                else
                {
                    #region ObtenerUsuario
                    usu = usu.getUser(txtUsuario.Text, txtPass.Text);
                    #endregion
                    string valorEncriptado = usu.SHA256Encripta(txtPass.Text);

                    if (usu.usuarioHabilitado == 0)
                    {
                        throw new Exception("El usuario se encuentra bloqueado");
                    }
                    else
                    {
                        #region CompararValor Ingresado contra la base

                        
                        if (usu.usuarioIngresado == 0)
                        {
                            usu.usuarioIngresado = 1;

                            MessageBox.Show("El Usuario ingresado en la primera vez que accede al sistema. La constraseña ingresada se almacenará y deberá utilizarla en su próximo ingreso.");

                        }
                        else
                        {

                            if (usu.pass == valorEncriptado)
                            {
                                Msg = "OK";
                                usu.usuarioHabilitado = 1;
                                usu.usuarioIntentos = 0;
                            }
                            else
                            {
                                Msg = "ERR";
                                if (usu.usuarioIntentos == 2)
                                {
                                    usu.usuarioHabilitado = 0;
                                    usu.usuarioIntentos=3;
                                }
                                else
                                    usu.usuarioIntentos++;
                             }

                        }


                        #endregion
                    }

                    usu = usu.ModificarIntento(Msg, valorEncriptado);

                    if (usu == null)
                    {
                        MessageBox.Show("La contraseña ingresada es incorrecta");
                        
                    }
                    else
                    {
                        string rol_seleccionado;
                        List<Rol> roles = new List<Rol>();

                        roles = new Rol().getRolesUsuario(usu.usuarioId);

                        if (cmbRolUsuario.Visible == true)
                        {
                            rol_seleccionado = cmbRolUsuario.Text;
                            foreach (Rol rol in roles)
                                if (rol.nombre == rol_seleccionado)
                                {
                                    usu.rolId = rol.rolId;
                                }

                            MenuPpal frm = new Menu.MenuPpal(usu);
                            this.Hide();
                            frm.Show();

                        }

                        if ((roles.Count) > 1)
                        {
                            cmbRolUsuario.Visible = true;

                            foreach (Rol rol in roles)
                                cmbRolUsuario.Items.Add(rol.nombre);
                        }
                        else
                        {
                            foreach (Rol rol in roles)
                                usu.rolId = rol.rolId;
                            MenuPpal frm = new Menu.MenuPpal(usu);
                            this.Hide();
                            frm.Show();

                        }

                    }

                }
                
                #endregion

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean validoParametros(TextBox usuario, TextBox pass)
        {

            if (usuario.Text == string.Empty || pass.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Desea cerrar la aplicación?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                
            }
            else
                e.Cancel = true;

        }
      }
}
