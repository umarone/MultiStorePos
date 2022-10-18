namespace Accounts.UI
{
    partial class frmPosBarCodePrinting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosBarCodePrinting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblItems = new System.Windows.Forms.Label();
            this.grdProducts = new System.Windows.Forms.DataGridView();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbxProducts = new System.Windows.Forms.ComboBox();
            this.toolPosStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCashier = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtbarcodecontrol = new MetroFramework.Controls.MetroTextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.toolPosStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(11, 72);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(79, 13);
            this.lblItems.TabIndex = 7;
            this.lblItems.Text = "Enter Item(s)";
            // 
            // grdProducts
            // 
            this.grdProducts.AllowUserToAddRows = false;
            this.grdProducts.AllowUserToDeleteRows = false;
            this.grdProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProducts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdProducts.ColumnHeadersHeight = 35;
            this.grdProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdItem,
            this.colBarCode,
            this.colItemName,
            this.colPackingSize,
            this.colQuantity,
            this.colMinus,
            this.colAdd,
            this.colDelete});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProducts.DefaultCellStyle = dataGridViewCellStyle17;
            this.grdProducts.EnableHeadersVisualStyles = false;
            this.grdProducts.Location = new System.Drawing.Point(14, 97);
            this.grdProducts.MultiSelect = false;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdProducts.RowHeadersVisible = false;
            this.grdProducts.Size = new System.Drawing.Size(948, 487);
            this.grdProducts.TabIndex = 10;
            this.grdProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProducts_CellClick);
            this.grdProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProducts_CellEndEdit);
            this.grdProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdProducts_CellFormatting);
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.ReadOnly = true;
            this.colIdItem.Visible = false;
            // 
            // colBarCode
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colBarCode.DefaultCellStyle = dataGridViewCellStyle14;
            this.colBarCode.FillWeight = 406.0914F;
            this.colBarCode.HeaderText = "Bar Code";
            this.colBarCode.MinimumWidth = 70;
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            // 
            // colItemName
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle15;
            this.colItemName.FillWeight = 39.66759F;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.MinimumWidth = 220;
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colPackingSize
            // 
            this.colPackingSize.HeaderText = "Packing";
            this.colPackingSize.MinimumWidth = 70;
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            // 
            // colQuantity
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle16;
            this.colQuantity.FillWeight = 49.53582F;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 65;
            this.colQuantity.Name = "colQuantity";
            // 
            // colMinus
            // 
            this.colMinus.FillWeight = 0.1879929F;
            this.colMinus.HeaderText = ".";
            this.colMinus.MinimumWidth = 50;
            this.colMinus.Name = "colMinus";
            this.colMinus.ReadOnly = true;
            // 
            // colAdd
            // 
            this.colAdd.FillWeight = 0.1879929F;
            this.colAdd.HeaderText = "..";
            this.colAdd.MinimumWidth = 50;
            this.colAdd.Name = "colAdd";
            this.colAdd.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 0.1879929F;
            this.colDelete.HeaderText = "...";
            this.colDelete.MinimumWidth = 50;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            // 
            // cbxProducts
            // 
            this.cbxProducts.BackColor = System.Drawing.SystemColors.Info;
            this.cbxProducts.FormattingEnabled = true;
            this.cbxProducts.Location = new System.Drawing.Point(94, 70);
            this.cbxProducts.Name = "cbxProducts";
            this.cbxProducts.Size = new System.Drawing.Size(587, 21);
            this.cbxProducts.TabIndex = 0;
            this.cbxProducts.TextChanged += new System.EventHandler(this.cbxProducts_TextChanged);
            this.cbxProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxProducts_KeyDown);
            this.cbxProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxProducts_KeyUp);
            this.cbxProducts.Leave += new System.EventHandler(this.cbxProducts_Leave);
            // 
            // toolPosStrip
            // 
            this.toolPosStrip.AutoSize = false;
            this.toolPosStrip.BackColor = System.Drawing.Color.LightCoral;
            this.toolPosStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNew,
            this.toolStripBtnCashier});
            this.toolPosStrip.Location = new System.Drawing.Point(0, 0);
            this.toolPosStrip.Name = "toolPosStrip";
            this.toolPosStrip.Size = new System.Drawing.Size(966, 66);
            this.toolPosStrip.TabIndex = 35;
            this.toolPosStrip.Text = "toolStrip1";
            // 
            // toolStripBtnNew
            // 
            this.toolStripBtnNew.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNew.Image")));
            this.toolStripBtnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNew.Name = "toolStripBtnNew";
            this.toolStripBtnNew.Size = new System.Drawing.Size(92, 63);
            this.toolStripBtnNew.Text = "New";
            this.toolStripBtnNew.Click += new System.EventHandler(this.toolStripBtnNew_Click);
            // 
            // toolStripBtnCashier
            // 
            this.toolStripBtnCashier.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnCashier.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnCashier.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCashier.Image")));
            this.toolStripBtnCashier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnCashier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCashier.Name = "toolStripBtnCashier";
            this.toolStripBtnCashier.Size = new System.Drawing.Size(106, 63);
            this.toolStripBtnCashier.Text = "Cashier";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(718, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 45);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Start BarCode Printing Job";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.txtbarcodecontrol.Location = new System.Drawing.Point(683, 68);
            this.txtbarcodecontrol.MaxLength = 32767;
            this.txtbarcodecontrol.Name = "txtbarcodecontrol";
            this.txtbarcodecontrol.PasswordChar = '\0';
            this.txtbarcodecontrol.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbarcodecontrol.SelectedText = "";
            this.txtbarcodecontrol.SelectionLength = 0;
            this.txtbarcodecontrol.SelectionStart = 0;
            this.txtbarcodecontrol.ShortcutsEnabled = true;
            this.txtbarcodecontrol.Size = new System.Drawing.Size(10, 23);
            this.txtbarcodecontrol.TabIndex = 1;
            this.txtbarcodecontrol.UseSelectable = true;
            this.txtbarcodecontrol.Visible = false;
            this.txtbarcodecontrol.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbarcodecontrol.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbarcodecontrol.Enter += new System.EventHandler(this.txtbarcodecontrol_Enter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 95;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn2.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn3.FillWeight = 657.868F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn4.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 220;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn5.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Total";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 102;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn6.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 146;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn7.FillWeight = 203.7314F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn8.FillWeight = 203.7314F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Disc(%)";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Net Amount";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Net Amount";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // frmPosBarCodePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 630);
            this.Controls.Add(this.txtbarcodecontrol);
            this.Controls.Add(this.toolPosStrip);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.cbxProducts);
            this.Controls.Add(this.grdProducts);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.Name = "frmPosBarCodePrinting";
            this.Text = "POS Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPosBarCodePrinting_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPosBarCodePrinting_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.toolPosStrip.ResumeLayout(false);
            this.toolPosStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridView grdProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ComboBox cbxProducts;
        private System.Windows.Forms.ToolStrip toolPosStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private MetroFramework.Controls.MetroTextBox txtbarcodecontrol;
        private System.Windows.Forms.ToolStripButton toolStripBtnCashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colMinus;
        private System.Windows.Forms.DataGridViewButtonColumn colAdd;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}