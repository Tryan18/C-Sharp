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
using Verrassing;
using System.Threading;
using System.Diagnostics;

namespace colorPower
{
    public partial class Invisible : Form
    {
        private int maxaantal = 60;
        private int aantal = 0;
        private List<Form1> forms = new List<Form1>();
        private System.Windows.Forms.Timer stuks;
        private Random r = new Random();
        private List<Thread> tlist = new List<Thread>();
        private Form2 f2;

        public Invisible()
        {
            InitializeComponent();
            if (false)
            {
                f2 = new Form2(300);
                f2.FormClosed += new FormClosedEventHandler(f2_FormClosed);
                f2.Show();
                new Tada().Show();
            }
            else
            {
                stuks = new System.Windows.Forms.Timer();
                stuks.Interval = 500;
                stuks.Tick += new EventHandler(stuks_Tick);
                stuks.Start();
                //new Tada().Show();
                //Form1 f = new Form1(10);
                //f.StartPosition = FormStartPosition.CenterScreen;
                //f.Show();
            }
        }

        void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        void stuks_Tick(object sender, EventArgs e)
        {
            if (maxaantal == aantal)
            {

                //Process[] ps = Process.GetProcesses();
                //foreach (Process p in ps)
                //{
                //    if (p.MainModule.ModuleName == "winamp.exe")
                //    {
                //        p.Kill();
                //        break;
                //    }
                //}
                foreach (Form1 ff in forms)
                {
                    ff.Show();
                }
                new Tada().Show();
                (sender as System.Windows.Forms.Timer).Stop();
                return;
            }
            tlist.Add(new Thread(new ThreadStart(startnewshit)));
            tlist[tlist.Count - 1].Start();
            startnewshit();
            aantal++;
        }

        private void startnewshit()
        {
            Form1 f = new Form1(10);
            f.Location = new Point(r.Next(0, Screen.PrimaryScreen.Bounds.Right), r.Next(0, Screen.PrimaryScreen.Bounds.Bottom));
            forms.Add(f);
        }
    }
}
