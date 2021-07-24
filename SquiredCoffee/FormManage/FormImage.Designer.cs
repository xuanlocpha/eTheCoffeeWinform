
namespace SquiredCoffee.FormManage
{
    partial class FormImage
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
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.rtbBase64 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(122, 365);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(143, 56);
            this.btnChooseImage.TabIndex = 0;
            this.btnChooseImage.Text = "Chọn Hình";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(557, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 56);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.White;
            this.pbImage.Location = new System.Drawing.Point(38, 42);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(330, 317);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // rtbBase64
            // 
            this.rtbBase64.Location = new System.Drawing.Point(462, 42);
            this.rtbBase64.Name = "rtbBase64";
            this.rtbBase64.Size = new System.Drawing.Size(352, 317);
            this.rtbBase64.TabIndex = 3;
            this.rtbBase64.Text = "";
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 493);
            this.Controls.Add(this.rtbBase64);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChooseImage);
            this.Name = "FormImage";
            this.Text = "FormImage";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.RichTextBox rtbBase64;
    }
}