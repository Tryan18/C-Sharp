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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Windows.Forms;
using UMP;
using PluginManager;

namespace CC_Client
{
    //deze klasse word gebruikt om instellingen op te slaan
    [Serializable]
    public class ConfigClient
    {
        //bevat alle geinstalleerde plugins/services
        private List<UpdatePluginInfo> installedplugins;

        public List<UpdatePluginInfo> InstalledPlugins
        {
            get { return installedplugins; }
        }

        //statische methode om instellingen op te slaan
        public static void SaveConfig(List<UpdatePluginInfo> installedplugins)
        {
            ConfigClient c = new ConfigClient();
            c.installedplugins = installedplugins;
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.StartupPath + "//" + "ConfigClient.ump";
            FileStream fs = File.Open(path, FileMode.Create);
            bf.Serialize(fs, c);
            fs.Close();
        }

        //statische methode om instellingen te laden
        public static ConfigClient OpenConfig()
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.StartupPath + "//" + "ConfigClient.ump";
            ConfigClient c = new ConfigClient();
            if (File.Exists(path))
            {
                FileStream fs = File.Open(path, FileMode.Open);
                c = (ConfigClient)bf.Deserialize(fs);
                fs.Close();
            }
            if (c.installedplugins != null)
            {
                return c;
            }
            else
            {
                FileStream fs = File.Open(path, FileMode.Create);
                ConfigClient cc = new ConfigClient();
                cc.installedplugins = new List<UpdatePluginInfo>();
                bf.Serialize(fs, cc);
                fs.Close();
                return cc;
            }
        }
    }
}
