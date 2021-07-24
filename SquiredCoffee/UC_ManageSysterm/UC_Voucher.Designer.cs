
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_Voucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Voucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisscount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDisscount_Unit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVoucherName = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ptQr_Code = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbStatus2 = new System.Windows.Forms.RadioButton();
            this.rbStatus1 = new System.Windows.Forms.RadioButton();
            this.txtMinimum_Order = new System.Windows.Forms.TextBox();
            this.dtpExpiry_Date = new System.Windows.Forms.DateTimePicker();
            this.dtpStart_Date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptQr_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1644, 45);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Voucher";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStaff);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1644, 299);
            this.panel2.TabIndex = 32;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AllowUserToResizeColumns = false;
            this.dgvStaff.AllowUserToResizeRows = false;
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaff.ColumnHeadersHeight = 30;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvStaff.EnableHeadersVisualStyles = false;
            this.dgvStaff.Location = new System.Drawing.Point(0, 6);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.ShowEditingIcon = false;
            this.dgvStaff.Size = new System.Drawing.Size(1644, 293);
            this.dgvStaff.TabIndex = 5;
            // 
            // txtCoupon
            // 
            this.txtCoupon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoupon.ForeColor = System.Drawing.Color.Black;
            this.txtCoupon.Location = new System.Drawing.Point(223, 141);
            this.txtCoupon.Multiline = true;
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(352, 32);
            this.txtCoupon.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(597, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "Trạng Thái:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(597, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 25);
            this.label11.TabIndex = 31;
            this.label11.Text = "Đơn Vị Giảm :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(597, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "QR_Code :";
            // 
            // txtDisscount
            // 
            this.txtDisscount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisscount.ForeColor = System.Drawing.Color.Black;
            this.txtDisscount.Location = new System.Drawing.Point(782, 81);
            this.txtDisscount.Multiline = true;
            this.txtDisscount.Name = "txtDisscount";
            this.txtDisscount.Size = new System.Drawing.Size(360, 32);
            this.txtDisscount.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(21, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Điều Kiện Giảm  :";
            // 
            // txtDisscount_Unit
            // 
            this.txtDisscount_Unit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisscount_Unit.ForeColor = System.Drawing.Color.Black;
            this.txtDisscount_Unit.Location = new System.Drawing.Point(781, 28);
            this.txtDisscount_Unit.Multiline = true;
            this.txtDisscount_Unit.Name = "txtDisscount_Unit";
            this.txtDisscount_Unit.Size = new System.Drawing.Size(361, 32);
            this.txtDisscount_Unit.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(597, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Giá Trị Giảm:";
            // 
            // txtVoucherName
            // 
            this.txtVoucherName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherName.ForeColor = System.Drawing.Color.Black;
            this.txtVoucherName.Location = new System.Drawing.Point(223, 29);
            this.txtVoucherName.Multiline = true;
            this.txtVoucherName.Name = "txtVoucherName";
            this.txtVoucherName.Size = new System.Drawing.Size(352, 32);
            this.txtVoucherName.TabIndex = 22;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(1132, 430);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(412, 38);
            this.txtSearch.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1544, 429);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.BackColor = System.Drawing.Color.Tomato;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(920, 427);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(146, 40);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "Làm Mới";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(690, 427);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 40);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.Tomato;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(476, 427);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 35;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.BackColor = System.Drawing.Color.Tomato;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(236, 427);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(155, 40);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.ptQr_Code);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.rbStatus2);
            this.groupBox1.Controls.Add(this.rbStatus1);
            this.groupBox1.Controls.Add(this.txtMinimum_Order);
            this.groupBox1.Controls.Add(this.dtpExpiry_Date);
            this.groupBox1.Controls.Add(this.dtpStart_Date);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCoupon);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDisscount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDisscount_Unit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtVoucherName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ptImage);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnChooseImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(15, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1610, 363);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Nhập Thông Tin";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.BackColor = System.Drawing.Color.Tomato;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(1010, 183);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(146, 40);
            this.btnGenerate.TabIndex = 40;
            this.btnGenerate.Text = "Mã Hóa";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ptQr_Code
            // 
            this.ptQr_Code.BackColor = System.Drawing.Color.White;
            this.ptQr_Code.Image = ((System.Drawing.Image)(resources.GetObject("ptQr_Code.Image")));
            this.ptQr_Code.Location = new System.Drawing.Point(781, 183);
            this.ptQr_Code.Name = "ptQr_Code";
            this.ptQr_Code.Size = new System.Drawing.Size(213, 167);
            this.ptQr_Code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptQr_Code.TabIndex = 50;
            this.ptQr_Code.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(461, 304);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 32);
            this.textBox2.TabIndex = 49;
            this.textBox2.Text = "Sản Phẩm";
            // 
            // rbStatus2
            // 
            this.rbStatus2.AutoSize = true;
            this.rbStatus2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStatus2.Location = new System.Drawing.Point(948, 143);
            this.rbStatus2.Name = "rbStatus2";
            this.rbStatus2.Size = new System.Drawing.Size(173, 26);
            this.rbStatus2.TabIndex = 48;
            this.rbStatus2.Text = "Ngưng Hoạt Động";
            this.rbStatus2.UseVisualStyleBackColor = true;
            // 
            // rbStatus1
            // 
            this.rbStatus1.AutoSize = true;
            this.rbStatus1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStatus1.Location = new System.Drawing.Point(782, 142);
            this.rbStatus1.Name = "rbStatus1";
            this.rbStatus1.Size = new System.Drawing.Size(116, 26);
            this.rbStatus1.TabIndex = 47;
            this.rbStatus1.Text = "Hoạt Động";
            this.rbStatus1.UseVisualStyleBackColor = true;
            // 
            // txtMinimum_Order
            // 
            this.txtMinimum_Order.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinimum_Order.ForeColor = System.Drawing.Color.Black;
            this.txtMinimum_Order.Location = new System.Drawing.Point(223, 304);
            this.txtMinimum_Order.Multiline = true;
            this.txtMinimum_Order.Name = "txtMinimum_Order";
            this.txtMinimum_Order.Size = new System.Drawing.Size(239, 32);
            this.txtMinimum_Order.TabIndex = 46;
            // 
            // dtpExpiry_Date
            // 
            this.dtpExpiry_Date.CustomFormat = "yyyy-MM-dd";
            this.dtpExpiry_Date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiry_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiry_Date.Location = new System.Drawing.Point(223, 257);
            this.dtpExpiry_Date.Name = "dtpExpiry_Date";
            this.dtpExpiry_Date.Size = new System.Drawing.Size(352, 30);
            this.dtpExpiry_Date.TabIndex = 45;
            // 
            // dtpStart_Date
            // 
            this.dtpStart_Date.CustomFormat = "yyyy-MM-dd";
            this.dtpStart_Date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Date.Location = new System.Drawing.Point(223, 198);
            this.dtpStart_Date.Name = "dtpStart_Date";
            this.dtpStart_Date.Size = new System.Drawing.Size(352, 30);
            this.dtpStart_Date.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 43;
            this.label4.Text = "Ngày Kết Thúc :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(22, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Ngày Bắt Đầu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên Voucher :";
            // 
            // ptImage
            // 
            this.ptImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ptImage.Image = ((System.Drawing.Image)(resources.GetObject("ptImage.Image")));
            this.ptImage.Location = new System.Drawing.Point(1239, 59);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(323, 273);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptImage.TabIndex = 20;
            this.ptImage.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1235, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Hình ảnh :";
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(1440, 18);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(122, 35);
            this.btnChooseImage.TabIndex = 11;
            this.btnChooseImage.Text = "Chọn Hình";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Coupon :";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.ForeColor = System.Drawing.Color.Black;
            this.txtContent.Location = new System.Drawing.Point(223, 83);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(352, 32);
            this.txtContent.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(19, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nội Dung Voucher :";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "title";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Tên Voucher";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "content";
            this.Column3.HeaderText = "Nội Dung Voucher";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "coupen_code";
            this.Column4.HeaderText = "Mã Coupon";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "start_date";
            this.Column5.HeaderText = "Ngày Bắt Đầu";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "expiry_date";
            this.Column6.HeaderText = "Ngày Kết Thúc";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "minimum_order";
            this.Column7.HeaderText = "Điều Kiện Tối Đa";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "disscount_unit";
            this.Column8.HeaderText = "Đơn Vị Giảm";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "disscount";
            this.Column9.HeaderText = "Giá Trị Giảm";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "status";
            this.Column10.FillWeight = 50F;
            this.Column10.HeaderText = "Trạng Thái";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "qr_code";
            this.Column11.HeaderText = "QR_Code";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "image";
            this.Column12.HeaderText = "Image";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // UC_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Voucher";
            this.Size = new System.Drawing.Size(1644, 776);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptQr_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDisscount_Unit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVoucherName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMinimum_Order;
        private System.Windows.Forms.DateTimePicker dtpExpiry_Date;
        private System.Windows.Forms.DateTimePicker dtpStart_Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbStatus2;
        private System.Windows.Forms.RadioButton rbStatus1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox ptQr_Code;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}
