
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageTopping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageTopping));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnProductTopping = new Guna.UI2.WinForms.Guna2Button();
            this.btnOptionGroup = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panelMenu.Location = new System.Drawing.Point(0, 70);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1644, 701);
            this.panelMenu.TabIndex = 29;
            // 
            // btnProductTopping
            // 
            this.btnProductTopping.BorderRadius = 20;
            this.btnProductTopping.CheckedState.Parent = this.btnProductTopping;
            this.btnProductTopping.CustomImages.Parent = this.btnProductTopping;
            this.btnProductTopping.FillColor = System.Drawing.Color.Tomato;
            this.btnProductTopping.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductTopping.ForeColor = System.Drawing.Color.White;
            this.btnProductTopping.HoverState.Parent = this.btnProductTopping;
            this.btnProductTopping.Image = ((System.Drawing.Image)(resources.GetObject("btnProductTopping.Image")));
            this.btnProductTopping.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProductTopping.Location = new System.Drawing.Point(911, 7);
            this.btnProductTopping.Name = "btnProductTopping";
            this.btnProductTopping.ShadowDecoration.Parent = this.btnProductTopping;
            this.btnProductTopping.Size = new System.Drawing.Size(345, 55);
            this.btnProductTopping.TabIndex = 27;
            this.btnProductTopping.Text = "Quản Lý Topping Sản Phẩm";
            this.btnProductTopping.Click += new System.EventHandler(this.btnProductTopping_Click);
            // 
            // btnOptionGroup
            // 
            this.btnOptionGroup.BorderRadius = 20;
            this.btnOptionGroup.CheckedState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.CustomImages.Parent = this.btnOptionGroup;
            this.btnOptionGroup.FillColor = System.Drawing.Color.Teal;
            this.btnOptionGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptionGroup.ForeColor = System.Drawing.Color.White;
            this.btnOptionGroup.HoverState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnOptionGroup.Image")));
            this.btnOptionGroup.ImageSize = new System.Drawing.Size(30, 30);
            this.btnOptionGroup.Location = new System.Drawing.Point(506, 7);
            this.btnOptionGroup.Name = "btnOptionGroup";
            this.btnOptionGroup.ShadowDecoration.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Size = new System.Drawing.Size(345, 55);
            this.btnOptionGroup.TabIndex = 26;
            this.btnOptionGroup.Text = "Quản Lý Topping";
            this.btnOptionGroup.Click += new System.EventHandler(this.btnOptionGroup_Click);
            // 
            // UC_ManageTopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnProductTopping);
            this.Controls.Add(this.btnOptionGroup);
            this.Name = "UC_ManageTopping";
            this.Size = new System.Drawing.Size(1644, 776);
            this.Load += new System.EventHandler(this.UC_ManageTopping_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnProductTopping;
        private Guna.UI2.WinForms.Guna2Button btnOptionGroup;
    }
}
