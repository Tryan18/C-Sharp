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

namespace PluginManager
{
    /// <summary>
    /// Interface wat gebruikt word om te kunnen communiceren tussen plugin manager en client plugin
    /// </summary>
    public interface IPClient
    {
        void PluginEventInfo(PluginEventArgs pe);
        string ReferencedName { set;}
        string PlugInName { get;}
        double PlugInVersion { get;}
        string Description { get;}
        IPrimaryClient PrimaryClient { get;set;}
        void SendToPluginServer(PluginEventArgs pe);
        void StartPlugin(string LocalUserName);
    }
    /// <summary>
    /// Interface wat gebruikt word om te kunnen communiceren tussen plugin service en server plugin
    /// </summary>
    public interface IPServer
    {
        void PluginEventInfo(PluginEventArgs re);
        void SendToPluginClient(PluginEventArgs pe);
        string ReferencedName { set;}
        string PlugInName { get;}
        double PlugInVersion { get;}
        string Description { get;}
        IPrimaryServer PrimaryServer { get;set;}
        void StartPlugin();
    }

    /// <summary>
    /// Aanvullende Interface wat gebruikt word om te kunnen communiceren tussen plugin manager en client plugin
    /// </summary>
    public interface IPrimaryClient
    {
        void InitializePlugin(IPClient p);
        void SendToPluginServer(IPClient c, PluginEventArgs pe);
    }

    /// <summary>
    /// Aanvullende Interface wat gebruikt word om te kunnen communiceren tussen plugin service en server plugin
    /// </summary>
    public interface IPrimaryServer
    {
        void InitializePlugin(IPServer p);
        void SendToPluginClient(IPServer s, PluginEventArgs pe);
    }

    //delegate wat gebruikt word om berichten binnen te halen van de server naar de plugin client
    public delegate void RemoteServerRecieveHandler(PluginEventArgs e);
    //delegate wat gebruikt word om berichten te versturen naar de server vanuit de plugin client
    public delegate void RemoteServerSend(PluginEventArgs e);

    //Algemene interface voor het form van de plugin
    public interface IMain
    {
        RemoteServerSend RSS { get;set;}
        RemoteServerRecieveHandler RSRH { get;set;}
    }

    //update event arguments klasse bevat meerdere plugins informatie
    [Serializable]
    public class UpdateEventArgs : EventArgs
    {
        public UpdatePluginInfo[] pluginsInfo;

        public UpdateEventArgs(UpdatePluginInfo[] pluginsInfo)
        {
            this.pluginsInfo = pluginsInfo;
        }
    }
    //update plugin informatie klasse bevat informatie over nieuwe plugins
    [Serializable]
    public class UpdatePluginInfo
    {
        public string name;
        public double version;
        public string description;

        public UpdatePluginInfo(string name,double version,string description)
        {
            this.name = name;
            this.version = version;
            this.description = description;
        }
    }

    //plugin event arguments bevat algemene plugin data wat verstuurt word van server plugin naar client plugin en weer terug 
    [Serializable]
    public class PluginEventArgs : EventArgs
    {
        public string message;
        public string username;
        public EventArgs pluginEventArgs;

        public PluginEventArgs(string message, string username, EventArgs customPluginEventArgs)
        {
            this.message = message;
            this.username = username;
            this.pluginEventArgs = customPluginEventArgs;
        }
    }

    //plugin classe wat daadwerkelijk de informatie bevat van de plugin bestand
    [Serializable]
    public class PluginFile : EventArgs
    {
        public string name;
        public string extension;
        public byte[] data;

        public PluginFile(string name, string extension, byte[] data)
        {
            this.name = name;
            this.extension = extension;
            this.data = data;
        }
    }
}
