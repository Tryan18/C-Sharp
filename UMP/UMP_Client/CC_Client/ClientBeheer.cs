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

namespace CC_Client
{
    //client beheer regelt het algemene data verkeer wat tussen GUI en client laag afspeelt
    public class ClientBeheer
    {
        //communicatie manager regelt communicatie met server
        public CommunicatieManager cm;
        //plugin manager regelt ouwe en nieuwe plugins
        internal PluginManager pm;
        //update manager controleer voor nieuwe plugins op de server
        public UpdateManager um;

        public ClientBeheer(EventHandler msghandler)
        {
            cm = new CommunicatieManager(msghandler);
            pm = new PluginManager(cm);
            um = new UpdateManager(cm, pm);
        }

        //maakt verbinding met de server
        public void ConnectToServer(string adres, string port, string username, string pass)
        {
            cm.ConnectServer(adres, Convert.ToInt32(port), username, pass);
        }

        public void StartPlugin(string serviceName)
        {
            //laad de geinstaleerde plugins in het geheugen
            pm.RegisterPlugins();
            //start een geselecteerde plugin
            pm.StartPlugin(serviceName);
        }

        public void SendMsgToServer(string msg)
        {
            //verstuurt een bericht naar de server
            cm.SendMsgToServer(msg);
        }

        public void DisconnectFromServer()
        {
            //verbreekt de verbinding met de server
            cm.DisconnectServer();
        }
    }
}
