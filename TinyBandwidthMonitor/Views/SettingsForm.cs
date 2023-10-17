using System;
using System.Drawing;
using System.Windows.Forms;

namespace Agama
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            InitializeValues();
        }

        protected Settings Settings
        {
            get
            {
                return Program.Settings;
            }
        }

        protected void InitializeValues()
        {
            try
            {
                cmbDefaultNetwork.Items.Clear();
                cmbDefaultNetwork.Items.Add("Automatic");

                var interfaces = Settings.GetNetworkInterfaces();
                foreach (var nic in interfaces)
                {
                    cmbDefaultNetwork.Items.Add(nic.Name);
                }

                cmbDefaultNetwork.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(Settings.DefaultNetworkInterface))
                {
                    int index = cmbDefaultNetwork.Items.IndexOf(Settings.DefaultNetworkInterface);
                    if (index >= 0)
                    {
                        cmbDefaultNetwork.SelectedIndex = index;
                    }
                }

                txtUpdateInterval.Text = Settings.UpdateInterval.ToString();
                txtChartTicks.Text = Settings.ChartCapacity.ToString();
                txtWindowOpacity.Text = Settings.WindowOpacity.ToString() + "%";

                pbColorDownload.BackColor = Settings.DownloadColor;
                pbColorUpload.BackColor = Settings.UploadColor;

                if (pbColorDownload.BackColor == Settings.Blue && pbColorUpload.BackColor == Settings.Yellow)
                {
                    cmbColorScheme.SelectedIndex = 0; //Blue + Yellow
                }
                else if (pbColorDownload.BackColor == Settings.Red && pbColorUpload.BackColor == Settings.Green)
                {
                    cmbColorScheme.SelectedIndex = 1; //Red + Green
                }
                else
                {
                    cmbColorScheme.SelectedIndex = 2; //Custom
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cmbColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var colors = new Color[2];

            switch (cmbColorScheme.SelectedIndex)
            {
                case 0:
                    colors[0] = Settings.Blue;
                    colors[1] = Settings.Yellow;
                    break;

                case 1:
                    colors[0] = Settings.Red;
                    colors[1] = Settings.Green;
                    break;

                default:
                    colors[0] = pbColorDownload.BackColor;
                    colors[1] = pbColorUpload.BackColor;
                    break;
            }

            pbColorDownload.BackColor = colors[0];
            pbColorUpload.BackColor = colors[1];
        }

        private void pbColorDownload_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            dialog.AllowFullOpen = true;
            dialog.FullOpen = true;
            dialog.AnyColor = true;
            dialog.Color = pbColorDownload.BackColor;

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbColorDownload.BackColor = dialog.Color;
                cmbColorScheme.SelectedIndex = 2; //Custom
            }
        }

        private void pbColorUpload_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            dialog.AllowFullOpen = true;
            dialog.FullOpen = true;
            dialog.AnyColor = true;
            dialog.Color = pbColorUpload.BackColor;

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbColorUpload.BackColor = dialog.Color;
                cmbColorScheme.SelectedIndex = 2; //Custom
            }
        }

        private void txtUpdateInterval_Leave(object sender, EventArgs e)
        {
            //Validate value
            int value = 0;
            if (int.TryParse(txtUpdateInterval.Text.Trim(), out value))
            {
                if (value < 100) //Min 100 ms
                {
                    txtUpdateInterval.Text = 100.ToString();
                }
                else if (value > 3600 * 1000) //Max 1 hour
                {
                    txtUpdateInterval.Text = (3600 * 1000).ToString();
                }
            }
            else
            {
                txtUpdateInterval.Text = Settings.UpdateInterval.ToString(); //Restore from settings
            }
        }

        private void txtChartTicks_Leave(object sender, EventArgs e)
        {
            //Validate value
            int value = 0;
            if (int.TryParse(txtChartTicks.Text.Trim(), out value))
            {
                if (value < 10) //Min 10 ticks
                {
                    txtChartTicks.Text = 10.ToString();
                }
                else if (value > 10000) //Max 10k ticks
                {
                    txtChartTicks.Text = 10000.ToString();
                }
            }
            else
            {
                txtChartTicks.Text = Settings.ChartCapacity.ToString(); //Restore from settings
            }
        }

        private void txtWindowOpacity_Leave(object sender, EventArgs e)
        {
            //Validate value
            int value = 0;
            if (int.TryParse(txtWindowOpacity.Text.Replace("%", "").Trim(), out value))
            {
                if (value < 0) //Min 0%
                {
                    txtWindowOpacity.Text = 0 + "%";
                }
                else if (value > 100) //Max 100%
                {
                    txtWindowOpacity.Text = 100 + "%";
                }
                else
                {
                    txtWindowOpacity.Text = value + "%"; //Add percent symbol
                }
            }
            else
            {
                txtWindowOpacity.Text = Settings.WindowOpacity + "%"; //Restore from settings
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string nic = cmbDefaultNetwork.SelectedIndex > 0 ? cmbDefaultNetwork.Items[cmbDefaultNetwork.SelectedIndex] as string : "";

                int refresh = int.Parse(txtUpdateInterval.Text.Trim());
                int capacity = int.Parse(txtChartTicks.Text.Trim());
                int opacity = int.Parse(txtWindowOpacity.Text.Replace("%", "").Trim());

                Color color1 = pbColorDownload.BackColor;
                Color color2 = pbColorUpload.BackColor;

                Settings.DefaultNetworkInterface = nic;
                Settings.UpdateInterval = refresh;
                Settings.ChartCapacity = capacity;
                Settings.WindowOpacity = opacity;
                Settings.DownloadColor = color1;
                Settings.UploadColor = color2;

                Settings.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
