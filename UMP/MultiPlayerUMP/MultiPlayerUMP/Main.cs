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
using PluginManager;
using UMP;
using System.Threading;

namespace MultiPlayerUMP
{
    public partial class Main : Form,IMain
    {
        #region Fields
        private RemoteServerRecieveHandler rsrh;
        private string localUserName;
        private SessionGame sg;
        private RemoteServerSend rss;
        public static string referencedName;
        #endregion

        #region Properties
        public RemoteServerRecieveHandler RSRH
        {
            get { return rsrh; }
            set { rsrh = value; }
        }

        internal string LocalUserName
        {
            get { return localUserName; }
            set { localUserName = value; }
        }

        public RemoteServerSend RSS
        {
            get { return rss; }
            set { rss = value; }
        }
        #endregion

        public Main(string localUserName,string referencedName)
        {
            Main.referencedName = referencedName;
            this.LocalUserName = localUserName;
            InitializeComponent();
            this.Text = PClient.ass.GetName().Name + " Lobby";
            RSRH += new RemoteServerRecieveHandler(RemoteInfo);
            this.Shown += new EventHandler(Main_Shown);
        }

        void DisconnectFromPluginServer()
        {
            RSS(new PluginEventArgs("REMOVEUSER", localUserName, new MultiPlayerEventArgs(localUserName, "Left the lobby", Room.lobby)));
        }

        void Main_Shown(object sender, EventArgs e)
        {
            RSS(new PluginEventArgs("ADDUSER", localUserName, new MultiPlayerEventArgs(localUserName, "Entering the lobby", Room.lobby)));
            RSS(new PluginEventArgs("GETUSERS", localUserName, new MultiPlayerEventArgs(localUserName,"",Room.lobby)));
        }

        public void WriteLine(string zin)
        {
            T_output.Text += zin + Environment.NewLine;
        }

        public void WriteUsers(string add, string remove,string[] users)
        {
            if (add != null)
            {
                if (!list_users.Items.ContainsKey(add))
                {
                    list_users.Items.Add(add);
                }
            }
            else if (remove != null)
            {
                ListViewItem hulp = null;
                foreach (ListViewItem lvi in list_users.Items)
                {
                    if (lvi.Text == remove)
                    {
                        hulp = lvi;
                    }
                }
                if (hulp != null)
                {
                    list_users.Items.Remove(hulp);
                }
            }
            else if (users != null)
            {
                list_users.Items.Clear();
                foreach (string s in users)
                {
                    list_users.Items.Add(s);
                }
            }
        }

        #region RemoteEvents

        public void RemoteInfo(PluginEventArgs pe)
        {
            string command = pe.message.Split(':')[0];
            string parameters = pe.message.Split(':')[1];
            MultiPlayerEventArgs me = null;
            if (pe.pluginEventArgs != null)
            {
                me = (MultiPlayerEventArgs)pe.pluginEventArgs;
            }
            switch (command)
            {
                case "REDIRECT":
                    if (sg != null)
                    {
                        sg.RemoteInfo(command, parameters, pe);
                    }
                    return;
                case "CREATEGAME":
                    SafeInvokeHelper.Invoke(this, "ChangeColorUsers", new object[] { parameters, "new" });
                    break;
                case "GAMEFULL":
                    SafeInvokeHelper.Invoke(this, "ChangeColorUsers", new object[] { parameters, "full" });
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { "Could not join " + parameters + " ,because game is full!" });
                    break;
                case "DISPOSEGAME":
                    SafeInvokeHelper.Invoke(this, "ChangeColorUsers", new object[] { parameters, "clear" });
                    break;
                case "JOINGAME":
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { parameters + " joined " + pe.username + " game" });
                    break;
                case "LEAVEGAME":
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { parameters + " left " + pe.username + " game" });
                    break;
                case "ADD":
                    SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { parameters, null, null });
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { Convert.ToString(me.username + ":" + me.message) });
                    break;
                case "REMOVE":
                    SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { null, parameters, null });
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { Convert.ToString(me.username + ":" + me.message) });
                    break;
                case "GETUSERS":
                    SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { null, null, parameters.Split(',') });
                    break;
                case "BROADCAST":
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { Convert.ToString(me.username + ":" + me.message) });
                    break;
            }
            if (sg != null)
            {
                sg.RemoteInfo(command, parameters, pe);
            }
        }
        #endregion

        public void ChangeColorUsers(string username, string gametype)
        {
            ListViewItem hulp = null;
            foreach (ListViewItem lvi in list_users.Items)
            {
                if (lvi.Text == username)
                {
                    hulp = lvi;
                    break;
                }
            }
            switch (gametype)
            {
                case "new":
                    list_users.Items[hulp.Index].BackColor = Color.Green;
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { username + ":Created a game" });
                    break;
                case "full":
                    SafeInvokeHelper.Invoke(this, "WriteLine", new object[] { username + ":The Game is Full" });
                    list_users.Items[hulp.Index].BackColor = Color.Red;
                    break;
                case "clear":
                    list_users.Items[hulp.Index].BackColor = Color.White;
                    break;
            }
        }

        private void B_host_Click(object sender, EventArgs e)
        {
            rss(new PluginEventArgs("CREATEGAME:" + num_maxplayers.Value.ToString(), localUserName, null));
            sg = new SessionGame(RSS,Convert.ToInt32(num_maxplayers.Value),localUserName);
            this.Hide();
            sg.FormClosed += new FormClosedEventHandler(sg_FormClosed);
            sg.Show();
        }

        void sg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void T_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RSS(new PluginEventArgs("BROADCAST", localUserName, new MultiPlayerEventArgs(localUserName, T_input.Text, Room.lobby)));
                T_input.Text = "";
            }
        }

        private void T_output_TextChanged(object sender, EventArgs e)
        {
            T_output.SelectionStart = T_output.Text.Length;
            T_output.ScrollToCaret();
        }

        private void B_connect_Click(object sender, EventArgs e)
        {
            if (list_users.SelectedItems.Count != 0)
            {
                if (list_users.SelectedItems[0].BackColor == Color.Green)
                {
                    string targetUser = list_users.SelectedItems[0].Text;
                    sg = new SessionGame(RSS, true, localUserName, targetUser);
                    this.Hide();
                    sg.FormClosed += new FormClosedEventHandler(sg_FormClosed);
                    sg.Show();
                    rss(new PluginEventArgs("JOINGAME:" + targetUser, localUserName, new MultiPlayerEventArgs(Room.host)));
                    rss(new PluginEventArgs("GETGAMEUSERS:" + targetUser, localUserName, new MultiPlayerEventArgs(Room.client)));
                }
                else
                {
                    WriteLine("ERROR:game not join able!");
                }
            }
            else
            {
                WriteLine("ERROR:You didn't selected a game!");
            }
        }
    }
}
