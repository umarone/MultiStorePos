namespace Accounts.UI
{
    partial class frmFindProductsOnForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdFindItems = new Accounts.UI.CustomDataGrid();
            this.colIdAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFindItems
            // 
            this.grdFindItems.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFindItems.BackgroundColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFindItems.ColumnHeadersHeight = 25;
            this.grdFindItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdAccount,
            this.colName,
            this.colLastPurchasePrice,
            this.colSalePrice,
            this.colClosingStock});
            this.grdFindItems.EnableHeadersVisualStyles = false;
            this.grdFindItems.Location = new System.Drawing.Point(2, 32);
            this.grdFindItems.MultiSelect = false;
            this.grdFindItems.Name = "grdFindItems";
            this.grdFindItems.RowHeadersVisible = false;
            this.grdFindItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindItems.Size = new System.Drawing.Size(585, 462);
            this.grdFindItems.TabIndex = 1;
            this.grdFindItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindItems_CellDoubleClick);
            this.grdFindItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindItems_KeyPress);
            // 
            // colIdAccount
            // 
            this.colIdAccount.DataPropertyName = "IdItem";
            this.colIdAccount.HeaderText = "IdItem";
            this.colIdAccount.Name = "colIdAccount";
            this.colIdAccount.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "Product Name";
            this.colName.Name = "colName";
            this.colName.Width = 270;
            // 
            // colLastPurchasePrice
            // 
            this.colLastPurchasePrice.DataPropertyName = "LastPurchaseRate";
            this.colLastPurchasePrice.HeaderText = "Last Purchase Rate";
            this.colLastPurchasePrice.Name = "colLastPurchasePrice";
            this.colLastPurchasePrice.Width = 110;
            // 
            // colSalePrice
            // 
            this.colSalePrice.DataPropertyName = "MRP";
            this.colSalePrice.HeaderText = "Sale Rate";
            this.colSalePrice.Name = "colSalePrice";
            // 
            // colClosingStock
            // 
            this.colClosingStock.DataPropertyName = "ClosingStock";
            this.colClosingStock.HeaderText = "Stock On Hand";
            this.colClosingStock.Name = "colClosingStock";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(2, 6);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(585, 25);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // frmFindProductsOnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 494);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.grdFindItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindProductsOnForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find Stocks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindProducts_FormClosing);
            this.Load += new System.EventHandler(this.frmFindProducts_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindProducts_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdFindItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastPurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingStock;
        private System.Windows.Forms.TextBox txtName;
    }
}