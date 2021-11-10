
namespace SquiredCoffee.CustomControls
{
    partial class CartItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItems));
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaLinePanel_Valid = new Guna.UI.WinForms.GunaLinePanel();
            this.gunaGradientButton_Valid = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaLinePanel_Valid.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 3;
            this.gunaElipse2.TargetControl = this;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 7;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaLinePanel_Valid
            // 
            this.gunaLinePanel_Valid.BackColor = System.Drawing.Color.Transparent;
            this.gunaLinePanel_Valid.Controls.Add(this.gunaGradientButton_Valid);
            this.gunaLinePanel_Valid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaLinePanel_Valid.LineBottom = 4;
            this.gunaLinePanel_Valid.LineColor = System.Drawing.Color.Tomato;
            this.gunaLinePanel_Valid.LineLeft = 4;
            this.gunaLinePanel_Valid.LineRight = 4;
            this.gunaLinePanel_Valid.LineStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaLinePanel_Valid.LineTop = 4;
            this.gunaLinePanel_Valid.Location = new System.Drawing.Point(0, 0);
            this.gunaLinePanel_Valid.Name = "gunaLinePanel_Valid";
            this.gunaLinePanel_Valid.Size = new System.Drawing.Size(180, 180);
            this.gunaLinePanel_Valid.TabIndex = 52;
            this.gunaLinePanel_Valid.Visible = false;
            this.gunaLinePanel_Valid.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaLinePanel_Valid_Paint);
            // 
            // gunaGradientButton_Valid
            // 
            this.gunaGradientButton_Valid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientButton_Valid.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton_Valid.AnimationSpeed = 0.03F;
            this.gunaGradientButton_Valid.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton_Valid.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.gunaGradientButton_Valid.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(115)))));
            this.gunaGradientButton_Valid.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton_Valid.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton_Valid.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton_Valid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientButton_Valid.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton_Valid.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton_Valid.Image")));
            this.gunaGradientButton_Valid.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton_Valid.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton_Valid.Location = new System.Drawing.Point(129, 176);
            this.gunaGradientButton_Valid.Name = "gunaGradientButton_Valid";
            this.gunaGradientButton_Valid.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.gunaGradientButton_Valid.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.gunaGradientButton_Valid.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton_Valid.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton_Valid.OnHoverImage = null;
            this.gunaGradientButton_Valid.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton_Valid.Radius = 8;
            this.gunaGradientButton_Valid.Size = new System.Drawing.Size(45, 0);
            this.gunaGradientButton_Valid.TabIndex = 0;
            this.gunaGradientButton_Valid.Visible = false;
            // 
            // CartItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.gunaLinePanel_Valid);
            this.Name = "CartItems";
            this.Size = new System.Drawing.Size(180, 180);
            this.Load += new System.EventHandler(this.CartItems_Load);
            this.Click += new System.EventHandler(this.CartItems_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.s);
            this.gunaLinePanel_Valid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaLinePanel gunaLinePanel_Valid;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton_Valid;
    }
}
