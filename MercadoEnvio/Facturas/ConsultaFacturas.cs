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
using System.Reflection;
using MercadoEnvio.Mappings;


namespace MercadoEnvio.Facturas
{
    public partial class ConsultaFacturas : Form
    {

        String query;
        DataTable dtSource;
        int PageCount;
        int maxRec;
        int pageSize;
        int currentPage;
        int recNo;

        public ConsultaFacturas()
        {
            InitializeComponent();
            SetMyCustomFormat();
            //Tipos de usuarios? 
            llenarCombo_clientes();
            label4.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label6.Visible = false;
            btnFirstPage.Enabled = false;
            btnLastPage.Enabled = false;
            btnNextPage.Enabled = false;
            btnPreviousPage.Enabled = false;
            comboDetalle.Enabled = false;
        }

        private void LoadPage()
        {
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = dtSource.Clone();

            if (currentPage == PageCount)
            {
                endRec = maxRec;
            }
            else
            {
                endRec = pageSize * currentPage;
            }
            startRec = recNo;

            //Copy rows from the source table to fill the temporary table.


            if (dtSource.Rows.Count == 0)
            {
                MessageBox.Show("Debe haber al menos un resultado ");
                return;
            }

            for (i = startRec; i < endRec; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
                recNo += 1;
            }
            dataGrid1.DataSource = dtTemp;
            DisplayPageInfo();
        }

        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Page " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private bool CheckFillButton()
        {
            // Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return false;
            }
            else
            {
                return true;
            }
        }



        private void llenarCombo_clientes()
        {

            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Factura().TraerDetalles();
            myDataSet.Tables.Add(dtable);
            comboDetalle.DataSource = dtable;
            comboDetalle.ValueMember = "TIPO_FACTU_DESC";


            
        }

        public void SetMyCustomFormat()
        {
            
            dateTimeDesde.Format = DateTimePickerFormat.Custom;
            dateTimeDesde.CustomFormat = "yyyy-dd-MM";
            dateTimeHasta.Format = DateTimePickerFormat.Custom;
            dateTimeHasta.CustomFormat = "yyyy-dd-MM";
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Empresa")
            {
                label4.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label6.Visible = true;

            }
            else
            {
                label4.Visible = false;
                label9.Visible = true;
                label6.Visible = false;
                label10.Visible = true;
            }
        }

        private void ConsultaFacturas_Load(object sender, EventArgs e){}


        private void button1_Click(object sender, EventArgs e)
        {
            
            query = "";
            btnLastPage.Enabled = false;
            btnNextPage.Enabled = false;
            btnPreviousPage.Enabled = false;
            btnFirstPage.Enabled = false;

            DataSet myDataSet = new DataSet();

            #region if Cliente
            if (comboBox1.Text == "Cliente")
            {
                if (textPersona.Text == "")
                {
                    query = "";
                }
                else
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND DNI =" + textPersona.Text;
                    }
                    else
                    {
                        query = "WHERE DNI = " + textPersona.Text;

                    }
                }

