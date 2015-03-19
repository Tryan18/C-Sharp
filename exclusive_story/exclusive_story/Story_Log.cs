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
using System.Text;
using System.Windows.Forms;

namespace exclusive_story
{
    public class Story_Log
    {
        public Timer speedtekst;
        private String tekst = "";
        private Form1 form;
        private int teller = 0;

        public Story_Log(int speed,Form1 f)
        {
            form = f;
            speedtekst = new Timer();
            speedtekst.Interval = speed;
            speedtekst.Tick += new EventHandler(speedtekst_Tick);
        }

        void speedtekst_Tick(object sender, EventArgs e)
        {
            if (tekst.Length != 0 && teller < tekst.Length)
            {
                form.T_log.Text += tekst[teller];
                teller++;
            }
            else
            {
                form.T_log.Text += Environment.NewLine;
                (sender as Timer).Stop();
            }
        }

        public void inputTekst(string tekst)
        {
            teller = 0;
            this.tekst = tekst;
        }

        public void Stop()
        {
            speedtekst.Stop();
        }

        public void Start()
        {
            speedtekst.Start();
        }

        public void Pause()
        {
            if (speedtekst.Enabled)
                speedtekst.Stop();
            else
                speedtekst.Start();
        }
    }
}
