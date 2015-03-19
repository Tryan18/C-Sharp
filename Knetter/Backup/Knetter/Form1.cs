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
using System.Threading;

namespace Knetter
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Thread t;
        int getal = 0;

        public Form1()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Form1_Shown);
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            getal = e.KeyValue * r.Next(0, 215);
            if (getal < 32000)
            {
                t = new Thread(new ThreadStart(Beep));
                t.Start();
                this.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            } 
        }

        private void Beep()
        {
            if (getal >= 37)
            {
                Console.Beep(getal, 1000);
                t.Abort();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X != 0 && e.Y != 0)
            {
                int rood = (Screen.PrimaryScreen.Bounds.Width % e.X);
                int groen = (Screen.PrimaryScreen.Bounds.Width % e.Y);
                int blauw = (Screen.PrimaryScreen.Bounds.Width % (e.X + e.Y));

                if (rood < 256 && groen < 256 && blauw < 256)
                {
                    this.BackColor = Color.FromArgb(rood, groen, blauw);
                }
            }
            Application.DoEvents();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("mouse X =" + e.X + Environment.NewLine + "mouse Y =" + e.Y);
        }
    }
}
