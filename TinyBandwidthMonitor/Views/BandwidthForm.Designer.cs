namespace Agama
{
    partial class BandwidthForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BandwidthForm));
            this.lblDownload = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kBsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accumulatedBytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUpload = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.PictureBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDownload
            // 
            this.lblDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownload.AutoSize = true;
            this.lblDownload.BackColor = System.Drawing.Color.White;
            this.lblDownload.ContextMenuStrip = this.contextMenu;
            this.lblDownload.Location = new System.Drawing.Point(2, 88);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(55, 13);
            this.lblDownload.TabIndex = 1;
            this.lblDownload.Text = "Download";
            this.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kBsToolStripMenuItem,
            this.bpsToolStripMenuItem,
            this.packetsToolStripMenuItem,
            this.accumulatedBytesToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(189, 114);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // kBsToolStripMenuItem
            // 
            this.kBsToolStripMenuItem.Checked = true;
            this.kBsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kBsToolStripMenuItem.Name = "kBsToolStripMenuItem";
            this.kBsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.kBsToolStripMenuItem.Tag = "1";
            this.kBsToolStripMenuItem.Text = "Bytes per second";
            // 
            // bpsToolStripMenuItem
            // 
            this.bpsToolStripMenuItem.Name = "bpsToolStripMenuItem";
            this.bpsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bpsToolStripMenuItem.Tag = "2";
            this.bpsToolStripMenuItem.Text = "Bits per second";
            // 
            // packetsToolStripMenuItem
            // 
            this.packetsToolStripMenuItem.Name = "packetsToolStripMenuItem";
            this.packetsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.packetsToolStripMenuItem.Tag = "3";
            this.packetsToolStripMenuItem.Text = "Accumulated bytes";
            // 
            // accumulatedBytesToolStripMenuItem
            // 
            this.accumulatedBytesToolStripMenuItem.Name = "accumulatedBytesToolStripMenuItem";
            this.accumulatedBytesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.accumulatedBytesToolStripMenuItem.Tag = "4";
            this.accumulatedBytesToolStripMenuItem.Text = "Accumulated packets";
            // 
            // lblUpload
            // 
            this.lblUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpload.BackColor = System.Drawing.Color.White;
            this.lblUpload.ContextMenuStrip = this.contextMenu;
            this.lblUpload.Location = new System.Drawing.Point(68, 88);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(120, 13);
            this.lblUpload.TabIndex = 2;
            this.lblUpload.Text = "Upload";
            this.lblUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line
            // 
            this.line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line.BackColor = System.Drawing.Color.Black;
            this.line.Location = new System.Drawing.Point(0, 84);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(200, 1);
            this.line.TabIndex = 3;
            this.line.TabStop = false;
            // 
            // chart
            // 
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.ScrollBar.Enabled = false;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "DefaultChartArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ContextMenuStrip = this.contextMenu;
            this.chart.Location = new System.Drawing.Point(0, -2);
            this.chart.Name = "chart";
            series1.ChartArea = "DefaultChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "PreviewSeries";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(188, 86);
            this.chart.TabIndex = 4;
            this.chart.Text = "Chart";
            // 
            // BandwidthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(190, 103);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.chart);
            this.Controls.Add(this.line);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.lblDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BandwidthForm";
            this.ShowInTaskbar = false;
            this.Text = "Tiny Bandwidth Monitor";
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.PictureBox line;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem kBsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accumulatedBytesToolStripMenuItem;
    }
}

