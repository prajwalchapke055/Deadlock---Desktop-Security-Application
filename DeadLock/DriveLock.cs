using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class DriveLock : Form
    {
        private RegistryKey regkey;
        private string Regpath = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
        private string OsDrive;
        private Int32 DriveDword, Loc;
        public DriveLock()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);//getting operating system path
            if (comboBox1.Text.Length > 0)
            {
                if (!(OsDrive == comboBox1.Text))
                {
                    //ragistrty path
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");//current user

                    int ss = int.Parse(key.GetValue("NoViewOnDrive").ToString());//getting value from registry
                    DriveDword = Driv(comboBox1.Text) + ss;//adding value from combobox
                    regkey = Registry.CurrentUser.OpenSubKey(Regpath, true);


                    regkey.SetValue("NoViewOnDrive", DriveDword, RegistryValueKind.DWord);//setting value
                    MessageBox.Show("Drive Lock Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (var myp in Process.GetProcessesByName("explorer"))//killing all processes
                        myp.Kill();
                    Process process = Process.Start("explorer.exe");//launching new process of explorer

                }
                else
                    MessageBox.Show("You Cannot Lock This Drive Because It Contains Your Operating System",  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please Select A Drive To Lock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void DriveLock_Load(object sender, EventArgs e)
        {

            // Creating Registry File With 0 Values
            regkey = Registry.CurrentUser.OpenSubKey(Regpath, true);
            regkey.SetValue("NoViewOnDrive", 0 , RegistryValueKind.DWord);//creating file in registry currentuser
            regkey.SetValue("NoDrives", 0, RegistryValueKind.DWord);//creating file in registry currentuser

            // Checking Admin And Putting Values On ComboBox
            if (this.IsAdministrator())
            {
                foreach (var drive in Environment.GetLogicalDrives())
                {
                    DriveInfo InfoDrive = new DriveInfo(drive);//checking all available drives in system
                    if (InfoDrive.DriveType == DriveType.Removable | InfoDrive.DriveType == DriveType.Fixed)
                        comboBox1.Items.Add(drive);
                }
                comboBox1.SelectedIndex = 0;
                comboBox1.Text = comboBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Administrators Access Rights Are Required.",  "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnunlock_Click(object sender, EventArgs e)
        {
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);
            if (comboBox1.Text.Length > 0)
            {
                if (!(OsDrive == comboBox1.Text))
                {
                    //getting registry value
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    if (key != null)
                    {
                        int ss = int.Parse(key.GetValue("NoViewOnDrive").ToString());//if file present getting value of it
                        DriveDword = ss - Driv(comboBox1.Text);//subtract from combobox value
                        regkey = Registry.CurrentUser.OpenSubKey(Regpath, true);
                        regkey.DeleteValue("NoViewOnDrive");

                        regkey.SetValue("NoViewOnDrive", DriveDword, RegistryValueKind.DWord);
                        MessageBox.Show("Drive UnLocked Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (var myp in Process.GetProcessesByName("explorer"))//killing  all process
                            myp.Kill();
                        Process process = Process.Start("explorer.exe");//launch file exlorer
                    }
                    else
                    {
                        MessageBox.Show("No Drive Locked", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    MessageBox.Show("You cannot Hide this drive because it contains your operating system",  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select a drive to Hide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool IsAdministrator()//method for checking administrator
        {
            bool isAdmin;

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isAdmin;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);
            if (comboBox1.Text.Length > 0)
            {
                if (!(OsDrive == comboBox1.Text))
                {
                    //getting registry value
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");

                    int ss = int.Parse(key.GetValue("NoDrives").ToString());
                    DriveDword = Driv(comboBox1.Text) + ss;
                    regkey = Registry.CurrentUser.OpenSubKey(Regpath, true);


                    regkey.SetValue("NoDrives", DriveDword, RegistryValueKind.DWord);
                    MessageBox.Show("Drive Hide successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (var myp in Process.GetProcessesByName("explorer"))
                        myp.Kill();
                    Process process = Process.Start("explorer.exe");
                }
                else
                    MessageBox.Show("You cannot Hide This Drive Because It Contains Operating System...",  "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please Select A Drive To Hide", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnunhide_Click(object sender, EventArgs e)
        {
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);
            if (comboBox1.Text.Length > 0)
            {
                if (!(OsDrive == comboBox1.Text))
                {
                    //getting registry value
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    if (key != null)
                    {
                        int ss = int.Parse(key.GetValue("NoDrives").ToString());
                        DriveDword = ss - Driv(comboBox1.Text);
                        regkey = Registry.CurrentUser.OpenSubKey(Regpath, true);
                        regkey.DeleteValue("NoDrives");

                        regkey.SetValue("NoDrives", DriveDword, RegistryValueKind.DWord);
                        MessageBox.Show("Drive Un-Hide Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (var myp in Process.GetProcessesByName("explorer"))
                            myp.Kill();
                        Process process = Process.Start("explorer.exe");
                    }
                    else
                    {
                        MessageBox.Show("No Drive Hidden", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    MessageBox.Show("You Cannot Hide This Drive Because It Contains Your Operating System", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select a drive to Hide", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public Int32 Driv(string Drive)
        {
            //it's default values of local drive
            if (Drive == @"A:\")
                Loc = 0;
            else if ((Drive == @"B:\"))
                Loc = 2;
            else if ((Drive == @"C:\"))
                Loc = 4;
            else if ((Drive == @"D:\"))
                Loc = 8;
            else if ((Drive == @"E:\"))
                Loc = 16;
            else if ((Drive == @"F:\"))
                Loc = 32;
            else if ((Drive == @"G:\"))
                Loc = 64;
            else if ((Drive == @"H:\"))
                Loc = 128;
            else if ((Drive == @"I:\"))
                Loc = 256;
            else if ((Drive == @"J:\"))
                Loc = 512;
            else if ((Drive == @"K:\"))
                Loc = 1024;
            else if ((Drive == @"L:\"))
                Loc = 2048;
            else if ((Drive == @"M:\"))
                Loc = 4096;
            else if ((Drive == @"N:\"))
                Loc = 8192;
            else if ((Drive == @"O:\"))
                Loc = 16384;
            else if ((Drive == @"P:\"))
                Loc = 16384 * 2;
            else if ((Drive == @"Q:\"))
                Loc = 65536;
            else if ((Drive == @"R:\"))
                Loc = 131072;
            else if ((Drive == @"S:\"))
                Loc = 262144;
            else if ((Drive == @"T:\"))
                Loc = 262144 * 2;
            else if ((Drive == @"U:\"))
                Loc = 1048576;
            else if ((Drive == @"V:\"))
                Loc = 1048576 * 2;
            else if ((Drive == @"W:\"))
                Loc = 1048576 * 4;
            else if ((Drive == @"X:\"))
                Loc = 1048576 * 8;
            else if ((Drive == @"Y:\"))
                Loc = 1048576 * 16;
            else if ((Drive == @"Z:\"))
                Loc = 1048576 * 32;
            return Loc;
        }

    }
}
