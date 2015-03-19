/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.IO;

namespace encryption
{
    public partial class beveiliging : Form
    {
        private bool encrypt;

        public beveiliging()
        {
            InitializeComponent();
        }

        void saveFile_FileOk(object sender, CancelEventArgs e)
        {
            T_destination.Text = saveFile.FileName;
        }

        private void B_zoeken_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
        }

        void openFile_FileOk(object sender, CancelEventArgs e)
        {
            if (openFile.FilterIndex != 2)
            {
                saveFile.FileName = "";
                saveFile.Filter = "Encrypt File (*.Ter) | *.Ter";
                encrypt = true;
                T_source.Text = openFile.FileName;
            }
            else
            {
                saveFile.FileName = "";
                saveFile.Filter = "Decrypt File (*.?)|*.*";
                encrypt = false;
                T_source.Text = openFile.FileName;
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }

        private void Encrypt_Decrypt_Click(object sender, EventArgs e)
        {
            if (T_source.Text == "")
            {
                MessageBox.Show("Je moet nog het orginele bestand selecteren!");
            }
            else if (T_destination.Text == "")
            {
                MessageBox.Show("Je moet nog het bestemmings pad selecteren!");
            }
            else if (T_pass.Text == "")
            {
                MessageBox.Show("Als je geen wachtwoord invoerd kan dit bestand alleen worden 'Encrypt/Decrypt' \n\r op deze computer!");
            }
            if (encrypt)
            {
                Encrypt();
            }
            else
            {
                Decrypt();
            }
        }

        private void Decrypt()
        {
            //try
            //{
            string passwoord = T_pass.Text;
            FileStream source = new FileStream(T_source.Text,FileMode.Open, FileAccess.ReadWrite);
            FileStream destination = new FileStream(T_destination.Text,FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            if (passwoord != "")
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(passwoord);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(passwoord);
            }
            else
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes("knetter7");
                DES.IV = ASCIIEncoding.ASCII.GetBytes("knetter7");
            }
            ICryptoTransform desencrypt = DES.CreateDecryptor();
            CryptoStream cryptostream = new CryptoStream(source,desencrypt,CryptoStreamMode.Write);

            StreamWriter fsDecrypted = new StreamWriter(T_destination.Text);
            fsDecrypted.Write(new StreamReader(cryptostream).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();

            MessageBox.Show("File Decrypted!");
                
            //}
            //catch
            //{
            //    MessageBox.Show("Failed to decrypt the file!");
                
            //}
            ClearTextboxen();
        }

        private void Encrypt()
        {
            //try
            //{
                string passwoord = T_pass.Text;
                FileStream source = new FileStream(T_source.Text, FileMode.Open, FileAccess.ReadWrite);
                FileStream destination = new FileStream(T_destination.Text, FileMode.Create, FileAccess.Write);
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            
                if (passwoord != "")
                {
                        DES.Key = ASCIIEncoding.ASCII.GetBytes(passwoord);
                        DES.IV = ASCIIEncoding.ASCII.GetBytes(passwoord);

                }
                else
                {
                    DES.Key = ASCIIEncoding.ASCII.GetBytes("knetter7");
                    DES.IV = ASCIIEncoding.ASCII.GetBytes("knetter7");
                }
                ICryptoTransform des_encrypt = DES.CreateEncryptor();
                CryptoStream cryptosource = new CryptoStream(source, des_encrypt, CryptoStreamMode.Write);
                byte[] destinationbestand = new byte[source.Length];
                
                cryptosource.Write(destinationbestand, 0, Convert.ToInt32(destination.Length));
                cryptosource.Close();
                destination.Write(destinationbestand, 0, destinationbestand.Length);
                source.Close();
                destination.Close();

                MessageBox.Show("File Encrypted!");
            //}
            //catch
            //{
            //    MessageBox.Show("Failed to encrypt the file!");
            //}
            ClearTextboxen();
        }

        private void ClearTextboxen()
        {
            T_pass.Clear();
            T_destination.Clear();
            T_source.Clear();
        }

        private void B_sluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
