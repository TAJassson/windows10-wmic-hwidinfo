using System;
using System.Text;
using System.Management;
namespace Hwid_info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Windows 10 Get end user hwid info");
            Console.WriteLine("");

            ObjectQuery disk = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
            ManagementObjectSearcher diskseacher = new ManagementObjectSearcher(disk);
            Console.WriteLine("----------------Hard disk info----------------");
            foreach (ManagementObject wmi_HD in diskseacher.Get())
            {
                string diskname = $"Disk Model = {wmi_HD["Model"]} , SN =  {wmi_HD["SerialNumber"]} ";
                Console.WriteLine(diskname);
            }
            Console.WriteLine("");
            Console.WriteLine("----------------Motherboard info----------------");
            ObjectQuery mb= new ObjectQuery("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher mbseacher = new ManagementObjectSearcher(mb);
            foreach (ManagementObject mbinfo in mbseacher.Get())
            {
                string getmb = $"Name =  {mbinfo["Product"]} , SN =  {mbinfo["SerialNumber"]} , Manufacturer = {mbinfo["Manufacturer"]}";
                Console.WriteLine(getmb);
            }
            Console.WriteLine();
            Console.WriteLine("----------------CPU info----------------");
            ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in cpuSearcher.Get())
            {
                Console.Write("CPU Model: {0} \n", obj["Name"]);
            }
            Console.WriteLine();
            Console.WriteLine("----------------GPU info----------------");
            ManagementObjectSearcher gpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (ManagementObject obj in gpuSearcher.Get())
            {
                Console.Write("GPU: {0}\n", obj["Name"]);
            }
            Console.WriteLine();
            string query = "SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionStatus = 2 AND Manufacturer != 'Microsoft'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection collection = searcher.Get();
               Console.WriteLine("------------NIC Card------------");
            foreach (ManagementObject obj in collection)
            {
                Console.WriteLine("Name: {0} ", obj["Name"]);
                Console.WriteLine("MAC Address: {0}", obj["MACAddress"]);
            }
        }
    }
}
