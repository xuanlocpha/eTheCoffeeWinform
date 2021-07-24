
namespace SquiredCoffee.FormManage
{
    partial class FormScannerBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScannerBarCode));
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.ptCamera = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptCamera)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(129, 511);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(679, 36);
            this.txtDisplay.TabIndex = 9;
            // 
            // ptCamera
            // 
            this.ptCamera.BackColor = System.Drawing.Color.White;
            this.ptCamera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptCamera.Location = new System.Drawing.Point(17, 117);
            this.ptCamera.Name = "ptCamera";
            this.ptCamera.Size = new System.Drawing.Size(794, 381);
            this.ptCamera.TabIndex = 8;
            this.ptCamera.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Tomato;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(545, 560);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 42);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(235, 68);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(473, 30);
            this.cbCamera.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Camera :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bar Code :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(685, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 42);
            this.button1.TabIndex = 11;
            this.button1.Text = "Tích Điểm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(171)))), ((int)(((byte)(121)))));
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.pbClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(834, 50);
            this.panel6.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(276, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tích Điểm Người Dùng";
            // 
            // pbClose
            // 
            this.pbClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(788, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(46, 50);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // FormScannerBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(834, 613);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.ptCamera);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormScannerBarCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormScannerBarCode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScannerBarCode_FormClosing);
            this.Load += new System.EventHandler(this.FormScannerBarCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptCamera)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.PictureBox ptCamera;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbClose;
    }
}