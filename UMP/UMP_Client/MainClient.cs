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
using System.Collections.Specialized;
using UMP;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Net;
using CC_Client;

namespace UMP_Client
{
    //delegate die algemene message naar de bovenste laag stuurt oftewel GUI
    delegate void MsgHandler(object sender,EventArgs e);

    public partial class MainClient : Form
    {
        //icoontje rechts onder in beeld
        private NotifyIcon ni;
        //form wat gebruikt word voor de inlog procedure
        private Login login;
        public string username, pass, regtype;
        //clientbeheer
        private ClientBeheer cb;
        //event handler die getriggert word op het moment dat er een algemene message naar de bovenste laag word gestuurt
        private EventHandler eventMsgHandler;

        public MainClient()
        {
            InitializeComponent();
            eventMsgHandler = new EventHandler(WriteLine);
            cb = new ClientBeheer(eventMsgHandler);
            foreach (IPAddress ip in Dns.GetHostByName(Dns.GetHostName()).AddressList)
            {
                combo_ip.Items.Add(ip.ToString());
            }
            NotifyIcon ni = new NotifyIcon();
            ni.Icon = Properties.Resources.ump;
            ni.ContextMenu = new ContextMenu();
            ni.ContextMenu.MenuItems.Add(new MenuItem("Open Menu",new EventHandler(OpenMenu)));
            ni.ContextMenu.MenuItems.Add(new MenuItem("Exit", new EventHandler(Exit)));
            ni.Visible = true;
            this.Disposed += new EventHandler(Form1_Disposed);
            this.MinimumSizeChanged += new EventHandler(Form1_MinimumSizeChanged);
        }

        void Form1_Disposed(object sender, EventArgs e)
        {
            if (ni != null)
            {
                ni.Dispose();
            }
        }

        //event voor messages te laten zien op het form
        internal void WriteLine(object sender, EventArgs e)
        {
            string zin = (string)sender;
            if (T_output.InvokeRequired)
            {
                MsgHandler mh = new MsgHandler(WriteLine);
                this.Invoke(mh, new object[] { zin, null });
            }
            else
            {
                T_output.Text += zin + Environment.NewLine;
            }
        }

        private void WriteLine(string zin)
        {
            T_output.Text += zin + Environment.NewLine;
        }

        #region StandardFormEvents
        void OpenMenu(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.BringToFront();
        }

        void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        void Exit(object sender,EventArgs e)
        {
            this.Close();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        private void B_login_Click(object sender, EventArgs e)
        {
            //controleert of server online is
            if (cb.cm.ServerOnline)
            {
                //controleert of er services geinstalleerd zijn
                if (cb.um.InstalledPlugins.Count != 0)
                {
                    login = new Login(this);
                    login.Text += " Service";
                    login.combo_regtype.Items.Remove("Server");
                    foreach (string[] s in cb.um.InstalledPlugins)
                    {
                        login.combo_regtype.Items.Add(s[0]);
                    }
                    login.T_username.Text = cb.cm.UserName;
                    login.T_username.Enabled = false;
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        cb.StartPlugin(login.combo_regtype.Text);
                    }
                }
                else
                {
                    Out.WriteLine("No Services Installed! Please Install first");
                }
            }
            else
            {
                Out.WriteLine("Server Offline! Connect first to server!");
            }
        }

        private void B_connect_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(combo_ip.Text, out ip))
            {
                int port;
                if(int.TryParse(T_port.Text,out port))
                {
                    login = new Login(this);
                    login.Text += " Server";
                    login.combo_regtype.Text = "Server";
                    login.combo_regtype.Enabled = false;

                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        cb.cm.ConnectServer(ip.ToString(), port,username,pass);
                    }
                }
                else
                {
                    WriteLine("Port format incorrect!");
                }
            }
            else
            {
                WriteLine("IP adress format incorrect!");
            }
        }

        private void T_output_TextChanged(object sender, EventArgs e)
        {
            //controleert of checkbox is aangevinkt zodat met de output tekst terug kan lezen
            if (!cb_scrollback.Checked)
            {
                T_output.SelectionStart = T_output.Text.Length;
                T_output.ScrollToCaret();
            }
        }

        private void B_disconnect_Click(object sender, EventArgs e)
        {
            //sluit verbinding met server
            cb.cm.DisconnectServer();
        }

        private void T_input_KeyDown(object sender, KeyEventArgs e)
        {
            //verstuurt een bericht naar server
            if (e.KeyCode == Keys.Enter)
            {
                cb.SendMsgToServer(T_input.Text);
                T_input.Clear();
            }
        }

        private void B_update_Click(object sender, EventArgs e)
        {
            //controleert of server online is
            if (cb.cm.ServerOnline)
            {
                Services s = new Services(cb);
                s.Show();
            }
            else
            {
                Out.WriteLine("Server Offline! Connect first to server!");
            }
        }
    }
}
