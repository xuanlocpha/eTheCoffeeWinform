
namespace SquiredCoffee.FormManage
{
    partial class FormAddVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddVoucher));
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdStatus1 = new System.Windows.Forms.RadioButton();
            this.rdStatus2 = new System.Windows.Forms.RadioButton();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.txtCoupenCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ptQr_Code = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDiscountUnit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscount = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbApply = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuantityRule = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPriceRule = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptQr_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.SuspendLayout();
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1253, 60);
            this.bunifuGradientPanel1.TabIndex = 129;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(1214, 17);
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
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(76, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm mới Voucher";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label12.Location = new System.Drawing.Point(645, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 25);
            this.label12.TabIndex = 135;
            this.label12.Text = "Trạng Thái  :";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
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
            this.txtTitle.Location = new System.Drawing.Point(207, 78);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTitle.PlaceholderText = "...";
            this.txtTitle.SelectedText = "";
            this.txtTitle.ShadowDecoration.Parent = this.txtTitle;
            this.txtTitle.Size = new System.Drawing.Size(403, 47);
            this.txtTitle.TabIndex = 134;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label6.Location = new System.Drawing.Point(87, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 130;
            this.label6.Text = "Mô Tả :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 131;
            this.label2.Text = "Tên Voucher :";
            // 
            // rdStatus1
            // 
            this.rdStatus1.AutoSize = true;
            this.rdStatus1.Checked = true;
            this.rdStatus1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus1.Location = new System.Drawing.Point(855, 237);
            this.rdStatus1.Name = "rdStatus1";
            this.rdStatus1.Size = new System.Drawing.Size(128, 29);
            this.rdStatus1.TabIndex = 132;
            this.rdStatus1.TabStop = true;
            this.rdStatus1.Text = "Kích Hoạt ";
            this.rdStatus1.UseVisualStyleBackColor = true;
            this.rdStatus1.CheckedChanged += new System.EventHandler(this.rdStatus1_CheckedChanged);
            // 
            // rdStatus2
            // 
            this.rdStatus2.AutoSize = true;
            this.rdStatus2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus2.Location = new System.Drawing.Point(1032, 239);
            this.rdStatus2.Name = "rdStatus2";
            this.rdStatus2.Size = new System.Drawing.Size(125, 29);
            this.rdStatus2.TabIndex = 133;
            this.rdStatus2.Text = "Tạm Khóa";
            this.rdStatus2.UseVisualStyleBackColor = true;
            this.rdStatus2.CheckedChanged += new System.EventHandler(this.rdStatus2_CheckedChanged);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // txtCoupenCode
            // 
            this.txtCoupenCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtCoupenCode.BorderRadius = 15;
            this.txtCoupenCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCoupenCode.DefaultText = "";
            this.txtCoupenCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCoupenCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCoupenCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCoupenCode.DisabledState.Parent = this.txtCoupenCode;
            this.txtCoupenCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCoupenCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCoupenCode.FocusedState.Parent = this.txtCoupenCode;
            this.txtCoupenCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoupenCode.ForeColor = System.Drawing.Color.Black;
            this.txtCoupenCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCoupenCode.HoverState.Parent = this.txtCoupenCode;
            this.txtCoupenCode.Location = new System.Drawing.Point(207, 223);
            this.txtCoupenCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCoupenCode.Name = "txtCoupenCode";
            this.txtCoupenCode.PasswordChar = '\0';
            this.txtCoupenCode.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCoupenCode.PlaceholderText = "...";
            this.txtCoupenCode.SelectedText = "";
            this.txtCoupenCode.ShadowDecoration.Parent = this.txtCoupenCode;
            this.txtCoupenCode.Size = new System.Drawing.Size(403, 47);
            this.txtCoupenCode.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label3.Location = new System.Drawing.Point(22, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 138;
            this.label3.Text = "Coupen Code :";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 15;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.DisabledState.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.Tomato;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageOffset = new System.Drawing.Point(0, -4);
            this.btnSave.ImageSize = new System.Drawing.Size(22, 22);
            this.btnSave.Location = new System.Drawing.Point(409, 754);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(560, 57);
            this.btnSave.TabIndex = 136;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContent
            // 
            this.txtContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtContent.BorderRadius = 15;
            this.txtContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContent.DefaultText = "";
            this.txtContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContent.DisabledState.Parent = this.txtContent;
            this.txtContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContent.FocusedState.Parent = this.txtContent;
            this.txtContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.ForeColor = System.Drawing.Color.Black;
            this.txtContent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContent.HoverState.Parent = this.txtContent;
            this.txtContent.Location = new System.Drawing.Point(207, 148);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Name = "txtContent";
            this.txtContent.PasswordChar = '\0';
            this.txtContent.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtContent.PlaceholderText = "...";
            this.txtContent.SelectedText = "";
            this.txtContent.ShadowDecoration.Parent = this.txtContent;
            this.txtContent.Size = new System.Drawing.Size(403, 47);
            this.txtContent.TabIndex = 137;
            this.txtContent.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(207, 300);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(403, 30);
            this.dtpStartDate.TabIndex = 141;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label7.Location = new System.Drawing.Point(18, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 140;
            this.label7.Text = "Ngày Bắt Đầu :";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpExpiryDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiryDate.Location = new System.Drawing.Point(207, 374);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(403, 30);
            this.dtpExpiryDate.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label4.Location = new System.Drawing.Point(18, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 142;
            this.label4.Text = "Ngày Kết Thúc :";
            // 
            // ptQr_Code
            // 
            this.ptQr_Code.BackColor = System.Drawing.Color.White;
            this.ptQr_Code.Image = ((System.Drawing.Image)(resources.GetObject("ptQr_Code.Image")));
            this.ptQr_Code.Location = new System.Drawing.Point(211, 617);
            this.ptQr_Code.Name = "ptQr_Code";
            this.ptQr_Code.Size = new System.Drawing.Size(151, 118);
            this.ptQr_Code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptQr_Code.TabIndex = 144;
            this.ptQr_Code.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label5.Location = new System.Drawing.Point(75, 650);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 25);
            this.label5.TabIndex = 145;
            this.label5.Text = "QR Code :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label8.Location = new System.Drawing.Point(30, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 25);
            this.label8.TabIndex = 146;
            this.label8.Text = "Phương Thức :";
            // 
            // cbDiscountUnit
            // 
            this.cbDiscountUnit.BackColor = System.Drawing.Color.Transparent;
            this.cbDiscountUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.cbDiscountUnit.BorderRadius = 15;
            this.cbDiscountUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDiscountUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscountUnit.FocusedColor = System.Drawing.Color.Empty;
            this.cbDiscountUnit.FocusedState.Parent = this.cbDiscountUnit;
            this.cbDiscountUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDiscountUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDiscountUnit.FormattingEnabled = true;
            this.cbDiscountUnit.HoverState.Parent = this.cbDiscountUnit;
            this.cbDiscountUnit.ItemHeight = 30;
            this.cbDiscountUnit.Items.AddRange(new object[] {
            "cash",
            "percent"});
            this.cbDiscountUnit.ItemsAppearance.Parent = this.cbDiscountUnit;
            this.cbDiscountUnit.Location = new System.Drawing.Point(205, 426);
            this.cbDiscountUnit.Name = "cbDiscountUnit";
            this.cbDiscountUnit.ShadowDecoration.Parent = this.cbDiscountUnit;
            this.cbDiscountUnit.Size = new System.Drawing.Size(403, 36);
            this.cbDiscountUnit.TabIndex = 147;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label9.Location = new System.Drawing.Point(50, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 25);
            this.label9.TabIndex = 148;
            this.label9.Text = "Chiết Khấu :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtDiscount.BorderRadius = 15;
            this.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscount.DefaultText = "";
            this.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.DisabledState.Parent = this.txtDiscount;
            this.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.FocusedState.Parent = this.txtDiscount;
            this.txtDiscount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Black;
            this.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.HoverState.Parent = this.txtDiscount;
            this.txtDiscount.Location = new System.Drawing.Point(205, 485);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtDiscount.PlaceholderText = "...";
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.ShadowDecoration.Parent = this.txtDiscount;
            this.txtDiscount.Size = new System.Drawing.Size(403, 47);
            this.txtDiscount.TabIndex = 149;
            // 
            // cbApply
            // 
            this.cbApply.BackColor = System.Drawing.Color.Transparent;
            this.cbApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.cbApply.BorderRadius = 15;
            this.cbApply.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbApply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApply.FocusedColor = System.Drawing.Color.Empty;
            this.cbApply.FocusedState.Parent = this.cbApply;
            this.cbApply.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbApply.FormattingEnabled = true;
            this.cbApply.HoverState.Parent = this.cbApply;
            this.cbApply.ItemHeight = 30;
            this.cbApply.Items.AddRange(new object[] {
            "product",
            "category",
            "order"});
            this.cbApply.ItemsAppearance.Parent = this.cbApply;
            this.cbApply.Location = new System.Drawing.Point(205, 558);
            this.cbApply.Name = "cbApply";
            this.cbApply.ShadowDecoration.Parent = this.cbApply;
            this.cbApply.Size = new System.Drawing.Size(403, 36);
            this.cbApply.TabIndex = 151;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label10.Location = new System.Drawing.Point(75, 565);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 25);
            this.label10.TabIndex = 150;
            this.label10.Text = "Áp Dụng :";
            // 
            // txtQuantityRule
            // 
            this.txtQuantityRule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtQuantityRule.BorderRadius = 15;
            this.txtQuantityRule.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantityRule.DefaultText = "";
            this.txtQuantityRule.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantityRule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantityRule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityRule.DisabledState.Parent = this.txtQuantityRule;
            this.txtQuantityRule.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityRule.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityRule.FocusedState.Parent = this.txtQuantityRule;
            this.txtQuantityRule.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityRule.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityRule.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityRule.HoverState.Parent = this.txtQuantityRule;
            this.txtQuantityRule.Location = new System.Drawing.Point(806, 76);
            this.txtQuantityRule.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantityRule.Name = "txtQuantityRule";
            this.txtQuantityRule.PasswordChar = '\0';
            this.txtQuantityRule.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtQuantityRule.PlaceholderText = "...";
            this.txtQuantityRule.SelectedText = "";
            this.txtQuantityRule.ShadowDecoration.Parent = this.txtQuantityRule;
            this.txtQuantityRule.Size = new System.Drawing.Size(403, 47);
            this.txtQuantityRule.TabIndex = 153;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label11.Location = new System.Drawing.Point(665, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 25);
            this.label11.TabIndex = 152;
            this.label11.Text = "Số Lượng :";
            // 
            // txtPriceRule
            // 
            this.txtPriceRule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtPriceRule.BorderRadius = 15;
            this.txtPriceRule.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPriceRule.DefaultText = "";
            this.txtPriceRule.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPriceRule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPriceRule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceRule.DisabledState.Parent = this.txtPriceRule;
            this.txtPriceRule.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceRule.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceRule.FocusedState.Parent = this.txtPriceRule;
            this.txtPriceRule.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceRule.ForeColor = System.Drawing.Color.Black;
            this.txtPriceRule.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceRule.HoverState.Parent = this.txtPriceRule;
            this.txtPriceRule.Location = new System.Drawing.Point(806, 150);
            this.txtPriceRule.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriceRule.Name = "txtPriceRule";
            this.txtPriceRule.PasswordChar = '\0';
            this.txtPriceRule.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPriceRule.PlaceholderText = "...";
            this.txtPriceRule.SelectedText = "";
            this.txtPriceRule.ShadowDecoration.Parent = this.txtPriceRule;
            this.txtPriceRule.Size = new System.Drawing.Size(403, 47);
            this.txtPriceRule.TabIndex = 155;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label13.Location = new System.Drawing.Point(644, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 25);
            this.label13.TabIndex = 154;
            this.label13.Text = "Giá tối thiểu :";
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BorderRadius = 15;
            this.btnChooseImage.CheckedState.Parent = this.btnChooseImage;
            this.btnChooseImage.CustomImages.Parent = this.btnChooseImage;
            this.btnChooseImage.DisabledState.Parent = this.btnChooseImage;
            this.btnChooseImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.HoverState.Parent = this.btnChooseImage;
            this.btnChooseImage.Location = new System.Drawing.Point(810, 683);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.ShadowDecoration.Parent = this.btnChooseImage;
            this.btnChooseImage.Size = new System.Drawing.Size(399, 45);
            this.btnChooseImage.TabIndex = 158;
            this.btnChooseImage.Text = "Chọn hình";
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // ptImage
            // 
            this.ptImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ptImage.Image = ((System.Drawing.Image)(resources.GetObject("ptImage.Image")));
            this.ptImage.Location = new System.Drawing.Point(810, 303);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(399, 365);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptImage.TabIndex = 157;
            this.ptImage.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label14.Location = new System.Drawing.Point(645, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 25);
            this.label14.TabIndex = 156;
            this.label14.Text = "Hình Ảnh :";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.dtpStartDate;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 15;
            this.guna2Elipse3.TargetControl = this.dtpExpiryDate;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 20;
            this.guna2Elipse4.TargetControl = this.ptImage;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.BorderRadius = 10;
            this.guna2Elipse5.TargetControl = this.ptQr_Code;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormAddVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1253, 833);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.ptImage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPriceRule);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtQuantityRule);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbApply);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cbDiscountUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ptQr_Code);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdStatus1);
            this.Controls.Add(this.rdStatus2);
            this.Controls.Add(this.txtCoupenCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddVoucher";
            this.Load += new System.EventHandler(this.FormAddVoucher_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptQr_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdStatus1;
        private System.Windows.Forms.RadioButton rdStatus2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox txtCoupenCode;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtContent;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ptQr_Code;
        private Guna.UI2.WinForms.Guna2ComboBox cbDiscountUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscount;
        private Guna.UI2.WinForms.Guna2ComboBox cbApply;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantityRule;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtPriceRule;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button btnChooseImage;
        private System.Windows.Forms.PictureBox ptImage;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private System.Windows.Forms.Timer timer1;
    }
}