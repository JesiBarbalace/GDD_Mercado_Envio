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

namespace MercadoEnvio.Generar_Publicación
{
    public partial class AltaPublicacion : Form
    {
        public AltaPublicacion()
        {
            InitializeComponent();
        }

        private void cmbPubli_DropDown(object sender, EventArgs e)
        {
            LlenarTipoPubli_ComboBox();

        }

        public void LlenarTipoPubli_ComboBox()
        {
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Publicacion().getTipoPubli();
            myDataSet.Tables.Add(dtable);
            //cmbRoles.DataSource = myDataSet.Tables["ROL_NOMBRE"].DefaultView;
            cmbPubli.Text = "Seleccionar Tipo de Publicación";
            cmbPubli.DataSource = dtable;
            cmbPubli.ValueMember = "PUBLI_TIPO_DESC";
            cmbPubli.DisplayMember = "Seleccionar Tipo de Publicación";
            cmbPubli.Text = "Seleccionar Tipo de Publicación";
        }

        private void cmbPubli_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPubli.Text == "System.Data.DataRowView")
            {
                cmbPubli.Text = "Seleccione un Rol";
                return;
            }

            string subasta = "Subasta";
            string compra = "Compra Inmediata";

            if (cmbPubli.Text == "Subasta")
            {


                //label10.Visible = false;
            }
        }
    }
}
