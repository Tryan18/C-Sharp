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
using UMP;
using System.Windows.Forms;
using System.IO;
using PluginManager;
using System.Reflection;
using System.Collections;

namespace CC_Server
{
    //regelt het algemeen data verkeer 
    public class ServerBeheer
    {
        private CommunicatieService cs;
        private PluginService ps;
        private UpdateService us;
        //commando's die ingevoert kunnen worden op het GUI scherm
        private string[] serverCommands = new string[4] { "/CreateUser", "/DeleteUser", "/Msg", "/LoadPlugins" };
        
        public ServerBeheer(CommunicatieService cs)
        {
            this.cs = cs;
            ps = new PluginService(cs);
            us = new UpdateService(cs,ps);
        }

        //methode om een commando uit te voeren
        public void SendCommand(string command)
        {
            if (cs.ServerOnline)
            {
                bool commandFound = false;
                foreach (string s in serverCommands)
                {
                    if (s == command.Split(' ')[0])
                    {
                        commandFound = true;
                    }
                }
                if (commandFound)
                {
                    string[] command_args = command.Split(' ');
                    switch (command_args[0])
                    {
                        case "/CreateUser":
                            if (command_args.Length == 3)
                            {
                                CreateUser(command_args[1], command_args[2]);
                            }
                            else
                            {
                                Out.WriteLine("Incorrect Command! Example. /CreateUser Terence 1337");
                                return;
                            }
                            break;
                        case "/DeleteUser":
                            if (command_args.Length == 2)
                            {
                                DeleteUser(command_args[1]);
                            }
                            else
                            {
                                Out.WriteLine("Incorrect Command Input! Example. /DeleteUser Terence");
                            }
                            break;
                        case "/Msg":
                            if (command_args.Length == 3)
                            {
                                SendMessageToClient(command_args[1], command_args[2]);
                            }
                            else
                            {
                                Out.WriteLine("Incorrect Command Input! Exapmple. /Msg Terence tralalalala");
                            }
                            break;
                        case "/LoadPlugins":
                            if (command_args.Length == 1)
                            {
                                ps.RegisterPlugins();
                            }
                            else
                            {
                                Out.WriteLine("Incorrect Command Input! Exapmple. /Msg Terence tralalalala");
                            }
                            break;
                    }
                    Config.SaveConfig(cs.Config,RemoteServer.dt);
                }
                else
                {
                    Out.WriteLine("Command not found!");
                    //cs.SendMsgToClient(command);
                }
            }
            else
            {
                Out.WriteLine("Server Not Online!");
            }
        }

        //methode om een tekst bericht door te sturen naar de client
        private void SendMessageToClient(string username, string msg)
        {
            if (cs.RServer.SendMsgToClient(new RemoteEventArgs(msg,username)))
            {
                Out.WriteLine("Message Send To " + username);
            }
            else
            {
                Out.WriteLine("Message could not be delivered to " + username);
            }
        }

        //methode om een gebruiker te verwijderen van de server
        private void DeleteUser(string username)
        {
            if (cs.RServer.RemoveUser(username))
            {
                Out.WriteLine("User " + username + " Deleted!");
            }
            else
            {
                Out.WriteLine("Error: User " + username + " Not Found!");
            }
        }

        //methode om een gebruiker toe te voegen aan de server
        private void CreateUser(string username, string pass)
        {
            if (cs.RServer.AddUser(username, pass))
            {
                Out.WriteLine("User " + username + " Created!");
            }
            else
            {
                Out.WriteLine("Error: User " + username + " Already Exists!");
            }
        }

        //methode om de server te starten
        public void StartServer(string adres, int port)
        {
            cs.startServer(adres, port);
            us.startUpdateService();
        }

        public void StopServer()
        {
            cs.stopserver();
        }
    }
}
