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
using PluginManager;
using System.IO;
using System.Windows.Forms;

namespace CC_Client
{
    //delegate die ervoor zorgt dat data in de update manager terecht komt van communicatie manager
    internal delegate void UpdateHandler(RemoteEventArgs re);
    //delegate die word gebruikt om aan te geven wanneer een plugin is getransporteert is
    public delegate void FileFinishedHandler(bool ok);

    //classe die gebruikt wordt om nieuwe plugins binnen te halen van de server
    public class UpdateManager
    {
        #region Fields
        private CommunicatieManager cm;
        private PluginManager pm;
        private UpdateHandler uh;
        //lijst met geinstalleerde plugins
        private List<UpdatePluginInfo> installedplugins;
        //lijst met nieuwe plugins van de server
        private List<UpdatePluginInfo> newplugins = new List<UpdatePluginInfo>();
        //object dat word gebruikt om algemene instellingen op te slaan
        private ConfigClient config;
        //event handler wat gebruikt word om aan te geven wanneer een nieuwe plugin is binnen gekomen
        private FileFinishedHandler fh;
        #endregion

        #region Properties
        public FileFinishedHandler FH
        {
            get { return fh; }
            set { fh = value; }
        }
        public List<string[]> InstalledPlugins
        {
            get { return GetOldPluginsInfo(); }
        }
        //property wat gebruikt om aan te geven wanneer een nieuwe plugin is aangekomen
        public bool NewPluginsAvailable
        {
            get
            {
                if (newplugins.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        public UpdateManager(CommunicatieManager cm,PluginManager pm)
        {
            this.cm = cm;
            this.pm = pm;
            config = ConfigClient.OpenConfig();
            installedplugins = config.InstalledPlugins;
            uh = new UpdateHandler(UpdateEventInfo);
            //hiermee wordt de event handler gekoppelt aan die van de communicatie manager
            cm.UH = uh;
        }

        //event wat gebruikt om om nieuwe plugins binnen te halen
        private void UpdateEventInfo(RemoteEventArgs re)
        {
            switch(re.message)
            {
                case "PLUGINS":
                    newplugins.Clear();
                    UpdateEventArgs uea = (UpdateEventArgs)re.customEventArgs;
                    foreach (UpdatePluginInfo upi in uea.pluginsInfo)
                    {
                        if (installedplugins.Count == 0)
                        {
                            newplugins.Add(upi);
                            continue;
                        }
                        foreach (UpdatePluginInfo upi2 in installedplugins)
                        {
                            if (upi2.name == upi.name && upi.version == upi2.version)
                            {
                                continue;
                            }
                            else
                            {
                                newplugins.Add(upi);
                            }
                        }
                    }
                    break;
                case "PLUGINFILE":
                    InstallPluginOnClient((PluginFile)re.customEventArgs);
                    break;
            }
        }

        //methode die gebruikt word om een nieuwe plugin weg te schrijven naar een bestand
        private void InstallPluginOnClient(PluginFile pluginFile)
        {
            bool ok;
            try
            {
                string path = Application.StartupPath + "//" + pluginFile.name+"."+pluginFile.extension;
                FileStream fs = File.Create(path);
                fs.Write(pluginFile.data, 0, pluginFile.data.Length);
                fs.Close();
                ok = true;
            }
            catch
            {
                ok = false;
            }
            fh(ok);
        }

        //methode die wordt gebruikt om nieuwe plugins op te halen
        public void GetNewPlugins()
        {
            RemoteEventArgs re = new RemoteEventArgs("GETUPDATEPLUGINS",cm.UserName,new EventArgs());
            cm.SendMsgToServer(re);
        }

        //methode die wordt gebruikt om nieuwe plugin informatie te converteren naar GUI laag 
        public List<string[]> GetNewPluginsInfo()
        {
            List<string[]> info = new List<string[]>();

            foreach (UpdatePluginInfo upi in newplugins)
            {
                string[] s = new string[3];
                s[0] = upi.name;
                s[1] = upi.version.ToString();
                s[2] = upi.description;

                info.Add(s);
            }
            return info;
        }

        //methode die wordt gebruikt om geinstalleerde plugin informatie te converteren naar GUI laag 
        public List<string[]> GetOldPluginsInfo()
        {
            List<string[]> info = new List<string[]>();

            foreach (UpdatePluginInfo upi in installedplugins)
            {
                string[] s = new string[3];
                s[0] = upi.name;
                s[1] = upi.version.ToString();
                s[2] = upi.description;

                info.Add(s);
            }
            return info;
        }

        //methode die wordt gebruikt om het nieuwe plugin bestand op te halen van de server
        public void InstallPlugin(string pluginName)
        {
            RemoteEventArgs re = new RemoteEventArgs("GETPLUGINFILE", cm.UserName, new PluginFile(pluginName,null,null));
            cm.SendMsgToServer(re);
        }

        //methode die wordt gebruikt om de nieuwe plugin op te slaan in het configuratie bestand van de client
        public void AddInstalledPlugin(string name, string version, string description)
        {
            UpdatePluginInfo upi = new UpdatePluginInfo(name, Convert.ToDouble(version), description);
            installedplugins.Add(upi);
            ConfigClient.SaveConfig(installedplugins);
        }

        //methode voor een geinstalleerde plugin te verwijderen
        public void DeletePlugin(string pluginName,bool nofile)
        {
            if (!nofile)
            {
                pm.UnRegisterPlugin(pluginName);
            }

            int index = -1;
            foreach (UpdatePluginInfo upi in installedplugins)
            {
                if (upi.name == pluginName)
                {
                    index = installedplugins.IndexOf(upi);
                }
            }
            if (index != -1)
            {
                installedplugins.RemoveAt(index);
                ConfigClient.SaveConfig(installedplugins);
            }
        }
    }
}
