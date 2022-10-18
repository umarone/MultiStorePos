using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmStockReceipt : MetroForm
    {
        #region Variables
        frmAccounts frmaccounts;
        frmFindAccounts frmAccount;
        frmFindProducts frmfindProducts;
        frmFindVouchers frmfindVouchers;
        frmAuthentication frmauthentication;
        frmPersons frmpersons;
        frmPurchasePrintReport frmpurchaseprintreport;
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Int64? IdVoucher = null;
        public Int64? SupplierTransactionId { get; set; }
        public Int64? CashTransactionId { get; set; }
        public Int64? PurchasesTransactionId { get; set; }
        public string VoucherType { get; set; }
        string EventCommandName;
        int EventTime = 0;
        public bool IsNetTransaction { get; set; }
        public bool IsImportTransaction { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        string SupplierAccountNo = "", PurchasesAccountNo = "", CashAccountNo = "";
        #endregion
        #region Form Methods And Events
        public frmStockReceipt()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            txtBillNo.Text = "0";
            ShowHideColumns();
            AdjustControls();
            //FillData();
            FillNaturalAccounts(string.Empty);
            FillCashAccounts(string.Empty);
            CheckModulePermissions();
            FillTotalVouchers();
            GetLastVoucherTransactionByType();
            if (IsNetTransaction)
            {
                this.Text = "Net Inventory Purchases";
                btnViewDetail.Enabled = false;
                btnAddSupplier.Text = "Add Cash Account";
                grpCreditor.Text = "Cash Account Information";
            }
            else
            {
                this.Text = "Credit Inventory Purchases";
            }

        }
        private void frmStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (IdVoucher != null && IdVoucher > 0)
                {
                    //FillData();
                    ClearControls();
                    if (DgvStockReceipt.Rows.Count > 0)
                    {
                        DgvStockReceipt.Rows.Clear();
                    }
                }
                else
                this.Close();
            }
        }
        #endregion
        #region Simple Methods
        private void ShowHideColumns()
        {
            List<SoftwareTypesEL> list = DataOperations.SoftwareTypes;
            if (list.Count > 0)
            {
                SoftwareTypesEL objActiveType = list.Find(x => x.ActiveSoftware == true);
                if (objActiveType != null)
                {
                    if (objActiveType.SoftwareType == "General Trading")
                    {
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 280;
                        DgvStockReceipt.Columns["colpacking"].Width = 90;
                        DgvStockReceipt.Columns["colQty"].Width = 80;
                        DgvStockReceipt.Columns["colUnitPrice"].Width = 90;
                    }
                    else if (objActiveType.SoftwareType == "Medicine General Trading")
                    {
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 330;
                        DgvStockReceipt.Columns["colpacking"].Width = 90;
                        DgvStockReceipt.Columns["colQty"].Width = 80;
                        DgvStockReceipt.Columns["colUnitPrice"].Width = 90;
                    }
                    else if (objActiveType.SoftwareType == "POS")
                    {
                        DgvStockReceipt.Columns["colpacking"].Visible = false;
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colDelete"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 400;
                        DgvStockReceipt.Columns["colQty"].Width = 170;
                        DgvStockReceipt.Columns["colUnitPrice"].Width = 170;
                        DgvStockReceipt.Columns["colAmount"].Width = 170;
                    }
                    else if (objActiveType.SoftwareType == "Motor Bikes")
                    {
                        DgvStockReceipt.Columns["colpacking"].Visible = false;
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 250;
                    }
                    else if (objActiveType.SoftwareType == "Motor Cars")
                    {
                        DgvStockReceipt.Columns["colpacking"].Visible = false;
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 250;
                    }
                    else if (objActiveType.SoftwareType == "Medicine Trading")
                    {
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;


                        DgvStockReceipt.Columns["colItemName"].Width = 240;
                        DgvStockReceipt.Columns["colExpiry"].Width = 80;
                        DgvStockReceipt.Columns["colBatchNo"].Width = 80;
                        DgvStockReceipt.Columns["colDiscount"].Width = 90;
                        DgvStockReceipt.Columns["colDiscountAmount"].Width = 90;
                    }
                    else if (objActiveType.SoftwareType == "Medicine POS")
                    {
                        DgvStockReceipt.Columns["colpacking"].Visible = false;
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;
                    }
                    else if (objActiveType.SoftwareType == "Mobile Soft")
                    {
                        DgvStockReceipt.Columns["colpacking"].Visible = true;
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 280;
                    }
                    if (objActiveType.SoftwareType == "Distribution Trading")
                    {
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 280;
                        DgvStockReceipt.Columns["colpacking"].Width = 90;
                        DgvStockReceipt.Columns["colQty"].Width = 80;
                        DgvStockReceipt.Columns["colUnitPrice"].Width = 90;
                    }
                    else if (objActiveType.SoftwareType == "Labs Materials Trading")
                    {
                        DgvStockReceipt.Columns["colCartons"].Visible = false;
                        DgvStockReceipt.Columns["colEngineNo"].Visible = false;
                        DgvStockReceipt.Columns["colChassisNo"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleNo"].Visible = false;
                        DgvStockReceipt.Columns["colBatchNo"].Visible = false;
                        DgvStockReceipt.Columns["colExpiry"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleModel"].Visible = false;
                        DgvStockReceipt.Columns["colVehicleColors"].Visible = false;
                        DgvStockReceipt.Columns["colFirstIMEI"].Visible = false;
                        DgvStockReceipt.Columns["colSecondIMEI"].Visible = false;

                        DgvStockReceipt.Columns["colItemName"].Width = 380;
                        DgvStockReceipt.Columns["colpacking"].Width = 90;
                        DgvStockReceipt.Columns["colQty"].Width = 80;
                        DgvStockReceipt.Columns["colUnitPrice"].Width = 90;
                    }
                }
            }
        }
        private void AdjustControls()
        {
            if (IsNetTransaction)
            {
                grpCreditor.Visible = false;
                grpSupplier.Visible = true;
            }
            else
            {
                pnlCash.Visible = false;
                grpSupplier.Visible = false;
            }
        }
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvPurchases.GetCellDisplayRectangle(5, -1, true).X;

            txtDebit.Width = DgvPurchases.Columns[5].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvPurchases.Height - txtDebit.Height);

            DgvPurchases.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvPurchases.GetCellDisplayRectangle(6, -1, true).X;
            txtCredit.Width = DgvPurchases.Columns[6].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvPurchases.Height - txtCredit.Height);

            DgvPurchases.Controls.Add(txtCredit);

            txtCredit.BringToFront();
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (PermissionsList[0].Posting == true)
                {
                    btnSave.Enabled = true;
                    chkPosted.Checked = true;
                    chkPosted.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = false;
                    chkPosted.Checked = false;
                    chkPosted.Enabled = true;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}

        }
        private void FillCreditor(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.GetPersonByAccount(Operations.IdProject, AccountNo);
            if (list.Count > 0)
            {
                txtContact.Text = list[0].Contact;
                txtCurrentBalance.Text = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, AccountNo)[0].TypedClosingBalance;
            }
        }
        private void FillData()
        {
            var manager = new PurchaseHeadBLL();
            VEditBox.Text = manager.GetMaxPurchaseNumber(Operations.IdProject, Operations.BookNo).ToString();
        }
        private void FillTotalVouchers()
        {
            var Manager = new VoucherBLL();
            lblTotalVouchers.Text = Manager.GetAllStockTotalTransactionalVouchersByType(Operations.IdProject, Operations.BookNo, VoucherTypes.StockReceiptVoucher.ToString(), IsNetTransaction).ToString();
        }
        private void GetLastVoucherTransactionByType()
        {
            var Manager = new VoucherBLL();
            List<VouchersEL> listLast = Manager.GetStockLastVoucherTransactionByType(Operations.IdProject, Operations.BookNo, VoucherTypes.StockReceiptVoucher.ToString(), IsNetTransaction);
            if (listLast != null && listLast.Count > 0)
            {
                lblLastVoucherNo.Text = listLast[0].VoucherNo.ToString();
            }
        }
        private void FillNaturalAccounts(string AccountNo)
        {
            var manager = new AccountsBLL();
            #region Fill Inventory Account
            List<AccountsEL> list = manager.GetAccountsByType("Inventory Accounts", Operations.IdCompany, Operations.IdProject);
            if (AccountNo == "")
            {
                if (list.Count > 0)
                {
                    cbxNaturalAccounts.DataSource = list;
                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "" });

                    cbxNaturalAccounts.DisplayMember = "AccountName";
                    cbxNaturalAccounts.ValueMember = "AccountNo";

                    cbxNaturalAccounts.SelectedIndex = 1;
                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = AccountNo;
            }
            #endregion
        }
        private void FillCashAccounts(string AccountNo)
        {
            #region Fill Cash Accounts
            if (IsNetTransaction)
            {
                var manager = new AccountsBLL();
                List<AccountsEL> listCash = manager.GetAccountsByType("Cash Accounts", Operations.IdCompany, Operations.IdProject);
                if (AccountNo == "")
                {
                    if (listCash.Count > 0)
                    {
                        cbxCashAccounts.DataSource = listCash;
                        listCash.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "" });

                        cbxCashAccounts.DisplayMember = "AccountName";
                        cbxCashAccounts.ValueMember = "AccountNo";

                        cbxCashAccounts.SelectedIndex = 1;
                    }
                }
                else
                {
                    cbxCashAccounts.SelectedValue = AccountNo;
                }
            }
            #endregion
        }
        private void ClearControls()
        {
            VDate.Value = DateTime.Now;
            DgvStockReceipt.Rows.Clear();
            DgvPurchases.Rows.Clear();
            //txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdVoucher = 0;
            VEditBox.Text = string.Empty;
            VEditBox.Enabled = true;
            txtSheetNo.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCashClosingBalance.Text = string.Empty;
            txtBillAmount.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            
            SupplierTransactionId = null;
            PurchasesTransactionId = null;
            CashTransactionId = null;

            SEditBox.Text = string.Empty;
            txtBillNo.Text = "0";
            lblStatuMessage.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }

            CashAccountNo = string.Empty;
            PurchasesAccountNo = string.Empty;
            SupplierAccountNo = string.Empty;


            txtSupplierName.Text = string.Empty;
            txtSupplierContact.Text = string.Empty;
            txtSupplerCNIC.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtBiltyNo.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtCurrentBalance.Text = string.Empty;
            txtBillNo.Text = string.Empty;

            cbxNaturalAccounts.SelectedIndex = -1;
            cbxCashAccounts.SelectedIndex = -1;

        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }
                else if (DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (!IsNetTransaction)
            {
                if (SupplierAccountNo == string.Empty)
                {
                    MessageBox.Show("Credit Account Missing...");
                    return false;
                }
                else if (PurchasesAccountNo == string.Empty)
                {
                    MessageBox.Show("Purchase Account Missing, Please Select...");
                    return false;
                }
            }
            else if (IsNetTransaction)
            {
                if (CashAccountNo == string.Empty)
                {
                    MessageBox.Show("Credit Account Missing...");
                    return false;
                }
                else if (PurchasesAccountNo == string.Empty)
                {
                    MessageBox.Show("Purchase Account Missing, Please Select...");
                    return false;
                }
            }

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
                    if (VDate.Value.Year == FirstYear || VDate.Value.Year == SecondYear)
                    {
                        if (VDate.Value.Month < FirstMonth && VDate.Value.Year == FirstYear)
                        {
                            Status = false;
                        }
                        else if (VDate.Value.Month > SecondMonth && VDate.Value.Year == SecondYear)
                        {
                            Status = false;
                        }
                        else
                        {
                            Status = true;
                        }
                    }
                    else
                    {
                        Status = false;
                    }
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
        private string BuildRemarks()
        {
            string Remarks = "";
            string First = txtDescription.Text == string.Empty ? "Follow Are Purchases From "+SEditBox.Text+"~" : txtDescription.Text + "~";
            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                Remarks += DgvStockReceipt.Rows[i].Cells[3].Value.ToString() + " - "
                           + DgvStockReceipt.Rows[i].Cells[15].Value.ToString() + "Units"
                           + "@" + DgvStockReceipt.Rows[i].Cells[20].Value.ToString() + "~";
            }
            First += Remarks;
            return First;
        }
        #endregion
        #region Buttons Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            List<ItemsEL> oelItemsCollection = new List<ItemsEL>();
            #endregion
            #region Main Content
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    if (ValidateBookPeriod())
                    {
                        /// Add Voucher...
                        #region VoucherHead
                        VouchersEL oelVoucher = new VouchersEL();
                        if (!IdVoucher.HasValue)
                        {
                            oelVoucher.IdVoucher = 0;
                        }
                        else
                        {
                            oelVoucher.IdVoucher = IdVoucher;
                        }
                        oelVoucher.IdUser = Operations.UserID;
                        oelVoucher.IdProject = Operations.IdProject;
                        oelVoucher.SheetNo = Validation.GetSafeLong(txtSheetNo.Text);
                        oelVoucher.BookNo = Operations.BookNo;
                        oelVoucher.TerminalNumber = Validation.GetSafeInteger(XmlConfiguration.ReadXmlTerminalsConfiguration()[0]);
                        oelVoucher.BiltyNo = Validation.GetSafeString(txtBiltyNo.Text);
                        oelVoucher.FirstName = Validation.GetSafeString(txtSupplierName.Text);
                        oelVoucher.Contact = Validation.GetSafeString(txtSupplierContact.Text);
                        oelVoucher.Cnic = Validation.GetSafeString(txtSupplerCNIC.Text);
                        oelVoucher.Address = Validation.GetSafeString(txtSupplierAddress.Text);
                        oelVoucher.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        if (!IsNetTransaction)
                        {
                            oelVoucher.AccountNo = SupplierAccountNo;
                        }
                        else
                        {
                            oelVoucher.AccountNo = CashAccountNo;
                        }
                        oelVoucher.SubAccountNo = "0";
                        oelVoucher.BillNo = txtBillNo.Text;
                        oelVoucher.VDate = VDate.Value;
                        oelVoucher.Discription = Validation.GetSafeString(txtDescription.Text);
                        oelVoucher.BillAmount = Validation.GetSafeDecimal(txtBillAmount.Text);
                        oelVoucher.TotalFreight = Validation.GetSafeDecimal(txtFreightAmount.Text);
                        oelVoucher.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                        oelVoucher.VAT = 0;//Validation.GetSafeInteger(txtVat.Text);
                        oelVoucher.VATAmount = 0;//Validation.GetSafeDecimal(txtTotalAmount.Text);
                        oelVoucher.IsNetTransaction = IsNetTransaction;
                        oelVoucher.IsImportTransaction = IsImportTransaction;
                        oelVoucher.Posted = chkPosted.Checked;
                        #endregion
                        #region Add Stock
                        for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (DgvStockReceipt.Rows[i].Cells["ColIdVoucherDetail"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelPurchaseDetial.IdVoucherDetail = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["ColIdVoucherDetail"].Value.ToString());
                                oelPurchaseDetial.IsNew = false;
                            }
                            else
                            {
                                oelPurchaseDetial.IdVoucherDetail = 0;
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelPurchaseDetial.IsNew = true;
                            }
                            oelPurchaseDetial.SeqNo = i + 1;
                            oelPurchaseDetial.IdVoucher = oelVoucher.IdVoucher;
                            oelPurchaseDetial.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelPurchaseDetial.IdItem = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                            oelItem.IdItem = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                            oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                            oelPurchaseDetial.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                            oelPurchaseDetial.TotalCartons = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colCartons"].Value);
                            oelPurchaseDetial.BatchNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colBatchNo"].Value);
                            oelPurchaseDetial.Expiry = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colExpiry"].Value);
                            oelPurchaseDetial.EngineNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colEngineNo"].Value);
                            oelPurchaseDetial.ChasisNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colChassisNo"].Value);
                            oelPurchaseDetial.VehicleModel = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleModel"].Value);
                            oelPurchaseDetial.VehicleNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleNo"].Value);
                            oelPurchaseDetial.FirstIMEI = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colFirstIMEI"].Value);
                            oelPurchaseDetial.SecondIMEI = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colSecondIMEI"].Value);
                            if (DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value != null && Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value) != string.Empty)
                            {
                                if (Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value) == "Red")
                                {
                                    oelPurchaseDetial.ColorCode = 1;
                                }
                                else if (Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value) == "Black")
                                {
                                    oelPurchaseDetial.ColorCode = 2;
                                }
                                else if (Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value) == "Blue")
                                {
                                    oelPurchaseDetial.ColorCode = 3;
                                }
                                else if (Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colVehicleColors"].Value) == "Silver")
                                {
                                    oelPurchaseDetial.ColorCode = 4;
                                }
                            }

                            oelPurchaseDetial.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                            oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                            oelPurchaseDetial.RemainingUnits = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                            oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                            oelItem.CurrentUnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                            //oelPurchaseDetial.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                            oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                            oelPurchaseDetial.Discount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscount"].Value.ToString().Replace('%', ' '));
                            oelPurchaseDetial.DiscountAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);

                            oelItemsCollection.Add(oelItem);
                            oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                        }
                        #endregion
                        #region Add Supplier
                        if (!IsNetTransaction)
                        {
                            VoucherDetailEL oelSupplierTransaction = new VoucherDetailEL();
                            SoftwareChecksEL oelSoftwareCheck = DataOperations.SoftwareChecks.ToList().Find(x => x.SoftwareCheckName == "ItemWiseLederPrint");
                            if (SupplierTransactionId.HasValue && SupplierTransactionId.Value > 0)
                            {
                                oelSupplierTransaction.IdTransactionDetail = SupplierTransactionId.Value;
                                oelSupplierTransaction.IsNew = false;
                            }
                            else
                            {
                                oelSupplierTransaction.IdTransactionDetail = 0;
                                oelSupplierTransaction.IsNew = true;
                            }
                            oelSupplierTransaction.IsNetTransaction = IsNetTransaction;
                            oelSupplierTransaction.SeqNo = 1;
                            oelSupplierTransaction.TrackNumber = 1;
                            oelSupplierTransaction.IdProject = Operations.IdProject;
                            oelSupplierTransaction.BookNo = Operations.BookNo;
                            oelSupplierTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
                            oelSupplierTransaction.AccountNo = SupplierAccountNo;
                            oelSupplierTransaction.SubAccountNo = "0";
                            oelSupplierTransaction.Date = VDate.Value;
                            oelSupplierTransaction.VoucherType = "P";
                            oelSupplierTransaction.TransactionType = 1;
                            oelSupplierTransaction.TransactionMode = "CR";
                            if (oelSoftwareCheck != null && oelSoftwareCheck.IsMust.Value)
                            {
                                oelSupplierTransaction.Description = BuildRemarks(); //txtDescription.Text;
                            }
                            else
                            {
                                oelSupplierTransaction.Description = "Purchases From : " + SEditBox.Text;
                            }
                            oelSupplierTransaction.Credit = Validation.GetSafeDecimal(txtTotalAmount.Text);

                            oelSupplierTransaction.Debit = 0;
                            oelSupplierTransaction.Posted = chkPosted.Checked;
                            oelSupplierTransaction.CreatedDateTime = VDate.Value;

                            oelCostOfSalesCollection.Add(oelSupplierTransaction);
                        }
                        #endregion
                        #region Add Cash
                        if (IsNetTransaction)
                        {
                            VoucherDetailEL oelCashTransaction = new VoucherDetailEL();
                            if (CashTransactionId.HasValue && CashTransactionId.Value > 0)
                            {
                                oelCashTransaction.IdTransactionDetail = CashTransactionId.Value;
                                oelCashTransaction.IsNew = false;
                            }
                            else
                            {
                                oelCashTransaction.IdTransactionDetail = 0;
                                oelCashTransaction.IsNew = true;
                            }
                            oelCashTransaction.IsNetTransaction = IsNetTransaction;
                            oelCashTransaction.SeqNo = 1;
                            oelCashTransaction.TrackNumber = 1;
                            oelCashTransaction.IdProject = Operations.IdProject;
                            oelCashTransaction.BookNo = Operations.BookNo;
                            oelCashTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCashTransaction.IdVoucher = oelVoucher.IdVoucher;
                            oelCashTransaction.AccountNo = CashAccountNo;
                            oelCashTransaction.SubAccountNo = "0";
                            oelCashTransaction.Date = VDate.Value;;
                            oelCashTransaction.VoucherType = "P";
                            oelCashTransaction.TransactionType = 1;
                            oelCashTransaction.TransactionMode = "CR";
                            if (txtDescription.Text == string.Empty)
                            {
                                oelCashTransaction.Description = "Cash Purchases From : " + SEditBox.Text;
                            }
                            else
                                oelCashTransaction.Description = txtDescription.Text;

                            oelCashTransaction.Credit = Convert.ToDecimal(txtTotalAmount.Text);

                            oelCashTransaction.Debit = 0;
                            oelCashTransaction.Posted = chkPosted.Checked;
                            oelCashTransaction.CreatedDateTime = VDate.Value;

                            oelCostOfSalesCollection.Add(oelCashTransaction);
                        }
                        #endregion
                        #region Add Purchase Account In Transactions
                        /// Add Purchase Account...
                        VoucherDetailEL oelPurchaseTransaction = new TransactionsEL();
                        if (PurchasesTransactionId.HasValue && PurchasesTransactionId.Value > 0)
                        {
                            oelPurchaseTransaction.IdTransactionDetail = PurchasesTransactionId.Value;
                            oelPurchaseTransaction.IsNew = false;
                        }
                        else
                        {
                            oelPurchaseTransaction.IdTransactionDetail = 0;
                            oelPurchaseTransaction.IsNew = true;
                        }
                        oelPurchaseTransaction.IsNetTransaction = IsNetTransaction;
                        oelPurchaseTransaction.SeqNo = 2;
                        oelPurchaseTransaction.TrackNumber = 2;
                        oelPurchaseTransaction.IdProject = Operations.IdProject;
                        oelPurchaseTransaction.BookNo = Operations.BookNo;
                        oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
                        //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                        oelPurchaseTransaction.AccountNo = PurchasesAccountNo;
                        oelPurchaseTransaction.SubAccountNo = "0";
                        oelPurchaseTransaction.Date = VDate.Value;
                        oelPurchaseTransaction.VoucherType = "P";
                        oelPurchaseTransaction.TransactionType = 2;
                        oelPurchaseTransaction.Description = txtDescription.Text;
                        oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                        oelPurchaseTransaction.Credit = 0;
                        oelPurchaseTransaction.TransactionMode = "DR";
                        oelPurchaseTransaction.CreatedDateTime = VDate.Value;
                        oelPurchaseTransaction.Posted = chkPosted.Checked;

                        oelCostOfSalesCollection.Add(oelPurchaseTransaction);
                        #endregion region
                        #region Add Cost of Sales Transactions
                        for (int j = 0; j < DgvPurchases.Rows.Count - 1; j++)
                        {
                            VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                            oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                            oelVoucherDetail.IdProject = Operations.IdProject;
                            oelVoucherDetail.BookNo = Operations.BookNo;
                            oelVoucherDetail.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            if (DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value != null)
                            {
                                oelVoucherDetail.IdTransactionDetail = Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value.ToString());
                                oelVoucherDetail.IsNew = false;
                            }
                            else
                            {
                                oelVoucherDetail.IdTransactionDetail = 0;
                                oelVoucherDetail.IsNew = true;

                            }
                            if (DgvPurchases.Rows[j].Cells["colDescription"].Value == null)
                            {
                                oelVoucherDetail.Description = "N/A";
                            }
                            else
                            {
                                oelVoucherDetail.Description = DgvPurchases.Rows[j].Cells["colDescription"].Value.ToString();
                            }
                            oelVoucherDetail.IsNetTransaction = IsNetTransaction;
                            oelVoucherDetail.SeqNo = j + 3;
                            oelVoucherDetail.TrackNumber = j + 3;
                            oelVoucherDetail.VoucherType = "P";
                            oelVoucherDetail.IdAccount = Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["colIdAccount"].Value);
                            oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colAccountNo"].Value);
                            oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colDebit"].Value);
                            if (oelVoucherDetail.Debit > 0)
                            {
                                oelVoucherDetail.TransactionMode = "DR";
                            }
                            else
                            {
                                oelVoucherDetail.TransactionMode = "CR";
                            }
                            oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colCredit"].Value);
                            oelVoucherDetail.CreatedDateTime = VDate.Value;
                            oelCostOfSalesCollection.Add(oelVoucherDetail);

                        }
                        #endregion
                        #region Saving Code
                        if (IsNetTransaction)
                        {
                            SoftwareChecksEL PCheck = DataOperations.SoftwareChecks.Find(x => x.SoftwareCheckName == "NetPurchasesCheck");
                            if (PCheck != null && PCheck.IsMust.Value)
                            {
                                if (CashAccountNo == string.Empty)
                                {
                                    MessageBox.Show("Please Select Cash Account For Net Purchasing....");
                                    return;
                                }
                                List<TransactionsEL> EndingBalanceList = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, CashAccountNo);
                                if (EndingBalanceList.Count > 0)
                                {
                                    if (EndingBalanceList[0].ClosingBalance > 0 && EndingBalanceList[0].BalanceType == "DR")
                                    {
                                        if (EndingBalanceList[0].ClosingBalance > Validation.GetSafeDecimal(txtTotalAmount.Text))
                                        {
                                            // Let It Go
                                        }
                                        else
                                        {
                                            MessageBox.Show("You Do Not Have Enough Balance for Net Purchasing...");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        // Stop It Here....
                                        MessageBox.Show("You Do Not Have Enough Balance for Net Purchasing...");
                                        return;
                                    }
                                }
                            }
                        }
                        if (IdVoucher == null || IdVoucher == 0)
                        {
                            var manager = new PurchaseHeadBLL();

                            EntityoperationInfo infoResult = manager.InsertPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                            if (infoResult.IsSuccess)
                            {
                                VEditBox.Text = infoResult.VoucherNo.ToString();
                                IdVoucher = infoResult.IntID;
                                FillVoucher();
                                MessageBox.Show("Transaction Successfully Done...");
                                //ClearControls();
                                //FillData();
                            }
                        }
                        else
                        {
                            var manager = new PurchaseHeadBLL();
                            var VManager = new VoucherBLL();
                            var ItemManager = new ItemsBLL();
                            EntityoperationInfo infoResult = manager.UpdatePurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                            if (infoResult.IsSuccess)
                            {
                                MessageBox.Show("Transaction Successfully Done...");
                                ClearControls();
                                //FillData();
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Voucher In This Book Period :" + Operations.BookPeriod);
                    }
                }
                else
                {
                    lblStatuMessage.Text = "Check Values";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
            #endregion
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelItemTransactionCollection = new List<TransactionsEL>();
            var manager = new PurchaseHeadBLL();

            if (IdVoucher > 0)
            {
                if (chkPosted.Checked)
                {
                    if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    {
                        frmauthentication = new frmAuthentication();
                        frmauthentication.ShowDialog();
                        if (Operations.IsAuthenticate && Operations.IdAuthenticationRole == Validation.GetSafeLong(EnRoles.Administrator) || Operations.IdAuthenticationRole == Validation.GetSafeLong(EnRoles.CheifExecutive))
                        {
                            if (manager.DeletePurchasesByVoucher(IdVoucher.Value, Operations.IdProject))
                            {
                                MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                                Operations.IsAuthenticate = false;
                                ClearControls();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You Need Admin OR CEO Login To Delete It...");
                        }
                    }
                    else if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeletePurchasesByVoucher(IdVoucher.Value, Operations.IdProject))
                        {
                            MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                            ClearControls();
                        }
                    }
                }
                //PurchaseStockReceiptBLL();
                else if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (manager.DeletePurchasesByVoucher(IdVoucher.Value, Operations.IdProject))
                    {
                        MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                        ClearControls();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Voucher To Delete...");
            }

        }
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (SupplierAccountNo != string.Empty)
            {
                frmpersons = new frmPersons();
                frmpersons.AccountNo = SupplierAccountNo;
                frmpersons.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Supplier To View Detail....");
            }
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmaccounts = new frmAccounts();
            frmaccounts.Show();
        }
        private void btnAddPurchasesAccount_Click(object sender, EventArgs e)
        {
            frmaccounts = new frmAccounts();
            frmaccounts.Show();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillNaturalAccounts(string.Empty);
        }
        private void btnAddCashAccount_Click(object sender, EventArgs e)
        {
            frmaccounts = new frmAccounts();
            frmaccounts.Show();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            //FillData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (VEditBox.Text != string.Empty)
            {
                long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
                NextVoucherNo += 1;
                FillPurchasesByNumber(NextVoucherNo);                
            }
            else
            {
                MessageBox.Show("Please Load Any Purchase First To Move Forward");
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (VEditBox.Text != string.Empty)
            {
                long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
                PreviousVoucherNo -= 1;
                FillPurchasesByNumber(PreviousVoucherNo);
            }
            else
            {
                MessageBox.Show("Please Load Any Purchase First To Move Back");
            }
        }
        private void btnPrintPurchaseInvoice_Click(object sender, EventArgs e)
        {
            frmpurchaseprintreport = new frmPurchasePrintReport();
            frmpurchaseprintreport.IsNetTransaction = IsNetTransaction;
            frmpurchaseprintreport.IdVoucher = IdVoucher.Value;
            frmpurchaseprintreport.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region DropDown Events
        private void cbxCashAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCashAccounts.SelectedIndex > 0)
            {
                CashAccountNo = Validation.GetSafeString(cbxCashAccounts.SelectedValue);
                List<TransactionsEL> EndingBalanceList = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, CashAccountNo);
                if (EndingBalanceList.Count > 0)
                {
                    txtCashClosingBalance.Text = EndingBalanceList[0].ClosingBalance + " " + EndingBalanceList[0].BalanceType;
                }
                else
                {
                    txtCashClosingBalance.Text = string.Empty;
                }
            }
            else
            {
                CashAccountNo = string.Empty;
            }
        }
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                PurchasesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
            else
            {
                PurchasesAccountNo = string.Empty;
            }
        }
        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtBillNo.Focus();
                DgvStockReceipt.Focus();
            }
        }
        #endregion
        #region Other Controls Methods And Events
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = VoucherTypes.StockReceiptVoucher.ToString();
            frmfindVouchers.IsNetTransaction = IsNetTransaction;
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillPurchasesByNumber(Validation.GetSafeLong(VEditBox.Text));
                }
            }
            else
                e.Handled = true;
        }
        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "SEditBox")
                    {
                        if (SEditBox.Text == string.Empty)
                        {
                            return;
                        }
                        DgvStockReceipt.Focus();
                        //cbxNaturalAccounts.Focus();
                        //cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (EventTime == 0)
                    {
                        EventCommandName = "Persons";
                        e.Handled = true;
                        frmAccount = new frmFindAccounts();
                        frmAccount.SearchText = e.KeyChar.ToString();
                        frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                        frmAccount.ShowDialog();
                    }
                }
                else
                    e.Handled = false;
            }
        }
        private void SEditBox_TextChanged(object sender, EventArgs e)
        {
            //if (EventTime == 0)
            //{

            //    frmAccount = new frmFindAccounts();
            //    frmAccount.SearchText = SEditBox.Text;
            //    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            //    frmAccount.ShowDialog();
            //}
        }
        private void txtFreigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
            else if(e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus(); 
            }
            //{
            //    if (e.KeyChar == (char)Keys.Enter)
            //    {
            //        decimal ActualAmount = Validation.GetSafeDecimal(txtBillAmount.Text);
            //        decimal Resultant = ActualAmount + Validation.GetSafeDecimal(txtFreightAmount.Text);
            //        txtTotalAmount.Text = Resultant.ToString();
            //    }
            //    else
            //        e.Handled = true;
            //}
            //else
            //    e.Handled = true;
        }
        private void txtFreightAmount_Leave(object sender, EventArgs e)
        {
            if (txtFreightAmount.Text != string.Empty)
            {
                decimal ActualAmount = Validation.GetSafeDecimal(txtBillAmount.Text);
                decimal Resultant = ActualAmount + Validation.GetSafeDecimal(txtFreightAmount.Text);
                txtTotalAmount.Text = Resultant.ToString();
            }
        }
        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SEditBox.Focus();
            }
        }
        #endregion
        #region Custom Controls Methods And Events
        private void PurchasesEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {         
            List<TransactionsEL> list = new List<TransactionsEL>();
            if (EventCommandName == "Persons")
            {
                SEditBox.Text = oelAccount.AccountName;
                SupplierAccountNo = oelAccount.AccountNo;
                FillCreditor(oelAccount.AccountNo);
                list = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    txtCurrentBalance.Text = list[0].TypedClosingBalance;
                }
            }
            else if (EventCommandName == "DgvPurchases")
            {
                DgvPurchases.RefreshEdit();   
                DgvPurchases.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvPurchases.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvPurchases.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                list = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    DgvPurchases.CurrentRow.Cells["colClosingBalance"].Value = list[0].ClosingBalance;
                }
                else 
                {
                    DgvPurchases.CurrentRow.Cells["colClosingBalance"].Value = 0;
                }
            }
            else
            {
                PurchasesAccountNo = oelAccount.AccountNo.ToString();
            }
        }
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
        }
        void frmfindProducts_ExecuteFindPorudctsEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockReceipt.RefreshEdit();
            var manager = new ItemsBLL();
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                //{
                //    if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value))
                //        {
                //            lblStatuMessage.Text = "Product Already exists";
                //            return;
                //        }
                //    }
                //}
                lblStatuMessage.Text = "";
                DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                DgvStockReceipt.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                //DgvStockReceipt.CurrentRow.Cells["ColBatch"].Value = oelItems.BatchNo;
            }
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher();

        }
        #endregion
        #region Tabs Related Events And Methods
        private void tabPurchaseTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPurchaseTransactions.SelectedIndex == 1)
                CreateAndInitializeFooterRow();
        }
        #endregion
        #region Stock Grid Events
        private void DgvStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.F2)
            //{
            //    if (DgvStockReceipt.CurrentCellAddress.X == 2)
            //    {
            //        checkSender = true;
            //        frmstockAccounts = new frmStockAccounts();
            //        frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            //        frmstockAccounts.ShowDialog(this);
            //    }
            //}
        }
        private void DgvStockReceipt_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindProducts = new frmFindProducts();
                    frmfindProducts.ExecuteFindPorudctsEvent += new frmFindProducts.FindProductsDelegate(frmfindProducts_ExecuteFindPorudctsEvent);
                    frmfindProducts.SearchText = e.KeyChar.ToString();
                    frmfindProducts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        private void DgvStockReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DgvStockReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 21)
            {
                e.Value = "Delete";
            }
        }
        private void DgvStockReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal lineAmount, value = 0;
            if (e.ColumnIndex == 21)
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["ColIdVoucherDetail"].Value == null)
                {
                    if (DgvStockReceipt.Rows.Count > 1)
                    {
                        DataGridViewRow oRow = DgvStockReceipt.Rows[e.RowIndex];
                        DgvStockReceipt.Rows.Remove(oRow);
                    }
                    DataGridViewCell oCell = DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"];
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        value += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                    }
                    //lineAmount = Validation.GetSafeDecimal(oCell.GetEditedFormattedValue(e.RowIndex, DataGridViewDataErrorContexts.Commit));
                    //txtCreditBalance.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) - lineAmount).ToString();
                    txtBillAmount.Text = value.ToString();
                    txtTotalAmount.Text = Validation.GetSafeString(Validation.GetSafeDecimal(txtBillAmount.Text) + Validation.GetSafeDecimal(txtFreightAmount.Text));
                    if (DgvStockReceipt.Rows.Count - 1 == 0)
                    {
                        txtBillAmount.Text = string.Empty;
                        txtFreightAmount.Text = string.Empty;
                        txtTotalAmount.Text = string.Empty;
                    }
                }
                else
                {
                    if (!chkPosted.Checked)
                    {
                        if (DgvStockReceipt.Rows.Count - 1 == 1)
                        {
                            MessageBox.Show("There Is Only One Record In This Voucher , Please Press Delete Button To Remove This Voucher");
                            return;
                        }
                        var Manager = new VoucherBLL();
                        lineAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value);
                        txtBillAmount.Text = (Validation.GetSafeDecimal(txtBillAmount.Text) - lineAmount).ToString();
                        txtTotalAmount.Text = Validation.GetSafeString(Validation.GetSafeDecimal(txtBillAmount.Text) + Validation.GetSafeDecimal(txtFreightAmount.Text));

                        if (Manager.DeleteChildRecords(Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["ColIdVoucherDetail"].Value), "StockReceiptVoucher"))
                        {
                            DataGridViewRow oRow = DgvStockReceipt.Rows[e.RowIndex];
                            DgvStockReceipt.Rows.Remove(oRow);
                            btnSave_Click(sender, e);
                            MessageBox.Show("This Voucher and Party Ledger Updated Automatically...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Voucher Is Posted...");
                    }

                }
            }
        }
        private void DgvStockReceipt_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvStockReceipt.IsCurrentCellDirty)
            {
                DgvStockReceipt.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DgvStockReceipt_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    OldValue = Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
            //}
        }
        private void DgvStockReceipt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var manager = new ItemsBLL();
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colQty")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value != null)
                {
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value == null)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value = manager.GetItemById(Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].CurrentUnitPrice;
                    }
                    if (Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) > 0)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                    }
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        if (Validation.GetSafeLong(CellValue) > 0)
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                          * Validation.GetSafeDecimal(CellValue)));

                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);

                        }
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        OldValue += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                    }
                    txtBillAmount.Text = OldValue.ToString();
                    txtTotalAmount.Text = Validation.GetSafeString(OldValue + Validation.GetSafeDecimal(txtFreightAmount.Text));
                    OldValue = 0;
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value != null)
                {
                   DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        if (Validation.GetSafeLong(CellValue) > 0)
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                          * Validation.GetSafeDecimal(CellValue)));

                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);

                        }
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                }
                txtBillAmount.Text = OldValue.ToString();
                txtTotalAmount.Text = Validation.GetSafeString(OldValue + Validation.GetSafeDecimal(txtFreightAmount.Text));
                OldValue = 0;
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDiscount")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null)
                {
                    string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeLong(CellValue) > 0)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue)));

                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                }
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                }
                txtBillAmount.Text = OldValue.ToString();
                txtTotalAmount.Text = Validation.GetSafeString(OldValue + Validation.GetSafeDecimal(txtFreightAmount.Text));
                OldValue = 0;
            }
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDisc")
            //{
            //    if (Validation.GetSafeInteger(DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != 0)
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
            //    }
            //    else
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value = "";
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colExpiry")
            //{
            //    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value != null)
            //    {
            //        bool Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Contains('/');
            //        if (Value == false)
            //        {
            //            MessageBox.Show("Wrong Expiry Date");
            //            DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //        }
            //        else
            //        {
            //            string[] splitString = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Split('/');
            //            if (splitString.Length == 3)
            //            {
            //                MessageBox.Show("Wrong Expiry Date");
            //                DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //            }
            //            else if (splitString.Length == 2)
            //            {
            //                int Year = Validation.GetSafeInteger(splitString[1]);
            //                int Month = Validation.GetSafeInteger(splitString[0]);
            //                int compareyear = Validation.GetSafeInteger(DateTime.Now.Year.ToString().Substring(2));
            //                int CurrentMonth = Validation.GetSafeInteger(DateTime.Now.Month.ToString());
            //                if (Year == compareyear)
            //                {
            //                    if (Month < CurrentMonth)
            //                    {
            //                        MessageBox.Show("Wrong Expiry Date.. Expiry Month is smaller then current Month");
            //                        DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                    }
            //                }
            //                else if (Year < compareyear)
            //                {
            //                    MessageBox.Show("Wrong Expiry Date.. Expiry Year is smaller then current year");
            //                    DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
            //                }
            //            }
            //        }
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    decimal value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            OldValue = 0;
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value != null)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        if (Validation.GetSafeLong(CellValue) > 0)
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                          * Validation.GetSafeDecimal(CellValue)));

                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);

                        }
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                {

                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDiscount")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                {
                    //DgvStockSales.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = (Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                    //                                                                   * Validation.GetSafeDecimal(DgvStockSales.Rows[e.RowIndex].Cells["colDiscount"]);
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Contains('%'))
                    {

                    }
                    else
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value) + "%";
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = "0" + "%";
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                }
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                }
                txtTotalAmount.Text = Validation.GetSafeString(OldValue + Validation.GetSafeDecimal(txtFreightAmount.Text));
                OldValue = 0;
            }
        }
        private void DgvStockReceipt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockReceipt.Columns["colVehicleColors"].Visible)
            {
                if (e.ColumnIndex == 11)
                {
                    SendKeys.Send("{F4}");
                }
            }
        }
        private void DgvStockReceipt_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DgvStockReceipt.EndEdit();
            //if (!DgvStockReceipt.IsCurrentRowDirty)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        //private void DgvStockReceipt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        ////    if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        ////    {
        ////        if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == string.Empty)
        ////        {
        ////            e.Cancel = true;
        ////        }
        ////        else
        ////        {
        ////            e.Cancel = false;
        ////        }
        ////    }
        //}
        #endregion
        #region Purchases Grid Code and Events
        private void DgvPurchases_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvPurchases_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
        private void DgvPurchases_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPurchases.CurrentCellAddress.X == 3)
            {
                TextBox txtAccountName = e.Control as TextBox;
                if (txtAccountName != null)
                {
                    txtAccountName.KeyPress -= new KeyPressEventHandler(txtAccountName_KeyPress);
                    txtAccountName.KeyPress += new KeyPressEventHandler(txtAccountName_KeyPress);
                }
            }
        }
        void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvPurchases.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    EventCommandName = "DgvPurchases";
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Grids Transactions Related Methods
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var PManager = new PurchaseHeadBLL();
            VoucherType = "P";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
            List<VoucherDetailEL> ListPurchases = PManager.GetPurchasesTransactions(IdVoucher.Value, Operations.IdProject, Operations.BookNo, IsNetTransaction);
            if (ListPurchases.Count > 0)
            {
                IdVoucher = ListPurchases[0].IdVoucher;
                VEditBox.Enabled = false;
                txtSheetNo.Text = ListPurchases[0].SheetNo.ToString();
                txtBiltyNo.Text = ListPurchases[0].BiltyNo;
                txtBillNo.Text = ListPurchases[0].BillNo;
                VDate.Value = ListPurchases[0].VDate.Value;
                txtDescription.Text = ListPurchases[0].VDiscription;
                txtBillAmount.Text = ListPurchases[0].BillAmount.ToString();
                txtFreightAmount.Text = ListPurchases[0].TotalFreight.ToString();
                txtTotalAmount.Text = ListPurchases[0].TotalAmount.ToString();
                if (!IsNetTransaction)
                {
                    FillCreditor(ListPurchases[0].AccountNo);
                }
                else
                {
                    txtSupplierName.Text = ListPurchases[0].FirstName;
                    txtSupplierContact.Text = ListPurchases[0].Contact;
                    txtSupplerCNIC.Text = ListPurchases[0].Cnic;
                    txtSupplierAddress.Text = ListPurchases[0].Address;
                }
                chkPosted.Checked = ListPurchases[0].Posted.Value;
                if (ListPurchases[0].Posted.Value)
                {
                    //if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    //{
                    //    btnSave.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    chkPosted.Enabled = false;
                    //}
                    chkPosted.Enabled = false;
                    lblStatuMessage.Text = "Posted Voucher ...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
                else
                {
                    chkPosted.Enabled = true;
                    //btnSave.Enabled = true;
                    //btnDelete.Enabled = true;
                }

                FillPurchases(ListPurchases);

                List<VoucherDetailEL> listTransactions = PManager.GetPurchasesSubTransactions(IdVoucher.Value, Operations.IdProject, Operations.BookNo, IsNetTransaction);

                FillHeadTransactions(listTransactions);
                FillPurchasesTransactions(listTransactions);

            }
            else
            {
                MessageBox.Show("Voucher Number Not Found ...");
                ClearControls();
            }
        }
        private void FillPurchasesByNumber(Int64 PNo)
        {
            var Manager = new VoucherBLL();
            var PManager = new PurchaseHeadBLL();
            VoucherType = "P";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
            List<VoucherDetailEL> ListPurchases = PManager.GetPurchasesTransactionsByNumber(PNo, Operations.IdProject, Operations.BookNo, IsNetTransaction);
            if (ListPurchases.Count > 0)
            {
                IdVoucher = ListPurchases[0].IdVoucher;
                VEditBox.Enabled = false;
                VEditBox.Text = Validation.GetSafeString(ListPurchases[0].VoucherNo);
                txtSheetNo.Text = ListPurchases[0].SheetNo.ToString();
                txtBiltyNo.Text = ListPurchases[0].BiltyNo;
                txtBillNo.Text = ListPurchases[0].BillNo;
                VDate.Value = ListPurchases[0].VDate.Value;
                txtDescription.Text = ListPurchases[0].VDiscription;
                txtBillAmount.Text = ListPurchases[0].BillAmount.ToString();
                txtFreightAmount.Text = ListPurchases[0].TotalFreight.ToString();
                txtTotalAmount.Text = ListPurchases[0].TotalAmount.ToString();
                if (!IsNetTransaction)
                {
                    FillCreditor(ListPurchases[0].AccountNo);
                }
                else
                {
                    txtSupplierName.Text = ListPurchases[0].FirstName;
                    txtSupplierContact.Text = ListPurchases[0].Contact;
                    txtSupplerCNIC.Text = ListPurchases[0].Cnic;
                    txtSupplierAddress.Text = ListPurchases[0].Address;
                }
                chkPosted.Checked = ListPurchases[0].Posted.Value;
                if (ListPurchases[0].Posted.Value)
                {
                    //if (Operations.IdRole != Validation.GetSafeLong(EnRoles.Administrator))
                    //{
                    //    btnSave.Enabled = false;
                    //    btnDelete.Enabled = false;
                    //    chkPosted.Enabled = false;
                    //}
                    chkPosted.Enabled = false;
                    lblStatuMessage.Text = "Posted Voucher ...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
                else
                {
                    chkPosted.Enabled = true;
                    //btnSave.Enabled = true;
                    //btnDelete.Enabled = true;
                }

                FillPurchases(ListPurchases);

                List<VoucherDetailEL> listTransactions = PManager.GetPurchasesSubTransactions(IdVoucher.Value, Operations.IdProject, Operations.BookNo, IsNetTransaction);

                FillHeadTransactions(listTransactions);
                FillPurchasesTransactions(listTransactions);

            }
            else
            {
                MessageBox.Show("Voucher Number Not Found ...");
                ClearControls();
            }
        }
        private void FillPurchases(List<VoucherDetailEL> List)
        {
            if (DgvStockReceipt.Rows.Count > 0)
            {
                DgvStockReceipt.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {

                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();
                    //DgvStockReceipt.Rows[i].Cells[0].Value = List[i].TransactionID;
                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].ItemNo;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].ItemName;
                    DgvStockReceipt.Rows[i].Cells[4].Value = List[i].PackingSize;
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].TotalCartons;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].BatchNo;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].Expiry;
                    DgvStockReceipt.Rows[i].Cells[8].Value = List[i].EngineNo;
                    DgvStockReceipt.Rows[i].Cells[9].Value = List[i].ChasisNo;
                    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].VehicleModel;
                    if (List[i].ColorCode == 1)
                    {
                        DgvStockReceipt.Rows[i].Cells[11].Value = "Red";
                    }
                    else if (List[i].ColorCode == 1)
                    {
                        DgvStockReceipt.Rows[i].Cells[11].Value = "Black";
                    }
                    else if (List[i].ColorCode == 1)
                    {
                        DgvStockReceipt.Rows[i].Cells[11].Value = "Blue";
                    }
                    else if (List[i].ColorCode == 1)
                    {
                        DgvStockReceipt.Rows[i].Cells[11].Value = "Silver";
                    }
                    DgvStockReceipt.Rows[i].Cells[12].Value = List[i].VehicleNo;
                    DgvStockReceipt.Rows[i].Cells[13].Value = List[i].FirstIMEI;
                    DgvStockReceipt.Rows[i].Cells[14].Value = List[i].SecondIMEI;


                    DgvStockReceipt.Rows[i].Cells[15].Value = CommonFunctions.RemoveTrailingZeros(List[i].Units);
                    DgvStockReceipt.Rows[i].Cells[16].Value = CommonFunctions.RemoveTrailingZeros(List[i].Bonus);
                    DgvStockReceipt.Rows[i].Cells[17].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[18].Value = List[i].Amount;
                    DgvStockReceipt.Rows[i].Cells[19].Value = List[i].Discount;
                    DgvStockReceipt.Rows[i].Cells[20].Value = List[i].DiscountAmount;

                }
            }
        }
        private void FillHeadTransactions(List<VoucherDetailEL> List)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].TrackNumber == 1)
                {
                    if (!IsNetTransaction)
                    {
                        SupplierTransactionId = List[i].IdTransactionDetail;
                        SEditBox.Text = List[i].AccountName;
                        SupplierAccountNo = List[i].AccountNo;
                    }
                    else
                    {
                        CashTransactionId = List[i].IdTransactionDetail;
                        CashAccountNo = List[i].AccountNo;
                        FillCashAccounts(CashAccountNo);
                    }
                }
                else if (List[i].TrackNumber == 2)
                {
                    PurchasesTransactionId = List[i].IdTransactionDetail;
                    cbxNaturalAccounts.SelectedValue = List[i].AccountNo;
                    PurchasesAccountNo = List[i].AccountNo;
                }
            }
        }
        private void FillPurchasesTransactions(List<VoucherDetailEL> List)
        {
            if (DgvPurchases.Rows.Count > 0)
            {
                DgvPurchases.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                List.RemoveAll(x => x.TrackNumber == 1 || x.TrackNumber == 2);
                for (int i = 0; i < List.Count; i++)
                {
                    if (List[i].TrackNumber != 1 && List[i].TrackNumber != 2)
                    {
                        DgvPurchases.Rows.Add();
                        DgvPurchases.Rows[i].Cells[0].Value = List[i].IdTransactionDetail;
                        DgvPurchases.Rows[i].Cells[1].Value = List[i].IdAccount;
                        DgvPurchases.Rows[i].Cells[2].Value = List[i].AccountNo;
                        DgvPurchases.Rows[i].Cells[3].Value = List[i].AccountName;
                        DgvPurchases.Rows[i].Cells[4].Value = List[i].Narration;
                        DgvPurchases.Rows[i].Cells[5].Value = List[i].Debit;
                        DgvPurchases.Rows[i].Cells[6].Value = List[i].Credit;
                    }
                }
                txtDebit.Text = List.Sum(x => x.Debit).ToString();
                txtCredit.Text = List.Sum(x => x.Credit).ToString();
            }
        }
        #endregion        
    }
}
