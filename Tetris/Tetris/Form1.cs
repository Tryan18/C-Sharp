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

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Speelbox sb;
        private Boolean tekenEenmalig = true;
        private Graphics g;
        private UserControl1 US;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (sb != null)
             {
                 g = e.Graphics;
                 sb.TekenSpeelVeld(g);
                 if (tekenEenmalig)
                 {
                     tekenEenmalig = false;
                     sb.setStartBlokken(g, niveaubox.SelectedIndex);
                 }
                 
             }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            tekenEenmalig = true;
            int niveau = niveaubox.SelectedIndex;
            this.Controls.Clear();
            InitializeComponent();
            niveaubox.SelectedIndex = niveau;
            
            sb = new Speelbox(niveau,this);
            US = new UserControl1(sb);
            this.Controls.Add(US);
            US.Focus();
        }

        private void niveaubox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sb != null) US.Focus();
        }
    }
}
