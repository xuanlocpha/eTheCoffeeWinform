
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageProductCategory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageProductCategory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCategory = new Guna.UI2.WinForms.Guna2Button();
            this.btnProduct = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnGroupOption = new Guna.UI2.WinForms.Guna2Button();
            this.btnOption = new Guna.UI2.WinForms.Guna2Button();
            this.btnProductOption = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnProductOption);
            this.panel1.Controls.Add(this.btnOption);
            this.panel1.Controls.Add(this.btnGroupOption);
            this.panel1.Controls.Add(this.btnCategory);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1624, 63);
            this.panel1.TabIndex = 37;
            // 
            // btnCategory
            // 
            this.btnCategory.BorderRadius = 4;
            this.btnCategory.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCategory.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnCategory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnCategory.CheckedState.Parent = this.btnCategory;
            this.btnCategory.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnCategory.CustomImages.Parent = this.btnCategory;
            this.btnCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategory.DisabledState.Parent = this.btnCategory;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnCategory.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.HoverState.Parent = this.btnCategory;
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageSize = new System.Drawing.Size(23, 23);
            this.btnCategory.Location = new System.Drawing.Point(320, 0);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(4);
            this.btnCategory.ShadowDecoration.Parent = this.btnCategory;
            this.btnCategory.Size = new System.Drawing.Size(320, 63);
            this.btnCategory.TabIndex = 7;
            this.btnCategory.Text = "Quản Lý Loại Sản Phẩm";
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BorderRadius = 4;
            this.btnProduct.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProduct.Checked = true;
            this.btnProduct.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnProduct.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnProduct.CheckedState.Parent = this.btnProduct;
            this.btnProduct.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnProduct.CustomImages.Parent = this.btnProduct;
            this.btnProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProduct.DisabledState.Parent = this.btnProduct;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnProduct.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.HoverState.Parent = this.btnProduct;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProduct.Location = new System.Drawing.Point(0, 0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(4);
            this.btnProduct.ShadowDecoration.Parent = this.btnProduct;
            this.btnProduct.Size = new System.Drawing.Size(320, 63);
            this.btnProduct.TabIndex = 6;
            this.btnProduct.Text = "Quản Lý Sản Phẩm";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Location = new System.Drawing.Point(10, 84);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1624, 681);
            this.panelMenu.TabIndex = 36;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 17;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.panelMenu;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 10;
            this.guna2Elipse3.TargetControl = this.panel1;
            // 
            // btnGroupOption
            // 
            this.btnGroupOption.BorderRadius = 4;
            this.btnGroupOption.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGroupOption.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnGroupOption.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnGroupOption.CheckedState.Parent = this.btnGroupOption;
            this.btnGroupOption.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnGroupOption.CustomImages.Parent = this.btnGroupOption;
            this.btnGroupOption.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGroupOption.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGroupOption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGroupOption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGroupOption.DisabledState.Parent = this.btnGroupOption;
            this.btnGroupOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGroupOption.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnGroupOption.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupOption.ForeColor = System.Drawing.Color.White;
            this.btnGroupOption.HoverState.Parent = this.btnGroupOption;
            this.btnGroupOption.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupOption.Image")));
            this.btnGroupOption.ImageSize = new System.Drawing.Size(27, 27);
            this.btnGroupOption.Location = new System.Drawing.Point(640, 0);
            this.btnGroupOption.Name = "btnGroupOption";
            this.btnGroupOption.Padding = new System.Windows.Forms.Padding(4);
            this.btnGroupOption.ShadowDecoration.Parent = this.btnGroupOption;
            this.btnGroupOption.Size = new System.Drawing.Size(320, 63);
            this.btnGroupOption.TabIndex = 8;
            this.btnGroupOption.Text = "Quản Lý Nhóm Option";
            this.btnGroupOption.Click += new System.EventHandler(this.btnGroupOption_Click);
            // 
            // btnOption
            // 
            this.btnOption.BorderRadius = 4;
            this.btnOption.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnOption.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnOption.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnOption.CheckedState.Parent = this.btnOption;
            this.btnOption.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnOption.CustomImages.Parent = this.btnOption;
            this.btnOption.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOption.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOption.DisabledState.Parent = this.btnOption;
            this.btnOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOption.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnOption.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnOption.ForeColor = System.Drawing.Color.White;
            this.btnOption.HoverState.Parent = this.btnOption;
            this.btnOption.Image = ((System.Drawing.Image)(resources.GetObject("btnOption.Image")));
            this.btnOption.ImageSize = new System.Drawing.Size(23, 23);
            this.btnOption.Location = new System.Drawing.Point(960, 0);
            this.btnOption.Name = "btnOption";
            this.btnOption.Padding = new System.Windows.Forms.Padding(4);
            this.btnOption.ShadowDecoration.Parent = this.btnOption;
            this.btnOption.Size = new System.Drawing.Size(320, 63);
            this.btnOption.TabIndex = 9;
            this.btnOption.Text = "Quản Lý Option";
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnProductOption
            // 
            this.btnProductOption.BorderRadius = 4;
            this.btnProductOption.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProductOption.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnProductOption.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnProductOption.CheckedState.Parent = this.btnProductOption;
            this.btnProductOption.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnProductOption.CustomImages.Parent = this.btnProductOption;
            this.btnProductOption.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProductOption.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProductOption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProductOption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProductOption.DisabledState.Parent = this.btnProductOption;
            this.btnProductOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProductOption.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnProductOption.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductOption.ForeColor = System.Drawing.Color.White;
            this.btnProductOption.HoverState.Parent = this.btnProductOption;
            this.btnProductOption.Image = ((System.Drawing.Image)(resources.GetObject("btnProductOption.Image")));
            this.btnProductOption.ImageSize = new System.Drawing.Size(27, 27);
            this.btnProductOption.Location = new System.Drawing.Point(1280, 0);
            this.btnProductOption.Name = "btnProductOption";
            this.btnProductOption.Padding = new System.Windows.Forms.Padding(4);
            this.btnProductOption.ShadowDecoration.Parent = this.btnProductOption;
            this.btnProductOption.Size = new System.Drawing.Size(320, 63);
            this.btnProductOption.TabIndex = 10;
            this.btnProductOption.Text = "Quản Lý Option Sản Phẩm";
            this.btnProductOption.Click += new System.EventHandler(this.btnProductOption_Click);
            // 
            // UC_ManageProductCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Name = "UC_ManageProductCategory";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1644, 776);
            this.Load += new System.EventHandler(this.UC_ManageProductCategory_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnCategory;
        private Guna.UI2.WinForms.Guna2Button btnProduct;
        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Button btnProductOption;
        private Guna.UI2.WinForms.Guna2Button btnOption;
        private Guna.UI2.WinForms.Guna2Button btnGroupOption;
    }
}
