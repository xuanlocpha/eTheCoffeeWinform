
namespace SquiredCoffee.UC_ManageSysterm
{
    partial class UC_TableList
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
            this.flpOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpOrder
            // 
            this.flpOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpOrder.AutoScroll = true;
            this.flpOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.flpOrder.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpOrder.Location = new System.Drawing.Point(2, 0);
            this.flpOrder.Name = "flpOrder";
            this.flpOrder.Size = new System.Drawing.Size(1083, 618);
            this.flpOrder.TabIndex = 9;
            // 
            // UC_TableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.flpOrder);
            this.Name = "UC_TableList";
            this.Size = new System.Drawing.Size(1086, 619);
            this.Load += new System.EventHandler(this.UC_TableList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpOrder;
    }
}
