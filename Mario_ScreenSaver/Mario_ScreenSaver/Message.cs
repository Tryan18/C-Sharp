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
using System.Reflection;

namespace Mario_ScreenSaver
{
    public partial class Message : Form
    {
        private Graphics g;
        private Bitmap message;
        private bool teken = false;

        public Message()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            message = Properties.Resources.MadeByTerence;
            message.MakeTransparent(Color.White);
            //object[] objecten = Assembly.GetExecutingAssembly().GetCustomAttributes(true);

            //AssemblyText tada = (AssemblyText)objecten[0];
            //MessageBox.Show(tada.Text);
            //string test = "";
            //for(int i=tada.Text.Length-1;i>-1;i--)
            //{
            //    test += tada.Text[i];
            //}
            //message = new Bitmap(88,66);
            //Graphics g = Graphics.FromImage((Image)message);
            //GraphicsUnit gu = GraphicsUnit.Pixel;
            //g.FillRectangle(Brushes.White, message.GetBounds(ref gu));
            //Pen p = new Pen(Brushes.Black);
            //Point[] points = new Point[] { new Point(0, 62),new Point(10, 43),new Point(19, 48),new Point(0, 63) };
            //Rectangle rec = new Rectangle(2, 4, 84, 50);
            //Rectangle rec2 = new Rectangle(15, 17, 41, 22);
            //g.DrawLine(p, points[0], points[1]);
            //g.DrawLine(p, points[3], points[2]);
            //g.DrawEllipse(p, rec);
            //g.FillRectangle(Brushes.White, rec);
            //g.FillClosedCurve(Brushes.Black, points);
            //g.DrawString(test, new Font(FontFamily.Families[1],8,FontStyle.Regular,GraphicsUnit.Pixel), Brushes.Black, new PointF(15, 17));
            //g.Dispose();
            

            teken = true;
        }

        private void Message_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if(teken)
                g.DrawImage((Image)message, 0, 0);
            g.Dispose();
        }
    }
}
