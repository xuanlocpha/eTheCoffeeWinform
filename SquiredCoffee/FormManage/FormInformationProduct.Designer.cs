
namespace SquiredCoffee.FormManage
{
    partial class FormInformationProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformationProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPriceProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbCategoryName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.rdStatus1 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rdStatus2 = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.btnChooseImage);
            this.panel1.Controls.Add(this.ptImage);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPriceProduct);
            this.panel1.Controls.Add(this.cbCategoryName);
            this.panel1.Controls.Add(this.rdStatus1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.rdStatus2);
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 652);
            this.panel1.TabIndex = 0;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 15;
            this.guna2Elipse3.TargetControl = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.txtContent;
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(221, 333);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(393, 216);
            this.txtContent.TabIndex = 154;
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 15;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.DisabledState.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDelete.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDelete.Location = new System.Drawing.Point(643, 576);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(393, 57);
            this.btnDelete.TabIndex = 156;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 15;
            this.btnEdit.CheckedState.Parent = this.btnEdit;
            this.btnEdit.CustomImages.Parent = this.btnEdit;
            this.btnEdit.DisabledState.Parent = this.btnEdit;
            this.btnEdit.FillColor = System.Drawing.Color.Tomato;
            this.btnEdit.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverState.Parent = this.btnEdit;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageSize = new System.Drawing.Size(30, 30);
            this.btnEdit.Location = new System.Drawing.Point(221, 579);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShadowDecoration.Parent = this.btnEdit;
            this.btnEdit.Size = new System.Drawing.Size(393, 57);
            this.btnEdit.TabIndex = 155;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BorderRadius = 15;
            this.btnChooseImage.CheckedState.Parent = this.btnChooseImage;
            this.btnChooseImage.CustomImages.Parent = this.btnChooseImage;
            this.btnChooseImage.DisabledState.Parent = this.btnChooseImage;
            this.btnChooseImage.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.HoverState.Parent = this.btnChooseImage;
            this.btnChooseImage.Location = new System.Drawing.Point(808, 507);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.ShadowDecoration.Parent = this.btnChooseImage;
            this.btnChooseImage.Size = new System.Drawing.Size(393, 45);
            this.btnChooseImage.TabIndex = 153;
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
            this.ptImage.Location = new System.Drawing.Point(805, 157);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(393, 342);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptImage.TabIndex = 152;
            this.ptImage.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label10.Location = new System.Drawing.Point(665, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 34);
            this.label10.TabIndex = 151;
            this.label10.Text = "Hình Ảnh :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label3.Location = new System.Drawing.Point(57, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 34);
            this.label3.TabIndex = 150;
            this.label3.Text = "Giới thiệu :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label12.Location = new System.Drawing.Point(648, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 34);
            this.label12.TabIndex = 149;
            this.label12.Text = "Trạng Thái  :";
            // 
            // txtProductName
            // 
            this.txtProductName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtProductName.BorderRadius = 15;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.DefaultText = "";
            this.txtProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.DisabledState.Parent = this.txtProductName;
            this.txtProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.FocusedState.Parent = this.txtProductName;
            this.txtProductName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.Black;
            this.txtProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductName.HoverState.Parent = this.txtProductName;
            this.txtProductName.Location = new System.Drawing.Point(217, 156);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.PlaceholderForeColor = System.Drawing.Color.Maroon;
            this.txtProductName.PlaceholderText = "......";
            this.txtProductName.SelectedText = "";
            this.txtProductName.ShadowDecoration.Parent = this.txtProductName;
            this.txtProductName.Size = new System.Drawing.Size(397, 47);
            this.txtProductName.TabIndex = 148;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label6.Location = new System.Drawing.Point(20, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 34);
            this.label6.TabIndex = 141;
            this.label6.Text = "Giá sản phẩm :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(20, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 34);
            this.label2.TabIndex = 142;
            this.label2.Text = "Tên sản phẩm :";
            // 
            // txtPriceProduct
            // 
            this.txtPriceProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.txtPriceProduct.BorderRadius = 15;
            this.txtPriceProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPriceProduct.DefaultText = "";
            this.txtPriceProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPriceProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPriceProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceProduct.DisabledState.Parent = this.txtPriceProduct;
            this.txtPriceProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceProduct.FocusedState.Parent = this.txtPriceProduct;
            this.txtPriceProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceProduct.ForeColor = System.Drawing.Color.Black;
            this.txtPriceProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceProduct.HoverState.Parent = this.txtPriceProduct;
            this.txtPriceProduct.Location = new System.Drawing.Point(217, 231);
            this.txtPriceProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriceProduct.Name = "txtPriceProduct";
            this.txtPriceProduct.PasswordChar = '\0';
            this.txtPriceProduct.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPriceProduct.PlaceholderText = "......";
            this.txtPriceProduct.SelectedText = "";
            this.txtPriceProduct.ShadowDecoration.Parent = this.txtPriceProduct;
            this.txtPriceProduct.Size = new System.Drawing.Size(397, 51);
            this.txtPriceProduct.TabIndex = 147;
            // 
            // cbCategoryName
            // 
            this.cbCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.cbCategoryName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.cbCategoryName.BorderRadius = 15;
            this.cbCategoryName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryName.FocusedColor = System.Drawing.Color.Empty;
            this.cbCategoryName.FocusedState.Parent = this.cbCategoryName;
            this.cbCategoryName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCategoryName.FormattingEnabled = true;
            this.cbCategoryName.HoverState.Parent = this.cbCategoryName;
            this.cbCategoryName.ItemHeight = 30;
            this.cbCategoryName.ItemsAppearance.Parent = this.cbCategoryName;
            this.cbCategoryName.Location = new System.Drawing.Point(221, 88);
            this.cbCategoryName.Name = "cbCategoryName";
            this.cbCategoryName.ShadowDecoration.Parent = this.cbCategoryName;
            this.cbCategoryName.Size = new System.Drawing.Size(393, 36);
            this.cbCategoryName.TabIndex = 146;
            // 
            // rdStatus1
            // 
            this.rdStatus1.AutoSize = true;
            this.rdStatus1.Checked = true;
            this.rdStatus1.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus1.Location = new System.Drawing.Point(845, 85);
            this.rdStatus1.Name = "rdStatus1";
            this.rdStatus1.Size = new System.Drawing.Size(147, 38);
            this.rdStatus1.TabIndex = 143;
            this.rdStatus1.TabStop = true;
            this.rdStatus1.Text = "Kích Hoạt ";
            this.rdStatus1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label11.Location = new System.Drawing.Point(12, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 34);
            this.label11.TabIndex = 145;
            this.label11.Text = "Loại Sản Phẩm :";
            // 
            // rdStatus2
            // 
            this.rdStatus2.AutoSize = true;
            this.rdStatus2.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus2.Location = new System.Drawing.Point(1035, 85);
            this.rdStatus2.Name = "rdStatus2";
            this.rdStatus2.Size = new System.Drawing.Size(145, 38);
            this.rdStatus2.TabIndex = 144;
            this.rdStatus2.Text = "Tạm Khóa";
            this.rdStatus2.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(1160, 17);
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
            this.label1.Size = new System.Drawing.Size(240, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Sản Phẩm";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.ptImage;
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1211, 60);
            this.bunifuGradientPanel1.TabIndex = 140;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 15;
            this.guna2Elipse4.TargetControl = this.panel1;
            // 
            // FormInformationProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(79)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(1231, 672);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInformationProduct";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInformationProduct";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormInformationProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private System.Windows.Forms.TextBox txtContent;
        private Guna.UI2.WinForms.Guna2Button btnChooseImage;
        private System.Windows.Forms.PictureBox ptImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtPriceProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategoryName;
        private System.Windows.Forms.RadioButton rdStatus1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdStatus2;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
    }
}