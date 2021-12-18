
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_ManageChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ManageChart));
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSelect = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.cbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1690, 60);
            this.bunifuGradientPanel1.TabIndex = 29;
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
            this.label1.Location = new System.Drawing.Point(76, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống Kê";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cbSelect);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dtpDate);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.cbYear);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbMonth);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1684, 64);
            this.panel3.TabIndex = 31;
            // 
            // cbSelect
            // 
            this.cbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.cbSelect.BackColor = System.Drawing.Color.Transparent;
            this.cbSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cbSelect.BorderRadius = 15;
            this.cbSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelect.FocusedColor = System.Drawing.Color.Empty;
            this.cbSelect.FocusedState.Parent = this.cbSelect;
            this.cbSelect.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelect.ForeColor = System.Drawing.Color.Black;
            this.cbSelect.FormattingEnabled = true;
            this.cbSelect.HoverState.Parent = this.cbSelect;
            this.cbSelect.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbSelect.ItemHeight = 30;
            this.cbSelect.Items.AddRange(new object[] {
            "- Thống kê hóa đơn hôm nay",
            "- Thống kê hóa đơn theo ngày",
            "- Thống kê hóa đơn theo tháng",
            "- Thống kê hóa đơn theo năm",
            "- Top 10 sản phẩm bán chạy theo ngày",
            "- Top 10 sản phẩm bán chạy theo tháng",
            "- Top 10 sản phẩm bán chạy theo năm",
            "- Khách hàng mua nhiều nhất",
            "- Nhân viên làm nhiều nhất",
            "- Thu chi theo tháng",
            "- Thu chi theo năm ",
            "- Sản phẩm gần hết trong kho"});
            this.cbSelect.ItemsAppearance.Parent = this.cbSelect;
            this.cbSelect.Location = new System.Drawing.Point(157, 11);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.ShadowDecoration.Parent = this.cbSelect;
            this.cbSelect.Size = new System.Drawing.Size(519, 36);
            this.cbSelect.TabIndex = 102;
            this.cbSelect.SelectedIndexChanged += new System.EventHandler(this.cbSelect_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(28, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 33);
            this.label5.TabIndex = 101;
            this.label5.Text = "Lựa chọn :";
            // 
            // dtpDate
            // 
            this.dtpDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpDate.BaseColor = System.Drawing.Color.White;
            this.dtpDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtpDate.CustomFormat = null;
            this.dtpDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDate.FocusedColor = System.Drawing.Color.Transparent;
            this.dtpDate.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.ForeColor = System.Drawing.Color.Black;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(791, 14);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtpDate.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDate.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtpDate.OnPressedColor = System.Drawing.Color.Black;
            this.dtpDate.Radius = 15;
            this.dtpDate.Size = new System.Drawing.Size(190, 36);
            this.dtpDate.TabIndex = 100;
            this.dtpDate.Text = "17/12/2021";
            this.dtpDate.Value = new System.DateTime(2021, 12, 17, 22, 20, 23, 970);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(701, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 33);
            this.label4.TabIndex = 99;
            this.label4.Text = "Ngày :";
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 17;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.DisabledState.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(79)))), ((int)(((byte)(157)))));
            this.btnSearch.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSearch.Location = new System.Drawing.Point(1477, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(186, 42);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.Text = "Tra Cứu";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbYear
            // 
            this.cbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.cbYear.BackColor = System.Drawing.Color.Transparent;
            this.cbYear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cbYear.BorderRadius = 15;
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FocusedColor = System.Drawing.Color.Empty;
            this.cbYear.FocusedState.Parent = this.cbYear;
            this.cbYear.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.ForeColor = System.Drawing.Color.Black;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.HoverState.Parent = this.cbYear;
            this.cbYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbYear.ItemHeight = 30;
            this.cbYear.Items.AddRange(new object[] {
            "Select",
            "2020",
            "2021"});
            this.cbYear.ItemsAppearance.Parent = this.cbYear;
            this.cbYear.Location = new System.Drawing.Point(1318, 11);
            this.cbYear.Name = "cbYear";
            this.cbYear.ShadowDecoration.Parent = this.cbYear;
            this.cbYear.Size = new System.Drawing.Size(147, 36);
            this.cbYear.TabIndex = 97;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1235, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 33);
            this.label3.TabIndex = 96;
            this.label3.Text = "Năm :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbMonth
            // 
            this.cbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.cbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cbMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cbMonth.BorderRadius = 15;
            this.cbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FocusedColor = System.Drawing.Color.Empty;
            this.cbMonth.FocusedState.Parent = this.cbMonth;
            this.cbMonth.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonth.ForeColor = System.Drawing.Color.Black;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.HoverState.Parent = this.cbMonth;
            this.cbMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbMonth.ItemHeight = 30;
            this.cbMonth.Items.AddRange(new object[] {
            "Select",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMonth.ItemsAppearance.Parent = this.cbMonth;
            this.cbMonth.Location = new System.Drawing.Point(1078, 11);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.ShadowDecoration.Parent = this.cbMonth;
            this.cbMonth.Size = new System.Drawing.Size(151, 36);
            this.cbMonth.TabIndex = 95;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(987, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tháng :";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 16;
            this.guna2Elipse2.TargetControl = this.panel3;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 16;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.BorderRadius = 16;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.Location = new System.Drawing.Point(4, 152);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1683, 621);
            this.panelMenu.TabIndex = 32;
            // 
            // UC_ManageChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "UC_ManageChart";
            this.Size = new System.Drawing.Size(1690, 776);
            this.Load += new System.EventHandler(this.UC_ManageChart_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2ComboBox cbYear;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cbSelect;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonth;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaDateTimePicker dtpDate;
        private System.Windows.Forms.Panel panelMenu;
    }
}
