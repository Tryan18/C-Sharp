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

namespace MultiPlayerUMP
{
    public class PClient : IPClient
    {
        private IPrimaryClient primaryClient;
        private Main m;
        private string referenceName;
        internal static IGame game;
        internal static Assembly ass;
        private string localUserName;

        public IPrimaryClient PrimaryClient
        {
            get { return primaryClient; }
            set
            {
                primaryClient = value;
                AppDomain.CurrentDomain.SetShadowCopyFiles();
                PClient.ass = Assembly.Load(referenceName);
                primaryClient.InitializePlugin(this);
            }
        }

        public string PlugInName
        {
            get 
            {
                return PClient.ass.GetName().Name;
            }
        }

        public double PlugInVersion
        {
            get
            {
                Version v = PClient.ass.GetName().Version;
                return Convert.ToDouble(v.Major.ToString() + "," + v.Minor.ToString());
            }
        }

        public string Description
        {
            get 
            {
                string description = ((AssemblyDescriptionAttribute)PClient.ass.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), true)[0]).Description;
                return description;
            }
        }

        public void StartPlugin(string LocalUserName)
        {
            this.localUserName = LocalUserName;
            m = new Main(LocalUserName,referenceName);
            m.RSS = new RemoteServerSend(SendToPluginServer);
            Type gameType = PClient.ass.GetType(PlugInName + ".Game");
            game = (IGame)Activator.CreateInstance(gameType);
            m.Show();

        }

        public void SendToPluginServer(PluginEventArgs pe)
        {
            primaryClient.SendToPluginServer(this, pe);
        }

        public void PluginEventInfo(PluginEventArgs pe)
        {
            m.RSRH(pe);
        }

        public string ReferencedName
        {
            set
            {
                referenceName = value;
            }
        }
    }
}
