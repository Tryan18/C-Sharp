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
using System.Reflection;

namespace MultiPlayerUMP
{
    public partial class SessionGame : Form, IMultiPlayerHost
    {
        private int maxplayers;
        private bool forcedShutdown = false;
        private RemoteServerSend rss;
        private string localUserName;
        private string targetUserName;
        private Room room;
        private IGame game = PClient.game;

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
            //SafeInvokeHelper.Invoke(this, "Sluiten", new object[] { true });
            this.Close();
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
                switch(me.room)
                {
                    case Room.game:
                        switch (command)
                        {
                            case "REDIRECT":
                                if (game != null)
                                {
                                    game.GameData(pe.pluginEventArgs);
                                }
                                break;
                            case "STARTGAME":
                                if (game != null)
                                {
                                    if (room == Room.host)
                                    {
                                        game.IsHost = true;
                                    }
                                    else if (room == Room.client)
                                    {
                                        game.IsHost = false;
                                    }
                                    game.Host = this;
                                    string[] users = parameter.Split(',');
                                    game.StartGame(localUserName, users);
                                }
                                break;
                        }
                        
                        break;
                    case Room.client:
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
                        break;
                    case Room.host:
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
                        break;
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
            string[] users = new string[list_users.Items.Count - 1];
            List<string> hulp = new List<string>();
            foreach(ListViewItem lvi in list_users.Items)
            {
                if(lvi.Text != localUserName)
                {
                    hulp.Add(lvi.Text);
                }
            }
            hulp.CopyTo(users);
            if(room == Room.host)
            {
                game.IsHost = true;
            }
            else if(room == Room.client)
            {
                game.IsHost = false;
            }
            game.Host = this;
            game.StartGame(localUserName, users);
            string hulpusers = "";
            foreach (string s in hulp)
            {
                hulpusers += s + ",";
            }
            hulpusers = hulpusers.Remove(hulpusers.Length - 1);
            rss(new PluginEventArgs("STARTGAME:" + hulpusers, localUserName, new MultiPlayerEventArgs(Room.game)));
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

        #region IMultiPlayerHost Members

        public void QuitGame()
        {
            if (room == Room.client)
            {
                this.Close();
            }
            else if (room == Room.host)
            {
                rss(new PluginEventArgs("DISPOSEGAME", localUserName, new MultiPlayerEventArgs(Room.client)));
            }
        }

        public void SendToPlayer(string userName,EventArgs gameEventArgs)
        {
            string hulp = null;
            foreach(string s in list_users.Items)
            {
                if(userName == s)
                {
                    hulp = s;
                    break;
                }
            }
            if(hulp != null)
            {
                rss(new PluginEventArgs("REDIRECT:" + hulp, localUserName, new MultiPlayerEventArgs(Room.game)));
            }
        }

        #endregion
    }
}
