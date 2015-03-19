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
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Windows.Forms;

namespace CC_Server
{
    //classe die algemene instellingen opslaat van de server
    [Serializable]
    public class Config
    {
        #region Fields
        //tabel die autorisatie gegevens opslaat van een gebruiker
        private DataTable dt;
        #endregion

        #region Properties
        internal DataTable DT
        {
            get { return dt; }
        }
        #endregion

        //statische methode die algemene instellingen opslaat
        public static void SaveConfig(Config c,DataTable DT)
        {
            BinaryFormatter bf = new BinaryFormatter();
            c.dt = DT.Copy();
            string path = Application.StartupPath + "//" + "Config.ump";
            FileStream fs = File.Open(path, FileMode.Create);
            bf.Serialize(fs,c);
            fs.Close();
        }

        //statische methode die algemene instellingen ophaalt
        public static Config OpenConfig()
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.StartupPath + "//" + "Config.ump";
            Config c = new Config();
            if (File.Exists(path))
            {
                FileStream fs = File.Open(path, FileMode.Open);
                c = (Config)bf.Deserialize(fs);
                fs.Close();
            }
            if (c.dt != null)
            {
                return c;
            }
            else
            {
                FileStream fs = File.Open(path, FileMode.Create);

                Config cc = new Config();
                cc.dt = new DataTable("Users");
                DataColumn column;
                column = new DataColumn();
                column.ColumnName = "UserName";
                cc.dt.Columns.Add(column);
                column = new DataColumn();
                column.ColumnName = "ServerPass";
                cc.dt.Columns.Add(column);

                bf.Serialize(fs, cc);
                fs.Close();
                return cc;
            }
        }
    }
}
