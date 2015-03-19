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
using System.Threading;
using MultiPlayerUMP;

namespace MultiMemory
{
    class SpeelVeld
    {
        public List<Kaartje> Mlist;
        private readonly int Lengte = 100;
        private readonly int Breedte = 100;
        private int space = 10;
        private Form1 f;
        private int Omgedraaid = 0;
        private Dictionary<string, int> spelers = new Dictionary<string, int>();
        private Random r;
        private bool switchSpeler = false;
        private string speler1;
        private string speler2 = null;
        private bool connected = false;
        private IMultiPlayerHost host;
        public GameDataRecieveHandler gameHandler;
        private System.Windows.Forms.Timer wachtenOpClient = new System.Windows.Forms.Timer();
        private bool isHost;

        public SpeelVeld(Form1 sender,string spelerNaam,IMultiPlayerHost host,bool isHost)
        {
            this.isHost = isHost;
            this.host = host;
            Mlist = new List<Kaartje>();
            f = sender;
            r = new Random();
            spelers.Add(spelerNaam, 0);
            speler1 = spelerNaam;
            wachtenOpClient.Interval = 3000;
            wachtenOpClient.Tick += new EventHandler(wachtenOpClient_Tick);
            gameHandler += new GameDataRecieveHandler(GameData);
            f.Shown += new EventHandler(f_Shown);
            
        }

        void wachtenOpClient_Tick(object sender, EventArgs e)
        {
            if (speler2 != null)
            {
                wachtenOpClient.Stop();
                startGame();
            }
        }

        void f_Shown(object sender, EventArgs e)
        {
            if (isHost)
            {
                wachtenOpClient.Start();
            }
        }

        private void GameData(EventArgs gameEventArgs)
        {
            MultiMemoryEventArgs me = (MultiMemoryEventArgs)gameEventArgs;
            switch (me.type)
            {
                case spelType.Start:
                    speler2 = me.spelerNaam;
                    host.SendToPlayer(speler2,new MultiMemoryEventArgs(spelType.Join,speler1));
                    break;
                case spelType.Stop:
                    host.QuitGame();
                    break;
                case spelType.Join:
                    Mlist = me.kaartjes;
                    SafeInvokeHelper.Invoke(f, "SpeelVeldOnvangen", new object[] { true });
                    break;
                case spelType.Data:
                    if (connected)
                    {
                        doeZet(me.nummer);
                    }
                    break;
            }
        }

        private void doeZet(int nummer)
        {
            if (Omgedraaid == 1)
            {
                if (switchSpeler)
                {
                    f.Bericht(speler1 + " is aan de beurt");
                }
                else
                {
                    f.Bericht(speler2 + " is aan de beurt");
                }
            }
            if (Omgedraaid == 2)
            {
                switchSpeler = true;
                ControleerPic();
            }
            if (!Mlist[nummer - 1].revealed)
            {
                Mlist[nummer - 1].changePic();
                Omgedraaid++;
            }
            ControleerSpeelVeld();
        }

        public void SpeelVeldOnvangen(bool invoke)
        {
            foreach (Kaartje k in Mlist)
            {
                k.pb = new PictureBox();
                k.pb.Left = k.x + 12;
                k.pb.Top = k.y + 12;
                k.pb.Width = k.breedte;
                k.pb.Height = k.lengte;
                k.changePic();
                k.pb.SizeMode = PictureBoxSizeMode.StretchImage;
                f.Controls.Add(k.pb);
            }
            connected = true;
        }

        public void startGame()
        {
            f.Bericht("Status = wacht op andere speler");
            SafeInvokeHelper.Invoke(f, "CreateSpeelVeld", new object[] { true });
            host.SendToPlayer(f.speler2, new MultiMemoryEventArgs(spelType.Start,speler1));
        }

