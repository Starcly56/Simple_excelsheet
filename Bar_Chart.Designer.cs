namespace DDOOCP_Assignment
{
    partial class Bar_Chart
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
            this.barchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).BeginInit();
            this.SuspendLayout();
            // 
            // barchart
            // 
            chartArea1.Name = "ChartArea1";
            this.barchart.ChartAreas.Add(chartArea1);
            this.barchart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.barchart.Legends.Add(legend1);
            this.barchart.Location = new System.Drawing.Point(0, 0);
            this.barchart.Name = "barchart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.barchart.Series.Add(series1);
            this.barchart.Size = new System.Drawing.Size(800, 450);
            this.barchart.TabIndex = 0;
            this.barchart.Text = "Bar Chart";
            // 
            // Bar_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.barchart);
            this.Name = "Bar_Chart";
            this.Text = "Bar Chart";
            this.Load += new System.EventHandler(this.Bar_Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart barchart;
    }
}