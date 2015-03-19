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
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using UMP;

namespace CC_Client
{
    //deze delegate word gebruikt om gegevens te transporteren van communicatie manager naar plugin manager
    internal delegate void PluginHandler(RemoteEventArgs e);

    //plugin manager word gebruikt om plugins te controleren en beheren
    public class PluginManager : IPrimaryClient
    {
        //lijst met geladen plugins
        private List<IPClient> plugins = new List<IPClient>();
        private CommunicatieManager cm;
        //plugin event handler 
        private PluginHandler ph;

        public PluginManager(CommunicatieManager cm)
        {
            this.cm = cm;
            ph += new PluginHandler(PluginEventInfo);
            //hier word de event handler gekoppelt met die van de communicatie manager
            cm.PH = ph;
        }

        //hier worden plugins ingeladen in het geheugen
        internal void RegisterPlugins()
        {
            //met behulp van deze code word het DLL bestand op een andere locatie ingeladen in het geheugen
            //AppDomain.CurrentDomain.SetShadowCopyPath("C://temp");
            AppDomain.CurrentDomain.SetShadowCopyFiles();
            string path = Application.StartupPath;
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            plugins = new List<IPClient>();

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                FileInfo fi = new FileInfo(pluginFiles[i]);
                string args = fi.Name.Split('.')[0];
                string referencedName = null;

                Type ObjType = null;
                try
                {
                    Assembly ass = null;
                    ass = Assembly.Load(args);
                    if (ass != null)
                    {
                        int level = 3;
                        Assembly hulp = checkForUMPDLL(ass.GetName(),ref level, ref referencedName, ref args);
                        if (hulp == null)
                        {
                            continue;
                        }
                        ObjType = hulp.GetType(args + ".PClient");
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
                        //hier word er een plugin object aangemaakt
                        IPClient p = (IPClient)Activator.CreateInstance(ObjType);
                        p.ReferencedName = referencedName;
                        p.PrimaryClient = this;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Assembly checkForUMPDLL(AssemblyName assemblyName, ref int level, ref string referencedName, ref string args)
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
                    level--;
                    args = assemblyName.Name;
                    return ass;
                }
                else if (configuration == "UMPDLL_INTEGRATED")
                {
                    level--;
                    AssemblyName[] ans = ass.GetReferencedAssemblies();
                    foreach (AssemblyName an in ans)
                    {
                        referencedName = ass.GetName().Name;
                        Assembly a = checkForUMPDLL(an, ref level, ref referencedName, ref args);
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
            catch(Exception ex)
            {
                return null;
            }
            return null;
        }

        //deze event stuurt alle informatie door naar de desbetreffende services/plugins
        private void PluginEventInfo(RemoteEventArgs e)
        {
            foreach (IPClient p in plugins)
            {
                if (p.PlugInName == e.serviceName)
                {
                    p.PluginEventInfo((PluginEventArgs)e.customEventArgs);
                }
            }
        }

        //hier word een specifieke plugin/service gestart
        internal void StartPlugin(string serviceName)
        {
            foreach (IPClient p in plugins)
            {
                if (p.PlugInName == serviceName)
                {
                    p.StartPlugin(cm.UserName);
                    return;
                }
            }
        }

        //deze methode word aangeroepen vanuit de plugin
        public void InitializePlugin(IPClient p)
        {
            plugins.Add(p);
        }

        //deze methode wordt gebruikt om data te versturen naar een plugin server
        public void SendToPluginServer(IPClient c,PluginEventArgs pe)
        {
            cm.SendMsgToPluginServer(new RemoteEventArgs("",pe.username,c.PlugInName,true,pe));
        }

        //hiermee word een plugin uit het geheugen geladen
        internal void UnRegisterPlugin(string pluginName)
        {
            int index = -1;
            foreach (IPClient c in plugins)
            {
                if (c.PlugInName == pluginName)
                {
                    index = plugins.IndexOf(c);
                }
            }
            if (index != -1)
            {
                plugins.RemoveAt(index);
            }
        }
    }
}
