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
using MultiPlayerUMP;

namespace MultiMemory
{
    public delegate void GameDataRecieveHandler(EventArgs gameEventArgs);

    public partial class Form1 : Form
    {
        private SpeelVeld veld;
        private IMultiPlayerHost host;
        private IGame game;
        public GameDataRecieveHandler gameHandler;
        internal string speler2;
        private string userName;
        private bool isHost;

        public Form1(string userName,IMultiPlayerHost host,Game game,string[] users,bool isHost)
        {
            this.isHost = isHost;
            this.userName = userName;
            foreach (string s in users)
            {
                if (s != userName)
                {
                    speler2 = s;
                    break;
                }
            }
            this.game = game;
            this.host = host;
            gameHandler += new GameDataRecieveHandler(GameData);
            InitializeComponent();
            veld = new SpeelVeld(this,userName,host,isHost);
        }

        public void Bericht(string bericht)
        {
            SafeInvokeHelper.Invoke(this, "InvokeBericht", new object[] { bericht });
        }

        public void InvokeBericht(string bericht)
        {
            L_status.Text = bericht;
        }

        public void newGame()
        {
            veld = new SpeelVeld(this, userName,host,isHost);
        }

        public void GameData(EventArgs gameEventArgs)
        {
            if (veld != null)
            {
                veld.gameHandler(gameEventArgs);
            }
        }
    }
}
