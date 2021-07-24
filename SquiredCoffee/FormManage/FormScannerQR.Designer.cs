
namespace SquiredCoffee.FormManage
{
    partial class FormScannerQR
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.ptCamera = new System.Windows.Forms.PictureBox();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(151, 34);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(468, 30);
            this.cbCamera.TabIndex = 1;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Tomato;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(646, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(303, 36);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ptCamera
            // 
            this.ptCamera.BackColor = System.Drawing.Color.White;
            this.ptCamera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptCamera.Location = new System.Drawing.Point(36, 78);
            this.ptCamera.Name = "ptCamera";
            this.ptCamera.Size = new System.Drawing.Size(974, 497);
            this.ptCamera.TabIndex = 3;
            this.ptCamera.TabStop = false;
            this.ptCamera.Click += new System.EventHandler(this.ptCamera_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(36, 594);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(974, 175);
            this.txtDisplay.TabIndex = 4;
            this.txtDisplay.TextChanged += new System.EventHandler(this.txtDisplay_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormScannerQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 781);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.ptCamera);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormScannerQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormScannerQR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScannerQR_FormClosing);
            this.Load += new System.EventHandler(this.FormScannerQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox ptCamera;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Timer timer1;
    }
}