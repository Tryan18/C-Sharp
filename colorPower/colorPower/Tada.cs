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
using System.Reflection;
using WMPLib;

namespace Verrassing
{
    public partial class Tada : Form
    {
        private Timer buffer;
        private Font f;
        private SolidBrush sb;
        private float afstand = 2;
        private char[] naam = Convert.ToString("Van Harte Gefeliciteerd!!!").ToCharArray();
        private Color[] kleuren = new Color[] { Color.Red,Color.Orange, Color.Green, Color.Yellow, Color.Magenta,
            Color.Blue, Color.Crimson, Color.Gold,Color.Red,Color.Orange, Color.Green, Color.Yellow, Color.Magenta,
            Color.Blue, Color.Crimson, Color.Gold,Color.Red,Color.Orange, Color.Green, Color.Yellow, Color.Magenta,
            Color.Blue, Color.Crimson, Color.Gold,Color.Red,Color.Orange, Color.Green, Color.Yellow, Color.Magenta,
            Color.Blue, Color.Crimson, Color.Gold};
        private WindowsMediaPlayer music = new WindowsMediaPlayer();
        private Random r = new Random();

        public Tada()
        {
            InitializeComponent();
            Start();
            FormClosing += new FormClosingEventHandler(Tada_FormClosing);
        }

        void Tada_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buffer != null)
            {
                buffer.Stop();
            }
        }

        private void Start()
        {
            CreateMusic();
            Color[] kls = new Color[naam.Length];
            for (int i = 0; i < naam.Length; i++)
            {
                if (kleuren.Length <= i)
                {
                    kls[i] = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                }
                else
                {
                    kls[i] = kleuren[i];
                }
            }
            kleuren = kls;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            bool pasAan = true;
            int fontSize = 64;
            f = new Font("Jokerman", fontSize);
            Graphics g = this.CreateGraphics();
            while (pasAan)
            {
                string s = "";
                foreach (char c in naam)
                {
                    s += c.ToString();
                }
                if (g.MeasureString(s, f).Width < this.Width-100)
                {
                    pasAan = false;
                }
                else
                {
                    fontSize -= 1;
                    f = new Font("Jokerman", fontSize);
                }
            }
            Label l = new Label();
            l.Text = "Groetjes Terence!";
            l.Font = new Font("Jokerman", 32);
            l.Size = new Size(Convert.ToInt32(g.MeasureString(l.Text, l.Font).Width+100), Convert.ToInt32(g.MeasureString(l.Text, l.Font).Height));
            l.Location = new Point(2, this.Bottom - Convert.ToInt32(g.MeasureString(l.Text, l.Font).Height));
            this.Controls.Add(l);
            sb = new SolidBrush(Color.Black);
            buffer = new Timer();
            buffer.Interval = 100;
            buffer.Tick += new EventHandler(buffer_Tick);
            buffer.Start();
        }

        private void CreateMusic()
        {
            string fileName = Application.StartupPath + "\\verrassing.mp3";
            music.URL = fileName;
            music.controls.play();
        }

        void buffer_Tick(object sender, EventArgs e)
        {
            if (music.playState == WMPPlayState.wmppsStopped)
            {
                (sender as Timer).Stop();
                Application.Exit();
                return;
            }
            Bitmap b = new Bitmap(this.Width, this.Height);
            Graphics gg = CreateGraphics();
            gg.Clear(Color.White);
            Graphics g = Graphics.FromImage((Image)b);
            for(int i =0;i<naam.Length;i++)
            {
                sb.Color = kleuren[i];
                g.DrawString(naam[i].ToString(),f,sb,new PointF(afstand + r.Next(0,Convert.ToInt32(f.Size/2)),this.Height/3 + r.Next(0,Convert.ToInt32(f.Size/2))));
                afstand += g.MeasureString(naam[i].ToString(),f).Width-20;
            }
            afstand = 2;
            gg.DrawImage(b, 0, 0);
            g.Dispose();
            gg.Dispose();
        }
    }
}
