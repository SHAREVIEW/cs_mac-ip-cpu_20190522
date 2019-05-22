using System.Net;
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace cs_mac_ip_cpu_20190522
{
    class Program
    {

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        static void Main(string[] args)
        {
            
                string macAddress = "";
                try
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in nics)
                    {
                        if (!adapter.GetPhysicalAddress().ToString().Equals(""))
                        {
                            macAddress = adapter.GetPhysicalAddress().ToString();
                            for (int i = 1; i < 6; i++)
                            {
                                macAddress = macAddress.Insert(3 * i - 1, ":");
                            }
                            break;
                        }
                    }

                }
                catch
                {
                }
            Console.WriteLine(macAddress);
            Console.ReadKey();

        }


        //public string GetMacAddressByNetworkInformation()
        //{
        //    string macAddress = "";
        //    try
        //    {
        //        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        //        foreach (NetworkInterface adapter in nics)
        //        {
        //            if (!adapter.GetPhysicalAddress().ToString().Equals(""))
        //            {
        //                macAddress = adapter.GetPhysicalAddress().ToString();
        //                for (int i = 1; i < 6; i++)
        //                {
        //                    macAddress = macAddress.Insert(3 * i - 1, ":");
        //                }
        //                break;
        //            }
        //        }

        //    }
        //    catch
        //    {
        //    }
        //    return macAddress;
        //}




        //public static string GetMacAddress()
        //{
        //    try
        //    {
        //        string strMac = string.Empty;
        //        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //        ManagementObjectCollection moc = mc.GetInstances();
        //        foreach (ManagementObject mo in moc)
        //        {
        //            if ((bool)mo["IPEnabled"] == true)
        //            {
        //                strMac = mo["MacAddress"].ToString();
        //            }
        //        }
        //        moc = null;
        //        mc = null;
        //        return strMac;
        //    }
        //    catch
        //    {
        //        return "unknown";
        //    }
        //}

    }

}
