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
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using UMP;
using PluginManager;

namespace CC_Server
{
    //Communicatie service zorgt voor de connectie met verschillende clients en regelt het dataverkeer
    public class CommunicatieService
    {
        #region Fields
        //het object wat berichten verstuurt naar de GUI laag
        private Out output;
        //het object wat algemene instellingen opslaat van de server
        private Config config;
        //het server object wat gebruikt wordt om te communiceren met de singleton server object
        private IServer rs;
        //het type kanaal
        private HttpChannel chan;
        private string adres;
        private int port;
        //boolean die aangeeft of de server online is of niet
        private bool serverOnline = false;
        //event handler die plugin events doorstuurt naar de plugin service
        private PluginHandler ph;
        //event handler die update events doorstuurt naar de update service
        private UpdateHandler uh;
        //statisch object van communicatie service om alle elementen aan te spreken in andere statische methodes
        private static object cm;
        #endregion

        #region Properties
        internal Config Config
        {
            get { return config; }
        }
        internal IServer RServer
        {
            get { return rs; }
        }
        internal bool ServerOnline
        {
            get { return serverOnline; }
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

        public CommunicatieService(EventHandler msghandler)
        {
            cm = this;
            config = Config.OpenConfig();
            output = new Out(msghandler);
            RemoteServer.serverHandler += new ServerEventHandler(OnMsgHandler);
        }

        //methode om de server starten
        internal void startServer(string adres, int port)
        {
            this.adres = adres;
            this.port = port;
            if (chan == null)
            {
                ListDictionary channelProperties = new ListDictionary();
                channelProperties.Add("port", port);
                IDictionary props = new Hashtable();
                props["typeFilterLevel"] = "Full";
                chan = new HttpChannel(channelProperties,
                    new SoapClientFormatterSinkProvider(),
                    new SoapServerFormatterSinkProvider(props, null));
                if (ChannelServices.GetChannel(chan.ToString()) == null)
                    ChannelServices.RegisterChannel(chan);
            }

            try
            {
                RemotingConfiguration.RegisterWellKnownServiceType(
                    Type.GetType("UMP.RemoteServer,UMP"),
                    "UMP", WellKnownObjectMode.Singleton);

                rs = (IServer)Activator.GetObject(
                    typeof(UMP.RemoteServer),
                    "http://" + adres + ":" + port + "/UMP");

                rs.LoadUserInfo(config.DT);
                
                Out.WriteLine("UMP Server is Online");
                serverOnline = true;
            }
            catch (Exception e2)
            {
                Out.WriteLine("UMP Server failed : " + e2.ToString() + Environment.NewLine);
            }
        }

        //methode om de server te stopppen
        internal void stopserver()
        {
            RemoteServer.serverHandler -= new ServerEventHandler(OnMsgHandler);
            if (rs != null)
            {
                rs.SendMsgToClient(new RemoteEventArgs("Server went offline!", "ServerDown"));
                rs = null;
                serverOnline = false;
            }
            Out.WriteLine("UMP Server is Offline!");
        }

        //statisch event wat alle berichten opvangt die naar de server worden gestuurt
        internal static void OnMsgHandler(RemoteEventArgs re)
        {
            CommunicatieService cs = (CommunicatieService)cm;
            if (re.userName == "ServerDown")
            {
                return;
            }
            if (re.updateEvent)
            {
                cs.UH(re);
                return;
            }
            else if (re.pingEvent && !re.pluginEvent)
            {
                if (re.serviceName == "ClientDown")
                {
                    cs.RServer.UnSinkRemoteObj(re.userName, "");
                    Out.WriteLine(re.userName + " logged off from Server");
                    return;
                }
            }
            else if (re.pluginEvent)
            {
                cs.PH(re);
                return;
            }
            Out.WriteLine(re.userName + ":" + re.message);
        }

        //deze methode maakt een plugin server aan voor een specifieke plugin
        internal bool CreatePluginServer(string serviceName)
        {
            int hulpport = port;
            RemoteObj ro = null;
            retry:
            {
                hulpport++;
            }
            try
            {
                RemotingConfiguration.RegisterWellKnownServiceType(
                            Type.GetType("UMP.RemoteObj,UMP"),
                            serviceName, WellKnownObjectMode.Singleton);

                ro = (RemoteObj)Activator.GetObject(typeof(RemoteObj),
                    "http://" + adres + ":" + port + "/" + serviceName);
            }
            catch
            {
                goto retry;
            }

            if(ro != null)
            {
                RemoteObj.remoteObjHandler += new RemoteEventHandler(OnMsgHandler);
                rs.SinkRemoteObj(ro, serviceName,"");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
