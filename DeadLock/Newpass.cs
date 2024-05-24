using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class Newpass : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Newpass()
        {
            InitializeComponent();
  
        }
        public string mail, type;
        public string passingvalue
        {

            get { return mail; }
            set { mail = value; }

        }
        public string passingtype
        {

            get { return type; }
            set { type = value; }

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Admin")
            {
                if ((TextBox3.Text == TextBox2.Text))
                {
                    cmd = new SqlCommand("UPDATE SuperAdmin set Password=@Password  where Email=@Email  ", con);
                    cmd.Parameters.AddWithValue("@Password", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", label1.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Reset Sucessfully :) ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login sw = new Login();
                    sw.Show();
                }
                else
                    MessageBox.Show("Password Do Not Match Try Again..... :( ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if ((TextBox3.Text == TextBox2.Text))
                {
                    cmd = new SqlCommand("UPDATE NewUser set Password=@Password  where Email=@Email  ", con);
                    cmd.Parameters.AddWithValue("@Password", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", label1.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Reset Sucessfully :) ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login sw = new Login();
                    sw.Show();
                }
                else
                    MessageBox.Show("Password Do Not Match Try Again..... :( ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void Newpass_Load(object sender, EventArgs e)
        {
            label2.Text = "" + type;
            label1.Text = "" + mail;
            btn_Add.Enabled = false;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            

            if (!(TextBox3.TextLength >= 8))
            {
                //  MessageBox.Show("Password Contain at least 8 Character ");
                label6.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label6.ForeColor = Color.SpringGreen;

            }
            //---------------------------
            if (!TextBox3.Text.Any(char.IsUpper))
            {
                label4.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label4.ForeColor = Color.SpringGreen;

            }
            //------------------------
            if (!TextBox3.Text.Any(char.IsLower))
            {
                label3.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label3.ForeColor = Color.SpringGreen;

            }
            //--------------------------------------
            if (!TextBox3.Text.Any(char.IsNumber))
            {
                label5.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label5.ForeColor = Color.SpringGreen;

            }
            //--------------------------------------------------
            if (TextBox3.Text.Contains(" "))
            {
                label8.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label8.ForeColor = Color.SpringGreen;

            }

            //----------------------------------
            String test_string = TextBox3.Text;
            if (Regex.IsMatch(test_string, "^[a-zA-Z0-9\x20]+$"))
            {

                label7.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label7.ForeColor = Color.SpringGreen;

            }
            passcheck();
        }
        private void passcheck()
        {
            if (TextBox3.Text == TextBox2.Text)
            {
                btn_Add.Enabled = true;

            }
            else
            {
                btn_Add.Enabled = false;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            passcheck();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
