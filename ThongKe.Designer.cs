
namespace ThưVien
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTuan = new System.Windows.Forms.Button();
            this.btnNam = new System.Windows.Forms.Button();
            this.btnThang = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(29, 146);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(491, 303);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.ThongKeForm_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIỂU ĐỒ THỐNG KÊ SÁCH";
            // 
            // btnTuan
            // 
            this.btnTuan.Location = new System.Drawing.Point(95, 77);
            this.btnTuan.Name = "btnTuan";
            this.btnTuan.Size = new System.Drawing.Size(75, 23);
            this.btnTuan.TabIndex = 2;
            this.btnTuan.Text = "WEEK";
            this.btnTuan.UseVisualStyleBackColor = true;
            this.btnTuan.Click += new System.EventHandler(this.btnTuan_Click_1);
            // 
            // btnNam
            // 
            this.btnNam.Location = new System.Drawing.Point(464, 77);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(75, 23);
            this.btnNam.TabIndex = 3;
            this.btnNam.Text = "YEAR";
            this.btnNam.UseVisualStyleBackColor = true;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click_1);
            // 
            // btnThang
            // 
            this.btnThang.Location = new System.Drawing.Point(275, 77);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(75, 23);
            this.btnThang.TabIndex = 4;
            this.btnThang.Text = "MONTH";
            this.btnThang.UseVisualStyleBackColor = true;
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(551, 146);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(433, 303);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 492);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.btnTuan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTuan;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}