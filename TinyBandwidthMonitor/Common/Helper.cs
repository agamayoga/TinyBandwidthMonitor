using System;

namespace Agama
{
    public class Helper
    {
        public static string FormatSize(long length)
        {
            string[] suffix = { "", "K", "M", "G", "T", "P", "EW" };
            if (length == 0)
            {
                return "0" + " " + suffix[0];
            }
            long bytes = Math.Abs(length);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(length) * num).ToString() + " " + suffix[place];
        }
    }
}
