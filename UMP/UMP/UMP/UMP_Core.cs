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
using System.Collections;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using System.Windows.Forms;
using PluginManager;
using System.Threading;

namespace UMP
{
    //delegate die gebruikt word om berichten te sturen naar de server
    public delegate void ServerEventHandler(RemoteEventArgs e);

    //het object waar elke client mee communiceert en ook de hoofd server GUI
    public class RemoteServer : MarshalByRefObject, IServer, IClient
    {
        public static event ServerEventHandler serverHandler;
        //data tabel om gebruikers in op te slaan voor toegang tot de server
        public static DataTable dt = new DataTable("UsrMgr");
        //list voor client objecten op te slaan gekoppelt aan een gebruikers naam
        private static SortedList<string,RemoteObj> handlerList = new SortedList<string, RemoteObj>();

        public DataTable GetDT()
        {
            return RemoteServer.dt;
        }

        static RemoteServer()
        {
            //thread word gestart om de gehele applicatie goed multi-threaded te laten functioneren
            Thread t = new Thread(new ThreadStart(CheckClientToServerQueue));
            t.IsBackground = true;
            t.Start();
        }

        //hier word een wachtrij gemaakt om threads 1 voor 1 op een veilige manier te werk te laten gaan
        private static Queue _ClientToServer = Queue.Synchronized(new Queue());

        //een oneindige loop die controleert of er berichten naar de server gestuurt moeten worden
        private static void CheckClientToServerQueue()
        {
            while (true)
            {
                //thread sleep word gebruikt zodat het systeem nog de kans heeft om ondertussen nog andere dingen te doen
                Thread.Sleep(50);
                if (_ClientToServer.Count > 0)
                {
                    RemoteEventArgs re = (RemoteEventArgs)_ClientToServer.Dequeue();
                    if (serverHandler != null)
                        serverHandler(re);
                }
            }
        }

        //methode die gebruikt wordt om een bericht te sturen naar de server
        public bool SendMsgToServer(RemoteEventArgs re)
        {
            //hier word een bericht in de wachtrij gezet
            _ClientToServer.Enqueue(re);
            return true;
        }

