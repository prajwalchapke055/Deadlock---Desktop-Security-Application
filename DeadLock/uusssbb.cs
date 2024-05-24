using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    class uusssbb
    {

        public string DeviceId { get; set; }
        public string PnpDeviceId { get; set; }
        public string OsDrive;

        public uusssbb()
        {
        }

        public uusssbb(string deviceId, string pnpDeviceId)
        {
            DeviceId = deviceId;
            PnpDeviceId = pnpDeviceId;
            string a = (DeviceId + PnpDeviceId).HashSHA512();

            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);


            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable).ToList();
            if (drives.FirstOrDefault() != null)
            {


                string path = OsDrive + "TextFile111.txt";
                    using (StreamWriter writer = new StreamWriter(path, true)) //// true to append data to the file
                    {
                        writer.WriteLine(a);
                    }
                
            }
            else
            {




                string path1 = OsDrive + "TextFile222.txt";

                //if (!File.Exists(path1))
                //{
                //    using (FileStream fs = File.Create(path1)) 
                //    using (StreamWriter writer = new StreamWriter(path1, true)) //// true to append data to the file
                //    {
                //        writer.WriteLine(a);
                //    }

                //}



                // using (FileStream fs = File.Create(path1))
                    using (StreamWriter writer = new StreamWriter(path1, true)) //// true to append data to the file
                    {
                        writer.WriteLine(a);
                    }

                





                //using (StreamWriter writer = new StreamWriter("E:\\lockpractice\\WindowsFormsApplication1\\WindowsFormsApplication1\\TextFile2.txt", true)) //// true to append data to the file
                //{
                //    writer.WriteLine(a);
                //}
            }


        }

        public override string ToString()
        {
            return (DeviceId + PnpDeviceId).HashSHA512();
        }

        public static List<uusssbb> GetUSBDevices()
        {


            List<uusssbb> devices = new List<uusssbb>();

            ManagementObjectCollection collection;
            using (var winApiSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_USBHub"))

                collection = winApiSearcher.Get();

            foreach (var device in collection)
                devices.Add(new uusssbb(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID")
                    ));

            collection.Dispose();
            return devices;
        }


    }

}

