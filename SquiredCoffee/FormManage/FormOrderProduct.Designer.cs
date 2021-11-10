
namespace SquiredCoffee.FormManage
{
    partial class FormOrderProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbTopping = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSugar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbIce = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSize = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ptImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.PictureBox();
            this.btnPlus = new System.Windows.Forms.PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblProductName1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.cbTopping);
            this.panel1.Controls.Add(this.cbSugar);
            this.panel1.Controls.Add(this.cbIce);
            this.panel1.Controls.Add(this.cbSize);
            this.panel1.Controls.Add(this.ptImage);
            this.panel1.Controls.Add(this.guna2GradientPanel1);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnMinus);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblProductName1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 818);
            this.panel1.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Animated = true;
            this.txtAmount.AutoRoundedCorners = true;
            this.txtAmount.BorderRadius = 20;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "1";
            this.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.DisabledState.Parent = this.txtAmount;
            this.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.FocusedState.Parent = this.txtAmount;
            this.txtAmount.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.HoverState.Parent = this.txtAmount;
            this.txtAmount.Location = new System.Drawing.Point(454, 205);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionStart = 1;
            this.txtAmount.ShadowDecoration.Parent = this.txtAmount;
            this.txtAmount.Size = new System.Drawing.Size(207, 42);
            this.txtAmount.TabIndex = 176;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // cbTopping
            // 
            this.cbTopping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.cbTopping.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.cbTopping.BorderRadius = 15;
            this.cbTopping.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTopping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopping.FocusedColor = System.Drawing.Color.Empty;
            this.cbTopping.FocusedState.Parent = this.cbTopping;
            this.cbTopping.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTopping.ForeColor = System.Drawing.Color.Black;
            this.cbTopping.FormattingEnabled = true;
            this.cbTopping.HoverState.Parent = this.cbTopping;
            this.cbTopping.ItemHeight = 30;
            this.cbTopping.ItemsAppearance.Parent = this.cbTopping;
            this.cbTopping.Location = new System.Drawing.Point(60, 635);
            this.cbTopping.Name = "cbTopping";
            this.cbTopping.ShadowDecoration.Parent = this.cbTopping;
            this.cbTopping.Size = new System.Drawing.Size(701, 36);
            this.cbTopping.TabIndex = 175;
            this.cbTopping.SelectedValueChanged += new System.EventHandler(this.cbTopping_SelectedValueChanged);
            // 
            // cbSugar
            // 
            this.cbSugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.cbSugar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.cbSugar.BorderRadius = 15;
            this.cbSugar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSugar.FocusedColor = System.Drawing.Color.Empty;
            this.cbSugar.FocusedState.Parent = this.cbSugar;
            this.cbSugar.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSugar.ForeColor = System.Drawing.Color.Black;
            this.cbSugar.FormattingEnabled = true;
            this.cbSugar.HoverState.Parent = this.cbSugar;
            this.cbSugar.ItemHeight = 30;
            this.cbSugar.ItemsAppearance.Parent = this.cbSugar;
            this.cbSugar.Location = new System.Drawing.Point(60, 530);
            this.cbSugar.Name = "cbSugar";
            this.cbSugar.ShadowDecoration.Parent = this.cbSugar;
            this.cbSugar.Size = new System.Drawing.Size(701, 36);
            this.cbSugar.TabIndex = 174;
            this.cbSugar.SelectedValueChanged += new System.EventHandler(this.cbSugar_SelectedValueChanged);
            // 
            // cbIce
            // 
            this.cbIce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.cbIce.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.cbIce.BorderRadius = 15;
            this.cbIce.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIce.FocusedColor = System.Drawing.Color.Empty;
            this.cbIce.FocusedState.Parent = this.cbIce;
            this.cbIce.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIce.ForeColor = System.Drawing.Color.Black;
            this.cbIce.FormattingEnabled = true;
            this.cbIce.HoverState.Parent = this.cbIce;
            this.cbIce.ItemHeight = 30;
            this.cbIce.ItemsAppearance.Parent = this.cbIce;
            this.cbIce.Location = new System.Drawing.Point(59, 424);
            this.cbIce.Name = "cbIce";
            this.cbIce.ShadowDecoration.Parent = this.cbIce;
            this.cbIce.Size = new System.Drawing.Size(701, 36);
            this.cbIce.TabIndex = 173;
            this.cbIce.SelectedValueChanged += new System.EventHandler(this.cbIce_SelectedValueChanged);
            // 
            // cbSize
            // 
            this.cbSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(171)))), ((int)(((byte)(84)))));
            this.cbSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.cbSize.BorderRadius = 15;
            this.cbSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FocusedColor = System.Drawing.Color.Empty;
            this.cbSize.FocusedState.Parent = this.cbSize;
            this.cbSize.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSize.ForeColor = System.Drawing.Color.Black;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.HoverState.Parent = this.cbSize;
            this.cbSize.ItemHeight = 30;
            this.cbSize.ItemsAppearance.Parent = this.cbSize;
            this.cbSize.Location = new System.Drawing.Point(60, 330);
            this.cbSize.Name = "cbSize";
            this.cbSize.ShadowDecoration.Parent = this.cbSize;
            this.cbSize.Size = new System.Drawing.Size(701, 36);
            this.cbSize.TabIndex = 172;
            this.cbSize.SelectedValueChanged += new System.EventHandler(this.cbSize_SelectedValueChanged);
            // 
            // ptImage
            // 
            this.ptImage.BorderRadius = 10;
            this.ptImage.Image = ((System.Drawing.Image)(resources.GetObject("ptImage.Image")));
            this.ptImage.ImageRotate = 0F;
            this.ptImage.Location = new System.Drawing.Point(24, 77);
            this.ptImage.Name = "ptImage";
            this.ptImage.ShadowDecoration.Parent = this.ptImage;
            this.ptImage.Size = new System.Drawing.Size(209, 200);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptImage.TabIndex = 171;
            this.ptImage.TabStop = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.pbClose);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(809, 54);
            this.guna2GradientPanel1.TabIndex = 169;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Quicksand", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(267, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chi Tiết Sản Phẩm Chọn";
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(763, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(46, 54);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrder.BorderRadius = 15;
            this.btnOrder.CheckedState.Parent = this.btnOrder;
            this.btnOrder.CustomImages.Parent = this.btnOrder;
            this.btnOrder.DisabledState.Parent = this.btnOrder;
            this.btnOrder.FillColor = System.Drawing.Color.Tomato;
            this.btnOrder.Font = new System.Drawing.Font("Quicksand", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.HoverState.Parent = this.btnOrder;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageOffset = new System.Drawing.Point(0, 3);
            this.btnOrder.ImageSize = new System.Drawing.Size(30, 30);
            this.btnOrder.Location = new System.Drawing.Point(154, 746);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.ShadowDecoration.Parent = this.btnOrder;
            this.btnOrder.Size = new System.Drawing.Size(570, 64);
            this.btnOrder.TabIndex = 168;
            this.btnOrder.Text = "Order";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(242, 690);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(93, 44);
            this.lblTotal.TabIndex = 152;
            this.lblTotal.Text = "Total";
            // 
            // btnMinus
            // 
            this.btnMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnMinus.Image")));
            this.btnMinus.Location = new System.Drawing.Point(402, 207);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(45, 40);
            this.btnMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMinus.TabIndex = 165;
            this.btnMinus.TabStop = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(668, 207);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(45, 40);
            this.btnPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPlus.TabIndex = 164;
            this.btnPlus.TabStop = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(452, 152);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(67, 33);
            this.lblPrice.TabIndex = 162;
            this.lblPrice.Text = "Price";
            // 
            // lblProductName1
            // 
            this.lblProductName1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductName1.AutoSize = true;
            this.lblProductName1.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName1.ForeColor = System.Drawing.Color.White;
            this.lblProductName1.Location = new System.Drawing.Point(448, 97);
            this.lblProductName1.Name = "lblProductName1";
            this.lblProductName1.Size = new System.Drawing.Size(153, 33);
            this.lblProductName1.TabIndex = 161;
            this.lblProductName1.Text = "ProducName";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(244, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 33);
            this.label13.TabIndex = 157;
            this.label13.Text = "Số Lượng :";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(244, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 33);
            this.label12.TabIndex = 156;
            this.label12.Text = "Giá Tiền :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(244, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 33);
            this.label11.TabIndex = 154;
            this.label11.Text = "Tên Sản Phẩm :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SeaGreen;
            this.label9.Location = new System.Drawing.Point(52, 690);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 44);
            this.label9.TabIndex = 151;
            this.label9.Text = "Tổng Tiền :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(53, 490);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 33);
            this.label8.TabIndex = 149;
            this.label8.Text = "Đường :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(53, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 33);
            this.label7.TabIndex = 147;
            this.label7.Text = "Đá :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(53, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 33);
            this.label6.TabIndex = 145;
            this.label6.Text = "Size :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(53, 587);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 33);
            this.label5.TabIndex = 143;
            this.label5.Text = "Topping :";
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 10;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 15;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.BorderRadius = 10;
            this.guna2Elipse5.TargetControl = this.panel1;
            // 
            // FormOrderProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(829, 838);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrderProduct";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOrderProduct";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOrderProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbClose;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.PictureBox btnMinus;
        private System.Windows.Forms.PictureBox btnPlus;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblProductName1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private Guna.UI2.WinForms.Guna2PictureBox ptImage;
        private Guna.UI2.WinForms.Guna2ComboBox cbSize;
        private Guna.UI2.WinForms.Guna2ComboBox cbSugar;
        private Guna.UI2.WinForms.Guna2ComboBox cbIce;
        private Guna.UI2.WinForms.Guna2ComboBox cbTopping;
        private Guna.UI2.WinForms.Guna2TextBox txtAmount;
    }
}