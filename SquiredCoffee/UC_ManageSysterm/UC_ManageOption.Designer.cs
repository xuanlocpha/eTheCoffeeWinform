
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageOption));
            this.btnOptionGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnOption = new Guna.UI2.WinForms.Guna2Button();
            this.btnProductOption = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnOptionGroup
            // 
            this.btnOptionGroup.BorderRadius = 20;
            this.btnOptionGroup.CheckedState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.CustomImages.Parent = this.btnOptionGroup;
            this.btnOptionGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.btnOptionGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptionGroup.ForeColor = System.Drawing.Color.White;
            this.btnOptionGroup.HoverState.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnOptionGroup.Image")));
            this.btnOptionGroup.ImageSize = new System.Drawing.Size(30, 30);
            this.btnOptionGroup.Location = new System.Drawing.Point(294, 7);
            this.btnOptionGroup.Name = "btnOptionGroup";
            this.btnOptionGroup.ShadowDecoration.Parent = this.btnOptionGroup;
            this.btnOptionGroup.Size = new System.Drawing.Size(345, 55);
            this.btnOptionGroup.TabIndex = 22;
            this.btnOptionGroup.Text = "Quản Lý Tùy Chọn Món";
            this.btnOptionGroup.Click += new System.EventHandler(this.btnOptionGroup_Click);
            // 
            // btnOption
            // 
            this.btnOption.BorderRadius = 20;
            this.btnOption.CheckedState.Parent = this.btnOption;
            this.btnOption.CustomImages.Parent = this.btnOption;
            this.btnOption.FillColor = System.Drawing.Color.Tomato;
            this.btnOption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.ForeColor = System.Drawing.Color.White;
            this.btnOption.HoverState.Parent = this.btnOption;
            this.btnOption.Image = ((System.Drawing.Image)(resources.GetObject("btnOption.Image")));
            this.btnOption.ImageSize = new System.Drawing.Size(30, 30);
            this.btnOption.Location = new System.Drawing.Point(699, 7);
            this.btnOption.Name = "btnOption";
            this.btnOption.ShadowDecoration.Parent = this.btnOption;
            this.btnOption.Size = new System.Drawing.Size(345, 55);
            this.btnOption.TabIndex = 23;
            this.btnOption.Text = "Quản Lý Tùy Chọn";
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnProductOption
            // 
            this.btnProductOption.BorderRadius = 20;
            this.btnProductOption.CheckedState.Parent = this.btnProductOption;
            this.btnProductOption.CustomImages.Parent = this.btnProductOption;
            this.btnProductOption.FillColor = System.Drawing.Color.Teal;
            this.btnProductOption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductOption.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProductOption.HoverState.Parent = this.btnProductOption;
            this.btnProductOption.Image = ((System.Drawing.Image)(resources.GetObject("btnProductOption.Image")));
            this.btnProductOption.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProductOption.Location = new System.Drawing.Point(1094, 7);
            this.btnProductOption.Name = "btnProductOption";
            this.btnProductOption.ShadowDecoration.Parent = this.btnProductOption;
            this.btnProductOption.Size = new System.Drawing.Size(345, 55);
            this.btnProductOption.TabIndex = 24;
            this.btnProductOption.Text = "Quản Lý Tùy Chọn Sản Phẩm";
            this.btnProductOption.Click += new System.EventHandler(this.btnProductOption_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panelMenu.Location = new System.Drawing.Point(0, 72);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1644, 701);
            this.panelMenu.TabIndex = 25;
            // 
            // UC_ManageOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnProductOption);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnOptionGroup);
            this.Name = "UC_ManageOption";
            this.Size = new System.Drawing.Size(1644, 776);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnOptionGroup;
        private Guna.UI2.WinForms.Guna2Button btnOption;
        private Guna.UI2.WinForms.Guna2Button btnProductOption;
        private System.Windows.Forms.Panel panelMenu;
    }
}
