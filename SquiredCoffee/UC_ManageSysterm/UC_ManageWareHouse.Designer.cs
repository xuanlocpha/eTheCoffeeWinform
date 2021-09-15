
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageWareHouse
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageWareHouse));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnManageStockProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnOptionGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnManageImportInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panelMenu.Location = new System.Drawing.Point(0, 69);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1644, 701);
            this.panelMenu.TabIndex = 32;
            // 
            // btnManageStockProduct
            // 
            this.btnManageStockProduct.BorderRadius = 15;
            this.btnManageStockProduct.CheckedState.Parent = this.btnManageStockProduct;
            this.btnManageStockProduct.CustomImages.Parent = this.btnManageStockProduct;
            this.btnManageStockProduct.FillColor = System.Drawing.Color.Tomato;
            this.btnManageStockProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStockProduct.ForeColor = System.Drawing.Color.White;
            this.btnManageStockProduct.HoverState.Parent = this.btnManageStockProduct;
            this.btnManageStockProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnManageStockProduct.Image")));
            this.btnManageStockProduct.ImageSize = new System.Drawing.Size(30, 30);
            this.btnManageStockProduct.Location = new System.Drawing.Point(398, 5);
            this.btnManageStockProduct.Name = "btnManageStockProduct";
            this.btnManageStockProduct.ShadowDecoration.Parent = this.btnManageStockProduct;
            this.btnManageStockProduct.Size = new System.Drawing.Size(345, 55);
            this.btnManageStockProduct.TabIndex = 31;
            this.btnManageStockProduct.Text = "Quản Lý Sản Phẩm Kho";
            this.btnManageStockProduct.Click += new System.EventHandler(this.btnManageStockProduct_Click);
            // 
            // btnOptionGroup
            // 
            this.btnOptionGroup.BorderRadius = 15;
            this.btnOptionGroup.CheckedState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.CustomImages.Parent = this.btnOptionGroup;
            this.btnOptionGroup.FillColor = System.Drawing.Color.Teal;
            this.btnOptionGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptionGroup.ForeColor = System.Drawing.Color.White;
            this.btnOptionGroup.HoverState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnOptionGroup.Image")));
            this.btnOptionGroup.ImageSize = new System.Drawing.Size(30, 30);
            this.btnOptionGroup.Location = new System.Drawing.Point(20, 5);
            this.btnOptionGroup.Name = "btnOptionGroup";
            this.btnOptionGroup.ShadowDecoration.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Size = new System.Drawing.Size(345, 55);
            this.btnOptionGroup.TabIndex = 30;
            this.btnOptionGroup.Text = "Quản Lý Nhà Cung Cấp";
            // 
            // btnManageImportInvoice
            // 
            this.btnManageImportInvoice.BorderRadius = 15;
            this.btnManageImportInvoice.CheckedState.Parent = this.btnManageImportInvoice;
            this.btnManageImportInvoice.CustomImages.Parent = this.btnManageImportInvoice;
            this.btnManageImportInvoice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnManageImportInvoice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageImportInvoice.ForeColor = System.Drawing.Color.White;
            this.btnManageImportInvoice.HoverState.Parent = this.btnManageImportInvoice;
            this.btnManageImportInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnManageImportInvoice.Image")));
            this.btnManageImportInvoice.ImageSize = new System.Drawing.Size(30, 30);
            this.btnManageImportInvoice.Location = new System.Drawing.Point(772, 3);
            this.btnManageImportInvoice.Name = "btnManageImportInvoice";
            this.btnManageImportInvoice.ShadowDecoration.Parent = this.btnManageImportInvoice;
            this.btnManageImportInvoice.Size = new System.Drawing.Size(345, 55);
            this.btnManageImportInvoice.TabIndex = 33;
            this.btnManageImportInvoice.Text = "Quản Lý Nhập Kho";
            this.btnManageImportInvoice.Click += new System.EventHandler(this.btnManageImportInvoice_Click);
            // 
            // UC_ManageWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.btnManageImportInvoice);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnManageStockProduct);
            this.Controls.Add(this.btnOptionGroup);
            this.Name = "UC_ManageWareHouse";
            this.Size = new System.Drawing.Size(1644, 776);
            this.Load += new System.EventHandler(this.UC_ManageWareHouse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnManageStockProduct;
        private Guna.UI2.WinForms.Guna2Button btnOptionGroup;
        private Guna.UI2.WinForms.Guna2Button btnManageImportInvoice;
    }
}
