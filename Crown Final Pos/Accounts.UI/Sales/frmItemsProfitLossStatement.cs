using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.Common;
using Accounts.EL;
using Accounts.BLL;
using MetroFramework.Forms;
using SpreadsheetLight;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmItemsProfitLossStatement : Form
    {
        DataTable dt;
        public frmItemsProfitLossStatement()
        {
            InitializeComponent();
        }
        private void frmItemsProfitLossStatement_Load(object sender, EventArgs e)
        {
            this.grdProductsProfitLoss.AutoGenerateColumns = false;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetItemsProfitLossStatementByDate(Operations.IdProject, dtStart.Value, dtEnd.Value);
            if (list.Count > 0)
            {
                dt = DataOperations.ToDataTable(list);
                grdProductsProfitLoss.DataSource = dt;
                lblTotalProfit.Text = "Total Profit OR Loss Is : " + list.Sum(x => x.NetProfit).ToString();
            }
            else
            {
                grdProductsProfitLoss.DataSource = null;
                MessageBox.Show("No Data Found....");
                lblTotalProfit.Text = string.Empty;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdProductsProfitLoss.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdProductsProfitLoss.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdProductsProfitLoss.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in grdProductsProfitLoss.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (cell.Value != null)
                        //{
                        if (cell.Visible)
                        {
                            //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value ?? 0.ToString();
                            colindex++;
                        }
                        //}
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdProductsProfitLoss.DataSource = DV;
            //(grdTotalStock.DataSource as DataTable).DefaultView.RowFilter = string.Format("colAccountName='{0}'", txtsearch.Text);
        }
    }
}
