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

namespace MultiPaint
{
    public partial class SessionGame : Form
    {
        private int maxplayers;
        private bool forcedShutdown = false;
        private Game game;
        private RemoteServerSend rss;
        private string localUserName;
        private string targetUserName;
        private Room room;

        public int Maxplayers
        {
            get { return maxplayers; }
        }
        public int CurrentTotalPlayers
        {
            get { return list_users.Items.Count; }
        }

        public SessionGame(RemoteServerSend rss,int maxplayers,string localUserName)
        {
            room = Room.host;
            this.localUserName = localUserName;
            this.rss = rss;
            this.maxplayers = maxplayers;
            InitializeComponent();
            this.Text = "Host Game";
            L_remaining_players.Text = maxplayers.ToString();
            WriteConnectedUsers(true);
            WriteUsers(localUserName,null, null);
            this.FormClosing += new FormClosingEventHandler(HostGame_FormClosing);
        }

        void HostGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            rss(new PluginEventArgs("DISPOSEGAME", localUserName, new MultiPlayerEventArgs(Room.client)));
        }

        public SessionGame(RemoteServerSend rss,bool Client,string localUserName,string targetUserName)
        {
            room = Room.client;
            this.localUserName = localUserName;
            this.targetUserName = targetUserName;
            this.rss = rss;
            InitializeComponent();
            this.Text = "Client Game";
            L_remaining_players.Enabled = false;
            L_remaining_players.Visible = false;
            L_total.Visible = false;
            B_start.Visible = false;
            WriteUsers(localUserName, null, null);
            this.FormClosed += new FormClosedEventHandler(ClientGame_FormClosed);
        }

        void ClientGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!forcedShutdown)
            {
                rss(new PluginEventArgs("LEAVEGAME:" + targetUserName, localUserName, new MultiPlayerEventArgs(Room.host)));
            }
        }

        public void WriteUsers(string add, string remove, string[] users)
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
                    if (!list_users.Items.ContainsKey(s))
                    {
                        list_users.Items.Add(s);
                    }
                }
            }
        }

        public void DisposeGame()
        {
            forcedShutdown = true;
            MessageBox.Show("The host has terminated the game!");
            SafeInvokeHelper.Invoke(this, "Sluiten", new object[] { true });
        }

        public void Sluiten(bool test)
        {
            this.Close();
        }

        public void RemoteInfo(string command, string parameter, PluginEventArgs pe)
        {
            MultiPlayerEventArgs me = null;
            if (pe.pluginEventArgs != null)
            {
                me = (MultiPlayerEventArgs)pe.pluginEventArgs;
            }
            if (me != null)
            {
                if (room == Room.client)
                {
                    switch (command)
                    {
                        case "GETGAMEUSERS":
                            string[] users = parameter.Split(',');
                            SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { null, null, users });
                            break;
                        case "DISPOSEGAME":
                            DisposeGame();
                            break;
                    }
                }
                else if (room == Room.host)
                {
                    switch (command)
                    {
                        case "JOINGAME":
                            SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { parameter, null, null });
                            SafeInvokeHelper.Invoke(this, "WriteConnectedUsers", new object[] { true });
                            break;
                        case "LEAVEGAME":
                            SafeInvokeHelper.Invoke(this, "WriteUsers", new object[] { null, parameter, null });
                            SafeInvokeHelper.Invoke(this, "WriteConnectedUsers", new object[] { false });
                            break;
                    }
                }
            }
        }

        public void WriteConnectedUsers(bool addingUser)
        {
            if (addingUser)
            {
                L_remaining_players.Text = Convert.ToString(Convert.ToInt32(L_remaining_players.Text) - 1);
            }
            else
            {
                L_remaining_players.Text = Convert.ToString(Convert.ToInt32(L_remaining_players.Text) + 1);
            }
        }

        private void B_start_Click(object sender, EventArgs e)
        {
            this.Hide();
            game = new Game("dad", false);
            game.FormClosing += new FormClosingEventHandler(game_FormClosing);
        }

        void game_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void L_remaining_players_TextChanged(object sender, EventArgs e)
        {
            int remainPlayers = maxplayers;
            if(int.TryParse(L_remaining_players.Text,out remainPlayers))
            {
                if (remainPlayers == 0)
                {
                    B_start.Enabled = true;
                }
            }
        }
    }
}
