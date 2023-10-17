using Agama.Properties;
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Agama
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CustomApplicationContext());
        }

        public static Settings Settings { get; set; }

        public static string Version
        {
            get
            {
                string version = null;
                try
                {
                    version = typeof(Program).Assembly.GetName().Version.ToString();
                    version = Regex.Replace(version, @"\.0$", ""); //Remove build version
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return version;
            }
        }

        public static string ReleaseDate
        {
            get
            {
                try
                {
                    string path = typeof(Program).Assembly.Location;
                    if (File.Exists(path))
                    {
                        var info = new FileInfo(path);
                        var dt = info.LastWriteTimeUtc;
                        return dt.ToString("yyyy-MM-dd");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
    }

    public class CustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private MenuItem miView;

        public CustomApplicationContext()
        {
            Program.Settings = new Settings();
            Program.Settings.Load();

            miView = new MenuItem("Open", new MenuItem[] { new MenuItem("Default") });
            miView.Popup += View_Popup;

            //Initialize tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Icon = Resources.icon;
            trayIcon.Text = "Tiny Bandwidth Monitor";
            trayIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                miView,
                new MenuItem("Settings", Settings_Click),
                new MenuItem("About", About_Click),
                new MenuItem("Exit", Exit_Click)
            });
            trayIcon.Visible = true;

            //Default window
            var window = new BandwidthForm();
            window.Show();
        }

        protected void View_Popup(object sender, EventArgs e)
        {
            miView.MenuItems.Clear();
            //miView.MenuItems.Add(new MenuItem("Default", Bandwidth_Click));

            var list = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in list)
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                {
                    continue;
                }
                if (nic.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }
                miView.MenuItems.Add(new MenuItem(nic.Name, Bandwidth_Click) { Tag = nic });
            }
        }

        protected void Bandwidth_Click(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var nic = item.Tag as NetworkInterface;

            var window = new BandwidthForm();
            window.NetworkInterface = nic;
            window.Show();
        }

        protected void Settings_Click(object sender, EventArgs e)
        {
            var window = new SettingsForm();
            window.Show();
        }

        protected void About_Click(object sender, EventArgs e)
        {
            var window = new AboutForm();
            window.Show();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            //Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
