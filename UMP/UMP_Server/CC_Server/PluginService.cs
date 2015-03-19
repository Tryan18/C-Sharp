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
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

namespace CC_Server
{
    //delegate die events doorstuurt van communicatie service naar plugin service
    internal delegate void PluginHandler(RemoteEventArgs re);

    //plugin service controleert alle plugins en beheert deze
    public class PluginService : IPrimaryServer
    {
        #region Fields
        private CommunicatieService cs;
        //server plugins
        private List<IPServer> plugins;
        //event handler die gekoppelt is aan de communicatie service
        private PluginHandler ph;
        #endregion

        #region Properties
        internal List<IPServer> Plugins
        {
            get { return plugins; }
            set { plugins = value; }
        }
        #endregion

        public PluginService(CommunicatieService cs)
        {
            this.cs = cs;
            ph += new PluginHandler(PluginEventInfo);
            cs.PH = ph;
        }

        //laad alle plugins in het geheugen
        internal void RegisterPlugins()
        {
            AppDomain.CurrentDomain.SetShadowCopyFiles();
            string path = Application.StartupPath;
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            plugins = new List<IPServer>();

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                FileInfo fi = new FileInfo(pluginFiles[i]);
                string args = fi.Name.Split('.')[0];
                string referencedName = null;
                Type ObjType = null;
                //IPlugin ipi;
                // load the dll
                try
                {
                    // load it
                    Assembly ass = null;
                    ass = Assembly.Load(args);
                    if (ass != null)
                    {
                        int level = 3;

                        Assembly hulp = checkForUMPDLL(ass.GetName(), ref level, ref referencedName, ref args);
                        if (hulp == null)
                        {
                            continue;
                        }
                        ObjType = hulp.GetType(args + ".PServer");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    if (ObjType != null)
                    {
                        //nieuw plugin server object word aangemaakt vanuit het bestand
                        IPServer p = (IPServer)Activator.CreateInstance(ObjType);
                        p.ReferencedName = referencedName;
                        p.PrimaryServer = this;
                        plugins.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Assembly checkForUMPDLL(AssemblyName assemblyName, ref int level,ref string referencedName,ref string args)
        {
            try
            {
                Assembly ass = null;
                if (level == 0)
                {
                    return null;
                }
                ass = Assembly.Load(assemblyName);

                string configuration = ((AssemblyConfigurationAttribute)ass.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), true)[0]).Configuration;

                if (configuration == "UMPDLL_DUAL" && referencedName != null)
                {
                    args = assemblyName.Name;
                    return ass;
                }
                else if (configuration == "UMPDLL_INTEGRATED")
                {
                    AssemblyName[] ans = ass.GetReferencedAssemblies();
                    foreach (AssemblyName an in ans)
                    {
                        level--;
                        referencedName = ass.GetName().Name;
                        Assembly a = checkForUMPDLL(an, ref level, ref referencedName,ref args);
                        if (a != null)
                        {
                            return a;
                        }
                    }
                }
                else if (configuration == "UMPDLL")
                {
                    return ass;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        //deze mthode word aangeroepen vanuit de plugin
        public void InitializePlugin(IPServer p)
        {
            if (cs.CreatePluginServer(p.PlugInName))
            {
                Out.WriteLine(p.PlugInName + " PluginServer Created!");
                p.StartPlugin();
            }
            else
            {
                Out.WriteLine("Failed to create " + p.PlugInName + " PluginServer");
            }
        }

        //event die vervolgens alle data doorstuurt naar de plugins
        public void PluginEventInfo(RemoteEventArgs re)
        {
            foreach (IPServer p in plugins)
            {
                if (p.PlugInName == re.serviceName)
                {
                    p.PluginEventInfo((PluginEventArgs)re.customEventArgs);
                    break;
                }
            }
        }

        //methode die berichten door stuurt naar plugin clients
        public void SendToPluginClient(IPServer s,PluginEventArgs pe)
        {
            cs.RServer.SendMsgToClient(new RemoteEventArgs("", pe.username, s.PlugInName, false, pe));
        }
    }
}
