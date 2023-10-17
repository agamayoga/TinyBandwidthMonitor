using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;

namespace Agama
{
    public class Settings
    {
        public const string RegistryKey = "Software\\Agama\\Tiny Bandwidth Monitor";

        public string DefaultNetworkInterface { get; set; }
        public int UpdateInterval { get; set; }
        public int ChartCapacity { get; set; }
        public int WindowOpacity { get; set; }
        public Color DownloadColor { get; set; }
        public Color UploadColor { get; set; }

        public static readonly Color Red = Color.OrangeRed;
        public static readonly Color Green = Color.ForestGreen;
        public static readonly Color Blue = ColorTranslator.FromHtml("#468eef");
        public static readonly Color Yellow = ColorTranslator.FromHtml("#fcb441");

        public Settings()
        {
            //Default values
            this.DefaultNetworkInterface = "";
            this.UpdateInterval = 500; //0.1 seconds
            this.ChartCapacity = 100; //Total number of X values
            this.WindowOpacity = 100; //100% solid
            this.DownloadColor = Blue;
            this.UploadColor = Yellow;
        }

        public void Load()
        {
            var key = Registry.CurrentUser.OpenSubKey(RegistryKey);
            if (key == null)
            {
                //No settings yet - keep default
                return;
            }

            this.DefaultNetworkInterface = key.GetValue("DefaultNetworkInterface") as string;
            this.UpdateInterval = int.Parse(key.GetValue("UpdateInterval") as string);
            this.ChartCapacity = int.Parse(key.GetValue("ChartCapacity") as string);
            this.WindowOpacity = int.Parse(key.GetValue("WindowOpacity") as string);
            this.DownloadColor = ColorTranslator.FromHtml(key.GetValue("DownloadColor") as string);
            this.UploadColor = ColorTranslator.FromHtml(key.GetValue("UploadColor") as string);
        }

        public void Save()
        {
            var key = Registry.CurrentUser.OpenSubKey(RegistryKey, true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(RegistryKey);
            }

            key.SetValue("DefaultNetworkInterface", this.DefaultNetworkInterface);
            key.SetValue("UpdateInterval", this.UpdateInterval.ToString());
            key.SetValue("ChartCapacity", this.ChartCapacity.ToString());
            key.SetValue("WindowOpacity", this.WindowOpacity.ToString());
            key.SetValue("DownloadColor", ColorTranslator.ToHtml(this.DownloadColor));
            key.SetValue("UploadColor", ColorTranslator.ToHtml(this.UploadColor));
        }

        public List<NetworkInterface> GetNetworkInterfaces()
        {
            var result = new List<NetworkInterface>();
            var all = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in all)
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && nic.OperationalStatus == OperationalStatus.Up)
                {
                    result.Add(nic);
                }
            }

            return result;
        }
    }
}
