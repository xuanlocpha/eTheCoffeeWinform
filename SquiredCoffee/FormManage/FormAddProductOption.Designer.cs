﻿
namespace SquiredCoffee.FormManage
{
    partial class FormAddProductOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProductOption));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDefault2 = new System.Windows.Forms.CheckBox();
            this.chkDefault1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rdStatus1 = new System.Windows.Forms.RadioButton();
            this.rdStatus2 = new System.Windows.Forms.RadioButton();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbOptionName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProductName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.chkDefault2);
            this.panel1.Controls.Add(this.chkDefault1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.rdStatus1);
            this.panel1.Controls.Add(this.rdStatus2);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbOptionName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbProductName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 533);
            this.panel1.TabIndex = 0;
            // 
            // chkDefault2
            // 
            this.chkDefault2.AutoSize = true;
            this.chkDefault2.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDefault2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.chkDefault2.Location = new System.Drawing.Point(454, 349);
            this.chkDefault2.Name = "chkDefault2";
            this.chkDefault2.Size = new System.Drawing.Size(206, 37);
            this.chkDefault2.TabIndex = 147;
            this.chkDefault2.Text = "Không Mặc định";
            this.chkDefault2.UseVisualStyleBackColor = true;
            this.chkDefault2.CheckedChanged += new System.EventHandler(this.chkDefault2_CheckedChanged);
            // 
            // chkDefault1
            // 
            this.chkDefault1.AutoSize = true;
            this.chkDefault1.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDefault1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.chkDefault1.Location = new System.Drawing.Point(236, 349);
            this.chkDefault1.Name = "chkDefault1";
            this.chkDefault1.Size = new System.Drawing.Size(131, 37);
            this.chkDefault1.TabIndex = 146;
            this.chkDefault1.Text = "Mặc định";
            this.chkDefault1.UseVisualStyleBackColor = true;
            this.chkDefault1.CheckedChanged += new System.EventHandler(this.chkDefault1_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 15;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.DisabledState.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.Tomato;
            this.btnSave.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(210, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(425, 57);
            this.btnSave.TabIndex = 145;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label5.Location = new System.Drawing.Point(74, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 33);
            this.label5.TabIndex = 144;
            this.label5.Text = "Mặc định  :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label12.Location = new System.Drawing.Point(57, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 33);
            this.label12.TabIndex = 143;
            this.label12.Text = "Trạng Thái  :";
            // 
            // rdStatus1
            // 
            this.rdStatus1.AutoSize = true;
            this.rdStatus1.Checked = true;
            this.rdStatus1.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus1.Location = new System.Drawing.Point(237, 413);
            this.rdStatus1.Name = "rdStatus1";
            this.rdStatus1.Size = new System.Drawing.Size(144, 37);
            this.rdStatus1.TabIndex = 141;
            this.rdStatus1.TabStop = true;
            this.rdStatus1.Text = "Kích Hoạt ";
            this.rdStatus1.UseVisualStyleBackColor = true;
            this.rdStatus1.CheckedChanged += new System.EventHandler(this.rdStatus1_CheckedChanged);
            // 
            // rdStatus2
            // 
            this.rdStatus2.AutoSize = true;
            this.rdStatus2.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus2.Location = new System.Drawing.Point(454, 413);
            this.rdStatus2.Name = "rdStatus2";
            this.rdStatus2.Size = new System.Drawing.Size(144, 37);
            this.rdStatus2.TabIndex = 142;
            this.rdStatus2.Text = "Tạm Khóa";
            this.rdStatus2.UseVisualStyleBackColor = true;
            this.rdStatus2.CheckedChanged += new System.EventHandler(this.rdStatus2_CheckedChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtPrice.BorderRadius = 15;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.DisabledState.Parent = this.txtPrice;
            this.txtPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrice.FocusedState.Parent = this.txtPrice;
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.Black;
            this.txtPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrice.HoverState.Parent = this.txtPrice;
            this.txtPrice.Location = new System.Drawing.Point(236, 272);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.PlaceholderForeColor = System.Drawing.Color.Maroon;
            this.txtPrice.PlaceholderText = "......";
            this.txtPrice.SelectedText = "";
            this.txtPrice.ShadowDecoration.Parent = this.txtPrice;
            this.txtPrice.Size = new System.Drawing.Size(397, 47);
            this.txtPrice.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label4.Location = new System.Drawing.Point(86, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 33);
            this.label4.TabIndex = 139;
            this.label4.Text = "Giá Tiền :";
            // 
            // cbOptionName
            // 
            this.cbOptionName.BackColor = System.Drawing.Color.Transparent;
            this.cbOptionName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.cbOptionName.BorderRadius = 15;
            this.cbOptionName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOptionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptionName.FocusedColor = System.Drawing.Color.Empty;
            this.cbOptionName.FocusedState.Parent = this.cbOptionName;
            this.cbOptionName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOptionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbOptionName.FormattingEnabled = true;
            this.cbOptionName.HoverState.Parent = this.cbOptionName;
            this.cbOptionName.ItemHeight = 30;
            this.cbOptionName.ItemsAppearance.Parent = this.cbOptionName;
            this.cbOptionName.Location = new System.Drawing.Point(236, 135);
            this.cbOptionName.Name = "cbOptionName";
            this.cbOptionName.ShadowDecoration.Parent = this.cbOptionName;
            this.cbOptionName.Size = new System.Drawing.Size(400, 36);
            this.cbOptionName.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label3.Location = new System.Drawing.Point(20, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 33);
            this.label3.TabIndex = 137;
            this.label3.Text = "Tên Tùy Chọn :";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtTitle.BorderRadius = 15;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.DefaultText = "";
            this.txtTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.DisabledState.Parent = this.txtTitle;
            this.txtTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.FocusedState.Parent = this.txtTitle;
            this.txtTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.HoverState.Parent = this.txtTitle;
            this.txtTitle.Location = new System.Drawing.Point(236, 198);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PlaceholderForeColor = System.Drawing.Color.Maroon;
            this.txtTitle.PlaceholderText = "......";
            this.txtTitle.SelectedText = "";
            this.txtTitle.ShadowDecoration.Parent = this.txtTitle;
            this.txtTitle.Size = new System.Drawing.Size(397, 47);
            this.txtTitle.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(86, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 33);
            this.label2.TabIndex = 133;
            this.label2.Text = "Tiêu Đề :";
            // 
            // cbProductName
            // 
            this.cbProductName.BackColor = System.Drawing.Color.Transparent;
            this.cbProductName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.cbProductName.BorderRadius = 15;
            this.cbProductName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductName.FocusedColor = System.Drawing.Color.Empty;
            this.cbProductName.FocusedState.Parent = this.cbProductName;
            this.cbProductName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.HoverState.Parent = this.cbProductName;
            this.cbProductName.ItemHeight = 30;
            this.cbProductName.ItemsAppearance.Parent = this.cbProductName;
            this.cbProductName.Location = new System.Drawing.Point(236, 76);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.ShadowDecoration.Parent = this.cbProductName;
            this.cbProductName.Size = new System.Drawing.Size(400, 36);
            this.cbProductName.TabIndex = 135;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label11.Location = new System.Drawing.Point(20, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 33);
            this.label11.TabIndex = 134;
            this.label11.Text = "Tên Sản Phẩm :";
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.btnClose);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DeepPink;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(60)))), ((int)(((byte)(212)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(723, 60);
            this.bunifuGradientPanel1.TabIndex = 132;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(672, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(76, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Mới Option Sản Phẩm";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.panel1;
            // 
            // FormAddProductOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(79)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(743, 553);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddProductOption";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddProductOption";
            this.Load += new System.EventHandler(this.FormAddProductOption_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkDefault2;
        private System.Windows.Forms.CheckBox chkDefault1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdStatus1;
        private System.Windows.Forms.RadioButton rdStatus2;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cbOptionName;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbProductName;
        private System.Windows.Forms.Label label11;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}