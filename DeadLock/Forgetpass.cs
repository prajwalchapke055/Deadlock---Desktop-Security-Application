using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class Forgetpass : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Forgetpass()
        {
            InitializeComponent();
         
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {

                con.Open();
                cmd = new SqlCommand("select Email from [SuperAdmin] where Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", TextBox1.Text);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if ((dt.Rows.Count == 1))
                {
                    string otpcode;
                    Random rand = new Random();
                    otpcode = (rand.Next(9999999)).ToString();
                    Label1.Text = otpcode;

                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("davidsonr882@gmail.com");
                        mail.To.Add(TextBox1.Text);
                        mail.IsBodyHtml = true;
                        mail.Subject = "Password Recovery...";
                        mail.Body = "Your OTP Code is :- " + otpcode;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("prajwalchapke055@gmail.com", "Pmchapke@123");
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                        MessageBox.Show("Email Sent Sucessfully | Check Email... ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBox2.Focus();
                        comboBox1.Enabled = false;
                        TextBox1.Enabled = false;
                        BTN_check.Enabled = true;
                        TextBox2.Enabled = true;
                    }
                    catch (SmtpException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Enter A Valid Email :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();


            }
            else if(comboBox1.SelectedIndex==1)
            {
                con.Open();
                cmd = new SqlCommand("select Email from [NewUser] where Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", TextBox1.Text);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if ((dt.Rows.Count == 1))
                {
                    string otpcode;
                    Random rand = new Random();
                    otpcode = (rand.Next(9999999)).ToString();
                    Label1.Text = otpcode;

                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("davidsonr882@gmail.com");
                        mail.To.Add(TextBox1.Text);
                        mail.IsBodyHtml = true;
                        mail.Subject = "Password Recovery...";
                        mail.Body = "Your OTP Code is :- " + otpcode;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("prajwalchapke055@gmail.com", "Pmchapke@123");

                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                        MessageBox.Show("Email Sent Sucessfully | Check Email... ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBox2.Focus();
                        comboBox1.Enabled = false;
                        TextBox1.Enabled = false;
                        BTN_check.Enabled = true;
                        TextBox2.Enabled = true;
                    }
                    catch (SmtpException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Enter A Valid Email :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            else
            {
                MessageBox.Show("Please select user type :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_check_Click(object sender, EventArgs e)
        {
            var r = 0;
            if (Label1.Text == TextBox2.Text)
            {
                
                Newpass qw = new Newpass();
                qw.passingtype = comboBox1.Text;
                qw.passingvalue = TextBox1.Text;
                qw.Show();
                this.Hide();



            }
            else
            {
               MessageBox.Show("Wrong Verification Code :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = r + 1;
                if (r == 3)
                    this.Close();
            }
        }

        private void Forgetpass_Load(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
            }
            else
            {
                MessageBox.Show("Please Connect Internet, To Proceed... :( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            BTN_check.Enabled = false;
            TextBox2.Enabled = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
