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
    public partial class Change_Password : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public Change_Password(string getname,string gettype)
        {
            InitializeComponent();
            //getting username and usertype
            label9.Text = getname;
            label10.Text = gettype;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            txtnew.Enabled = false;
            txtretype.Enabled = false;
            btn_Add.Enabled = false;
        }

        private void txtold_TextChanged(object sender, EventArgs e)
        {
            if (label9.Text == "User")
            {
                con.Open();
                SqlDataAdapter dt = new SqlDataAdapter("select Password from [NewUser] where Username='" + label9.Text + "'and Password='" + txtold.Text + "' ", con);
             
                DataTable d1 = new DataTable();
                dt.Fill(d1);
                if (d1.Rows.Count == 1)
                {

                   
                    txtnew.Enabled = true;
                    txtretype.Enabled = true;
                    btn_Add.Enabled = true;



                }
                else
                {
                    txtnew.Enabled = false;
                    txtretype.Enabled = false;
                    btn_Add.Enabled = false;

                }
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataAdapter dt = new SqlDataAdapter("select Password from [SuperAdmin] where Username='" + label9.Text + "'and Password='" + txtold.Text + "' ", con);
                
                DataTable d1 = new DataTable();
                dt.Fill(d1);
                if (d1.Rows.Count == 1)
                {

                   
                    txtnew.Enabled = true;
                    txtretype.Enabled = true;
                    btn_Add.Enabled = true;



                }
                else
                {
                    txtnew.Enabled = false;
                    txtretype.Enabled = false;
                    btn_Add.Enabled = false;

                }
               con.Close();
            }

        }
      
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //updating password
            if (label10.Text == "Admin")
            {
                if (txtnew.Text == txtretype.Text)//checking password
                {
                    cmd = new SqlCommand("UPDATE SuperAdmin set Password=@Password  where Username=@Username  ", con);
                    cmd.Parameters.AddWithValue("@Password", txtnew.Text);
                    cmd.Parameters.AddWithValue("@Username", label9.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Reset Sucessfully :)  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                  
                }
                else
                    
                MessageBox.Show("Password Do Not Match Try Again..... :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (txtnew.Text == txtretype.Text)
                {
                    cmd = new SqlCommand("UPDATE NewUser set Password=@Password  where Username=@Username  ", con);
                    cmd.Parameters.AddWithValue("@Password", txtnew.Text);
                    cmd.Parameters.AddWithValue("@Username", label9.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Reset Sucessfully :)  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Password Do Not Match Try Again..... :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnew_TextChanged(object sender, EventArgs e)
        {
            //checking password condition
            if (!(txtnew.TextLength >= 8))
            {
               
                label6.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label6.ForeColor = Color.SpringGreen;

            }
            //---------------------------
            if (!txtnew.Text.Any(char.IsUpper))
            {
                label4.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label4.ForeColor = Color.SpringGreen;

            }
            //------------------------
            if (!txtnew.Text.Any(char.IsLower))
            {
                label3.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label3.ForeColor = Color.SpringGreen;

            }
            //--------------------------------------
            if (!txtnew.Text.Any(char.IsNumber))
            {
                label5.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label5.ForeColor = Color.SpringGreen;

            }
            //--------------------------------------------------
            if (txtnew.Text.Contains(" "))
            {
                label8.ForeColor = Color.Red;
                btn_Add.Enabled = false;
            }
            else
            {
                label8.ForeColor = Color.SpringGreen;

            }

            //----------------------------------
            String test_string = txtnew.Text;
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
            if (txtnew.Text == txtretype.Text)
            {
                btn_Add.Enabled = true;

            }
            else
            {
                btn_Add.Enabled = false;
            }
        }

        private void txtretype_TextChanged(object sender, EventArgs e)
        {
            passcheck();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
