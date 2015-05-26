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

namespace PuzzleBattle
{
    public partial class BattleField : Form
    {
        private Algoritme Alg;
        private Blok[,] veld;
        public Blok cursor;
        public Blok oldCursor;
        private int xPos = 0;
        private int yPos = 0;
        private int xOldPos = 0;
        private int yOldPos = 0;
        private Random r = new Random();
        private bool selected = false;
        private Timer t = new Timer();
        private Timer tt = new Timer();

        public BattleField()
        {
            InitializeComponent();
            CreateControls();
            CreateGameField();
        }

        private void CreateControls()
        {
            cursor = new Blok(this, 0, 0, 20, FieldType.cursor, 0, 0);
            oldCursor = new Blok(this, 0, 0, 20, FieldType.oldcursor, 0, 0);
            oldCursor.pb.Visible = false;

            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            T_controls.Focus();
        }

        private void CreateGameField()
        {
            veld = new Blok[8, 8];
            int x = 6;
            int y = 10;
            int groote = 50;

            for (int i = 0; i < veld.GetLength(0); i++)
            {
                for (int j = 0; j < veld.GetLength(1); j++)
                {
                    veld[j, i] = new Blok(this, x, y, groote, (FieldType)r.Next(1, 8), j, i);
                    if (j != 0 || j != 7 && veld[j + 1, i] != null)
                    {
                        while (veld[j - 1, i].veldtype == veld[j, i].veldtype)
                        {
                            veld[j, i].setPlaatje((FieldType)r.Next(1, 8));
                        }
                    }
                    if (i != 0 || i != 7 && veld[j, i + 1] != null)
                    {
                        while (veld[j, i - 1].veldtype == veld[j, i].veldtype)
                        {
                            veld[j, i].setPlaatje((FieldType)r.Next(1, 8));
                        }
                    }
                    x += groote;
                }
                x = 6;
                y += groote;
            }
            setCursor();
        }

        private void setCursor()
        {
            veld[xPos, yPos].setCursor(cursor);
            cursor.xPos = xPos;
            cursor.yPos = yPos;
            Refresh();
        }

        private void setOldCursor()
        {
            if (!selected)
            {
                oldCursor.setPlaatje(FieldType.oldcursor);
                oldCursor.pb.Visible = true;
                veld[xPos, yPos].setCursor(oldCursor);
                xOldPos = xPos;
                yOldPos = yPos;
                oldCursor.xPos = xPos;
                oldCursor.yPos = yPos;
            }
            else
            {
                if (checkControle())
                {
                    Alg = new Algoritme(veld, cursor, oldCursor, xPos, yPos, xOldPos, yOldPos);
                    if (Alg.checkSwitch())
                    {
                        Alg.Switch();
                    }
                    else
                    {
                        Alg.FakeSwitch();
                    }
                    foreach (Blok b in Alg.scanList)
                    {
                        b.setPlaatje(FieldType.fout);
                        //b.pb.Image = b.overige[2];
                    }
                    Alg.DeleteBlocks(new List<Blok>());
                    debug();
                    oldCursor.pb.Visible = false;
                }
                else
                {
                    oldCursor.setPlaatje(FieldType.fout);
                    t.Start();
                }
            }
            selected = !selected;
            Refresh();
        }

        private void debug()
        {
            string[] combos = Alg.checkCombos();
            if(L_3.Text.Length != 15) L_3.Text = L_3.Text.Remove(15);
            L_3.Text += combos[0].ToString();
            if (L_4.Text.Length != 15) L_4.Text = L_4.Text.Remove(15);
            L_4.Text += combos[1].ToString();
            if (L_5.Text.Length != 15) L_5.Text = L_5.Text.Remove(15);
            L_5.Text += combos[2].ToString();

        //    tt.Interval = 500;
        //    tt.Tick += new EventHandler(tt_Tick);
        //    //tt.Start();
        }

        //void tt_Tick(object sender, EventArgs e)
        //{
        //    foreach (Blok b in Alg.scanList)
        //    {
        //        b.setPlaatje(b.veldtype);
        //    }
        //    tt.Stop();
        //}

        void t_Tick(object sender, EventArgs e)
        {
            oldCursor.pb.Visible = false;
            t.Stop();
        }

        private void T_controls_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (xPos > 0)
                    {
                        xPos--;
                        setCursor();
                    }
                    break;
                case Keys.Right:
                    if (xPos < (veld.GetLength(0) - 1))
                    {
                        xPos++;
                        setCursor();
                    }
                    break;
                case Keys.Up:
                    if (yPos > 0)
                    {
                        yPos--;
                        setCursor();
                    }
                    break;
                case Keys.Down:
                    if (yPos < (veld.GetLength(1) - 1))
                    {
                        yPos++;
                        setCursor();
                    }
                    break;
                case Keys.Space:
                    setOldCursor();
                    break;
            }
        }

        private bool checkControle()
        {
            if (xPos == (xOldPos) - 1 && yPos == yOldPos || xPos == xOldPos + 1 && yPos == yOldPos ||
                yPos == (yOldPos) - 1 && xPos == xOldPos || yPos == (yOldPos) + 1 && xPos == xOldPos)
            {
                return true;
            }
            else return false;
        }
    }
        public enum FieldType : int
        {
            green = 1,
            red,
            yellow,
            blue,
            skull,
            money,
            star,
            wildcard,
            cursor,
            oldcursor,
            fout
        }
    
}