        private void CreateSpeelVeld(bool invoke)
        {
            int plaats = 1;
            int x = 0;
            int y = 0;

            for (int i = 0; i < 16; i++)
            {
                if (plaats < 5)
                {
                    Mlist.Add(new Kaartje(x, y, Breedte, Lengte, plaats, plaats, f));
                    Mlist[i].pb.MouseClick += new MouseEventHandler(MouseClick);
                    plaats++;
                    x += Breedte + space;
                }
                else if (plaats < 9 && plaats > 4)
                {
                    if (plaats == 5)
                    {
                        y += Lengte + space;
                        x = 0;
                    }
                    Mlist.Add(new Kaartje(x, y, Breedte, Lengte, plaats, plaats, f));
                    Mlist[i].pb.MouseClick += new MouseEventHandler(MouseClick);
                    plaats++;
                    x += Breedte + space;
                }
                else if (plaats < 13 && plaats > 8)
                {
                    if (plaats == 9)
                    {
                        y += Lengte + space;
                        x = 0;
                    }
                    Mlist.Add(new Kaartje(x, y, Breedte, Lengte, plaats - 8, plaats, f));
                    Mlist[i].pb.MouseClick += new MouseEventHandler(MouseClick);
                    plaats++;
                    x += Breedte + space;
                }
                else if (plaats < 17 && plaats > 12)
                {
                    if (plaats == 13)
                    {
                        y += Lengte + space;
                        x = 0;
                    }
                    Mlist.Add(new Kaartje(x, y, Breedte, Lengte, plaats - 8, plaats, f));
                    Mlist[i].pb.MouseClick += new MouseEventHandler(MouseClick);
                    plaats++;
                    x += Breedte + space;
                }
            }
            Random();
            Random();
            Random();
            Random();
            Random();
        }

        private void MouseClick(object sender, EventArgs e)
        {
            if (connected && !switchSpeler)
            {
                int select = 0;
                for (int i = 0; i < Mlist.Count; i++)
                {
                    if (Mlist[i].pb.Top == (sender as PictureBox).Top && Mlist[i].pb.Left == (sender as PictureBox).Left)
                    {
                        select = Mlist[i].Pos;
                    }
                }
                doeZet(select);
            }
        }

        private void ControleerPic()
        {
            for (int i = 0; i < Mlist.Count; i++)
            {
                for (int u = 0; u < Mlist.Count; u++)
                {
                    if (i != u && Mlist[i].revealed && Mlist[u].revealed)
                    {
                        if (i != u && Mlist[u].nummer == Mlist[i].nummer)
                        {
                            Mlist[i].pb.Dispose();
                            Mlist[i].Weggevaagd = true;
                            Mlist[i].revealed = false;
                            Mlist[u].pb.Dispose();
                            Mlist[u].Weggevaagd = true;
                            Mlist[u].revealed = false;
                            Omgedraaid = 0;
                            string naamSpeler;
                            if (switchSpeler)
                                naamSpeler = speler1;
                            else
                                naamSpeler = speler2;
                            int score = spelers[naamSpeler];
                            score++;
                            spelers[naamSpeler] = score;
                            return;
                        }
                        Mlist[i].changePic();
                        Mlist[u].changePic();
                        Omgedraaid = 0;
                    }
                }
            }
        }

        private void ControleerSpeelVeld()
        {
            int klaar = 0;
            for (int i = 0; i < 16; i++)
            {
                if (Mlist[i].Weggevaagd) klaar++;
            }
            if (klaar == 14 && Omgedraaid==2)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (Mlist[i].revealed)
                    {
                        Mlist[i].pb.Dispose();
                        Mlist[i].revealed = false;
                    }
                }
                string bericht = "";
                int scoreSpeler1 = spelers[speler1];
                int scoreSpeler2 = spelers[speler2];
                if (scoreSpeler1 < scoreSpeler2)
                {
                    bericht = speler2 + " heeft gewonnen!" + Environment.NewLine +
                        "En helaas heeft " + speler1 + " Verloren!" + Environment.NewLine;
                }
                else if (scoreSpeler1 > scoreSpeler2)
                {
                    bericht = speler1 + " heeft gewonnen!" + Environment.NewLine +
                        "En helaas heeft " + speler2 + " Verloren!" + Environment.NewLine;
                }
                else if (scoreSpeler1 == scoreSpeler2)
                {
                    bericht = "Het is een gelijk spel!" + Environment.NewLine;
                }
                if (MessageBox.Show(bericht + "Wilt u nog een spel starten?","Einde Spel!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    f.newGame();
                }
                else
                {
                    f.Close();
                }
            }
        }

        private void Random()
        {
            for (int i = r.Next(0,15); i < 16; i++)
            {
                for (int u = r.Next(0, 15); u < 16; u++)
                {
                    if (i != u)
                    {
                        int temp = Mlist[u].nummer;
                        Mlist[u].nummer = Mlist[i].nummer;
                        Mlist[i].nummer = temp;
                    }
                }
            }
        }

        internal void voegSpelerToe(string spelerNaam,int score)
        {
            spelers.Add(spelerNaam,score);
            speler2 = spelerNaam;
        }
    }
}
