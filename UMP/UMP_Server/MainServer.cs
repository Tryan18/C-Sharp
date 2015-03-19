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
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using CC_Server;

namespace UMP_Server
{
    //delegate die gebruikt wordt om berichten door te sturen naar de GUI
    delegate void MsgHandler(object sender,EventArgs e);

    public partial class MainServer : Form
    {
        private CommunicatieService cs;
        private ServerBeheer sb;
        //event handler die gebruikt word om berichten op te vangen het de CC_Server laag
        private EventHandler eventmsgHandler;

        public MainServer()
        {
            InitializeComponent();
            eventmsgHandler = new EventHandler(WriteLine);
            cs = new CommunicatieService(eventmsgHandler);
            sb = new ServerBeheer(cs);
            foreach (IPAddress ip in Dns.GetHostByName(Dns.GetHostName()).AddressList)
            {
                combo_ip.Items.Add(ip.ToString());
            }
        }

        //methode die gebruikt wordt om verschillende binnenkomende threads af te handelen zodat een cross-threading exception kan
        //worden voorkomen
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

        //event wat gebruikt word om commando's te versturen naar de server
        private void T_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sb.SendCommand(T_input.Text);
                T_input.Clear();
            }
        }

        private void B_host_start_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            int port;
            if (IPAddress.TryParse(combo_ip.Text, out ip))
            {
                if (int.TryParse(T_port.Text, out port))
                {
                    sb.StartServer(ip.ToString(), port);
                }
                else
                {
                    Out.WriteLine("Incorrect Port Number!");
                }
            }
            else
            {
                Out.WriteLine("Incorrect IP adress!");
            }
        }

        //event om de server te stoppen
        private void B_host_stop_Click(object sender, EventArgs e)
        {
            sb.StopServer();
        }

        private void T_output_TextChanged(object sender, EventArgs e)
        {
            //deze boolean zorgt voor de restrictie of je nu wel of niet de geschiedenis kan terug bekijken
            if (!cb_scrollback.Checked)
            {
                T_output.SelectionStart = T_output.Text.Length;
                T_output.ScrollToCaret();
            }
        }
    }
}
