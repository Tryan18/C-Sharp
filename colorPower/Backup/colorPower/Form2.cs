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

namespace colorPower
{
    public partial class Form2 : Form
    {
        private List<blokje> blokken = new List<blokje>();
        private Timer draw_timer = new Timer();
        private Random r = new Random();

        public Form2(int aantal)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            draw_timer.Interval = 100;
            draw_timer.Tick += new EventHandler(draw_timer_Tick);
            
            for (int i = 0; i < aantal; i++)
            {
                blokken.Add(new blokje(10,r.Next(0,Screen.PrimaryScreen.Bounds.Right),r.Next(0,Screen.PrimaryScreen.Bounds.Bottom)));
            }
            draw_timer.Start();
        }

        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            draw_timer.Stop();
        }

        void draw_timer_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap b = new Bitmap(this.Width,this.Height);
            Graphics gg = Graphics.FromImage((Image)b);
            g.Clear(Color.White);
            //gg.FillRectangle(Brushes.White, new Rectangle(0, 0, b.Width, b.Height));
            foreach (blokje bk in blokken)
            {
                gg.FillRectangle(bk.b, bk.r);
            }
            b.MakeTransparent(Color.White);
            g.DrawImage((Image)b, 0, 0);
            gg.Dispose();
            g.Dispose();
        }
    }
}
