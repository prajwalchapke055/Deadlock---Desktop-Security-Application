using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class HideFolder : Form
    {
        SqlConnection abc = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public HideFolder(string getname)
        {
            InitializeComponent();
            label1.Text = getname;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Select the folder to lock
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                textBox1.Text = $"\"{textBox1.Text}\"";
                BtnLock.Enabled = true;
            }
        }

        private void display()
        {

            SqlDataAdapter adapt = new SqlDataAdapter("select * from hiden where username like '" + label1.Text + "%' ", abc);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
               


                BtnLock.Enabled = false;
                ProcessStartInfo ps = new ProcessStartInfo();
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                ps.FileName = "cmd.exe";
                ps.Arguments = @"/c  attrib  +s +h  /s /d " + textBox1.Text;
                ps.Verb = "runas";
                Process.Start(ps);
                MessageBox.Show("Hiden Sucessfully","Sucess...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //---------------------------------------------

                cmd = new SqlCommand("insert into hiden(path,username)values(@path,@username)", abc);
                abc.Open();
                cmd.Parameters.AddWithValue("@path", textBox1.Text);
                cmd.Parameters.AddWithValue("@username", label1.Text);               
                cmd.ExecuteNonQuery();
                // MessageBox.Show(this, "ADDED SUCESSFULLY.", "Sucess...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                display();
                abc.Close();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Please Select Folder For Hide.....", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (e.ColumnIndex == 2)
            {

                if (textBox1.Text != "")
                {
                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.FileName = "cmd.exe";
                    ps.Arguments = @"/c  attrib  -s -h  /s /d  " + textBox1.Text.ToString();
                    ps.Verb = "runas";
                    Process.Start(ps);
                    MessageBox.Show("Folder Un-Hide Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //----------------------------------------------
                    if (id != 0)
                    {
                        cmd = new SqlCommand("delete hiden where ID=@id", abc);
                        abc.Open();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        //  MessageBox.Show("Record Deleted Successfully!");
                        display();
                        textBox1.Clear();
                        abc.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Delete", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Folder For Un-Hide.....", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


       }

        private void HideFolder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'deadLockDataSet1.hiden' table. You can move, or remove it, as needed.
            this.hidenTableAdapter1.Fill(this.deadLockDataSet1.hiden);
           
            BtnLock.Enabled = false;
            display();

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            abc.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from  hiden where path like'%" + guna2TextBox2.Text + "%' ", abc);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            abc.Close();
        }
    }
}
