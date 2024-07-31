
namespace FormQLNV
{
    partial class frmMain
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
            this.btnTT = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTT
            // 
            this.btnTT.Location = new System.Drawing.Point(50, 135);
            this.btnTT.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnTT.Name = "btnTT";
            this.btnTT.Size = new System.Drawing.Size(390, 208);
            this.btnTT.TabIndex = 0;
            this.btnTT.Text = "Thông Tin Nhân Viên";
            this.btnTT.UseVisualStyleBackColor = true;
            this.btnTT.Click += new System.EventHandler(this.btnTT_Click);
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(483, 135);
            this.btnLuong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(390, 208);
            this.btnLuong.TabIndex = 1;
            this.btnLuong.Text = "Bảng lương";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 497);
            this.Controls.Add(this.btnLuong);
            this.Controls.Add(this.btnTT);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmMain";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTT;
        private System.Windows.Forms.Button btnLuong;
    }
}