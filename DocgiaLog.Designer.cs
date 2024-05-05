
namespace ThưVien
{
    partial class DocgiaLog
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.btntra = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanel2.Controls.Add(this.button5);
            this.flowLayoutPanel2.Controls.Add(this.btntra);
            this.flowLayoutPanel2.Controls.Add(this.button6);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(193, 466);
            this.flowLayoutPanel2.TabIndex = 28;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(189, 49);
            this.button5.TabIndex = 10;
            this.button5.Text = "SÁCH MƯỢN";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btntra
            // 
            this.btntra.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btntra.FlatAppearance.BorderSize = 0;
            this.btntra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntra.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntra.Location = new System.Drawing.Point(3, 58);
            this.btntra.Name = "btntra";
            this.btntra.Size = new System.Drawing.Size(189, 49);
            this.btntra.TabIndex = 38;
            this.btntra.Text = "SÁCH ĐÃ TRẢ";
            this.btntra.UseVisualStyleBackColor = false;
            this.btntra.Click += new System.EventHandler(this.btntra_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(3, 113);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(189, 49);
            this.button6.TabIndex = 11;
            this.button6.Text = "THOÁT";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DocgiaLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "DocgiaLog";
            this.Text = "DocgiaLog";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btntra;
        private System.Windows.Forms.Button button6;
    }
}