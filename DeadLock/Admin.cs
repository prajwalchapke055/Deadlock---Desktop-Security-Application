﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DeadLock
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public Admin()
        {
            InitializeComponent();
        }
       
        private void txtpass_Leave(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
            //Validating  groupbox condition...............
            if (!(txtpass.TextLength >= 8))
            {
                //  MessageBox.Show("Password Contain at least 8 Character ");
                label4.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label4.ForeColor = Color.SpringGreen;
               
            }
            //---------------------------
            if (!txtpass.Text.Any(char.IsUpper))//checking one upper char
            {
                label2.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label2.ForeColor = Color.SpringGreen;
               
            }
            //------------------------
            if (!txtpass.Text.Any(char.IsLower))//checking one lower char
            {
                label3.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label3.ForeColor = Color.SpringGreen;
                
            }
            //--------------------------------------
            if (!txtpass.Text.Any(char.IsNumber))//checking number
            {
                label5.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label5.ForeColor = Color.SpringGreen;
               
            }
            //--------------------------------------------------
            if (txtpass.Text.Contains(" "))//no blank spaces in pass
            {
                label8.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label8.ForeColor = Color.SpringGreen;
                
            }

            //----------------------------------
            String test_string = txtpass.Text;
            if (Regex.IsMatch(test_string, "^[a-zA-Z0-9\x20]+$"))//using regular expression for checking symbol in pass
            {
              
                label7.ForeColor = Color.Red;
                btnCreateacc.Enabled = false;
            }
            else
            {
                label7.ForeColor = Color.SpringGreen;
                
            }
            //Checking Password and Retype Password
            passcheck();
        }
        private void passcheck()
        {
            if (txtpass.Text == TextBox5.Text)
            {
                btnCreateacc.Enabled = true;

            }
            else
            {
                btnCreateacc.Enabled = false;
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_Click(object sender, EventArgs e)
        {
           
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox1.Visible = true;
        }
        //Foram Load
        private void Admin_Load(object sender, EventArgs e)
        {
            

          

            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            txtotp.Enabled = true;
            TextBox3.Enabled = false;
            TextBox5.Enabled = false;
            txtpass.Enabled = false;


            if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "" && txtpass.Text == "" && TextBox5.Text == ""&&txtotp.Text=="")
            {
                btnCreateacc.Enabled = false;  
            }
            else
            {
                btnCreateacc.Enabled = true;
            }
            PictureBox3.Visible = false;
            pictureBox1.Visible = false;
            //Checking Internet Connection...
            if (NetworkInterface.GetIsNetworkAvailable())
            {
            }
            else
            {
                MessageBox.Show("Please Connect Internet, To Proceed... :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                this.Close();
            }
            //------------------

           

        }

       
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            //Checking Password and Retype Password
            passcheck();
        }
        private void email()
        {
            //Genrate Random OTP
            string otpcode;
            Random rand = new Random();
            otpcode = (rand.Next(9999999)).ToString();
            label9.Text = otpcode;

            //Sending Mail
            try
            {
                TextBox1.Enabled = false;
                TextBox2.ReadOnly = true;
                
                TextBox3.Enabled = false;
                TextBox5.Enabled = false;
                txtpass.Enabled = false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("prajwalchapke055@gmail.com");
                mail.To.Add(TextBox2.Text);
                mail.IsBodyHtml = true;
                mail.Subject = "OTP Verification...";
                mail.Body = "Your OTP Code is :- " + otpcode;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("prajwalchapke055@gmail.com", "Pmchapke@123");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Email Sent Sucessfully | Check Email...  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
        }

        private void txtotp_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //Validating OTP

            if (label9.Text == txtotp.Text)
            {
                MessageBox.Show("OTP Verified Sucessfully ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBox1.Enabled = true;
                TextBox2.ReadOnly = true;
                txtotp.ReadOnly = true;
                TextBox3.Enabled = true;
                TextBox5.Enabled = true;
                txtpass.Enabled = true;
                PictureBox3.Visible = false;

            }
            else
            {
                MessageBox.Show("Wrong Verification Code :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtotp.Clear();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Checking Domain And Sending Mail 

            if (TextBox2.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Please Enter OTP To Continue ", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                email();
                PictureBox3.Visible = true;
                MessageBox.Show("Please Check Your Gmail ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Please Enter Only Gmail Id ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox2.PlaceholderText = "E.g :-  abcpqr@gmail.com";
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void picshowpass_Click(object sender, EventArgs e)
        {
            //displaying or hiding password
            if (txtpass.UseSystemPasswordChar == false && TextBox5.UseSystemPasswordChar == false)
            {
                txtpass.UseSystemPasswordChar = true;
                TextBox5.UseSystemPasswordChar = true;
            }
            else
            {
                txtpass.UseSystemPasswordChar = false;
                TextBox5.UseSystemPasswordChar = false;
            }
                
        }

        private void btnCreateacc_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && txtpass.Text != "" && TextBox5.Text != "" && txtotp.Text != "")
            {
                cmd = new SqlCommand("insert into SuperAdmin(Name,Email,Username,Password,Twostep_status,Two_Step,Form_Status) values(@Name,@Email,@Username,@Password,@Twostep_status,@Two_Step,@Form_Status)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Username", TextBox3.Text);
                cmd.Parameters.AddWithValue("@Password", txtpass.Text);
                cmd.Parameters.AddWithValue("@Twostep_status","0");
                cmd.Parameters.AddWithValue("@Two_Step", "0");
                cmd.Parameters.AddWithValue("@Form_Status", "1");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Super User Added Sucessfully ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                Login ss = new Login();
                ss.Show();
                
                Form1 sq = new Form1();
                sq.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Fill All Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
