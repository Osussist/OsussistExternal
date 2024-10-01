using Microsoft.Win32;
using Newtonsoft.Json;
using OpenCvSharp.XFeatures2D;
using Osussist.src.utils;
using System;
using System.Collections.Generic;
using System.Data.Design;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Osussist.src.cheat
{
    public class Spoofer
    {
        #region NativeImports
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );
        #endregion

        private static Logger logger = Logger.LoggingInstance;
        private const string baseReg = @"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\";

        public static Dictionary<string, string> GetHWIDs()
        {
            Dictionary<string, string> hwids = new Dictionary<string, string>();

            hwids.Add("CPU", GetCPUId());
            hwids.Add("Disk", GetDiskDriveSerialNumber());
            hwids.Add("BaseBoard", GetBaseBoardSerialNumber());
            hwids.Add("MACAddress", GetMACAddress());

            return hwids;
        }

        public static bool SpoofHWIDs(out string msg)
        {
            msg = String.Empty;

            try
            {
                WebClient client = new WebClient();
                bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

                Dictionary<string, string> links = JsonConvert.DeserializeObject<Dictionary<string, string>>(client.DownloadString("https://osussist.pages.dev/.data/spoofer.json"));

                if (!File.Exists("driver-mapper.exe"))
                    client.DownloadFile($"{links["mapper"]}", "driver-mapper.exe");

                if (!File.Exists("spoofdrv.sys"))
                    client.DownloadFile($"{links["driver"]}", "spoofdrv.sys");

                ProcessStartInfo mapper = new ProcessStartInfo
                {
                    FileName = "driver-mapper.exe",
                    Arguments = "spoofdrv.sys",
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(mapper).WaitForExit();

                logger.Info("Spoofer", "Main HWIDs spoofed successfully.");

                if (!isAdmin)
                {
                    logger.Error("Spoofer", "Failed to spoof MAC address: Not running as administrator.");
                    msg = "Not running as administrator.";
                    return false;
                }
                string uniqueMAC = "";
                foreach (string nicId in GetNicIds())
                {
                    try
                    {
                        using (RegistryKey bkey = GetBaseKey())
                        using (RegistryKey key = bkey.OpenSubKey(baseReg + nicId, writable: true))
                        {
                            if (key != null)
                            {
                                uniqueMAC = RandomMACAddress();
                                key.SetValue("NetworkAddress", uniqueMAC, RegistryValueKind.String);
                                ManagementObjectSearcher mos = new ManagementObjectSearcher(
                                    new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Index = " + nicId));
                                foreach (ManagementObject o in mos.Get().OfType<ManagementObject>())
                                {
                                    o.InvokeMethod("Disable", null);
                                    o.InvokeMethod("Enable", null);
                                }
                                logger.Info("Spoofer", $"{nicId} MAC address spoofed to {uniqueMAC} successfully.");
                            }
                            else
                            {
                                logger.Error("Spoofer", $"Registry key not found for NIC ID: {nicId}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Spoofer", $"An error occurred while processing NIC ID: {nicId}. Details: {ex.Message}");
                        msg = $"An error occurred while processing NIC ID: {nicId}. Details: {ex.Message}";
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
        }

        private static RegistryKey GetBaseKey()
        {
            return RegistryKey.OpenBaseKey(
                RegistryHive.LocalMachine,
                InternalCheckIsWow64() ? RegistryView.Registry64 : RegistryView.Registry32);
        }

        public static IEnumerable<string> GetNicIds()
        {
            using (RegistryKey bkey = GetBaseKey())
            using (RegistryKey key = bkey.OpenSubKey(baseReg))
            {
                if (key != null)
                {
                    foreach (string name in key.GetSubKeyNames().Where(n => n != "Properties"))
                    {
                        using (RegistryKey sub = key.OpenSubKey(name))
                        {
                            if (sub != null)
                            {
                                object busType = sub.GetValue("BusType");
                                string busStr = busType != null ? busType.ToString() : string.Empty;
                                if (busStr != string.Empty)
                                {
                                    yield return name;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }

        private static string RandomMACAddress()
        {
            Random random = new Random();
            byte[] macAddr = new byte[6];
            random.NextBytes(macAddr);
            macAddr[0] = (byte)(macAddr[0] & 0xFE);
            return string.Join("-", macAddr.Select(b => b.ToString("X2")).ToArray());
        }

        private static string GetCPUId()
        {
            string cpuInfo = "";
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return cpuInfo;
        }

        private static string GetBaseBoardSerialNumber()
        {
            string baseboardSerial = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    baseboardSerial = wmi.GetPropertyValue("SerialNumber").ToString();
                    break;
                }
                catch { }
            }
            return baseboardSerial;
        }

        private static string GetDiskDriveSerialNumber()
        {
            string diskDriveSerial = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    diskDriveSerial = wmi.GetPropertyValue("SerialNumber").ToString();
                    break;
                }
                catch { }
            }
            return diskDriveSerial;
        }

        private static string GetMACAddress()
        {
            string macStr = string.Empty;
            foreach (string nicId in GetNicIds())
            {
                using (RegistryKey bkey = GetBaseKey())
                using (RegistryKey key = bkey.OpenSubKey(baseReg + nicId))
                {
                    if (key != null)
                    {
                        object macAddr = key.GetValue("NetworkAddress");
                        macStr = macAddr != null ? macAddr.ToString() : string.Empty;
                        if (macStr != string.Empty)
                        {
                            return macStr;
                        }
                    }
                }
            }
            return macStr;
        }
    }
}
