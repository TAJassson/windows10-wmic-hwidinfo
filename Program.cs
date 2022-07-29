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
            ObjectQuery disk = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
            ManagementObjectSearcher diskseacher = new ManagementObjectSearcher(disk);
            foreach (ManagementObject wmi_HD in diskseacher.Get())
            {
                string diskname = $"Model = {wmi_HD["Model"]}SN =  {wmi_HD["SerialNumber"]} ";
                Console.WriteLine(diskname);
            }

            ObjectQuery mb= new ObjectQuery("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher mbseacher = new ManagementObjectSearcher(mb);
            foreach (ManagementObject mbinfo in mbseacher.Get())
            {
                string getmb = $"Name =  {mbinfo["Model"]} SN =  {mbinfo["SerialNumber"]} , Manufacturer = {mbinfo["Manufacturer"]}";
                Console.WriteLine(getmb);
            }
            Console.ReadLine();
        }
    }
}
