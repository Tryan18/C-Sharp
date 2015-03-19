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

namespace Sudoku
{
    public partial class InvoerNummer : Form
    {
        private Boolean extension;
        private SpeelBox SB;

        public InvoerNummer(object sender,Boolean extension)
        {
            InitializeComponent();
            SB = (sender as SpeelBox);
            this.extension = extension;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (extension && textBox1.Text.Length == 2)
            {
                int getal = Convert.ToInt16(textBox1.Text);
                if (getal > 0 && getal < 17)
                {
                    SB.ChangeImage(getal);
                    this.Close();
                }
                else this.Close();
            }
            else if(!extension)
            {
                int getal = Convert.ToInt16(textBox1.Text);
                if (getal > 0 && getal < 10)
                {
                    SB.ChangeImage(getal);
                    this.Close();
                }
                else this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
            if (e.KeyChar == 13 && textBox1.Text.Length != 0)
            {
                if (Convert.ToInt16(textBox1.Text) == 0)
                {
                    this.Close();
                    return;
                }
                SB.ChangeImage(Convert.ToInt16(textBox1.Text));
                this.Close();
            }
            
        }
    }
}
