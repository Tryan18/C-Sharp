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
using System.Security.Cryptography;
using Nevron.UI.WinForm.Controls;
using CC;



namespace GUI
{
    public partial class UI_login_scherm : Form
    {
        private List<string[]> checklist;

        public UI_login_scherm()
        {
            InitializeComponent();
            checklist = new List<string[]>();
            BU.BUInitialization.InitAR();
            vulCheckList();
            //checklist.Add(new string[3] { "Terence", "e48e13207341b6bffb7fb1622282247b","Systeem Beheerder" });
            //checklist.Add(new string[3] { "Ali", "ac64504cc249b070772848642cffe6ff", "Systeem Beheerder" });
            nTooltip1.SetTooltip(label_Close);
        }

        private void vulCheckList()
        {
            CC_authorisatie auth = new CC_authorisatie();
            string[,] authorisaties = auth.getAuthorisaties();
            for (int i = 0; i < authorisaties.GetLength(0); i++)
            {
                string[] hulp = new string[3];
                hulp[0] = authorisaties[i, 0];
                hulp[1] = authorisaties[i, 1];
                hulp[2] = authorisaties[i, 2];
                checklist.Add(hulp);
            }
        }
        //login=Terence
        //pass=1337
        //status=systeem beheerder
        //
        //login=Ali
        //pass=7331
        //status=systeem beheerder
        //
        //login=Piet
        //pass=blaat
        //status=klant medewerker
        //
        //login=Jan
        //pass=blaat2
        //status=ontwerper
        //
        //login=Heins
        //pass=blaat3
        //status=product medewerker
        //

        #region Events

        // x label mouse click
        private void label_Close_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        // x label mousehover
        private void label_Close_MouseHover(object sender, EventArgs e)
        {
            nTooltip1.Content.Text = "Sluiten";
            nTooltip1.SetTooltip(label_Close);
        }

        // wachtwoord label mousehover
        private void label_wachtwoord_MouseHover(object sender, EventArgs e)
        {
            nTooltip1.Content.Text = "Vul uw wachtwoord in";
            nTooltip1.SetTooltip(label_wachtwoord);
        }

        //ok button mouseclick
        private void button_OK_Click(object sender, EventArgs e)
        {
            string status;
            if (checkLoginPass(textbox_gebNaam.EntryControl.Text, textbox_wachtwoord.Text,out status))
            {
                label1.Text = "Inloggen succesvol!";
                label1.Visible = true;
                this.Hide();
                new UI_hoofd_menu(status).Show();
            }
            else
            {
                label1.Text = "Onjuiste combinatie login/passwoord!";
                label1.Visible = true;
            }
        }

        // textbox gebnaam textchanged
        private void textbox_gebNaam_TextChanged(object sender, EventArgs e)
        {
            maakLabelOnzichtbaar();
        }

        //textbox wachtwoord textchanged
        private void textbox_wachtwoord_TextChanged(object sender, EventArgs e)
        {
            maakLabelOnzichtbaar();
        }

        //textbox wachtwoord keydown
        private void textbox_wachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_OK_Click(this, null);
            }
        }

        #endregion


        #region Methodes

        private bool checkLoginPass(string login,string pass,out string status)
        {
            foreach (string[] s in checklist)
            {
                if (s[0] == login && s[1] == checkmd5(pass))
                {
                    status = s[2];
                    return true;
                }
            }
            status = "";
            return false;
        }

        private string checkmd5(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(pass);
            bs = md5.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        private void maakLabelOnzichtbaar()
        {
            label1.Visible = false;
        }

        #endregion


    }
}
