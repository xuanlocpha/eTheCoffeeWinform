
namespace SquiredCoffee.FormManage
{
    partial class FormInformationCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformationCategory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnClose = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTitleCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.rdStatus1 = new System.Windows.Forms.RadioButton();
            this.rdStatus2 = new System.Windows.Forms.RadioButton();
            this.btnLock = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTitleCategory);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.rdStatus1);
            this.panel1.Controls.Add(this.rdStatus2);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 344);
            this.panel1.TabIndex = 0;
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(677, 60);
            this.bunifuGradientPanel1.TabIndex = 139;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(638, 17);
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
            this.label1.Location = new System.Drawing.Point(76, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Tiết Loại Sản Phẩm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label12.Location = new System.Drawing.Point(97, 218);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 33);
            this.label12.TabIndex = 146;
            this.label12.Text = "Trạng Thái  :";
            // 
            // txtTitleCategory
            // 
            this.txtTitleCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.txtTitleCategory.BorderRadius = 15;
            this.txtTitleCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitleCategory.DefaultText = "";
            this.txtTitleCategory.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTitleCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTitleCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitleCategory.DisabledState.Parent = this.txtTitleCategory;
            this.txtTitleCategory.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitleCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitleCategory.FocusedState.Parent = this.txtTitleCategory;
            this.txtTitleCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleCategory.ForeColor = System.Drawing.Color.Black;
            this.txtTitleCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitleCategory.HoverState.Parent = this.txtTitleCategory;
            this.txtTitleCategory.Location = new System.Drawing.Point(270, 72);
            this.txtTitleCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitleCategory.Name = "txtTitleCategory";
            this.txtTitleCategory.PasswordChar = '\0';
            this.txtTitleCategory.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTitleCategory.PlaceholderText = "...";
            this.txtTitleCategory.SelectedText = "";
            this.txtTitleCategory.ShadowDecoration.Parent = this.txtTitleCategory;
            this.txtTitleCategory.Size = new System.Drawing.Size(403, 47);
            this.txtTitleCategory.TabIndex = 145;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label6.Location = new System.Drawing.Point(123, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 33);
            this.label6.TabIndex = 140;
            this.label6.Text = "Thể Loại :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 33);
            this.label2.TabIndex = 141;
            this.label2.Text = "Tên Loại Sản Phẩm  :";
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Transparent;
            this.cbType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            this.cbType.BorderRadius = 15;
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FocusedColor = System.Drawing.Color.Empty;
            this.cbType.FocusedState.Parent = this.cbType;
            this.cbType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbType.FormattingEnabled = true;
            this.cbType.HoverState.Parent = this.cbType;
            this.cbType.ItemHeight = 30;
            this.cbType.Items.AddRange(new object[] {
            "drink",
            "food"});
            this.cbType.ItemsAppearance.Parent = this.cbType;
            this.cbType.Location = new System.Drawing.Point(270, 152);
            this.cbType.Name = "cbType";
            this.cbType.ShadowDecoration.Parent = this.cbType;
            this.cbType.Size = new System.Drawing.Size(403, 36);
            this.cbType.TabIndex = 144;
            // 
            // rdStatus1
            // 
            this.rdStatus1.AutoSize = true;
            this.rdStatus1.Checked = true;
            this.rdStatus1.Font = new System.Drawing.Font("Quicksand SemiBold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.rdStatus1.Location = new System.Drawing.Point(279, 218);
            this.rdStatus1.Name = "rdStatus1";
            this.rdStatus1.Size = new System.Drawing.Size(144, 37);
            this.rdStatus1.TabIndex = 142;
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
            this.rdStatus2.Location = new System.Drawing.Point(473, 220);
            this.rdStatus2.Name = "rdStatus2";
            this.rdStatus2.Size = new System.Drawing.Size(144, 37);
            this.rdStatus2.TabIndex = 143;
            this.rdStatus2.Text = "Tạm Khóa";
            this.rdStatus2.UseVisualStyleBackColor = true;
            this.rdStatus2.CheckedChanged += new System.EventHandler(this.rdStatus2_CheckedChanged);
            // 
            // btnLock
            // 
            this.btnLock.BorderRadius = 15;
            this.btnLock.CheckedState.Parent = this.btnLock;
            this.btnLock.CustomImages.Parent = this.btnLock;
            this.btnLock.DisabledState.Parent = this.btnLock;
            this.btnLock.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLock.Font = new System.Drawing.Font("Quicksand", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ForeColor = System.Drawing.Color.White;
            this.btnLock.HoverState.Parent = this.btnLock;
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLock.Location = new System.Drawing.Point(390, 272);
            this.btnLock.Name = "btnLock";
            this.btnLock.ShadowDecoration.Parent = this.btnLock;
            this.btnLock.Size = new System.Drawing.Size(209, 57);
            this.btnLock.TabIndex = 148;
            this.btnLock.Text = "Khóa";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
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
            this.btnEdit.Location = new System.Drawing.Point(108, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShadowDecoration.Parent = this.btnEdit;
            this.btnEdit.Size = new System.Drawing.Size(209, 57);
            this.btnEdit.TabIndex = 147;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.panel1;
            // 
            // FormInformationCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(79)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(697, 364);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInformationCategory";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInformationCategory";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormInformationCategory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtTitleCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbType;
        private System.Windows.Forms.RadioButton rdStatus1;
        private System.Windows.Forms.RadioButton rdStatus2;
        private Guna.UI2.WinForms.Guna2Button btnLock;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}