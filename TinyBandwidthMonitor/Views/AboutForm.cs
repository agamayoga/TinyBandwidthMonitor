using System;
using System.Windows.Forms;

namespace Agama
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            string version = Program.Version;
            string date = Program.ReleaseDate;

            if (version != null)
            {
                lblTitle.Text = lblTitle.Text.Replace("v1.0", "v" + version);
            }

            if (date != null)
            {
                lblReleaseDate.Text = lblReleaseDate.Text.Replace("2023-10-15", date);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
