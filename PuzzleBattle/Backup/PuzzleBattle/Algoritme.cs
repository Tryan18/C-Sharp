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
using System.Collections;

namespace PuzzleBattle
{
    public class Algoritme
    {
        private Blok[,] veld;
        private Blok cursor;
        private Blok oldCursor;
        private int xPos;
        private int yPos;
        private int xOldPos;
        private int yOldPos;
        public List<Blok> scanList = new List<Blok>();
        private Random r = new Random();

        public Algoritme(Blok[,] velden,Blok cursor,Blok oldCursor,int x,int y,int xOld,int yOld)
        {
            veld = velden;
            this.cursor = cursor;
            this.oldCursor = oldCursor;
            xPos = x;
            yPos = y;
            xOldPos = xOld;
            yOldPos = yOld;
        }

        public void Scan()
        {
            scanList.Clear();
            scanList.Add(cursor);
            scanList.Add(oldCursor);
            scanPart(veld[xPos,yPos].veldtype, xPos, yPos,ref scanList);
            scanPart(veld[xOldPos, yOldPos].veldtype, xOldPos, yOldPos,ref scanList);
        }

        private void scanPart(FieldType veldtype, int xPos, int yPos,ref List<Blok> TempScanList)
        {
            #region X-bereik
            if (xPos - 1 >= 0 && xPos + 1 < 8 && veld[xPos, yPos].veldtype == veld[xPos - 1, yPos].veldtype && veld[xPos, yPos].veldtype == veld[xPos + 1, yPos].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos - 1, yPos]))
                {
                    TempScanList.Add(veld[xPos - 1, yPos]);
                    scanPart(veld[xPos - 1, yPos].veldtype, xPos - 1, yPos, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos + 1, yPos]))
                {
                    TempScanList.Add(veld[xPos + 1, yPos]);
                    scanPart(veld[xPos + 1, yPos].veldtype, xPos + 1, yPos, ref TempScanList);
                }
            }
            if (xPos+2 < 8 && veld[xPos, yPos].veldtype == veld[xPos + 1, yPos].veldtype && veld[xPos, yPos].veldtype == veld[xPos + 2, yPos].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos + 1, yPos]))
                {
                    TempScanList.Add(veld[xPos + 1, yPos]);
                    scanPart(veld[xPos + 1, yPos].veldtype, xPos + 1, yPos, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos + 2, yPos]))
                {
                    TempScanList.Add(veld[xPos + 2, yPos]);
                    scanPart(veld[xPos + 2, yPos].veldtype, xPos + 2, yPos, ref TempScanList);
                }
            }
            if (xPos - 2 >= 0 && veld[xPos, yPos].veldtype == veld[xPos - 1, yPos].veldtype && veld[xPos, yPos].veldtype == veld[xPos - 2, yPos].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos - 1, yPos]))
                {
                    TempScanList.Add(veld[xPos - 1, yPos]);
                    scanPart(veld[xPos - 1, yPos].veldtype, xPos - 1, yPos, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos - 2, yPos]))
                {
                    TempScanList.Add(veld[xPos - 2, yPos]);
                    scanPart(veld[xPos - 2, yPos].veldtype, xPos - 2, yPos, ref TempScanList);
                }
            }
            #endregion
            #region Y-bereik
            if (yPos - 1 >= 0 && yPos + 1 < 8 && veld[xPos, yPos].veldtype == veld[xPos, yPos - 1].veldtype && veld[xPos, yPos].veldtype == veld[xPos, yPos + 1].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos, yPos - 1]))
                {
                    TempScanList.Add(veld[xPos, yPos - 1]);
                    scanPart(veld[xPos, yPos - 1].veldtype, xPos, yPos - 1, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos, yPos + 1]))
                {
                    TempScanList.Add(veld[xPos, yPos + 1]);
                    scanPart(veld[xPos, yPos + 1].veldtype, xPos, yPos + 1, ref TempScanList);
                }
            }
            if (yPos + 2 < 8 && veld[xPos, yPos].veldtype == veld[xPos, yPos + 1].veldtype && veld[xPos, yPos].veldtype == veld[xPos, yPos + 2].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos, yPos + 1]))
                {
                    TempScanList.Add(veld[xPos, yPos + 1]);
                    scanPart(veld[xPos, yPos + 1].veldtype, xPos, yPos + 1, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos, yPos + 2]))
                {
                    TempScanList.Add(veld[xPos, yPos + 2]);
                    scanPart(veld[xPos, yPos + 2].veldtype, xPos, yPos + 2, ref TempScanList);
                }
            }
            if (yPos - 2 >= 0 && veld[xPos, yPos].veldtype == veld[xPos, yPos - 1].veldtype && veld[xPos, yPos].veldtype == veld[xPos, yPos - 2].veldtype)
            {
                if (!TempScanList.Contains(veld[xPos, yPos - 1]))
                {
                    TempScanList.Add(veld[xPos, yPos - 1]);
                    scanPart(veld[xPos, yPos - 1].veldtype, xPos, yPos - 1, ref TempScanList);
                }
                if (!TempScanList.Contains(veld[xPos, yPos - 2]))
                {
                    TempScanList.Add(veld[xPos, yPos - 2]);
                    scanPart(veld[xPos, yPos - 2].veldtype, xPos, yPos - 2, ref TempScanList);
                }
            }
            #endregion
        }
        
        public bool checkSwitch()
        {
            FieldType hulp = veld[xPos, yPos].veldtype;
            veld[xPos, yPos].veldtype = veld[xOldPos, yOldPos].veldtype;
            veld[xOldPos, yOldPos].veldtype = hulp;
            Scan();
            hulp = veld[xPos, yPos].veldtype;
            veld[xPos, yPos].setPlaatje(veld[xOldPos, yOldPos].veldtype);
            veld[xOldPos, yOldPos].setPlaatje(hulp);
            return true;
            if (scanList.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Switch()
        {
            veld[xOldPos, yOldPos].Animation();
            veld[xPos, yPos].Animation();
            FieldType hulp = veld[xPos, yPos].veldtype;
            veld[xPos, yPos].setPlaatje(veld[xOldPos, yOldPos].veldtype);
            veld[xOldPos, yOldPos].setPlaatje(hulp);
        }

        public void FakeSwitch()
        {
            veld[xOldPos, yOldPos].FakeAnimation();
            veld[xPos, yPos].FakeAnimation();
            System.Threading.Thread.Sleep(100);
        }

        public string[] checkCombos()
        {
            //combos[0] ,dit zijn het aantal 3 of a kind combos.
            //combos[1] ,dit zijn het aantal 4 of a kind combos.
            //combos[2] ,dit zijn het aantal 5 of a kind combos.
            string[] combos = new string[3];
            combos[0] = "";
            combos[1] = "";
            combos[2] = "";
            List<string> combolist = new List<string>();
            Hashtable ht = new Hashtable();
            for(int i=2;i<scanList.Count;i++)
            {
                combolist.Clear();
                combolist.Add(scanList[i].xPos.ToString() + "," + scanList[i].yPos.ToString()+ "," + scanList[i].veldtype.ToString());
                for(int j=2;j<scanList.Count;j++)
                {
                    if (i != j && int.Parse(combolist[0].Split(',')[0]) == scanList[j].xPos && combolist[0].Split(',')[2] == scanList[j].veldtype.ToString())
                    {
                        combolist.Add(scanList[j].xPos.ToString() + "," + scanList[j].yPos.ToString() + "," + scanList[j].veldtype.ToString());
                    }
                }
                if (combolist.Count >= 3)
                {
                    combolist.Sort();
                    string[] temp = new string[combolist.Count];
                    combolist.CopyTo(temp);
                    string key = "";
                    foreach (string s in temp)
                    {
                        key += s + "*";
                    }
                    if (!ht.ContainsKey(key)) ht.Add(key,temp);
                }
            }

            for (int i = 2; i < scanList.Count; i++)
            {
                combolist.Clear();
                combolist.Add(scanList[i].xPos.ToString() + "," + scanList[i].yPos.ToString() + "," + scanList[i].veldtype.ToString());
                for (int j = 2; j < scanList.Count; j++)
                {
                    if (i != j && int.Parse(combolist[0].Split(',')[1]) == scanList[j].yPos && combolist[0].Split(',')[2] == scanList[j].veldtype.ToString())
                    {
                        combolist.Add(scanList[j].xPos.ToString() + "," + scanList[i].yPos.ToString() + "," + scanList[j].veldtype.ToString());
                    }
                }
                if (combolist.Count >= 3)
                {
                    combolist.Sort();
                    string[] temp2 = new string[combolist.Count];
                    combolist.CopyTo(temp2);
                    string key = "";
                    foreach (string s in temp2)
                    {
                        key += s +"*";
                    }
                    if(!ht.ContainsKey(key)) ht.Add(key,temp2);
                }
            }
            foreach (string[] ss in ht.Values)
            {
                if (ss.Length == 3)
                {
                    combos[0] += ss[0].Split(',')[2] + ",";
                }
                else if (ss.Length == 4)
                {
                    combos[1] += ss[0].Split(',')[2] + ",";
                }
                else if (ss.Length == 5)
                {
                    combos[2] += ss[0].Split(',')[2] + ",";
                }
            }
            if (combos[0] != "") combos[0] = combos[0].Remove(combos[0].Length - 1);
            if (combos[1] != "") combos[1] = combos[1].Remove(combos[1].Length - 1);
            if (combos[2] != "") combos[2] = combos[2].Remove(combos[2].Length - 1);
            return combos;
        }

        public void DeleteBlocks(List<Blok> scanz)
        {
            List<Blok> nieuweScanList = MoveBlocks(scanz);

            List<Blok> hulp = new List<Blok>();
            foreach (Blok b in nieuweScanList)
            {
                hulp.Add(b);
            }
            foreach (Blok b in nieuweScanList)
            {
                scanPart(b.veldtype, b.xPos, b.yPos,ref hulp);
                if (hulp.Count >= 3) break;
            }
            if (hulp.Count != 0)
            {
                foreach (Blok b in hulp)
                {
                    //scanList.Clear();
                    scanList.Add(b);
                    //veld[b.xPos, b.yPos].veldtype = FieldType.fout;
                }
                MoveBlocks(hulp);
            }
            //System.Threading.Thread.Sleep(2000);
        }

        private void CreateNewBlocks()
        {
            foreach (Blok b in veld)
            {
                if (b.veldtype == FieldType.fout) //if statements voor restricties
                {
                    if (b.xPos != 0 && b.xPos != 7 && b.yPos != 0 && b.yPos != 7) //midden
                    {
                        FieldType[] ft = new FieldType[4];
                        ft[0] = veld[b.xPos + 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[2] = veld[b.xPos, b.yPos + 1].veldtype;
                        ft[3] = veld[b.xPos, b.yPos - 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1] || ft_temp == ft[2] || ft_temp == ft[3])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.yPos == 0 && b.xPos != 0 && b.xPos != 7) //midden boven
                    {
                        FieldType[] ft = new FieldType[3];
                        ft[0] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos + 1].veldtype;
                        ft[2] = veld[b.xPos + 1, b.yPos].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1] || ft_temp == ft[2])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.xPos == 0 && b.yPos != 0 && b.yPos != 7) //links midden
                    {
                        FieldType[] ft = new FieldType[3];
                        ft[0] = veld[b.xPos, b.yPos - 1].veldtype;
                        ft[1] = veld[b.xPos, b.yPos + 1].veldtype;
                        ft[2] = veld[b.xPos + 1, b.yPos].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1] || ft_temp == ft[2])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.xPos == 7 && b.yPos != 0 && b.yPos != 7) //rechts midden
                    {
                        FieldType[] ft = new FieldType[3];
                        ft[0] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos + 1].veldtype;
                        ft[2] = veld[b.xPos, b.yPos - 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1] || ft_temp == ft[2])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }                                      
                    else if (b.xPos == 0 && b.yPos == 0) //links boven
                    {
                        FieldType[] ft = new FieldType[2];
                        ft[0] = veld[b.xPos + 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos + 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.xPos == 7 && b.yPos == 0) //rechts boven
                    {
                        FieldType[] ft = new FieldType[2];
                        ft[0] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos + 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }                    
                    else if (b.xPos != 0 && b.xPos != 7 && b.yPos == 7) //midden onder
                    {
                        FieldType[] ft = new FieldType[3];
                        ft[0] = veld[b.xPos + 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[2] = veld[b.xPos, b.yPos - 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1] || ft_temp == ft[2])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.xPos == 0 && b.yPos == 7) //links onder
                    {
                        FieldType[] ft = new FieldType[2];
                        ft[0] = veld[b.xPos + 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos - 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                    else if (b.xPos == 7 && b.yPos == 7) //rechts onder
                    {
                        FieldType[] ft = new FieldType[2];
                        ft[0] = veld[b.xPos - 1, b.yPos].veldtype;
                        ft[1] = veld[b.xPos, b.yPos - 1].veldtype;
                        FieldType ft_temp = veld[b.xPos, b.yPos].veldtype;
                        while (ft_temp == FieldType.fout || ft_temp == ft[0] || ft_temp == ft[1])
                        {
                            ft_temp = (FieldType)r.Next(1, 9);
                        }
                        veld[b.xPos, b.yPos].setPlaatje(ft_temp);
                        //veld[b.xPos, b.yPos].FakeAnimation();
                    }
                }
            }
        }

        private List<Blok> MoveBlocks(List<Blok> scanz)
        {
            List<Blok> nieuwScanList = scanz;
            for (int w = 0; w < 2; w++)
            {
                for (int i = 7; i >= 0; i--)
                {
                    for (int j = 7; j >= 0; j--)
                    {
                        if (i != 0 && veld[j, i].veldtype == FieldType.fout && veld[j, i - 1].veldtype != FieldType.fout)
                        {
                            if (!nieuwScanList.Contains(veld[j, i - 1])) nieuwScanList.Add(veld[j, i - 1]);
                            veld[j, i].setPlaatje(veld[j, i - 1].veldtype);
                            //veld[j,i].FakeAnimation();
                            veld[j, i - 1].setPlaatje(FieldType.fout);
                        }
                        else if (i != 0 && veld[j, i].veldtype == FieldType.fout && veld[j, i - 1].veldtype == FieldType.fout)
                        {
                            int hulp = i - 1;
                            for (int k = i; hulp >= 0; k--)
                            {
                                if (!nieuwScanList.Contains(veld[j, k])) nieuwScanList.Add(veld[j, k]);
                                veld[j, k].setPlaatje(veld[j, hulp].veldtype);
                                veld[j, hulp].setPlaatje(FieldType.fout);
                                hulp--;
                            }
                        }
                    }
                }
            }
            CreateNewBlocks();
            return nieuwScanList;
        }
    }
}