        //Met deze methode wordt de inlog procedure gecontroleerd van een gebruiker om te kijken of deze niet al eens een keer is ingelogd
        public bool CheckLogin(string username)
        {
            if (handlerList.ContainsKey(username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Met deze methode word het client object vast gelegd in de server
        public void SinkRemoteObj(RemoteObj obj, string serviceName,string username)
        {
            if (serviceName != "")
            {
                if (handlerList.ContainsKey(serviceName))
                {
                    handlerList.Remove(serviceName);
                }
                handlerList.Add(serviceName, obj);
            }
            else if (username != "")
            {
                if (handlerList.ContainsKey(username))
                {
                    handlerList.Remove(username);
                }
                handlerList.Add(username, obj);
            }
        }

        //Met deze methode wordt het client object losgekoppelt van de server
        public bool UnSinkRemoteObj(string username, string serviceName)
        {
            if (serviceName != "")
            {
                if (handlerList.ContainsKey(serviceName))
                {
                    handlerList.Remove(serviceName);
                    return true;
                }
            }
            else if (username != "")
            {
                if (handlerList.ContainsKey(username))
                {
                    handlerList.Remove(username);
                    return true;
                }
            }
            return false;
        }

        //met deze methode word een bericht verstuurt naar de client
        public bool SendMsgToClient(RemoteEventArgs e)
        {
            try
            {
                if (e.userName == "ServerDown")
                {
                    foreach (RemoteObj ro in handlerList.Values)
                    {
                        try
                        {
                            ro.Recieving(new RemoteEventArgs(e.message, "ServerDown"));
                        }
                        catch { }
                    }
                    return true;
                }
                else if (e.routeToService && !e.pingEvent)
                {
                    RemoteObj ro = (RemoteObj)handlerList[e.serviceName];
                    ro.Recieving(e);
                    return true;
                }
                else if (e.userName != "" || e.userName == null)
                {
                    RemoteObj ro = (RemoteObj)handlerList[e.userName];
                    ro.Recieving(e);
                    return true;
                }
                else if (e.serviceName != "" || e.serviceName == null)
                {
                    RemoteObj ro = (RemoteObj)handlerList[e.serviceName];
                    ro.Recieving(e);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public override object InitializeLifetimeService()
        {
            //Hier mee geven we aan dat het als Singleton aangemaakt is, de eerste instantie zal nooit verloren gaan
            //maakt niet uit hoelang de client objecten met elkaar communiceren
            return null;
        }

        //Hier worden de autorisatie gegevens van de gebruiker verstuurt naar de server
        public void LoadUserInfo(DataTable dt)
        {
            RemoteServer.dt = dt;
        }

        //Hier word een gebruiker toegevoegt met wachtwoord
        public bool AddUser(string username, string pass)
        {
            DataRow hulp = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserName"].ToString() == username)
                {
                    hulp = dr;
                }
            }
            if (hulp != null || username == "ServerDown")
            {
                return false;
            }
            else
            {
                
                DataRow dr;
                dr = dt.NewRow();
                dr["UserName"] = username;
                dr["ServerPass"] = pass;
                dt.Rows.Add(dr);
                return true;
            }
        }

        //Hier word een gebruiker verwijderd
        public bool RemoveUser(string username)
        {
            DataRow hulp = null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UserName"].ToString() == username)
                {
                    hulp = dr;
                }
            }
            if (hulp != null)
            {
                dt.Rows.Remove(hulp);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Hier word een gebruiker gecontroleerd op gebruikers naam en wachtwoord om vervolgens toestemming te geven aan de client
        public bool CheckUser(string uname, string password)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (uname == (string)dt.Rows[i]["UserName"] && password == (string)dt.Rows[i]["ServerPass"])
                {
                    return true;
                }
            }
            return false;
        }
    }

    //Hier word een zelfgemaakt event arguments aangemaakt wat hoofdzakelijk gebruikt wordt om al het data verkeer te transporteren
    //van client naar server en weer terug
    [Serializable]
    public class RemoteEventArgs : EventArgs
    {
        /// <summary>
        /// normaal bericht of commando
        /// </summary>
        public string message;
        /// <summary>
        /// Gebruikers Naam
        /// </summary>
        public string userName;
        /// <summary>
        /// Service Naam
        /// </summary>
        public string serviceName;
        /// <summary>
        /// Zelfgedefinierde Event Arguments
        /// </summary>
        public EventArgs customEventArgs;
        /// <summary>
        /// plugin event?
        /// </summary>
        public bool pluginEvent;
        /// <summary>
        /// ping event voor in leven te houden
        /// </summary>
        public bool pingEvent;
        /// <summary>
        /// naar de plugin server toe?
        /// </summary>
        public bool routeToService;
        /// <summary>
        /// update event?
        /// </summary>
        public bool updateEvent;
        /// <summary>
        /// Server Event
        /// </summary>
        public RemoteEventArgs(string message, string userName)
        {
            this.message = message;
            this.userName = userName;
            this.pluginEvent = false;
            this.pingEvent = false;
            this.routeToService = false;
            this.updateEvent = false;
        }
        /// <summary>
        /// Plugin Event
        /// </summary>
        public RemoteEventArgs(string message, string userName, string serviceName,bool routeToService,EventArgs pluginEventArgs)
        {
            this.message = message;
            this.userName = userName;
            this.serviceName = serviceName;
            this.pluginEvent = true;
            this.pingEvent = false;
            this.customEventArgs = pluginEventArgs;
            this.routeToService = routeToService;
            this.updateEvent = false;
        }
        /// <summary>
        /// Ping Event
        /// </summary>
        public RemoteEventArgs(string userName,string serviceName,bool pluginEvent)
        {
            this.userName = userName;
            this.serviceName = serviceName;
            this.pluginEvent = pluginEvent;
            this.pingEvent = true;
            this.routeToService = false;
            this.updateEvent = false;
        }
        /// <summary>
        /// Update Event
        /// </summary>
        public RemoteEventArgs(string message, string userName,EventArgs updateEventArgs)
        {
            this.message = message;
            this.userName = userName;
            this.serviceName = "";
            this.pluginEvent = false;
            this.pingEvent = false;
            this.routeToService = false;
            this.updateEvent = true;
            this.customEventArgs = updateEventArgs;
        }
    }
    //delegate wat gebruikt word om naar een client te kunnen communiceren
    public delegate void RemoteEventHandler(RemoteEventArgs e);

    //Het client object wat gebruikt wordt om naar de server te kunnen communiceren en weer terug
    public class RemoteObj : MarshalByRefObject
    {
        public static event RemoteEventHandler remoteObjHandler;

        static RemoteObj()
        {
            //een background thread wat gestart word om voortdurend naar inkomende berichten te luisteren
            Thread t = new Thread(new ThreadStart(CheckServerToClientQueue));
            t.IsBackground = true;
            t.Start();
        }

        //event om berichten in de wachtrij te zetten
        public void Recieving(RemoteEventArgs e)
        {
            _ServerToClient.Enqueue(e);
        }

        //wachtrij wat aangemaakt word om veilig multi-threaded te werk te gaan
        private static Queue _ServerToClient = Queue.Synchronized(new Queue());

        //methode wat voortdurend controleert naar nieuwe berichten
        private static void CheckServerToClientQueue()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (_ServerToClient.Count > 0)
                {
                    RemoteEventArgs re = (RemoteEventArgs)_ServerToClient.Dequeue();
                    if (remoteObjHandler != null)
                        remoteObjHandler(re);
                }
            }
        }

        public override object InitializeLifetimeService()
        {
            //Hier mee geven we aan dat het als Singleton aangemaakt is, de eerste instantie zal nooit verloren gaan
            //maakt niet uit hoelang de client objecten met elkaar communiceren
            return null;
        }
    }

    //Interface wat gebruikt wordt zodat de server alleen maar toegang heeft tot deze methodes en properties
    public interface IServer
    {
        DataTable GetDT();
        bool AddUser(string username,string pass);
        bool RemoveUser(string username);
        void LoadUserInfo(DataTable dt);
        bool SendMsgToClient(RemoteEventArgs re);
        void SinkRemoteObj(RemoteObj Obj, string serviceName, string username);
        bool UnSinkRemoteObj(string username, string serviceName);
        object InitializeLifetimeService();
    }

    //Interface wat gebruikt wordt zodat de client alleen maar toegang heeft tot deze methodes
    public interface IClient
    {
        bool CheckLogin(string username);
        bool CheckUser(string username, string pass);
        bool SendMsgToServer(RemoteEventArgs re);
        void SinkRemoteObj(RemoteObj Obj, string serviceName, string username);
        bool UnSinkRemoteObj(string username, string serviceName);
        object InitializeLifetimeService();
    }
}
