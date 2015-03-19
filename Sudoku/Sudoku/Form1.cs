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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private SpeelBox SB;
        private DrawImages DI;
        public Image[,] images;
        private Boolean Laad = false;
        private WMPLib.WindowsMediaPlayerClass wmp;
        private Boolean playstatus = false;

        public Form1()
        {
            InitializeComponent();
            DI = new DrawImages();
            images = DI.GetImages();

            if (DateTime.Now.Day == 22 && DateTime.Now.Month == 2)
            {
                MessageBox.Show("JAAAAA van harte gefeliciteerd Pap!!! :D","FEEST!!!!!");
            }
            
            string fileName = "Temp1.MP3";
            byte[] buffer = Properties.Resources.Greece;
            FileStream outputStream = new FileStream(fileName, FileMode.Create);
            outputStream.Write(buffer, 0, buffer.Length);
            outputStream.Close();
            wmp = new WMPLib.WindowsMediaPlayerClass();
            wmp.settings.autoStart = false;
            wmp.playCount = 9999;

            fileName = "Temp2.MP3";
            buffer = Properties.Resources.God_Hand;
            outputStream = new FileStream(fileName, FileMode.Create);
            outputStream.Write(buffer, 0, buffer.Length);
            outputStream.Close();
            wmp.URL = "Temp1.MP3";
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            File.Delete("Temp1.MP3");
            File.Delete("Temp2.MP3");
            File.Delete("Temp3.WAV");
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Dispose();
            if (SB != null)
            {
                SB.ClearVeld();
            }
            if (!Laad)
            {
                label1.Visible = true;
                label1.Refresh();
                pb1.Visible = true;
                pb1.Refresh();
            }
            int z;
            if (comboBox1.Text == "Big Sudoku")
            {
                z = 16;
            }
            else z = 9;
            SB = new SpeelBox(this, z, Laad);
            //controleer.Visible = true;
        }

        private void controleer_Click(object sender, EventArgs e)
        {
            //controleer.Visible = false;
            //if (Controleer1x)
            //{
            SB.ChangeImage3();
            //    Controleer1x = false;
            //}
            
            int goed = SB.punten[1];
            int fout = SB.punten[0] - goed;
            if (SB.punten[0] <= 0) fout += goed;
            if (fout == 0)
            {
                MessageBox.Show("BINGO, allemaal goed Pap :D", "Perfect Klaar!!!");
                if (!musicbox.Items.Contains("Kotake & Koume"))
                {
                    string fileName = "Temp3.WAV";
                    byte[] buffer = Properties.Resources.Kotake___Koume_s_Theme___Fast;
                    FileStream outputStream = new FileStream(fileName, FileMode.Create);
                    outputStream.Write(buffer, 0, buffer.Length);
                    outputStream.Close();
                    musicbox.Items.Add("Kotake & Koume");
                }
            }
            else
            {
                MessageBox.Show("Hey Pap je hebt er " + goed + " goed en " + fout + " fout.", "Klaar!!!");
                
            }
            SB.punten[1] = 0;
            SB.punten[0] = 0;
            controleer.Visible = false;
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
                Laad = true;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.DefaultExt = ".Ter";
                OFD.Filter = "Only Sudoku Files (*.Ter)|*.Ter";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    button1_Click(this, null);
                    IFormatter loader = new BinaryFormatter();
                    try
                    {
                        FileStream FS = new FileStream(OFD.FileName, FileMode.Open, FileAccess.Read);
                        blokje[,] temp = loader.Deserialize(FS) as blokje[,];
                        SB.LoadImages(temp);
                        FS.Close();
                    }
                    catch { MessageBox.Show("Geen Geldig Sudoku Bestand. Moet namelijk een Ter extensie hebbu ;)", "YOOOO Dit klopt niet"); }
                }
                Laad = false;
        }

        private void Save_B_Click(object sender, EventArgs e)
        {
            
            if (SB != null)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.DefaultExt = ".Ter";
                SFD.FileName = "SaveGame 1";
                SFD.Filter = "Only Sudoku Files (*.Ter)|*.Ter";
                try
                {
                    if (SFD.ShowDialog() == DialogResult.OK)
                    {
                        IFormatter saver = new BinaryFormatter();
                        FileStream FS = new FileStream(SFD.FileName, FileMode.Create, FileAccess.ReadWrite);
                        saver.Serialize(FS, SB.blok);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is iets VIES fout gegaan... LOL" + ex.ToString(), "WOEST");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Big Sudoku")
            {
                MessageBox.Show("JAA, om deze te krijgen moet je, je zoon iets meer sponseren...:D", "Big Sudoku");
                comboBox1.Text = "Small Sudoku";
            }
        }

        private void musicb_Click(object sender, EventArgs e)
        {
            if (!playstatus)
            {
                wmp.play();
                playstatus = !playstatus;
            }
            else
            {
                wmp.stop();
                playstatus = !playstatus;
            }
        }

        private void musicbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wmp.stop();
            if (musicbox.SelectedIndex == 0) wmp.URL = "Temp1.MP3";
            else if (musicbox.SelectedIndex == 1) wmp.URL = "Temp2.MP3";
            else if (musicbox.SelectedIndex == 2) wmp.URL = "Temp3.WAV";
        }

        private void AGG_ValueChanged(object sender, EventArgs e)
        {
            if (AGG.Value < 36) label4.Text = "Hard =";
            else if (AGG.Value > 36) label4.Text = "Easy =";
            else label4.Text = "Normal =";
        }

    }
}
