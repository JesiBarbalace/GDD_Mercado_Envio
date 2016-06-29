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
            //Tipos de usuarios? 
            llenarCombo_clientes();
            label4.Visible = false;
            label9.Visible = false;
            btnFirstPage.Enabled = false;
            btnLastPage.Enabled = false;
            btnNextPage.Enabled = false;
            btnPreviousPage.Enabled = false;
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

            // FALTA MANEJO DE ERROR CUANDO DEVUELVE NULL FILA
            //TAMBIÉN CUANDO PASO DE UNA PAGINA CUANDO VOLVI A RESIZE

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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDetalle.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable dtable;
            DataSet myDataSet = new DataSet();

            dtable = new Factura().TraerDetalles();
            myDataSet.Tables.Add(dtable);
            comboDetalle.DataSource = dtable;
            comboDetalle.ValueMember = "TIPO_FACTU_DESC";
            comboDetalle.Text = "Seleccionar Visibilidad";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Empresa")
            {
                label4.Visible = true;
                label9.Visible = false;
            }
            else
            {
                label4.Visible = false;
                label9.Visible = true;
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
                        query = "WHERE monto <=" + textMontoDesde.Text;
                    }

                }
                if (textFechaDesde.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha >=" + "'" + textFechaDesde.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha >=" + "'" + textFechaDesde.Text + "'";
                    }
                }
                if (textFechaHasta.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha <=" + "'" + textFechaHasta.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha <=" + "'" + textFechaHasta.Text + "'";
                    }
                }
                /* 
                 * FALTA EL DETALLE EN SQL
                 * if (comboDetalle.Text != "")
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
                        */

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
                        query = "WHERE monto <=" + textMontoDesde.Text;
                    }

                }
                if (textFechaDesde.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha <=" + "'" +textFechaDesde.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha <=" + "'" +textFechaDesde.Text + "'";
                    }
                }
                if (textFechaHasta.Text != "")
                {
                    if (query.Contains("WHERE"))
                    {
                        query = query + "AND fecha >=" + "'" + textFechaHasta.Text + "'";
                    }
                    else
                    {
                        query = "WHERE fecha >=" + "'" + textFechaHasta.Text + "'";
                    }
                }
              /* 
               * FALTA EL DETALLE EN SQL
               * if (comboDetalle.Text != "")
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
                */
                dtSource = new Factura().TraerFacturasEmpresas(query);
                myDataSet.Tables.Add(dtSource);
                dataGrid1.DataSource = dtSource;
            }
            #endregion if empresa

        }



        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            btnLastPage.Enabled = true;
            btnNextPage.Enabled = true;
            btnPreviousPage.Enabled = true;
            btnFirstPage.Enabled = true;
            // Set the start and max records. 
            pageSize = Convert.ToInt32(txtPageSize.Text);
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
                MessageBox.Show("You are at the First Page!");
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
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return;
            }

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                //Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("You are at the Last Page!");
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
                MessageBox.Show("You are at the First Page!");
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
                MessageBox.Show("You are at the Last Page!");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            LoadPage();
        }

    }
}
