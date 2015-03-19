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
using System.Text;
using PluginManager;
using System.Reflection;
using UMP;
using System.Threading;

namespace MultiPaint
{
    public class PServer : IPServer
    {
        private IPrimaryServer primaryServer;
        private List<string> users;
        private Dictionary<string, List<string>> games;

        public PServer()
        {

        }

        public IPrimaryServer PrimaryServer
        {
            get { return primaryServer; }
            set
            {
                primaryServer = value;
                primaryServer.InitializePlugin(this);
            }
        }

        public double PlugInVersion
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return Convert.ToDouble(v.Major.ToString()+","+v.Minor.ToString());
            }
        }

        public string PlugInName
        {
            get 
            { 
                //later moet dit dynamisch worden
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        public string Description
        {
            get 
            { 
                //later moet dit dynamisch worden
                string description = ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), true)[0]).Description;
                return description;
            }
        }

        public void StartPlugin()
        {
            users = new List<string>();
            games = new Dictionary<string, List<string>>();
        }

        public void SendToPluginClient(PluginEventArgs pe)
        {
            primaryServer.SendToPluginClient(this, pe);
        }

        public void PluginEventInfo(PluginEventArgs pe)
        {
            if (pe.message.Split(':').Length > 1)
            {
                string command = pe.message.Split(':')[0];
                string parameter = pe.message.Split(':')[1];

                switch (command)
                {
                    case "CREATEGAME":
                        games.Add(pe.username, new List<string>(Convert.ToInt32(parameter)));
                        games[pe.username].Add(pe.username);
                        foreach (string s in users)
                        {
                            SendToPluginClient(new PluginEventArgs("CREATEGAME:" + pe.username, s, pe.pluginEventArgs));
                        }
                        break;
                    case "GETGAMEUSERS":
                        foreach (string s in games.Keys)
                        {
                            if (s == parameter)
                            {
                                string hulp = "";
                                foreach (string user in games[parameter])
                                {
                                    hulp += user + ",";
                                }
                                hulp = hulp.Remove(hulp.Length - 1);
                                SendToPluginClient(new PluginEventArgs("GETGAMEUSERS:" + hulp, pe.username, pe.pluginEventArgs));
                                break;
                            }
                        }
                        break;
                    case "JOINGAME":
                        bool join = false;
                        foreach (string s in games.Keys)
                        {
                            if (s == parameter)
                            {
                                if (games[s].Capacity != games[s].Count)
                                {
                                    SendToPluginClient(new PluginEventArgs("JOINGAME:" + pe.username, parameter, pe.pluginEventArgs));
                                    join = true;
                                }
                                else
                                {
                                    foreach (string user in users)
                                    {
                                        SendToPluginClient(new PluginEventArgs("GAMEFULL:" + parameter, user, pe.pluginEventArgs));
                                    }
                                }
                                break;
                            }
                        }
                        if (join)
                        {
                            games[parameter].Add(pe.username);
                        }
                        break;
                    case "LEAVEGAME":
                        foreach (string s in games.Keys)
                        {
                            if (s == parameter)
                            {
                                SendToPluginClient(new PluginEventArgs("LEAVEGAME:" + pe.username, parameter, pe.pluginEventArgs));
                                games[parameter].Remove(pe.username);
                                break;
                            }
                        }
                        break;
                }
                return;
            }
            switch (pe.message)
            {
                case "ADDUSER":
                    users.Add(pe.username);
                    foreach (string s in users)
                    {
                        if (s != pe.username)
                        {
                            SendToPluginClient(new PluginEventArgs("ADD:" + pe.username, s, pe.pluginEventArgs));
                        }
                    }
                    break;
                case "DISPOSEGAME":
                    bool gamefound = false;
                    foreach (string s in games.Keys)
                    {
                        if (s == pe.username)
                        {
                            gamefound = true;
                            foreach (string user in users)
                            {
                                SendToPluginClient(new PluginEventArgs("DISPOSEGAME:" + pe.username, user, pe.pluginEventArgs));
                            }
                            break;
                        }
                    }
                    if (gamefound)
                    {
                        games.Remove(pe.username);
                    }
                    break;
                case "GAMEFULL":
                    foreach (string s in users)
                    {
                        if (s != pe.username)
                        {
                            SendToPluginClient(new PluginEventArgs("GAMEFULL:" + pe.username, s, pe.pluginEventArgs));
                        }
                    }
                    break;
                case "REMOVEUSER":
                    if (users.Contains(pe.username))
                    {
                        users.Remove(pe.username);
                        foreach (string s in users)
                        {
                            SendToPluginClient(new PluginEventArgs("REMOVE:" + pe.username, s, pe.pluginEventArgs));
                        }
                    }
                    break;
                case "BROADCAST":
                    foreach (string s in users)
                    {
                        SendToPluginClient(new PluginEventArgs("BROADCAST:", s, pe.pluginEventArgs));
                    }
                    break;
                case "GETUSERS":
                    string hulp = "";
                    foreach(string s in users)
                    {
                        hulp += s + ",";
                    }
                    hulp = hulp.Remove(hulp.Length-1);
                    SendToPluginClient(new PluginEventArgs("GETUSERS:" + hulp, pe.username, pe.pluginEventArgs));
                    break;
            }
        }
    }
}
