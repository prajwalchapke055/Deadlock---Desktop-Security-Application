using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class Lock_Folder : Form
    {
        SqlConnection abc = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt = new SqlDataAdapter();
        
        int id = 0;

        public Lock_Folder(string getname,string gettype)
        {
            InitializeComponent();
            label1.Text = getname;//Getting value from master form
            label7.Text = gettype;
            arr = new string[6];
            status = "";
            arr[0] = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
        }

        public static string fc;
        public string status;
        public static string sp; //selected path
        string[] arr;
        private string _pathkey;
        public string pathkey
        {
            get { return _pathkey; }
            set { _pathkey = value; }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            status = arr[0];
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                sp = folderBrowserDialog1.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                string selectedpath = d.Parent.FullName + d.Name;
                label4.Text = selectedpath;
                BtnLock.Enabled = true;
            }
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            //calling random pass
            string password = GetRandomPassword(5);
            label2.Text = password + label1.Text;

            BtnLock.Enabled = false;
            if (textBox1.Text.LastIndexOf(".{") == -1)
            {


                try
                {

                    string[] directoryFiles = Directory.GetFiles(textBox1.Text, ".*", SearchOption.AllDirectories);
                    // DirectoryInfo di = new DirectoryInfo("YourPath");
                    foreach (string directoryFile in directoryFiles)
                    {
                        FileSecurity fs = File.GetAccessControl(sp);//getting list of access control
                        fs.SetOwner(WindowsIdentity.GetCurrent().User);//getting current user and set current user as owner
                        fs.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));//removing all acess rule of directory
                        File.SetAccessControl(sp, fs);
                    }

                    DirectoryInfo d = new DirectoryInfo(sp);
                    string selectedpath = d.Parent.FullName + d.Name;
                    if (!d.Root.Equals(d.Parent.FullName))
                        d.MoveTo(d.Parent.FullName + "\\" + d.Name + status);

                    else d.MoveTo(d.Parent.FullName + d.Name + status);

                    sp = sp + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
                    FileSecurity fileSecurity = File.GetAccessControl(sp);
                    fileSecurity.SetOwner(WindowsIdentity.GetCurrent().User);
                    fileSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
                    File.SetAccessControl(sp, fileSecurity);


                    MessageBox.Show("The Selected Folder Has Been Locked  Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }


                //------------------------------------------------------------------------------------------------------------
                cmd = new SqlCommand("insert into lock(path,username,rndpass)values(@path,@username,@rndpass)", abc);
                abc.Open();
                cmd.Parameters.AddWithValue("@path", textBox1.Text);
                cmd.Parameters.AddWithValue("@username", label1.Text);
                cmd.Parameters.AddWithValue("@rndpass", label2.Text);
                cmd.ExecuteNonQuery();
                // MessageBox.Show(this, "ADDED SUCESSFULLY.", "Sucess...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                display();
                abc.Close();
                textBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Folder Is Already Locked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void display()
        {

            adapt = new SqlDataAdapter("select * from lock where username like '" + label1.Text + "%' ", abc);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private string getstatus(string stat)
        {
            for (int i = 0; i < 6; i++)
                stat = stat.Substring(stat.LastIndexOf("."));
            return stat;
        }

        /// Genrate random password....
        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^*()_+=-";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        private void fetched()
        {

            SqlCommand cmd = new SqlCommand("SELECT rndpass FROM lock WHERE rndpass='" + label3.Text + "'", abc);
            abc.Open();
            SqlDataReader re = cmd.ExecuteReader();

            if (re.Read())
            {
                label6.Text = re["rndpass"].ToString();
            }
            abc.Close();
            // dataGridView1.DataSource = dt;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            abc.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from  lock where path like'%" + guna2TextBox2.Text + "%' ", abc);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            abc.Close();
        }

        private void Lock_Folder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'deadLockDataSet1._lock' table. You can move, or remove it, as needed.
            this.lockTableAdapter1.Fill(this.deadLockDataSet1._lock);
            //label77.Text = "" + getname;
            display();
            BtnLock.Enabled = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            label3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (e.ColumnIndex == 4)
            {

                label5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";

                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                // textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                fetched();
                status = arr[0];
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                    sp = folderBrowserDialog1.SelectedPath;
                    DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                    string selectedpath = d.Parent.FullName + d.Name;
                    label4.Text = selectedpath;

                }

                //-----------------------------------------------------------------------------------





                if (label5.Text == textBox1.Text && label3.Text == label6.Text)
                {

                    //  MessageBox.Show("Matcheddddddd");
                    if (sp.LastIndexOf(".{") == -1)
                    {
                        MessageBox.Show("Folder Is Already Unlocked", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        fc = null;
                        DirectoryInfo d = new DirectoryInfo(sp);

                        //NTAccount account = new NTAccount();









                        string selectedpath = d.Parent.FullName + d.Name;
                        FileSecurity fileSecurity = File.GetAccessControl(sp);
                        //   fileSecurity.SetOwner(WindowsIdentity.GetCurrent().User);
                        fileSecurity.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
                        File.SetAccessControl(sp, fileSecurity);

                        MessageBox.Show("The Selected Folder Has Been Unlocked Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        status = getstatus(status);
                        d.MoveTo(sp.Substring(0, sp.LastIndexOf(".")));
                        string nsp = sp.Replace(".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}", "");
                        sp = nsp;
                        textBox1.Text = nsp;



                        string[] directoryFiles = Directory.GetFiles(textBox1.Text, ".*", SearchOption.AllDirectories);
                        // DirectoryInfo di = new DirectoryInfo("YourPath");
                        foreach (string directoryFile in directoryFiles)
                        {
                            FileSecurity fs = File.GetAccessControl(sp);//getting list of access control
                         //   fs.SetOwner(WindowsIdentity.GetCurrent().User);//getting current user and set current user as owner
                            fs.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));//removing all acess rule of directory
                            File.SetAccessControl(sp, fs);
                        }






                        //---------------------------------------------------------------------------------------------------------------------------------
                        if (id != 0)
                        {
                            cmd = new SqlCommand("delete lock where ID=@id", abc);
                            abc.Open();
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            display();
                            abc.Close();
                            textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                        }


                    }

                }
                else
                {
                    MessageBox.Show("Please Select Proper Folder Path.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }


            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
