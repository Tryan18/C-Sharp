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
using UMP;
using System.IO;
using System.Windows.Forms;

namespace CC_Server
{
    internal delegate void UpdateHandler(RemoteEventArgs re);

    public class UpdateService
    {
        private CommunicatieService cs;
        private PluginService ps;
        private UpdateHandler uh;

        public UpdateService(CommunicatieService cs,PluginService ps)
        {
            this.cs = cs;
            this.ps = ps;
            uh = new UpdateHandler(UpdateEventInfo);
            cs.UH = uh;
        }

        private void UpdateEventInfo(RemoteEventArgs re)
        {
            switch (re.message)
            {
                case "GETUPDATEPLUGINS":
                    UpdatePluginInfo[] upis = new UpdatePluginInfo[ps.Plugins.Count];
                    for (int i = 0; i < ps.Plugins.Count; i++)
                    {
                        upis[i] = new UpdatePluginInfo(ps.Plugins[i].PlugInName, ps.Plugins[i].PlugInVersion, ps.Plugins[i].Description);
                    }
                    UpdateEventArgs pe = new UpdateEventArgs(upis);
                    RemoteEventArgs e = new RemoteEventArgs("PLUGINS", re.userName, pe);
                    cs.RServer.SendMsgToClient(e);
                    break;
                case "GETPLUGINFILE":
                    PluginFile pf = GetPluginFile((PluginFile)re.customEventArgs);
                    cs.RServer.SendMsgToClient(new RemoteEventArgs("PLUGINFILE",re.userName,pf));
                    break;
            }
        }

        private PluginFile GetPluginFile(PluginFile pluginFile)
        {
            try
            {
                byte[] data = File.ReadAllBytes(Application.StartupPath + "//" + pluginFile.name + ".dll");
                string fileName = pluginFile.name;
                PluginFile pf = new PluginFile(pluginFile.name, "dll", data);
                return pf;
            }
            catch
            {
                return null;
            }
        }

        internal void startUpdateService()
        {
            ps.RegisterPlugins();
        }
    }
}
