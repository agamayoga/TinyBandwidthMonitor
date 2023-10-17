using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Agama
{
    public partial class BandwidthForm : Form
    {
        //Chart
        private long lastBytesSent = -1;
        private long lastBytesReceived = -1;

        //Label
        private long lastBytesSentLabel = -1;
        private long lastBytesReceivedLabel = -1;
        private long initialBytesSentLabel = -1;
        private long initialBytesReceivedLabel = -1;
        private long initialPacketsSentLabel = -1;
        private long initialPacketsReceivedLabel = -1;

        //Chart series
        private List<string> xval;
        private List<List<object>> yvals;

        //Network interfaces
        private List<NetworkInterface> interfaces;

        //Display mode
        private DisplayMode mode = DisplayMode.BytesPerSecond;

        public enum DisplayMode
        {
            BytesPerSecond = 1,
            BitsPerSecond = 2,
            AccumulatedBytes = 3,
            AccumulatedPackets = 4
        }

        private Timer timerChart;
        private Timer timerLabel;

        public BandwidthForm()
        {
            InitializeComponent();
            InitializeNetworkInterfaces();
            InitializeChart();

            UpdateSize();
            MoveToBottomRight();

            this.Load += BandwidthForm_Load;
            this.Resize += BandwidthForm_Resize;

            this.TopMost = true;
        }

        protected Settings Settings
        {
            get
            {
                return Program.Settings;
            }
        }

        public NetworkInterface NetworkInterface
        {
            get;
            set;
        }

        protected void InitializeChart()
        {
            chart.Series.Clear();

            xval = new List<string>();
            yvals = new List<List<object>>();

            //Create two series
            var names = new string[] { "Download", "Upload" };
            for (int i = 0; i < names.Length; i++)
            {
                yvals.Add(new List<object>());
            }

            //Add max points
            int capacity = Settings.ChartCapacity;
            for (int i = 0; i <= capacity; i++)
            {
                xval.Add("" + i);
                yvals[0].Add(0);
                yvals[1].Add(0);
            }

            //Populate the chart with points
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                chart.Series.Add(name);
                chart.Series[name].ChartType = SeriesChartType.FastLine; //FastLine, FastPoint, StepLine
                chart.Series[name].Color = (i == 0 ? Settings.DownloadColor : Settings.UploadColor);
                chart.Series[name].IsValueShownAsLabel = false;
                chart.Series[name].Points.DataBindXY(xval, yvals[i]);
            }

            //Hide chart until the first actual point is resolved
            chart.Visible = false;

            //Label colors
            lblDownload.ForeColor = Settings.DownloadColor;
            lblUpload.ForeColor = Settings.UploadColor;
        }

        protected void InitializeNetworkInterfaces()
        {
            interfaces = Settings.GetNetworkInterfaces();
        }

        protected void InitializeTimers()
        {
            timerChart = new Timer();
            timerChart.Interval = Settings.UpdateInterval; //User-defined interval
            timerChart.Tick += new EventHandler((sender, e) => RefreshChart());
            timerChart.Start();

            RefreshChart();

            timerLabel = new Timer();
            timerLabel.Interval = 1000; //Every second
            timerLabel.Tick += new EventHandler((sender, e) => RefreshLabel());
            timerLabel.Start();

            RefreshLabel();
        }

        protected void UpdateSize()
        {
            chart.Width = this.ClientSize.Width;
            chart.Height = this.ClientSize.Height - 19;
            chart.Top = 0;
            chart.Left = 0;
            line.Top = chart.Height;
        }

        protected void UpdateTitle(NetworkInterface nic = null)
        {
            if (nic == null)
            {
                nic = GetNetworkInterface();
            }

            if (nic == null)
            {
                return;
            }

            //Find first IPv4 and display it as window title
            UnicastIPAddressInformationCollection addresses = nic.GetIPProperties().UnicastAddresses;
            foreach (UnicastIPAddressInformation item in addresses)
            {
                if (item.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    this.Text = item.Address.ToString();
                    break;
                }
            }
        }

        protected void MoveToBottomRight()
        {
            var screen = System.Windows.Forms.Screen.PrimaryScreen;
            this.StartPosition = FormStartPosition.Manual;
            //this.Location = screen.Bounds.Location;

            //Bottom right of the primary screen
            int x = screen.WorkingArea.Width - this.Width - 30;
            int y = screen.WorkingArea.Height - this.Height - 30;
            this.Location = new Point(x, y);
        }

        protected NetworkInterface GetNetworkInterface()
        {
            return this.NetworkInterface ?? interfaces.FirstOrDefault(x => x.Name == "Local Area Connection") ?? interfaces.FirstOrDefault();
        }

        private void BandwidthForm_Load(object sender, EventArgs e)
        {
            UpdateTitle();
            InitializeTimers();
        }

        private void BandwidthForm_Resize(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = int.Parse(e.ClickedItem.Tag as string);
            this.mode = (DisplayMode)i;

            foreach (ToolStripMenuItem item in contextMenu.Items)
            {
                item.Checked = (item == e.ClickedItem);
            }
        }

        protected void RefreshChart()
        {
            try
            {
                //Get the observing network interface
                var nic = GetNetworkInterface();
                if (nic == null)
                {
                    return;
                }

                //Get interface statistics
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

                if (lastBytesSent == -1)
                {
                    //First time
                    lastBytesSent = interfaceStats.BytesSent;
                    lastBytesReceived = interfaceStats.BytesReceived;
                }
                else
                {
                    //Calculate difference since last capture
                    long bytesSentSpeed = interfaceStats.BytesSent - lastBytesSent;
                    long bytesReceivedSpeed = interfaceStats.BytesReceived - lastBytesReceived;

                    //Shift download metrics
                    yvals[0].RemoveAt(0);
                    yvals[0].Add(0);
                    yvals[0][yvals[0].Count - 1] = (double)bytesReceivedSpeed / 1024;

                    //Shift upload metrics
                    yvals[1].RemoveAt(0);
                    yvals[1].Add(0);
                    yvals[1][yvals[0].Count - 1] = (double)bytesSentSpeed / 1024;

                    //Update chart values
                    chart.Series["Download"].Points.DataBindXY(xval, yvals[0]);
                    chart.Series["Upload"].Points.DataBindXY(xval, yvals[1]);

                    //Show chart
                    chart.Visible = true;

                    //Remember last value
                    lastBytesSent = interfaceStats.BytesSent;
                    lastBytesReceived = interfaceStats.BytesReceived;
                }


                lastBytesSent = interfaceStats.BytesSent;
                lastBytesReceived = interfaceStats.BytesReceived;
            }
            catch
            {
            }
        }

        protected void RefreshLabel()
        {
            try
            {
                //Get the observing network interface
                var nic = GetNetworkInterface();
                if (nic == null)
                {
                    return;
                }
                
                //Get interface statistics
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

                string suffix = "";
                switch (mode)
                {
                    case DisplayMode.BytesPerSecond:
                        suffix = "B/s";
                        break;

                    case DisplayMode.BitsPerSecond:
                        suffix = "bps";
                        break;

                    case DisplayMode.AccumulatedBytes:
                        suffix = "B";
                        break;
                }

                if (lastBytesSentLabel == -1)
                {
                    //First time
                    lastBytesSentLabel = interfaceStats.BytesSent;
                    lastBytesReceivedLabel = interfaceStats.BytesReceived;
                    initialBytesSentLabel = interfaceStats.BytesSent;
                    initialBytesReceivedLabel = interfaceStats.BytesReceived;
                    initialPacketsSentLabel = interfaceStats.NonUnicastPacketsSent + interfaceStats.UnicastPacketsSent;
                    initialPacketsReceivedLabel = interfaceStats.NonUnicastPacketsReceived + interfaceStats.UnicastPacketsReceived;

                    if (mode == DisplayMode.AccumulatedPackets)
                    {
                        lblUpload.Text = "0";
                        lblDownload.Text = "0";
                    }
                    else
                    {
                        lblUpload.Text = Helper.FormatSize(0) + suffix;
                        lblDownload.Text = Helper.FormatSize(0) + suffix;
                    }
                }
                else
                {
                    long bytesSentSpeed = interfaceStats.BytesSent - lastBytesSentLabel;
                    long bytesReceivedSpeed = interfaceStats.BytesReceived - lastBytesReceivedLabel;

                    switch (mode)
                    {
                        case DisplayMode.BytesPerSecond:
                            lblUpload.Text = Helper.FormatSize(bytesSentSpeed) + suffix;
                            lblDownload.Text = Helper.FormatSize(bytesReceivedSpeed) + suffix;
                            break;

                        case DisplayMode.BitsPerSecond:
                            lblUpload.Text = Helper.FormatSize(bytesSentSpeed * 8) + suffix;
                            lblDownload.Text = Helper.FormatSize(bytesReceivedSpeed * 8) + suffix;
                            break;

                        case DisplayMode.AccumulatedBytes:
                            lblUpload.Text = Helper.FormatSize(interfaceStats.BytesSent - initialBytesSentLabel) + suffix;
                            lblDownload.Text = Helper.FormatSize(interfaceStats.BytesReceived - initialBytesReceivedLabel) + suffix;
                            break;

                        case DisplayMode.AccumulatedPackets:
                            lblUpload.Text = (interfaceStats.NonUnicastPacketsSent + interfaceStats.UnicastPacketsSent - initialPacketsSentLabel).ToString();
                            lblDownload.Text = (interfaceStats.NonUnicastPacketsReceived + interfaceStats.UnicastPacketsReceived - initialPacketsReceivedLabel).ToString();
                            break;
                    }

                    lastBytesSentLabel = interfaceStats.BytesSent;
                    lastBytesReceivedLabel = interfaceStats.BytesReceived;
                }

                UpdateTitle(nic);
            }
            catch
            {
            }
        }
    }
}
