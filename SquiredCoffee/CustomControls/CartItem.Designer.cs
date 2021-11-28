
namespace SquiredCoffee.CustomControls
{
    partial class CartItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItem));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(77)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.lblDiscount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.btnQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 68);
            this.panel1.TabIndex = 12;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Quicksand", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.White;
            this.lblDiscount.Location = new System.Drawing.Point(328, 36);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(70, 28);
            this.lblDiscount.TabIndex = 22;
            this.lblDiscount.Text = "0 VNĐ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(226, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Giảm Giá :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(261, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "ĐGiá :";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblQuantity.Location = new System.Drawing.Point(160, 37);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(22, 25);
            this.lblQuantity.TabIndex = 19;
            this.lblQuantity.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(64, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Số Lượng :";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Quicksand", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(328, 6);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(121, 28);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "42.000 VNĐ";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.White;
            this.lblItemName.Location = new System.Drawing.Point(64, 3);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(121, 30);
            this.lblItemName.TabIndex = 15;
            this.lblItemName.Text = "Item Name";
            // 
            // btnQuantity
            // 
            this.btnQuantity.CheckedState.Parent = this.btnQuantity;
            this.btnQuantity.CustomImages.Parent = this.btnQuantity;
            this.btnQuantity.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuantity.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuantity.DisabledState.Parent = this.btnQuantity;
            this.btnQuantity.FillColor = System.Drawing.Color.Tomato;
            this.btnQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuantity.ForeColor = System.Drawing.Color.White;
            this.btnQuantity.HoverState.Parent = this.btnQuantity;
            this.btnQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnQuantity.Image")));
            this.btnQuantity.ImageSize = new System.Drawing.Size(25, 25);
            this.btnQuantity.Location = new System.Drawing.Point(10, 10);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnQuantity.ShadowDecoration.Parent = this.btnQuantity;
            this.btnQuantity.Size = new System.Drawing.Size(45, 45);
            this.btnQuantity.TabIndex = 0;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // CartItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CartItem";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Size = new System.Drawing.Size(464, 71);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblItemName;
        private Guna.UI2.WinForms.Guna2CircleButton btnQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label3;
    }
}
