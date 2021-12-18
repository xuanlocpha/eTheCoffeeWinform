
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageStaffRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageStaffRole));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRole = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaff = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnAssignment = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnAssignment);
            this.panel1.Controls.Add(this.btnRole);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1624, 63);
            this.panel1.TabIndex = 35;
            // 
            // btnRole
            // 
            this.btnRole.BorderRadius = 4;
            this.btnRole.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRole.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnRole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnRole.CheckedState.Parent = this.btnRole;
            this.btnRole.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnRole.CustomImages.Parent = this.btnRole;
            this.btnRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRole.DisabledState.Parent = this.btnRole;
            this.btnRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnRole.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRole.ForeColor = System.Drawing.Color.White;
            this.btnRole.HoverState.Parent = this.btnRole;
            this.btnRole.Image = ((System.Drawing.Image)(resources.GetObject("btnRole.Image")));
            this.btnRole.ImageSize = new System.Drawing.Size(23, 23);
            this.btnRole.Location = new System.Drawing.Point(320, 0);
            this.btnRole.Name = "btnRole";
            this.btnRole.Padding = new System.Windows.Forms.Padding(4);
            this.btnRole.ShadowDecoration.Parent = this.btnRole;
            this.btnRole.Size = new System.Drawing.Size(320, 63);
            this.btnRole.TabIndex = 7;
            this.btnRole.Text = "Quản Lý Quyền";
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BorderRadius = 4;
            this.btnStaff.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStaff.Checked = true;
            this.btnStaff.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnStaff.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnStaff.CheckedState.Parent = this.btnStaff;
            this.btnStaff.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnStaff.CustomImages.Parent = this.btnStaff;
            this.btnStaff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStaff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStaff.DisabledState.Parent = this.btnStaff;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStaff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnStaff.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.HoverState.Parent = this.btnStaff;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageSize = new System.Drawing.Size(30, 30);
            this.btnStaff.Location = new System.Drawing.Point(0, 0);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(4);
            this.btnStaff.ShadowDecoration.Parent = this.btnStaff;
            this.btnStaff.Size = new System.Drawing.Size(320, 63);
            this.btnStaff.TabIndex = 6;
            this.btnStaff.Text = "Quản Lý Nhân Viên";
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Location = new System.Drawing.Point(10, 82);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1624, 681);
            this.panelMenu.TabIndex = 34;
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
            // btnAssignment
            // 
            this.btnAssignment.BorderRadius = 4;
            this.btnAssignment.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAssignment.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnAssignment.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnAssignment.CheckedState.Parent = this.btnAssignment;
            this.btnAssignment.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnAssignment.CustomImages.Parent = this.btnAssignment;
            this.btnAssignment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAssignment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAssignment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAssignment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAssignment.DisabledState.Parent = this.btnAssignment;
            this.btnAssignment.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAssignment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnAssignment.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignment.ForeColor = System.Drawing.Color.White;
            this.btnAssignment.HoverState.Parent = this.btnAssignment;
            this.btnAssignment.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignment.Image")));
            this.btnAssignment.ImageSize = new System.Drawing.Size(23, 23);
            this.btnAssignment.Location = new System.Drawing.Point(640, 0);
            this.btnAssignment.Name = "btnAssignment";
            this.btnAssignment.Padding = new System.Windows.Forms.Padding(4);
            this.btnAssignment.ShadowDecoration.Parent = this.btnAssignment;
            this.btnAssignment.Size = new System.Drawing.Size(320, 63);
            this.btnAssignment.TabIndex = 8;
            this.btnAssignment.Text = "Quản Lý Lịch Làm Việc";
            this.btnAssignment.Click += new System.EventHandler(this.btnAssignment_Click);
            // 
            // UC_ManageStaffRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Name = "UC_ManageStaffRole";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1644, 776);
            this.Load += new System.EventHandler(this.UC_ManageStaffRole_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnRole;
        private Guna.UI2.WinForms.Guna2Button btnStaff;
        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Button btnAssignment;
    }
}
