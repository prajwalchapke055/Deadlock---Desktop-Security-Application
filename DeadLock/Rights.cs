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
    public partial class Rights : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Rights()
        {
            InitializeComponent();
           
        }
      
        public void retrive()
        {
            cmd = new SqlCommand("Select * from rightss  ", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                comboBox1.Text = sdr["Drive_Lock"].ToString();
                comboBox2.Text = sdr["Rights"].ToString();
                comboBox3.Text = sdr["Lock_Folder"].ToString();
                comboBox4.Text = sdr["Hide_Folder"].ToString();
                comboBox5.Text = sdr["Encrypt_Folder"].ToString();
                comboBox6.Text = sdr["Two_step"].ToString();
                comboBox7.Text = sdr["Change_Password"].ToString();

            }
           
            con.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update rightss set Drive_Lock='" + comboBox1.Text + "',Lock_Folder='" + comboBox3.Text + "',Hide_Folder='" + comboBox4.Text + "',Encrypt_Folder='" + comboBox5.Text + "',Two_step='" + comboBox6.Text + "',Change_Password='" + comboBox7.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Rights Update Sucessfully...:)", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Rights_Load(object sender, EventArgs e)
        {
         
            retrive();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
