using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class securitykey : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private static string _correctHash ;
        public securitykey()
        {
            InitializeComponent();
        }
        public string name, type;
        public string passingvalue
        {

            get { return name; }
            set { name = value; }

        }
        public string passingtype
        {

            get { return type; }
            set { type = value; }

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void fetchday()
        {

            if (label3.Text == "Admin")
            {
                try
                {
                    cmd = new SqlCommand("Select * from SuperAdmin where Username = '" + label2.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        _correctHash = sdr["Two_Step"].ToString();
                      
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("Select * from NewUser where Username = '" + label2.Text + "' ", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        _correctHash = sdr["Two_Step"].ToString();

                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            while (true)
            {
                
                if (uusssbb.GetUSBDevices().Any(x => x.ToString() == _correctHash))
                    break;
                Thread.Sleep(1000);
            }
            Master2 sq = new Master2();
            sq.passingtype = label3.Text;
            sq.passingvalue = label2.Text;
            sq.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void securitykey_Load(object sender, EventArgs e)
        {
            label3.Text = "" + type;
            label2.Text = "" + name;
            fetchday();


        }
    }
}
