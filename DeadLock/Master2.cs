using SpeechLib;
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
    public partial class Master2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9QTIITB\\SQLEXPRESS;Initial Catalog=DeadLock;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Master2()
        {
            InitializeComponent();
            customizeDesign();
        }
        public string name,type;
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

        private void customizeDesign()
        {
            panelSubMenu1.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
            panelSubMenu4.Visible = false;

        }
        private void hideSubMenu()
        {
            if (panelSubMenu1.Visible == true)
                panelSubMenu1.Visible = false;
            if (panelSubMenu2.Visible == true)
                panelSubMenu2.Visible = false;
            if (panelSubMenu3.Visible == true)
                panelSubMenu3.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void Super_Button1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu1);
        }

        private void Lock_Folder_Click(object sender, EventArgs e)
        {
            
            openChildFormInPanel(new Lock_Folder(label1.Text,label4.Text));
           
            hideSubMenu();
            
        }

        private void Super_Button2_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu2);
        }

        private void Lock_Drive_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new DriveLock());
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChieldForm.Controls.Add(childForm);
            panelChieldForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //Fetching Name
        string nnmmee;
        private void fetchname()
        {
          
            if (label4.Text == "User")
            {
                cmd = new SqlCommand("select Name from NewUser where Username='"+ label1.Text + "' ", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    nnmmee = sdr["Name"].ToString();
                }
                con.Close();
            }
            else
            {
                cmd = new SqlCommand("select Name from SuperAdmin where Username='" + label1.Text + "' ", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    nnmmee = sdr["Name"].ToString();
                }
                con.Close();
            }   
        }
     
       // Checking Rights For USer
        public void retrive()
        {
            if (label4.Text == "User")
            {
                string drivelock,rights,folderlock,hidefolder,encrypt,twostep,changepass;
                cmd = new SqlCommand("Select * from rightss  ", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    drivelock = sdr["Drive_Lock"].ToString();
                    rights = sdr["Rights"].ToString();
                    folderlock = sdr["Lock_Folder"].ToString();
                    hidefolder = sdr["Hide_Folder"].ToString();
                    encrypt = sdr["Encrypt_Folder"].ToString();
                    twostep = sdr["Two_step"].ToString();
                    changepass = sdr["Change_Password"].ToString();


                    if (drivelock == "Deny")                   
                        Super_Button2.Visible = false;                     
                    if(rights == "Deny")
                        btnRights.Visible = false;
                    if (folderlock == "Deny")
                        Lock_Folder.Visible = false;
                    if (hidefolder == "Deny")
                        btnHide.Visible = false;
                    if (encrypt == "Deny")
                        Super_Button4.Visible = false;
                    if (twostep == "Deny")
                        guna2GradientButton11.Visible = false;
                    if (changepass == "Deny")
                        guna2GradientButton10.Visible = false;




                }
                con.Close();
            }

        }

        private void Master2_Load(object sender, EventArgs e)
        {
          
            
            label4.Text = "" + type;
            label1.Text = "" + name;
            retrive();
            fetchname();



        }
        
        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            if (DialogResult.Yes == MessageBox.Show("Are You Sure Want To Exit..?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           // ll.Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new HideFolder(label1.Text));
            hideSubMenu();
        }

        private void btntwostep_Click(object sender, EventArgs e)
        {
            
        }

        private void Super_Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void Super_Button3_Click_1(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu3);
        }

       
        private void btnEncryption_Click(object sender, EventArgs e)
        {
            
            
           
        }

        private void Super_Button4_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenu4);
        }

        private void btnenccc_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Encrypt2());
            hideSubMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SpVoice voice = new SpVoice();
            voice.Speak("Welcome To The World Of Dead Lock. Master "+ nnmmee, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            voice.WaitUntilDone(30000);
            timer1.Stop();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Change_Password(label1.Text, label4.Text));
            hideSubMenu(); 
            
        }

        private void guna2GradientButton11_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new TwoStep(label1.Text, label4.Text));
            hideSubMenu();
        }

        private void btnRights_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new Rights());
            hideSubMenu();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void panelChieldForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
