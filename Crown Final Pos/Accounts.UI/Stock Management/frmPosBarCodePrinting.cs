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
//using Microsoft.Reporting.WinForms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Common;
using CrystalDecisions.Shared;

namespace Accounts.UI
{
    public partial class frmPosBarCodePrinting : Form
    {
        #region Variables
        int EnterCounter = 0;
        string CashRecievedAmount = string.Empty;
        string CustomerAccountNo = string.Empty;
        string CashAccountNo = string.Empty;
        string SalesAccountNo = string.Empty;
        string SalesTaxAccountNo = string.Empty;
        public Int64? PosInvoiceNumber = null;
        public Int64? CustomerTransactionId { get; set; }
        public Int64? CashTransactionId { get; set; }
        public Int64? SalesTransactionId { get; set; }
        public Int64? SalesTaxTransactionId { get; set; }
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        #endregion
        #region Form Methods And Events
        public frmPosBarCodePrinting()
        {
            InitializeComponent();
        }
        private void frmPosBarCodePrinting_Load(object sender, EventArgs e)
        {
            LoadAllItems();
            
            toolStripBtnCashier.Text = Operations.UserName;       
        }
        private void frmPosBarCodePrinting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
            }
        }
        #endregion
        #region Simple Methods        
        private void LoadAllItems()
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetAllItems(Operations.IdProject);
            if (list.Count > 0)
            {
                //cbxProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cbxProducts.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbxProducts.DataSource = list;
                cbxProducts.DisplayMember = "ItemName";
                cbxProducts.ValueMember = "IdItem";
                cbxProducts.SelectedIndex = -1;
                cbxProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbxProducts.AutoCompleteSource = AutoCompleteSource.ListItems;

                //foreach (var item in list)
                //{
                //    cbxProducts.AutoCompleteCustomSource.Add(item.ItemName);
                //}
            }
        }
        private void ClearControls()
        {
            grdProducts.Rows.Clear();
            EnterCounter = 0;
            CashRecievedAmount = string.Empty;
            cbxProducts.Focus();
        }
        #endregion
        #region Grid Events
        private void grdProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void grdProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = "-";
            }
            else if (e.ColumnIndex == 6)
            {
                e.Value = "+";
            }
            else if (e.ColumnIndex == 7)
            {
                e.Value = "Delete";
            }
        }
        private void grdProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow ORow = grdProducts.Rows[e.RowIndex];
                    decimal CurrentRowQuantity = Validation.GetSafeDecimal(ORow.Cells["colQuantity"].Value);
                    if (CurrentRowQuantity >= 1)
                    {
                        CurrentRowQuantity--;
                        if (CurrentRowQuantity > 0)
                        {
                            grdProducts.Rows[e.RowIndex].Cells["colQuantity"].Value = CurrentRowQuantity;                            
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow ORow = grdProducts.Rows[e.RowIndex];
                    decimal CurrentRowQuantity = Validation.GetSafeDecimal(ORow.Cells["colQuantity"].Value);
                    if (CurrentRowQuantity >= 1)
                    {
                        CurrentRowQuantity++;
                        grdProducts.Rows[e.RowIndex].Cells["colQuantity"].Value = CurrentRowQuantity;                        
                    }
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewRow ORow = grdProducts.Rows[e.RowIndex];
                    grdProducts.Rows.Remove(ORow);
                }
            }
        }
        #endregion
        #region Validate Methods
        private bool ValidateRows()
        {

            if (grdProducts.Rows.Count == 0)
                return false;
            else
                return true;
        }
        private bool ValidateBookPeriod()
        {
            bool Status = true;
            if (Operations.BookPeriod == "" || Operations.BookPeriod == "Open")
            {
                Status = true;
            }
            else
            {
                string[] Period = Operations.BookPeriod.Split('=');
                if (Period.Length == 2)
                {
                    int FirstMonth = Convert.ToInt32(Period[0].Split(',')[0]);
                    int FirstYear = Convert.ToInt32(Period[0].Split(',')[1]);

                    int SecondMonth = Convert.ToInt32(Period[1].Split(',')[0]);
                    int SecondYear = Convert.ToInt32(Period[1].Split(',')[1]);
                   
                    //if (VDate.Value.Month == FirstMonth && VDate.Value.Year == FirstYear || (VDate.Value.Month == SecondMonth && VDate.Value.Year == SecondYear))
                    //{
                    //    Status = true;
                    //}
                }
                else
                {
                    Status = false;
                }
            }
            return Status;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Main Button Area
            if (ValidateRows())
            {      
                /// Start Barcode Printing Here....
                if (MessageBox.Show("Are You Sure To Start Job ?", "Printing BarCode Job", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSave.Enabled = false;
                    for (int i = 0; i < grdProducts.Rows.Count; i++)
                    {
                        DataGridViewRow oRow = grdProducts.Rows[i];
                        if (oRow != null)
                        {
                            Int64 IdItem = Validation.GetSafeLong(oRow.Cells["colIdItem"].Value);
                            Int64 Quantity = Validation.GetSafeLong(oRow.Cells["colQuantity"].Value);
                            SendToPrinter(IdItem, Quantity);
                        }
                    }
                    MessageBox.Show("Job Completed....");
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("No Row Found To Print...");
            }
            #endregion
        }
        private void SendToPrinter(Int64 IdItem, Int64 Quantity)
        {
            for (int i = 0; i < Quantity; i++)
            {
                PrintReport(IdItem);
            }
        }
        private void toolStripBtnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        private void PrintReport(Int64 IdItem)
        {
            string strSchemaName = "Setup";
            ReportDocument RptDocument = new ReportDocument();

            RptDocument.Load("..//..//Reports/rptLabelledPrintingDefault.rpt");
            
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
            connectionBuilder.ConnectionString = DBHelper.DataConnection;
            oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
            oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
            oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
            oConnectionInfo.Password = connectionBuilder["password"].ToString();
            //oConnectionInfo.IntegratedSecurity = true;
            oConnectionInfo.Type = ConnectionInfoType.SQL;


            foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
            {
                oTableLogOnInfo = oTable.LogOnInfo;
                oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                oTable.ApplyLogOnInfo(oTableLogOnInfo);
            }

            for (int i = 0; i <= RptDocument.Database.Tables.Count - 1; i++)
            {
                RptDocument.Database.Tables[i].Location = oConnectionInfo.DatabaseName + "." + strSchemaName + "." + RptDocument.Database.Tables[i].Location.Substring(RptDocument.Database.Tables[i].Location.LastIndexOf(".") + 1);
            }

            ParameterFieldDefinitions crParamFieldDefinitions = RptDocument.DataDefinition.ParameterFields;
            foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
            {

                if (def.ReportName == "")
                {
                    if (def.ParameterFieldName == "@IdItem")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = IdItem;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }                                                   
                }
            }
            //PageMargins margins = RptDocument.PrintOptions.PageMargins;
            //margins.bottomMargin = 350;/
            //margins.leftMargin = 350;
            //margins.rightMargin = 350;
            //margins.topMargin = 350;   
            //RptDocument.PrintOptions.ApplyPageMargins(margins);

            //ReportLedger.ReportSource = RptDocument;
            RptDocument.PrintToPrinter(1, false, 0, 0);
            //reportViewer1.repo = RptDocument;

            // crystalReportViewer1.ReportSource = RptDocument;
        }
        #endregion
        #region WinControls And Custom Controls Methods And Events
        private void cbxProducts_TextChanged(object sender, EventArgs e)
        {
            //GetItemByBarCode(Validation.GetSafeString(cbxProducts.Text));
        }
        private void cbxProducts_KeyUp(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Down || (e.KeyCode == Keys.Shift && e.KeyCode == Keys.Home))
            //    return;
            //if (e.KeyCode != Keys.Enter)
            //{
            //    cbxProducts.DroppedDown = true;
            //}
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    cbxProducts.DroppedDown = false;
            //}
            //int index;
            //string actual;
            //string found;
            //actual = this.cbxProducts.Text;
            //index = cbxProducts.FindString(actual);
            //if (index > -1)
            //{
            //    found = ((ItemsEL)(this.cbxProducts.Items[index])).ItemName;

            //    //Select this item from the list.
            //    this.cbxProducts.SelectedIndex = index;

            //    //Select the portion of the text that was automatically
            //    //added so that additional typing replaces it.
            //    this.cbxProducts.SelectionStart = actual.Length;
            //    this.cbxProducts.SelectionLength = found.Length;
            //}

        }
        private void cbxProducts_Leave(object sender, EventArgs e)
        {
            GetItemByBarCode(Validation.GetSafeString(cbxProducts.Text));
            //int iFoundIndex;
            //iFoundIndex = cbxProducts.FindStringExact(cbxProducts.Text);
            //cbxProducts.SelectedIndex = iFoundIndex;
        }
        private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxProducts.SelectedIndex > 0)
            //{
            //    MessageBox.Show(cbxProducts.Text);
            //    MessageBox.Show(cbxProducts.SelectedValue.ToString());
            //}
        }
        private void cbxProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || (e.KeyCode == Keys.Shift && e.KeyCode == Keys.Home))
            {
                return;
            }
            //else if (e.KeyCode == Keys.Down)
            //{
            //    if (!cbxProducts.DroppedDown)
            //        cbxProducts.DroppedDown = true;
            //}
            else if (e.KeyCode == Keys.Enter)
            {
                cbxProducts.Refresh();
                if (cbxProducts.Text != string.Empty)
                {
                    GetItemById(Validation.GetSafeLong(cbxProducts.SelectedValue));
                    cbxProducts.Text = string.Empty;
                }
                else
                {
                    EnterCounter++;
                    if (EnterCounter >= 2 && grdProducts.Rows.Count > 0)
                    {
                        EnterCounter = 0;
                    }
                }
            }
            //else
            //{
            //    if (!char.IsNumber((char)e.KeyCode))
            //        e.SuppressKeyPress = false;
            //    else
            //    {
            //        GetItemByBarCode(Validation.GetSafeString(cbxProducts.Text));
            //        cbxProducts.Text = string.Empty;
            //    }
            //}
        }
        private void txtbarcodecontrol_Enter(object sender, EventArgs e)
        {
            cbxProducts.Focus();
        }        
        #endregion
        #region Item Fetch Methods
        private void GetItemById(Int64? Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(Id.Value);
            FillProductInGrid(list, Id);
           
        }
        private void GetItemByBarCode(string BarCode)
        {
            if (!string.IsNullOrEmpty(BarCode))
            {
                var manager = new ItemsBLL();
                List<ItemsEL> list = manager.GetItemByBarCode(Operations.IdProject, BarCode);
                if (list.Count > 0)
                {
                    //MessageBox.Show(cbxProducts.Text);
                    {
                        FillProductInGrid(list, list[0].IdItem);
                        cbxProducts.Text = string.Empty;
                        cbxProducts.Focus();
                    }
                    
                }
            }
        }
        private void FillProductInGrid(List<ItemsEL> list, Int64? Id)
        {            
            bool IsItemFound = false;
            int ItemFoundIndex = 0;
            if (list.Count > 0)
            {
                //MessageBox.Show(cbxProducts.Text);
                //MessageBox.Show(cbxProducts.SelectedValue.ToString());   
                //First Check Item If Exists In Grid
                if (grdProducts.Rows.Count > 0)
                {
                    for (int i = 0; i < grdProducts.Rows.Count; i++)
                    {
                        if (Id == Validation.GetSafeLong(grdProducts.Rows[i].Cells["colIdItem"].Value))
                        {
                            IsItemFound = true;
                            ItemFoundIndex = i;
                            break;
                        }
                    }
                }
                if (IsItemFound)
                {
                    // Update Items Here...   
                    DataGridViewRow oFoundRow = grdProducts.Rows[ItemFoundIndex];
                    grdProducts.Rows[ItemFoundIndex].Cells["colQuantity"].Value = Validation.GetSafeDecimal(grdProducts.Rows[ItemFoundIndex].Cells["colQuantity"].Value) + 1;
                    SendKeys.Send("");
                }
                else
                {
                    // Add New Items Here If No Item Found
                    grdProducts.Rows.Add();
                    grdProducts.Rows[grdProducts.Rows.Count - 1].Cells["colIdItem"].Value = Id;
                    grdProducts.Rows[grdProducts.Rows.Count - 1].Cells["colBarCode"].Value = list[0].BarCode;
                    grdProducts.Rows[grdProducts.Rows.Count - 1].Cells["colItemName"].Value = list[0].ItemName;
                    grdProducts.Rows[grdProducts.Rows.Count - 1].Cells["colPackingSize"].Value = list[0].PackingSize;
                    grdProducts.Rows[grdProducts.Rows.Count - 1].Cells["colQuantity"].Value = 1;
                    SendKeys.Send("");
                }               
            }
        }
        #endregion
    }
}
