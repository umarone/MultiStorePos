﻿namespace Accounts.UI
{
    partial class frmCurrentStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.grdCurrentStock = new Accounts.UI.TabDataGrid();
            this.ColIdCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEngineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChassisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleColors = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstIMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecondIMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonusUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbarcodecontrol = new MetroFramework.Controls.MetroTextBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.cbxProducts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.Location = new System.Drawing.Point(888, 542);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 52);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdCurrentStock
            // 
            this.grdCurrentStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdCurrentStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCurrentStock.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrentStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCurrentStock.ColumnHeadersHeight = 25;
            this.grdCurrentStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdCurrentStock,
            this.colIdItem,
            this.colItemNo,
            this.colItemName,
            this.colpacking,
            this.colCartons,
            this.colBatchNo,
            this.colExpiry,
            this.colEngineNo,
            this.colChassisNo,
            this.colVehicleModel,
            this.colVehicleColors,
            this.colVehicleNo,
            this.colFirstIMEI,
            this.colSecondIMEI,
            this.colQty,
            this.colBonusUnit,
            this.colUnitPrice,
            this.colTotalAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCurrentStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdCurrentStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCurrentStock.EnableHeadersVisualStyles = false;
            this.grdCurrentStock.Location = new System.Drawing.Point(10, 93);
            this.grdCurrentStock.MultiSelect = false;
            this.grdCurrentStock.Name = "grdCurrentStock";
            this.grdCurrentStock.RowHeadersVisible = false;
            this.grdCurrentStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCurrentStock.Size = new System.Drawing.Size(1015, 443);
            this.grdCurrentStock.TabIndex = 26;
            this.grdCurrentStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentStock_CellEndEdit);
            this.grdCurrentStock.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentStock_CellLeave);
            this.grdCurrentStock.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCurrentStock_EditingControlShowing);
            // 
            // ColIdCurrentStock
            // 
            this.ColIdCurrentStock.HeaderText = "IdCurrentStock";
            this.ColIdCurrentStock.Name = "ColIdCurrentStock";
            this.ColIdCurrentStock.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.DataPropertyName = "IdItem";
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItemNo
            // 
            this.colItemNo.DataPropertyName = "ItemNo";
            this.colItemNo.HeaderText = "Product Code";
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Product Discription";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 250;
            // 
            // colpacking
            // 
            this.colpacking.DataPropertyName = "PackingSize";
            this.colpacking.HeaderText = "UOM";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 90;
            // 
            // colCartons
            // 
            this.colCartons.DataPropertyName = "TotalCartons";
            this.colCartons.HeaderText = "CTN";
            this.colCartons.Name = "colCartons";
            this.colCartons.Width = 90;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "BatchNo";
            this.colBatchNo.HeaderText = "BatchNo";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.Width = 90;
            // 
            // colExpiry
            // 
            this.colExpiry.DataPropertyName = "Expiry";
            this.colExpiry.HeaderText = "Expiry";
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.Width = 90;
            // 
            // colEngineNo
            // 
            this.colEngineNo.DataPropertyName = "EngineNo";
            this.colEngineNo.HeaderText = "Engine #";
            this.colEngineNo.Name = "colEngineNo";
            this.colEngineNo.Width = 80;
            // 
            // colChassisNo
            // 
            this.colChassisNo.DataPropertyName = "ChasisNo";
            this.colChassisNo.HeaderText = "Chassis #";
            this.colChassisNo.Name = "colChassisNo";
            this.colChassisNo.Width = 80;
            // 
            // colVehicleModel
            // 
            this.colVehicleModel.HeaderText = "Model";
            this.colVehicleModel.Name = "colVehicleModel";
            this.colVehicleModel.Width = 80;
            // 
            // colVehicleColors
            // 
            this.colVehicleColors.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colVehicleColors.HeaderText = "Color";
            this.colVehicleColors.Items.AddRange(new object[] {
            "",
            "Red",
            "Black",
            "Blue",
            "Silver"});
            this.colVehicleColors.Name = "colVehicleColors";
            this.colVehicleColors.Width = 80;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicleNo";
            this.colVehicleNo.HeaderText = "Vehicle #";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.Width = 90;
            // 
            // colFirstIMEI
            // 
            this.colFirstIMEI.DataPropertyName = "FirstIMEI";
            this.colFirstIMEI.HeaderText = "IMEI No";
            this.colFirstIMEI.Name = "colFirstIMEI";
            // 
            // colSecondIMEI
            // 
            this.colSecondIMEI.DataPropertyName = "SecondIMEI";
            this.colSecondIMEI.HeaderText = "Second IMEI";
            this.colSecondIMEI.Name = "colSecondIMEI";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 80;
            // 
            // colBonusUnit
            // 
            this.colBonusUnit.HeaderText = "Bonus";
            this.colBonusUnit.Name = "colBonusUnit";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 90;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "qty*amount";
            this.colTotalAmount.HeaderText = "Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // txtbarcodecontrol
            // 
            // 
            // 
            // 
            this.txtbarcodecontrol.CustomButton.Image = null;
            this.txtbarcodecontrol.CustomButton.Location = new System.Drawing.Point(-12, 1);
            this.txtbarcodecontrol.CustomButton.Name = "";
            this.txtbarcodecontrol.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbarcodecontrol.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbarcodecontrol.CustomButton.TabIndex = 1;
            this.txtbarcodecontrol.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbarcodecontrol.CustomButton.UseSelectable = true;
            this.txtbarcodecontrol.CustomButton.Visible = false;
            this.txtbarcodecontrol.Lines = new string[0];
            this.txtbarcodecontrol.Location = new System.Drawing.Point(682, 61);
            this.txtbarcodecontrol.MaxLength = 32767;
            this.txtbarcodecontrol.Name = "txtbarcodecontrol";
            this.txtbarcodecontrol.PasswordChar = '\0';
            this.txtbarcodecontrol.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbarcodecontrol.SelectedText = "";
            this.txtbarcodecontrol.SelectionLength = 0;
            this.txtbarcodecontrol.SelectionStart = 0;
            this.txtbarcodecontrol.ShortcutsEnabled = true;
            this.txtbarcodecontrol.Size = new System.Drawing.Size(10, 23);
            this.txtbarcodecontrol.TabIndex = 28;
            this.txtbarcodecontrol.UseSelectable = true;
            this.txtbarcodecontrol.Visible = false;
            this.txtbarcodecontrol.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbarcodecontrol.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbarcodecontrol.Enter += new System.EventHandler(this.txtbarcodecontrol_Enter);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(10, 65);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(79, 13);
            this.lblItems.TabIndex = 29;
            this.lblItems.Text = "Enter Item(s)";
            // 
            // cbxProducts
            // 
            this.cbxProducts.BackColor = System.Drawing.SystemColors.Info;
            this.cbxProducts.FormattingEnabled = true;
            this.cbxProducts.Location = new System.Drawing.Point(93, 63);
            this.cbxProducts.Name = "cbxProducts";
            this.cbxProducts.Size = new System.Drawing.Size(587, 21);
            this.cbxProducts.TabIndex = 27;
            this.cbxProducts.TextChanged += new System.EventHandler(this.cbxProducts_TextChanged);
            this.cbxProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxProducts_KeyDown);
            this.cbxProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxProducts_KeyUp);
            this.cbxProducts.Leave += new System.EventHandler(this.cbxProducts_Leave);
            // 
            // frmCurrentStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1042, 627);
            this.Controls.Add(this.txtbarcodecontrol);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.cbxProducts);
            this.Controls.Add(this.grdCurrentStock);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCurrentStock";
            this.Text = "Add Current Stock";
            this.Load += new System.EventHandler(this.frmCurrentStock_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCurrentStock_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnSave;
        private TabDataGrid grdCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEngineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChassisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleModel;
        private System.Windows.Forms.DataGridViewComboBoxColumn colVehicleColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstIMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecondIMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonusUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private MetroFramework.Controls.MetroTextBox txtbarcodecontrol;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.ComboBox cbxProducts;
    }
}