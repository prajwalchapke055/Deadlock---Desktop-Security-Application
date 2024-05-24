using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            string regeditpath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
            if (objRegistryKey.GetValue("DisableRegistryTools") == null)
            {
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(regeditpath, true);
                regkey.SetValue("DisableRegistryTools", 2, RegistryValueKind.DWord);
            }
           // MessageBox.Show("Disabled Sucessfully");
            objRegistryKey.Close();


            con.Open();
            SqlDataAdapter dt = new SqlDataAdapter("select Form_Status from [SuperAdmin] where Form_Status='" + textBox1.Text + "'", con);
            DataTable d1 = new DataTable();
            dt.Fill(d1);
            if (d1.Rows.Count == 1)
            {
                Login sw = new Login();
                sw.Show();

                this.Hide();

            }
            else
            {
                Admin ss = new Admin();
                ss.Show();
                
                this.Hide();

            }
            con.Close();
            this.Hide();
          //  Application.Exit();
        }
    }
}