                if (textMontoDesde.Text != "" && textMontoHasta.Text != "")
                {
                    Single desde = Convert.ToSingle(textMontoDesde.Text);
                    Single hasta = Convert.ToSingle(textMontoHasta.Text);
                    if (desde > hasta)
                    {

                        MessageBox.Show("Elija un monto válido");
                        return;

                    }
                }
                if (textMontoDesde.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND monto >=" + textMontoDesde.Text;
                    }
                    else
                    {
                        query = "WHERE monto >=" + textMontoDesde.Text;
                    }

                }
                if (textMontoHasta.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND monto <=" + textMontoHasta.Text;
                    }
                    else
                    {
                        query = "WHERE monto <=" + textMontoHasta.Text;
                    }

                }
                if (dateTimeDesde.Checked == true && dateTimeHasta.Checked == true)
                {
                    int result = DateTime.Compare(dateTimeDesde.Value, dateTimeHasta.Value);
                    if (result > 0)
                    {
                        MessageBox.Show("Elija una fecha válida");
                        return;
                    }
                }
                if (dateTimeDesde.Checked == true)
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha >=" + "'" + dateTimeDesde.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha >=" + "'" + dateTimeDesde.Text + "'";
                    }
                }
                if (dateTimeHasta.Checked == true)
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha <=" + "'" + dateTimeHasta.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha <=" + "'" + dateTimeHasta.Text + "'";
                    }
                }
                if (textNombre.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND Nombre_Apellido like" + "'%" + textNombre.Text + "%'";

                    }
                    else
                    {
                        query = "WHERE Nombre_Apellido like" + "'%" + textNombre.Text + "%'";
                    }
                }

                if (checkBox1.Checked == true)
                    {
                      if (query.Contains("WHERE"))
                       {
                           query = query + "AND detalle =" + "'" + comboDetalle.Text + "'";
                        }
                      else
                        {
                           query = "WHERE detalle =" + "'" + comboDetalle.Text + "'";
                         }
                      }

                    if (checkBox1.Checked == true)
                    {
                        
                        dtSource = new Factura().TraerFacturasNuevasPersonas(query);
                        myDataSet.Tables.Add(dtSource);
                        dataGrid1.DataSource = dtSource;
                        return;
                    }
                    
                dtSource = new Factura().TraerFacturasPersonas(query);
                myDataSet.Tables.Add(dtSource);
                dataGrid1.DataSource = dtSource;

            }
            #endregion if Cliente

            #region if empresa
            if (comboBox1.Text == "Empresa")
            {
                //EMPRESA
                if (textPersona.Text == "")
                {
                    query = "";
                }
                else
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND CUIT =" + "'" + textPersona.Text + "'";
                    }
                    else
                    {
                        query = "WHERE CUIT = " + "'" +textPersona.Text + "'";
                    }
                }
                if (textMontoDesde.Text != "" && textMontoHasta.Text != "")
                {
                    Single desde = Convert.ToSingle(textMontoDesde.Text);
                    Single hasta = Convert.ToSingle(textMontoHasta.Text);
                    if (desde > hasta)
                    {
                        
                            MessageBox.Show("Elija un monto válido");
                            return;
                        
                    }
                }
                if (textMontoDesde.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND monto >=" + textMontoDesde.Text;
                    }
                    else
                    {
                        query = "WHERE monto >=" + textMontoDesde.Text;
                    }

                }
                if (textMontoHasta.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND monto <=" + textMontoHasta.Text;
                    }
                    else
                    {
                        query = "WHERE monto <=" + textMontoHasta.Text;
                    }

                }
                if (dateTimeDesde.Checked == true && dateTimeHasta.Checked == true)
                {
                    int result = DateTime.Compare(dateTimeDesde.Value, dateTimeHasta.Value);
                    if (result > 0)
                    {
                        MessageBox.Show("Elija una fecha válida");
                        return;
                    }
                }

                if (dateTimeDesde.Checked == true)
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + " AND fecha >=" + "'" + dateTimeDesde.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha >= " + "'" + dateTimeDesde.Text + "'";
                    }
                }
                if (dateTimeHasta.Checked == true)
                {
                    
                    if (query.Contains("WHERE"))
                    {
                        query = query + " AND fecha <= " + "'" + dateTimeHasta.Text +"'";
                    }
                    else
                    {
                        query = "WHERE fecha <= " + "'" + dateTimeHasta.Text + "'";
                    }
                }
                if(textNombre.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND razon_social like" + "'%" + textNombre.Text + "%'";

                    }
                    else
                    {
                        query = "WHERE razon_social like" + "'%" + textNombre.Text + "%'";
                    }
                }
               
                if (checkBox1.Checked == true)
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND detalle =" + "'" + comboDetalle.Text + "'";
                    }
                    else
                    {
                        query = "WHERE detalle =" + "'" + comboDetalle.Text + "'";
                    }
                }

                if (checkBox1.Checked == true)
                {
                    
                    dtSource = new Factura().TraerFacturasNuevasEmpresas(query);
                    myDataSet.Tables.Add(dtSource);
                    dataGrid1.DataSource = dtSource;
                    return;
                }
                
                dtSource = new Factura().TraerFacturasEmpresas(query);
                myDataSet.Tables.Add(dtSource);
                dataGrid1.DataSource = dtSource;
              }
              #endregion if empresa
            if (comboBox1.Text == "Seleccione un valor")
            {
                MessageBox.Show("Debe elegir un tipo de usuario");
                return;
            }

                   }
            
            
            


        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            btnLastPage.Enabled = true;
            btnNextPage.Enabled = true;
            btnPreviousPage.Enabled = true;
            btnFirstPage.Enabled = true;
            // Set the start and max records. 
            pageSize = Convert.ToInt32(txtPageSize.Text);
            if (pageSize == 0)
            {
                MessageBox.Show("Debe elegir un numero mayor a 0");
                return;
            }
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / pageSize;

            //Adjust the page number if the last page contains a partial page.
            if ((maxRec % pageSize) > 0)
            {
                PageCount += 1;
            }

            // Initial seeings
            currentPage = 1;
            recNo = 0;

            // Display the content of the current page.

            LoadPage();
        }

        private void btnFillGrid_Click()
        {
            throw new NotImplementedException();
        }


        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("Ya estás en la primera página");
                return;
            }

            currentPage = 1;
            recNo = 0;
            LoadPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //If the user did not click the "Fill Grid" button, then return.
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Fija el tamaño de página y luego clickea en el boton de dividir en págins");
                return;
            }

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                //Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("Ya estás en la última página");
                    return;
                }
            }
            LoadPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }

            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("Ya estás en la primera página");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            LoadPage();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {

            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("Ya estás en la última página");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            LoadPage();
        }

        private void textMontoDesde_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros con decimales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (textMontoDesde.Text.Contains("."))
            {
                if ((e.KeyChar == '.'))
                {
                    MessageBox.Show("Ingrese un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }

        }

        private void textMontoHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros con decimales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (textMontoHasta.Text.Contains("."))
            {
                if ((e.KeyChar == '.'))
                {
                    MessageBox.Show("Ingrese un número", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void textPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '-'))
            {
                MessageBox.Show("Solo se permiten numeros y guiones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dateTimeDesde_ValueChanged(object sender, EventArgs e)
        {
            dateTimeDesde.Enabled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboDetalle.Enabled = true;
            }
            else
            {
                comboDetalle.Enabled = false;
            }

        }

    }
}
