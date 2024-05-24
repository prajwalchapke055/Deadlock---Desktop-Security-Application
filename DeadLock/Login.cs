using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DeadLock
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Login()
        {
            InitializeComponent();
        }
        public string str_, str1_;
        public int count_, count1_;
        public SoundPlayer Player = new SoundPlayer();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
     
      
        private void twostep()
        {
            if (guna2ToggleSwitch1.Checked)
            {
                //Its User Check

              //  con.Open();
                SqlDataAdapter dt = new SqlDataAdapter("select Twostep_status from [NewUser] where Twostep_status='" + label9.Text + "'", con);
                DataTable d1 = new DataTable();
                dt.Fill(d1);
                if (d1.Rows.Count == 1)
                {
                    //two  step is enabled
                    securitykey sw = new securitykey();
                    //passing value of username 
                    sw.passingvalue = guna2TextBox1.Text;
                    //passing admin or user value
                    if (guna2ToggleSwitch1.Checked)
                    {
                        //user
                        sw.passingtype = label7.Text;

                    }
                    else
                    {
                        //admin
                        sw.passingtype = label4.Text;
                    }
                    sw.Show();

                    this.Hide();

                }
                else
                {
                    //two step is disabled
                    Master2 ss = new Master2();
                    ss.passingvalue = guna2TextBox1.Text;//username
                    if (guna2ToggleSwitch1.Checked)
                    {
                        ss.passingtype = label7.Text;//user

                    }
                    else
                    {
                        ss.passingtype = label4.Text;//admin
                    }
                    ss.Show();

                     this.Hide();

                }
               // con.Close();


            }
            else
            {
                //Its Admin Check
             //   con.Open();
                SqlDataAdapter dt = new SqlDataAdapter("select Twostep_status from [SuperAdmin] where Twostep_status='" + label9.Text + "'", con);
                DataTable d1 = new DataTable();
                dt.Fill(d1);
                if (d1.Rows.Count == 1)
                {
                    
                    securitykey sw = new securitykey();
                    sw.passingvalue = guna2TextBox1.Text;//paasing username
                    if (guna2ToggleSwitch1.Checked)
                    {
                        sw.passingtype = label7.Text;//passing user

                    }
                    else
                    {
                        sw.passingtype = label4.Text;// passing admin
                    }
                    sw.Show();

                    this.Hide();

                }
                else
                {
                    Master2 ss = new Master2();
                    ss.passingvalue = guna2TextBox1.Text;
                    if (guna2ToggleSwitch1.Checked)
                    {
                        ss.passingtype = label7.Text;

                    }
                    else
                    {
                        ss.passingtype = label4.Text;
                    }
                    ss.Show();

                     this.Hide();

                }
              //  con.Close();

            }

            //Two Step End

           
        }
        private void Login_Load(object sender, EventArgs e)
        {
           
            loop();
        
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
       int r=0;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                try
                {
                    //user pass check
                    con.Open();
                    SqlDataAdapter dt = new SqlDataAdapter("select Username from [NewUser] where Username='" + guna2TextBox1.Text + "'and Password='" + guna2TextBox2.Text + "'", con);
                    DataTable d1 = new DataTable();
                    dt.Fill(d1);
                    if (d1.Rows.Count == 1)
                    {

                        MessageBox.Show(this, "LOGIN SUCESSFULLY...:)", "Sucess...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Player.Stop();
                      
                        twostep();//calling twostep for checking two  step verification
                     
                    }
                    else
                    {

                        MessageBox.Show(this, "Wrong Username And Password....:(", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2TextBox1.Clear();
                        guna2TextBox2.Clear();
                        r = r + 1;
                        if (r == 3)
                        {
                            Application.Exit();
                        }
                        else if (r == 2)
                        {
                            this.Player.SoundLocation = @"D:\DeadLock\DeadLock\Resources\Alarm.wav";
                             this.Player.PlayLooping();
                        }
                        else
                        {

                        }

                    }
                    con.Close();
                }
                catch (Exception ew)
                {
                    var rr = 0;
                    MessageBox.Show(this, "Wrong Username And Password...:(", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    rr = rr + 1;
                    if (rr == 3)
                    {
                        Application.Exit();
                    }
                }
            }
            //  it's admin login entry
            else
            {
                
                try
                {
                    con.Open();
                    SqlDataAdapter dt = new SqlDataAdapter("select Username from [SuperAdmin] where Username='" + guna2TextBox1.Text + "'and Password='" + guna2TextBox2.Text + "'", con);
                    DataTable d1 = new DataTable();
                    dt.Fill(d1);
                    if (d1.Rows.Count == 1)
                    {

                        MessageBox.Show(this, "LOGIN SUCESSFULLY....:)", "Sucess...", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Player.Stop();                     
                        twostep();                      
                    }
                    else
                    {

                        MessageBox.Show(this, "Wrong Username And Password.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2TextBox1.Clear();
                        guna2TextBox2.Clear();
                        r = r + 1;
                        if (r == 3)
                        {
                            Application.Exit();
                        }
                        else if (r == 2)
                        {
                            this.Player.SoundLocation = @"D:\DeadLock\DeadLock\Resources\Alarm.wav";
                            this.Player.PlayLooping();
                        }
                        else
                        {

                        }

                    }
                    con.Close();
                }
                catch (Exception ew)
                {
                    var rr = 0;
                    MessageBox.Show(ew.ToString());
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    rr = rr + 1;
                    if (rr == 3)
                    {
                        Application.Exit();
                    }
                }
            }


           


        }

        private void label6_Click(object sender, EventArgs e)
        {
            //displaying new user form
            User sw = new User();
            sw.Show();
            this.Hide();
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }

      

        private void Swtshow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Swtshow_CheckedChanged_1(object sender, EventArgs e)
        {//password view
            if (Swtshow.Checked)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Forgetpass sw = new Forgetpass();
            sw.Show();
            this.Hide();
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }
        public void loop()
        {
            Label1.Text = "";
            count_ = 1;
            str_ = "D E A D L O C K E R";
            timer1.Enabled = true;
            //--------------------------------
            label2.Text = "";
            count1_ = 1;
            str1_ = "T H E";
            timer2.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Label1.Text.Length == str_.Length)
            {
                timer1.Enabled = false;
                loop();
                return;
            }
            Label1.Text = str_.Substring(0, count_);
            count_++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label2.Text.Length == str1_.Length)
            {
                timer2.Enabled = false;
                return;
            }
            label2.Text = str1_.Substring(0, count1_);
            count1_++;
        }
    }
}
