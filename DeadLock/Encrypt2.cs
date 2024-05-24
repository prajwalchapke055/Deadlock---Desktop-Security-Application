using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeadLock
{
    public partial class Encrypt2 : Form
    {
        public Encrypt2()
        {
            InitializeComponent();
        }

        private void Encrypt2_Load(object sender, EventArgs e)
        {
            btnEncrypt.Visible = false;
            btnDecrypt.Visible = false;
            progressBar1.Visible = false;
            btnbrowse_opt.Enabled = false;
        }

        private void btnBrowse_inp_Click(object sender, EventArgs e)
        {
            if (!swtcheck.Checked)
            {//folder browse dialog for inpute box
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Select the folder to lock
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                    btnbrowse_opt.Enabled = true;
                    progressBar1.Value = 0;

                }
            }
            else
            {
                //selected decrypt the open file dialog
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"E:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt | All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                    btnbrowse_opt.Enabled = true;
                    btnDecrypt.Visible = true;

                }
            }

          
        }

        private void btnbrowse_opt_Click(object sender, EventArgs e)
        {
            if (!swtcheck.Checked)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    // display dialogbox for output
                    textBox2.Text = folderBrowserDialog1.SelectedPath;
                    if (File.Exists(textBox2.Text + "\\Encrypt.zip"))
                    {
                        File.Delete(textBox2.Text + "\\Encrypt.zip");

                    }
                    btnEncrypt.Visible = true;
                    
              
                        
                }
            }
            else
            {
                if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                  
                    textBox2.Text = folderBrowserDialog1.SelectedPath;
                    if (Directory.Exists(textBox2.Text + "\\Decrypted"))
                    {
                        MessageBox.Show("Please Change Decrypted Directory Name | Otherwise Change The Output Location...");
                        textBox2.Clear();

                    }
                   

                }
            }
           
           
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != "" && textBox1.Text!="" && textBox2.Text!="")
            {
                string input = textBox1.Text;

                string op = textBox2.Text + "\\Encrypt.zip";

                string password = txtpass.Text;
         
                ZipFile.CreateFromDirectory(input, op);//creating zip file
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 40;
                FileEncrypt(op, password);//calling encrypt method
                
                progressBar1.Value = 50;
                File.Delete(op);

                progressBar1.Value = 100;
                MessageBox.Show("Encrypted | Sucessfully....:) ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressBar1.Visible = false;
                MessageBox.Show("Please Enter Secret Key....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                string input = textBox1.Text;

                string output = textBox2.Text + "\\Encrypt.zip";

                string password = txtpass.Text;

                string ex = textBox2.Text + "\\Decrypted";
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 30;

                FileDecrypt(input, output, password);//calling decypt method

                progressBar1.Value = 80;
                ZipFile.ExtractToDirectory(output, ex);//extracting zip file

                string[] directoryFiles = Directory.GetFiles(ex, "*.aes", SearchOption.AllDirectories);
                // DirectoryInfo di = new DirectoryInfo("YourPath");
                foreach (string directoryFile in directoryFiles)
                {
                    File.Delete(directoryFile);
                }
                File.Delete(output);
                progressBar1.Value = 100;
                MessageBox.Show("Decrypted | Sucessfully...:)", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressBar1.Visible = false;
                MessageBox.Show("Please Enter Secret Key....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static byte[] GenerateRandomSalt()
        {

            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())//genrating high quality random number
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        private void FileEncrypt(string inputFile, string password)
        {
               //generate random salt
            byte[] salt = GenerateRandomSalt();
            
            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);
            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);            
            RijndaelManaged AES = new RijndaelManaged();//define aes
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;                      
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);//genrating key encryption decryption
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
             AES.Mode = CipherMode.CFB;         
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                cs.Close();
                fsCrypt.Close();
            }
            //  File.Delete = textBox1.Text;
            //  MessageBox.Show("Done");
        }


        private void FileDecrypt(string inputFile, string outputFile, string password)
        {

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);
            //  FileStream fsOut = new FileStream(outputFile + ".zip" ,FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                MessageBox.Show("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }

        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 15;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
