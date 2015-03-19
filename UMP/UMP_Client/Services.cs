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
using CC_Client;
using System.Media;
using System.IO;
using System.Threading;

namespace UMP_Client
{
    public partial class Services : Form
    {
        //timer die nieuwe plugins checked
        private System.Windows.Forms.Timer status = new System.Windows.Forms.Timer();
        //clientbeheer
        private ClientBeheer cb;
        //hier worden de nieuwe plugins in opgeslagen
        private List<string[]> newPlugins = new List<string[]>();
        //hier worden de geinstalleerde plugins in opgeslagen
        private List<string[]> oldPlugins;
        //deze eventhandler word getriggert op het moment dat de plugin bij de client is binnen gekomen
        private FileFinishedHandler fh;
        //deze boolean zorgt voor het 1x laden van nieuwe plugins
        private bool GetPluginsOnce = true;

        public Services(ClientBeheer cb)
        {
            this.cb = cb;
            InitializeComponent();
            fh = new FileFinishedHandler(PluginInstalled);
            //hier word de event handler gekoppelt aan die van de updatemanager
            cb.um.FH = fh;
            this.Shown += new EventHandler(Services_Shown);
        }

        //event die getriggert word op het moment dat de nieuwe plugin is binnen gekomen
        private void PluginInstalled(bool ok)
        {
            if (ok)
            {
                MessageBox.Show("Succesfully installed plugin!");
                SafeInvokeHelper.Invoke(this, "InvokeList", null);
                SafeInvokeHelper.Invoke(this, "InvokeStatusStrip", new object[] { "Done!" });
            }
            else
            {
                MessageBox.Show("Error: could not install plugin");
            }
        }

        //methode die word gebruikt om windows form component te invoken zodat er geen cross threading exception voorkomt
        public void InvokeStatusStrip(string text)
        {
            L_status.Text = text;
        }

        //methode die word gebruikt om windows form component te invoken zodat er geen cross threading exception voorkomt
        public void InvokeList()
        {
            ListViewItem lvi = (ListViewItem)list_newPlugins.SelectedItems[0].Clone();
            list_oldPlugins.Items.Add(lvi);
            list_newPlugins.Items.RemoveAt(list_newPlugins.SelectedItems[0].Index);
            cb.um.AddInstalledPlugin(lvi.Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text);
            L_status.Text = "Done!";
        }

        //zodra services form geladen word
        void Services_Shown(object sender, EventArgs e)
        {
            L_status.Text = "Retrieving New Services";
            status.Interval = 2000;
            status.Tick += new EventHandler(status_Tick);
            status.Start();
            loadOldPlugins();
            cb.um.GetNewPlugins();
        }

        //geinstalleerde plugins worden hier geladen
        private void loadOldPlugins()
        {
            list_newPlugins.Items.Clear();
            oldPlugins = cb.um.GetOldPluginsInfo();

            foreach (string[] s in oldPlugins)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = s[0];
                lvi.SubItems.Add(s[1]);
                lvi.SubItems.Add(s[2]);
                list_oldPlugins.Items.Add(lvi);
            }
        }

        //timer event die nieuwe plugins controleert
        void status_Tick(object sender, EventArgs e)
        {
            if (GetPluginsOnce && cb.um.NewPluginsAvailable)
            {
                status.Stop();
                GetPluginsOnce = false;
                GetNewPlugins();
                L_status.Text = "Done!";
            }
            statusStrip1.Refresh();
        }

        //methode die nieuwe plugins ophaalt
        private void GetNewPlugins()
        {
            list_newPlugins.Items.Clear();
            newPlugins = cb.um.GetNewPluginsInfo();
            SoundPlayer sp = new SoundPlayer(Properties.Resources.NewServices);
            sp.Play();
            MessageBox.Show(newPlugins.Count.ToString() + " New Plugin(s) available!","Update Service!");
            foreach (string[] s in newPlugins)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = s[0];
                lvi.SubItems.Add(s[1]);
                lvi.SubItems.Add(s[2]);
                list_newPlugins.Items.Add(lvi);
            }
        }

        private void list_oldPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_oldPlugins.SelectedItems.Count != 0)
            {
                T_inst_description.Text = list_oldPlugins.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void list_newPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_newPlugins.SelectedItems.Count != 0)
            {
                T_new_description.Text = list_newPlugins.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void B_remove_Click(object sender, EventArgs e)
        {
            if (list_oldPlugins.SelectedItems.Count != 0)
            {
                RemovePlugin(list_oldPlugins.SelectedItems[0].Text);
            }
            else
            {
                MessageBox.Show("No Installed Plugin Selected!");
            }
        }

        //methode die een geselecteerd geinstaleerde plugin verwijdert
        private void RemovePlugin(string pluginName)
        {
            if (MessageBox.Show("Are you sure you want to delete the installed plugin?", "Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = Application.StartupPath + "//" + pluginName + ".dll";
                if (File.Exists(path))
                {
                    cb.um.DeletePlugin(pluginName,false);
                    File.Delete(path);
                    list_oldPlugins.Items.Remove(list_oldPlugins.SelectedItems[0]);
                    MessageBox.Show("Plugin UnInstalled!");
                }
                else
                {
                    cb.um.DeletePlugin(pluginName,true);
                    list_oldPlugins.Items.Remove(list_oldPlugins.SelectedItems[0]);
                    MessageBox.Show("Could not find the installed plugin!");
                }
            }
        }

        private void B_install_Click(object sender, EventArgs e)
        {
            if (list_newPlugins.SelectedItems.Count != 0)
            {
                cb.um.InstallPlugin(list_newPlugins.SelectedItems[0].Text);
            }
            else
            {
                MessageBox.Show("No Update Plugin Selected!");
            }
        }

        private void B_refresh_Click(object sender, EventArgs e)
        {
            cb.um.GetNewPlugins();
            status.Start();
            GetPluginsOnce = true;
        }
    }
}
