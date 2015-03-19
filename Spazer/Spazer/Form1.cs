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

namespace Spazer
{
    public partial class Form1 : Form
    {
        private Game spel;
        public int score = 0;

        public Form1()
        {
            InitializeComponent();
            Bitmap b = new Bitmap(this.Width, this.Height);
            Graphics g = this.CreateGraphics();
            g.FillRectangle(Brushes.LightGray,new Rectangle(0,0,b.Width,b.Height));
            g.FillRectangle(Brushes.White, new Rectangle(panel_speelveld.Location, panel_speelveld.Size));
            g.Dispose();
            this.BackgroundImage = b;
        }

        private void B_start_Click(object sender, EventArgs e)
        {
            if (spel != null)
            {
                spel.DisposeGame();
            }
            spel = new Game(this,Niveau.Easy);
            T_besturing.Focus();
            //B_start.Visible = false;
        }

        internal void UpdateScore()
        {
            T_score.Text = score.ToString();
        }
    }
}
