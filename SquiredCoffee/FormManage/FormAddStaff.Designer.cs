
namespace SquiredCoffee.FormManage
{
    partial class FormAddStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddStaff));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.chkFemale = new System.Windows.Forms.CheckBox();
            this.chkMale = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtlast_name = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdStatus1 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rdStatus2 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cbRoleName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 735);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
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
            this.btnSave.Location = new System.Drawing.Point(424, 652);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(408, 57);
            this.btnSave.TabIndex = 131;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpBirthday.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(217, 284);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(391, 30);
            this.dtpBirthday.TabIndex = 136;
            // 
            // chkFemale
            // 
            this.chkFemale.AutoSize = true;
            this.chkFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.chkFemale.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.chkFemale.Location = new System.Drawing.Point(341, 221);
            this.chkFemale.Name = "chkFemale";
            this.chkFemale.Size = new System.Drawing.Size(62, 34);
            this.chkFemale.TabIndex = 135;
            this.chkFemale.Text = "Nữ";
            this.chkFemale.UseVisualStyleBackColor = false;
            this.chkFemale.CheckedChanged += new System.EventHandler(this.chkFemale_CheckedChanged);
            // 
            // chkMale
            // 
            this.chkMale.AutoSize = true;
            this.chkMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.chkMale.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.chkMale.Location = new System.Drawing.Point(217, 221);
            this.chkMale.Name = "chkMale";
            this.chkMale.Size = new System.Drawing.Size(81, 34);
            this.chkMale.TabIndex = 134;
            this.chkMale.Text = "Nam";
            this.chkMale.UseVisualStyleBackColor = false;
            this.chkMale.CheckedChanged += new System.EventHandler(this.chkMale_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label12.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label12.Location = new System.Drawing.Point(629, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 30);
            this.label12.TabIndex = 133;
            this.label12.Text = "Trạng Thái  :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtFirstName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtFirstName.BorderRadius = 15;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.DisabledState.Parent = this.txtFirstName;
            this.txtFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.FocusedState.Parent = this.txtFirstName;
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirstName.HoverState.Parent = this.txtFirstName;
            this.txtFirstName.Location = new System.Drawing.Point(217, 83);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = '\0';
            this.txtFirstName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtFirstName.PlaceholderText = "...";
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.ShadowDecoration.Parent = this.txtFirstName;
            this.txtFirstName.Size = new System.Drawing.Size(397, 47);
            this.txtFirstName.TabIndex = 132;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.btnChooseImage.BorderRadius = 15;
            this.btnChooseImage.CheckedState.Parent = this.btnChooseImage;
            this.btnChooseImage.CustomImages.Parent = this.btnChooseImage;
            this.btnChooseImage.DisabledState.Parent = this.btnChooseImage;
            this.btnChooseImage.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.HoverState.Parent = this.btnChooseImage;
            this.btnChooseImage.Location = new System.Drawing.Point(806, 572);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.ShadowDecoration.Parent = this.btnChooseImage;
            this.btnChooseImage.Size = new System.Drawing.Size(393, 45);
            this.btnChooseImage.TabIndex = 130;
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
            this.ptImage.Location = new System.Drawing.Point(806, 228);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(393, 329);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptImage.TabIndex = 129;
            this.ptImage.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label10.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label10.Location = new System.Drawing.Point(649, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 30);
            this.label10.TabIndex = 128;
            this.label10.Text = "Hình Ảnh :";
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
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(10, 10);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1218, 60);
            this.bunifuGradientPanel1.TabIndex = 110;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(1162, 17);
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
            this.label1.Location = new System.Drawing.Point(76, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Mới Nhân Viên";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtPassword.BorderRadius = 15;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new System.Drawing.Point(211, 587);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPassword.PlaceholderText = "Password đăng nhập ...";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(397, 47);
            this.txtPassword.TabIndex = 127;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label3.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label3.Location = new System.Drawing.Point(25, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 30);
            this.label3.TabIndex = 112;
            this.label3.Text = "Số Điện Thoại :";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtUserName.BorderRadius = 15;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.Parent = this.txtUserName;
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.FocusedState.Parent = this.txtUserName;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.HoverState.Parent = this.txtUserName;
            this.txtUserName.Location = new System.Drawing.Point(211, 510);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtUserName.PlaceholderText = "UserName đăng nhập ...";
            this.txtUserName.SelectedText = "";
            this.txtUserName.ShadowDecoration.Parent = this.txtUserName;
            this.txtUserName.Size = new System.Drawing.Size(397, 47);
            this.txtUserName.TabIndex = 126;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label6.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label6.Location = new System.Drawing.Point(20, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 30);
            this.label6.TabIndex = 111;
            this.label6.Text = "Tên Lót && Tên  :";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtEmail.BorderRadius = 15;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(214, 430);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmail.PlaceholderText = "Email nhân viên ...";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(397, 47);
            this.txtEmail.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label4.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label4.Location = new System.Drawing.Point(80, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 30);
            this.label4.TabIndex = 113;
            this.label4.Text = "Email  :";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtPhone.BorderRadius = 15;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.Parent = this.txtPhone;
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.FocusedState.Parent = this.txtPhone;
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.HoverState.Parent = this.txtPhone;
            this.txtPhone.Location = new System.Drawing.Point(214, 348);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPhone.PlaceholderText = "Số điện thoại nhân viên ...";
            this.txtPhone.SelectedText = "";
            this.txtPhone.ShadowDecoration.Parent = this.txtPhone;
            this.txtPhone.Size = new System.Drawing.Size(400, 47);
            this.txtPhone.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(125, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 30);
            this.label2.TabIndex = 114;
            this.label2.Text = "Họ  :";
            // 
            // txtlast_name
            // 
            this.txtlast_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtlast_name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtlast_name.BorderRadius = 15;
            this.txtlast_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtlast_name.DefaultText = "";
            this.txtlast_name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtlast_name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtlast_name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtlast_name.DisabledState.Parent = this.txtlast_name;
            this.txtlast_name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtlast_name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtlast_name.FocusedState.Parent = this.txtlast_name;
            this.txtlast_name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlast_name.ForeColor = System.Drawing.Color.Black;
            this.txtlast_name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtlast_name.HoverState.Parent = this.txtlast_name;
            this.txtlast_name.Location = new System.Drawing.Point(214, 158);
            this.txtlast_name.Margin = new System.Windows.Forms.Padding(4);
            this.txtlast_name.Name = "txtlast_name";
            this.txtlast_name.PasswordChar = '\0';
            this.txtlast_name.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtlast_name.PlaceholderText = "Tên & Tên lót nhân viên ...";
            this.txtlast_name.SelectedText = "";
            this.txtlast_name.ShadowDecoration.Parent = this.txtlast_name;
            this.txtlast_name.Size = new System.Drawing.Size(397, 47);
            this.txtlast_name.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label5.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label5.Location = new System.Drawing.Point(73, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 30);
            this.label5.TabIndex = 116;
            this.label5.Text = "Giới Tính:";
            // 
            // rdStatus1
            // 
            this.rdStatus1.AutoSize = true;
            this.rdStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.rdStatus1.Checked = true;
            this.rdStatus1.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus1.Location = new System.Drawing.Point(806, 161);
            this.rdStatus1.Name = "rdStatus1";
            this.rdStatus1.Size = new System.Drawing.Size(133, 34);
            this.rdStatus1.TabIndex = 117;
            this.rdStatus1.TabStop = true;
            this.rdStatus1.Text = "Kích Hoạt ";
            this.rdStatus1.UseVisualStyleBackColor = false;
            this.rdStatus1.CheckedChanged += new System.EventHandler(this.rdStatus1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label11.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label11.Location = new System.Drawing.Point(680, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 30);
            this.label11.TabIndex = 121;
            this.label11.Text = "Quyền :";
            // 
            // rdStatus2
            // 
            this.rdStatus2.AutoSize = true;
            this.rdStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.rdStatus2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus2.Location = new System.Drawing.Point(983, 163);
            this.rdStatus2.Name = "rdStatus2";
            this.rdStatus2.Size = new System.Drawing.Size(132, 34);
            this.rdStatus2.TabIndex = 118;
            this.rdStatus2.Text = "Tạm Khóa";
            this.rdStatus2.UseVisualStyleBackColor = false;
            this.rdStatus2.CheckedChanged += new System.EventHandler(this.rdStatus2_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label9.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label9.Location = new System.Drawing.Point(51, 596);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 30);
            this.label9.TabIndex = 120;
            this.label9.Text = "Password :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label8.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label8.Location = new System.Drawing.Point(43, 514);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 30);
            this.label8.TabIndex = 119;
            this.label8.Text = "UserName :";
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.TargetControl = this.dtpBirthday;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.ptImage;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.label7.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label7.Location = new System.Drawing.Point(63, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 30);
            this.label7.TabIndex = 115;
            this.label7.Text = "Ngày Sinh :";
            // 
            // cbRoleName
            // 
            this.cbRoleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.cbRoleName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.cbRoleName.BorderRadius = 15;
            this.cbRoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoleName.FocusedColor = System.Drawing.Color.Empty;
            this.cbRoleName.FocusedState.Parent = this.cbRoleName;
            this.cbRoleName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbRoleName.FormattingEnabled = true;
            this.cbRoleName.HoverState.Parent = this.cbRoleName;
            this.cbRoleName.ItemHeight = 30;
            this.cbRoleName.ItemsAppearance.Parent = this.cbRoleName;
            this.cbRoleName.Location = new System.Drawing.Point(806, 88);
            this.cbRoleName.Name = "cbRoleName";
            this.cbRoleName.ShadowDecoration.Parent = this.cbRoleName;
            this.cbRoleName.Size = new System.Drawing.Size(393, 36);
            this.cbRoleName.TabIndex = 122;
            // 
            // FormAddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(79)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1238, 755);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.chkFemale);
            this.Controls.Add(this.chkMale);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.ptImage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtlast_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdStatus1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rdStatus2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbRoleName);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddStaff";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddStaff";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAddStaff_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.CheckBox chkFemale;
        private System.Windows.Forms.CheckBox chkMale;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnChooseImage;
        private System.Windows.Forms.PictureBox ptImage;
        private System.Windows.Forms.Label label10;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtlast_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdStatus1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdStatus2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoleName;
    }
}