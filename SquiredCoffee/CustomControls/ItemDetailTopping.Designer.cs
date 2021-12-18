
namespace SquiredCoffee.CustomControls
{
    partial class ItemDetailTopping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDetailTopping));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblPriceTopping = new System.Windows.Forms.Label();
            this.lblNameTopping = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gunaPictureBox1);
            this.panel1.Controls.Add(this.lblPriceTopping);
            this.panel1.Controls.Add(this.lblNameTopping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 50);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(67, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 33);
            this.label2.TabIndex = 24;
            this.label2.Text = "Topping :";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(15, 3);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(46, 44);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gunaPictureBox1.TabIndex = 23;
            this.gunaPictureBox1.TabStop = false;
            // 
            // lblPriceTopping
            // 
            this.lblPriceTopping.AutoSize = true;
            this.lblPriceTopping.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceTopping.ForeColor = System.Drawing.Color.White;
            this.lblPriceTopping.Location = new System.Drawing.Point(395, 10);
            this.lblPriceTopping.Name = "lblPriceTopping";
            this.lblPriceTopping.Size = new System.Drawing.Size(38, 30);
            this.lblPriceTopping.TabIndex = 21;
            this.lblPriceTopping.Text = "0đ";
            // 
            // lblNameTopping
            // 
            this.lblNameTopping.AutoSize = true;
            this.lblNameTopping.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTopping.ForeColor = System.Drawing.Color.White;
            this.lblNameTopping.Location = new System.Drawing.Point(176, 10);
            this.lblNameTopping.Name = "lblNameTopping";
            this.lblNameTopping.Size = new System.Drawing.Size(92, 30);
            this.lblNameTopping.TabIndex = 20;
            this.lblNameTopping.Text = "Topping";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // ItemDetailTopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(128)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.panel1);
            this.Name = "ItemDetailTopping";
            this.Size = new System.Drawing.Size(492, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label lblPriceTopping;
        private System.Windows.Forms.Label lblNameTopping;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
