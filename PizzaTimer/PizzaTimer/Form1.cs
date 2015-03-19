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

namespace PizzaTimer
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer pizzaTimer = new System.Windows.Forms.Timer();
        private TimeSpan ts;
        private int minuten;
        private bool stop;

        public Form1()
        {
            InitializeComponent();
            pizzaTimer.Tick += new EventHandler(pizzaTimer_Tick);
            pizzaTimer.Interval = 1000;
        }

        void pizzaTimer_Tick(object sender, EventArgs e)
        {
            lock (pizzaTimer)
            {
                if (ts.Ticks == 0)
                {
                    B_ok.Text = "Stop Alarm";
                    Thread t = new Thread(new ThreadStart(StartAlarm));
                    t.IsBackground = true;
                    t.Start();
                    pizzaTimer.Stop();
                    return;
                }
                ts = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds - 1);
                L_tijd.Text = ts.ToString();
            }
        }

        private void StartAlarm()
        {
            while (!stop)
            {
                Console.Beep(1000, 500);
                Thread.Sleep(1000);
                Console.Beep();
                Thread.Sleep(1000);
            }
        }

        private void B_ok_Click(object sender, EventArgs e)
        {
            if (B_ok.Text == "Set")
            {
                stop = false;
                minuten = Convert.ToInt32(num_minuten.Value);
                ts = new TimeSpan(0, minuten, 0);
                L_tijd.Text = ts.ToString();
                pizzaTimer.Start();
                B_ok.Text = "Abort";
            }
            else if (B_ok.Text == "Abort")
            {
                L_tijd.Text = "-";
                pizzaTimer.Stop();
                stop = true;
                B_ok.Text = "Set";
            }
            else if (B_ok.Text == "Stop Alarm")
            {
                pizzaTimer.Stop();
                L_tijd.Text = "-";
                stop = true;
                B_ok.Text = "Set";
            }
        }
    }
}
