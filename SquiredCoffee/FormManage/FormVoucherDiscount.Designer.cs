
namespace SquiredCoffee.FormManage
{
    partial class FormVoucherDiscount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVoucherDiscount));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnDiscount = new Guna.UI2.WinForms.Guna2Button();
            this.btnVoucher = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Location = new System.Drawing.Point(13, 140);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1334, 630);
            this.panelMenu.TabIndex = 46;
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
            // 
            // btnDiscount
            // 
            this.btnDiscount.BorderRadius = 4;
            this.btnDiscount.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDiscount.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnDiscount.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnDiscount.CheckedState.Parent = this.btnDiscount;
            this.btnDiscount.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnDiscount.CustomImages.Parent = this.btnDiscount;
            this.btnDiscount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDiscount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDiscount.DisabledState.Parent = this.btnDiscount;
            this.btnDiscount.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDiscount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnDiscount.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.HoverState.Parent = this.btnDiscount;
            this.btnDiscount.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscount.Image")));
            this.btnDiscount.ImageSize = new System.Drawing.Size(23, 23);
            this.btnDiscount.Location = new System.Drawing.Point(320, 0);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Padding = new System.Windows.Forms.Padding(4);
            this.btnDiscount.ShadowDecoration.Parent = this.btnDiscount;
            this.btnDiscount.Size = new System.Drawing.Size(320, 63);
            this.btnDiscount.TabIndex = 7;
            this.btnDiscount.Text = "Giảm giá hiện tại";
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnVoucher
            // 
            this.btnVoucher.BorderRadius = 4;
            this.btnVoucher.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnVoucher.Checked = true;
            this.btnVoucher.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.btnVoucher.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnVoucher.CheckedState.Parent = this.btnVoucher;
            this.btnVoucher.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnVoucher.CustomImages.Parent = this.btnVoucher;
            this.btnVoucher.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVoucher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVoucher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVoucher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVoucher.DisabledState.Parent = this.btnVoucher;
            this.btnVoucher.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVoucher.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.btnVoucher.Font = new System.Drawing.Font("Quicksand SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoucher.ForeColor = System.Drawing.Color.White;
            this.btnVoucher.HoverState.Parent = this.btnVoucher;
            this.btnVoucher.Image = ((System.Drawing.Image)(resources.GetObject("btnVoucher.Image")));
            this.btnVoucher.ImageSize = new System.Drawing.Size(30, 30);
            this.btnVoucher.Location = new System.Drawing.Point(0, 0);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Padding = new System.Windows.Forms.Padding(4);
            this.btnVoucher.ShadowDecoration.Parent = this.btnVoucher;
            this.btnVoucher.Size = new System.Drawing.Size(320, 63);
            this.btnVoucher.TabIndex = 6;
            this.btnVoucher.Text = "Voucher hiện tại";
            this.btnVoucher.Click += new System.EventHandler(this.btnVoucher_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.btnDiscount);
            this.panel2.Controls.Add(this.btnVoucher);
            this.panel2.Location = new System.Drawing.Point(13, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1335, 63);
            this.panel2.TabIndex = 47;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(18, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(52, 47);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBack.TabIndex = 174;
            this.btnBack.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Quicksand", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(1297, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 41);
            this.btnClose.TabIndex = 173;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Quicksand", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 41);
            this.label1.TabIndex = 172;
            this.label1.Text = "Khuyến Mãi && Giảm Giá";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.btnBack);
            this.guna2GradientPanel1.Controls.Add(this.btnClose);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(10, 10);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1342, 52);
            this.guna2GradientPanel1.TabIndex = 48;
            // 
            // FormVoucherDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 782);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVoucherDiscount";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVoucherDiscount";
            this.TopMost = true;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnDiscount;
        private Guna.UI2.WinForms.Guna2Button btnVoucher;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
    }
}