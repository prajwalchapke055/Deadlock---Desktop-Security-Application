using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class TwoStep : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private static string correctHash = @"";
        public TwoStep(string getname,string gettype)
        {
            InitializeComponent();
            label2.Text = getname;
            label3.Text = gettype;
        }
        public string OsDrive;
        private void Btnstp1_Click(object sender, EventArgs e)
        {
           
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);


            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable).ToList();
            if (drives.FirstOrDefault() != null)
            {
                Btnstp1.Enabled = false;
                btnstp3.Enabled = false;
                btnstp2.Enabled = true;
                label4.Text = drives.FirstOrDefault().Name.ToString();
                int i = 1;
                while (i <= 1)
                {

                    if (uusssbb.GetUSBDevices().Any(x => drives.ToString() == correctHash))
                        i++;
                    break;
                }
                string path = OsDrive + "TextFile111.txt";
                richTextBox1.Text = File.ReadAllText(path);
            }
            else
            {
                MessageBox.Show("Please Connect Usb Drive.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnstp2_Click(object sender, EventArgs e)
        {
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);

            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable).ToList();
            if (drives.FirstOrDefault() != null)
            {
                MessageBox.Show("Please Disconnect Pendrive...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnstp2.Enabled = false;
                btnstp3.Enabled = true;
                int q = 1;
                while (q <= 1)
                {

                    if (uusssbb.GetUSBDevices().Any(x => x.ToString() == correctHash))
                        q++;
                    break;
                }
                string path = OsDrive + "TextFile111.txt";
                string path1 = OsDrive + "TextFile222.txt";
                richTextBox1.Text = File.ReadAllText(path1);

                string[] names1 = File.ReadAllLines(path);
                string[] names2 = File.ReadAllLines(path1);

                // Create the query. Note that method syntax must be used here.  
                IEnumerable<string> differenceQuery = names1.Except(names2);

                // Execute the query.  

                foreach (string s in differenceQuery)
                    richTextBox2.Text = (s);

            }

        }

        private void TwoStep_Load(object sender, EventArgs e)
        {
            btnstp2.Enabled = false;
            btnstp3.Enabled = false;
            OsDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string path = OsDrive + "TextFile111.txt";
            string path1 = OsDrive + "TextFile222.txt";
            try
            {
                File.Delete(path);
                File.Delete(path1);
            }
            catch
            {

            }
           
            using (FileStream fs = File.Create(path));
            using (FileStream fs = File.Create(path1));

          
        }

        private void btnstp3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Admin")
            {
               
                    cmd = new SqlCommand("UPDATE SuperAdmin set Twostep_status=@Twostep_status,Two_Step=@Two_Step  where Username=@Username  ", con);
                    cmd.Parameters.AddWithValue("@Twostep_status", 1);
                   cmd.Parameters.AddWithValue("@Two_Step", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Username", label2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                MessageBox.Show("Two Step Verification Enabled Sucessfully :) ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Btnstp1.Enabled = false;
                btnstp2.Enabled = false;
                btnstp3.Enabled = false;
                OsDrive = Path.GetPathRoot(Environment.SystemDirectory);
                string path = OsDrive + "TextFile111.txt";
                string path1 = OsDrive + "TextFile222.txt";
                try
                {
                    File.Delete(path);
                    File.Delete(path1);
                }
                catch
                {

                }
                this.Close();




            }
            else
            {
                
                    cmd = new SqlCommand("UPDATE NewUser set Twostep_status=@Twostep_status,Two_Step=@Two_Step  where Username=@Username  ", con);
                    cmd.Parameters.AddWithValue("@Twostep_status", 1);
                    cmd.Parameters.AddWithValue("@Two_Step", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Username", label2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Two Step Verification Enabled Sucessfully :) ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Btnstp1.Enabled = false;
                btnstp2.Enabled = false;
                btnstp3.Enabled = false;
                string path = OsDrive + "TextFile111.txt";
                string path1 = OsDrive + "TextFile222.txt";
                try
                {
                    File.Delete(path);
                    File.Delete(path1);
                }
                catch
                {

                }
                this.Close();


            }
        }
    }
}
