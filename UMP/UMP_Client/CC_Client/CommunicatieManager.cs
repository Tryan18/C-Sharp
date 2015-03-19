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
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Http;
using UMP;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Net;
using PluginManager;
using System.Threading;

namespace CC_Client
{
    public class CommunicatieManager : MarshalByRefObject
    {
        #region Fields
        //veld om aan te geven of de server online is of niet
        private bool serverOnline = false;
        //dit object word gebruikt om berichten door te sturen naar de GUI laag
        private Out output;
        //http kanaal word gebruikt om te kunnen communiceren over het internet
        private HttpChannel registedChan;
        //het object wat gebruikt wordt om de server te kunnen aanspreken
        private RemoteServer rs = null;
        private string username, adres;
        private int port;
        private int localPort = 6666;
        private string localAdress;
        //event handler wat getriggert word om het moment dat er een plugin event binnen komt
        //deze word vervolgens gestuurt naar de plugin manager
        private PluginHandler ph;
        //event handler wat getrigger word op het moment dat er een update event binnen komt
        //deze word vervolgens gestuurt naar de update manager
        private UpdateHandler uh;
        #endregion

        #region Properties
        public bool ServerOnline
        {
            get { return serverOnline; }
        }

        public string UserName
        {
            get { return username; }
        }

        internal PluginHandler PH
        {
            get { return ph; }
            set { ph = value; }
        }

        internal UpdateHandler UH
        {
            get { return uh; }
            set { uh = value; }
        }

        #endregion

        public CommunicatieManager(EventHandler msghandler)
        {
            output = new Out(msghandler);
        }

        public void ConnectServer(string adres, int port,string username,string pass)
        {
            try
            {
                if (ServerOnline)
                {
                    Out.WriteLine("Already Connected with the Server!");
                    return;
                }
                if (registedChan != null)
                {
                    ChannelServices.UnregisterChannel(registedChan);
                    registedChan = null;
                }
                Retry:
                {
                }
                try
                {
                    ListDictionary channelProperties = new ListDictionary();
                    channelProperties.Add("port", localPort);
                    //properties om security goed te krijgen
                    IDictionary props = new Hashtable();
                    props["typeFilterLevel"] = "Full";
                    registedChan = new HttpChannel(channelProperties,
                        new SoapClientFormatterSinkProvider(),
                        new SoapServerFormatterSinkProvider(props, null));
                    if (ChannelServices.GetChannel(registedChan.ToString()) == null)
                        ChannelServices.RegisterChannel(registedChan);
                }
                catch
                {
                    localPort++;
                    goto Retry;
                }

                //server object word opgehaald
                rs = (RemoteServer)Activator.GetObject(typeof(RemoteServer), "http://" + adres + ":" + port + "/UMP");

                if (rs == null)
                    Out.WriteLine("Can't connect to server");
                else
                {
                    this.adres = adres;
                    this.port = port;
                    localAdress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
                    if (registerClientOnServer(username, pass))
                    {
                        serverOnline = true;
                        Out.WriteLine("Connected With Server");
                        this.username = username;
                    }
                }
            }
            catch (Exception e2)
            {
                serverOnline = false;
                Out.WriteLine("Connection Server Error: " + Environment.NewLine + e2.Message);
            }
        }

        //event handler wat gebruikt word op ALLE data verkeer op te vangen wat van de server komt
        public void OnMsgHandler(RemoteEventArgs e)
        {
            if (e.userName == "ServerDown")
            {
                Out.WriteLine(e.message);
                if (registedChan != null)
                {
                    ChannelServices.UnregisterChannel(registedChan);
                    registedChan = null;
                }
                serverOnline = false;
            }
            else if (e.updateEvent)
            {
                uh(e);
            }
            else if (e.pluginEvent)
            {
                ph(e);
            }
            else
            {
                Out.WriteLine(e.userName + ":" + e.message);
            }
        }

        //methode die gebruikt wordt om een client te autoriseren op de server
        internal bool registerClientOnServer(string username,string pass)
        {
            try
            {
                RemoteEventArgs e = new RemoteEventArgs("logged in", username);
                if (rs.CheckUser(username, pass))
                {
                    if (rs.CheckLogin(username))
                    {
                        RemotingConfiguration.RegisterWellKnownServiceType(
                        Type.GetType("UMP.RemoteObj,UMP"),
                        "ClientObj", WellKnownObjectMode.Singleton);

                        RemoteObj ro = (RemoteObj)Activator.GetObject(typeof(RemoteObj),
                            "http://" + localAdress + ":" + localPort + "/ClientObj");

                        //hier word de event handler gekoppelt met die van het client object
                        RemoteObj.remoteObjHandler += new RemoteEventHandler(OnMsgHandler);
                        rs.SinkRemoteObj(ro, "", username);
                        //ISrvObj
                        rs.SendMsgToServer(e);
                        return true;
                    }
                    else
                    {
                        Out.WriteLine("Client already logged on to selected service!");
                    }
                }
                else
                {
                    Out.WriteLine("Server: " + username + " is not a registered account on Server! or not a valid account!");
                }

            }
            catch (Exception e2)
            {
                MessageBox.Show("RegisterClientException: " + e2.ToString());
            }
            return false;
        }

        //verbreekt verbinding met server
        public void DisconnectServer()
        {
            if (serverOnline)
            {
                rs.SendMsgToServer(new RemoteEventArgs(username, "ClientDown", false));
            }
            else
            {
                Out.WriteLine("Server is Offline!");
                return;
            }
            if (registedChan != null)
            {
                ChannelServices.UnregisterChannel(registedChan);
                registedChan = null;
            }
            serverOnline = false;
            Out.WriteLine("Disconnected From Server!");
        }

        //verstuurt bericht naar de server
        internal void SendMsgToServer(string msg)
        {
            rs.SendMsgToServer(new RemoteEventArgs(msg, username));
        }

        //verstuurt bericht naar plugin server
        internal void SendMsgToPluginServer(RemoteEventArgs e)
        {
            rs.SendMsgToClient(e);
        }

        internal void SendMsgToServer(RemoteEventArgs e)
        {
            rs.SendMsgToServer(e);
        }
    }
}
