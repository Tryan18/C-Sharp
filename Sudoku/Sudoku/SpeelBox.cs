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

namespace Sudoku
{
    public class SpeelBox
    {
        private Form1 F;
        private InvoerNummer IN;
        public blokje[,] blok;
        private Random r;
        public blokje SelectedBlok;
        public Boolean BigSudoku;
        private int speelveldgroote;
        //index 0 is aantal selecteerde cijfers
        //index 1 is aantal goede cijfers
        public int[] punten;

        public SpeelBox(object sender, int z,Boolean LoadGame)
        {
            punten = new int[2];
            punten[0] = 0;
            punten[1] = 0;
            if (z == 9) BigSudoku = false;
            else BigSudoku = true;
            F = (sender as Form1);
            F.pb1.Value = 0;
            blok = new blokje[z, z];
            speelveldgroote = z;
            r = new Random();
            int nummer = 0;
            int x = 0;
            int y = 0;
            for (int i = 0; i < z; i++)
            {
                for (int a = 0; a < z; a++)
                {
                    blok[i, a] = new blokje(x, y, 999, nummer, sender);
                    blok[i, a].pb.Image = F.images[0, 0];
                    blok[i, a].pb.MouseClick += new MouseEventHandler(pb_MouseClick);
                    nummer++;
                    x += 30;
                    if ((a + 1) % 4 == 0 && z==16) x += 4;
                    if ((a + 1) % 3 == 0 && z==9) x += 4;
                }
                nummer = 1;
                y += 30;
                x = 0;
                if ((i + 1) % 4 == 0 && z==16) y += 4;
                if ((i + 1) % 3 == 0 && z==9) y += 4;
            }
            if (!LoadGame)
            {
                FillSpeelbox();
                //VullAlleGetallen();
                VullRandomGetallen();
            }
        }

        private void VullAlleGetallen()
        {
            foreach (blokje bl in blok)
            {
                ChangeImage2(bl,bl.plaats);
            }
        }

        public void VullRandomGetallen()
        {
            int max = speelveldgroote;
            List<int> checklist = new List<int>();
            Boolean klaar = false;
            while (!klaar)
            {
                int random1 = r.Next(0,max);
                int random2 = r.Next(0,max);
                if (!checklist.Contains((random1 * 100) + random2))
                {
                    checklist.Add((random1 * 100) + random2);
                    ChangeImage2(blok[random1, random2], blok[random1, random2].plaats);
                }
                if (checklist.Count == F.AGG.Value) klaar = true;
            }
            F.label1.Visible = false;
            F.pb1.Visible = false;
        }

        public void ClearVeld()
        {
            foreach (blokje blokk in blok)
            {
                blokk.pb.Dispose();
            }
        }

        void pb_MouseClick(object sender, MouseEventArgs e)
        {
            foreach(blokje bl in blok)
            {
                if (bl.pb.Top == (sender as PictureBox).Top && bl.pb.Left == (sender as PictureBox).Left)
                {
                    if (bl.compSelect) return;
                    SelectedBlok = bl;
                }
            }
            if (IN != null) IN.Dispose();
            IN = new InvoerNummer(this, BigSudoku);
            IN.Show();
        }

        public void controle()
        {
            foreach (blokje bl in blok)
            {
                if (!bl.compSelect && !bl.userSelect)
                {
                    return;
                }
            }
            F.controleer.Visible = true;
            F.controleer.Refresh();
        }

        public void ChangeImage(int getal)
        {//red
            SelectedBlok.pb.Image = F.images[1, getal];
            if (!SelectedBlok.userSelect) punten[0]++;
            SelectedBlok.userSelect = true;
            SelectedBlok.nummer = getal;
            controle();
        }

        public void ChangeImage2(blokje bl, int getal)
        {//black
            bl.pb.Image = F.images[0, getal];
            bl.compSelect = true;
        }

        public void ChangeImage3()
        {//green
            foreach (blokje bl in blok)
            {
                if (bl.userSelect && bl.nummer == bl.plaats)
                {
                    bl.pb.Image = F.images[2, bl.plaats];
                    punten[1]++;
                }
            }
        }

        public void LoadImages(blokje[,] temp)
        {//herstel alle plaatjes

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int a=0; a < temp.GetLength(0); a++)
                {
                    blok[i, a].nummer = temp[i, a].nummer;
                    blok[i, a].plaats = temp[i, a].plaats;
                    blok[i, a].userSelect = temp[i, a].userSelect;
                    blok[i, a].compSelect = temp[i, a].compSelect;
                }
            }

            foreach (blokje bl in blok)
            {
                if (bl.nummer == 999 && !bl.compSelect) bl.pb.Image = F.images[0, 0];
                else if (bl.userSelect && !bl.compSelect) bl.pb.Image = F.images[1, bl.nummer];
                else if (bl.compSelect) bl.pb.Image = F.images[0, bl.plaats];
            }
        }

        //132 max weergeven in heel speelbox.
        //10 max in sector en min 4.
        private void FillSpeelbox()
        {
            int max = speelveldgroote;
            int getal = r.Next(1, max+1);
            
            List<int> rij = new List<int>();
            List<int>[] sector = new List<int>[max];
            List<int>[] kolom = new List<int>[max];
            List<int>[] hulplist = new List<int>[max];

            for (int k = 0; k < max; k++)
            {
                kolom[k] = new List<int>();
                hulplist[k] = new List<int>();
                sector[k] = new List<int>();
            }

            Boolean hulp=true;
            int index = 0;
            while(hulp)
            {
                if (rij.Count == max) hulp = false;
                if (!rij.Contains(getal))
                {
                    if (index < 3) sector[0].Add(getal);
                    else if (index >= 3 && index < 6) sector[1].Add(getal);
                    else if (index >= 6) sector[2].Add(getal);
                        
                    kolom[index].Add(getal);
                    rij.Add(getal);
                    index++;
                }
                getal = r.Next(1, max+1);
            }
            F.pb1.Value++;
            int sectorindex = 0;
            for(int q=0;q<max;q++)
            {
                index = 0;
                foreach (int rii in rij)
                {
                    hulplist[q].Add(rii);
                }
                if (hulplist[max - 1].Count == max) { }
                else
                {
                    ShuffleRij(rij, kolom, sector,sectorindex);

                    foreach (int ri in rij)
                    {
                        if (index < 3) sector[sectorindex].Add(ri);
                        else if (index >= 3 && index < 6) sector[sectorindex+1].Add(ri);
                        else if (index >= 6) sector[sectorindex+2].Add(ri);
                        kolom[index].Add(ri);
                        index++;
                    }
                    if (kolom[0].Count % 3 == 0) sectorindex += 3;
                }
                F.pb1.Value++;
            }
            for (int i = 0; i < max; i++)
            {
                for (int a = 0; a < max; a++)
                {
                    blok[i, a].plaats = hulplist[i][a];
                }
            }
        }

        private List<int> ShuffleRij(List<int> rij2, List<int>[] kolom,List<int>[] sector,int sectorindex)
        {//methode is goed ,nu alleen sectoren nog
            int max = speelveldgroote;
            List<int> goed = new List<int>();
            Boolean[] hulp = new Boolean[4];
            hulp[0] = true;
            hulp[3] = false;

            while (hulp[0])
            {
                int wissel1 = r.Next(0,max);
                int wissel2 = r.Next(0,max);
                hulp[1] = true;
                hulp[2] = true;
                //if (rij2.Count == max) return rij2;
                while (hulp[1])
                {
                    if (!goed.Contains(wissel1) || hulp[3] && wissel1 !=0)
                    {
                        hulp[1] = false;
                    }
                    else wissel1 = r.Next(0, max);
                }
                while (hulp[2])
                {
                    if (!goed.Contains(wissel2) || hulp[3] && wissel2 != 0)
                    {
                        if (wissel1 == wissel2) wissel2 = r.Next(0, max);
                        else
                        {
                            hulp[2] = false;
                        }
                    }
                    else wissel2 = r.Next(0, max);
                }
                int hulpgetal = rij2[wissel1];
                rij2[wissel1] = rij2[wissel2];
                rij2[wissel2] = hulpgetal;
                goed.Clear();
                hulp[3] = false;
                int hulpindex=0;
                for (int u = 0; u < rij2.Count; u++)
                {
                    if(u%3==0 && u!=0) hulpindex++;
                    if (!kolom[0].Contains(rij2[u])) hulp[3] = true;
                    if (!kolom[u].Contains(rij2[u]) && !sector[hulpindex+sectorindex].Contains(rij2[u])) goed.Add(rij2[u]);

                }
                if(goed.Count == rij2.Count) hulp[0] = false;
            }
            return rij2;
        }

        private void FillSpeelbox2()
        {
            int max = speelveldgroote;
            int getal = r.Next(1, max+1);
            int sectorindex = 0;
            int si;
            if (max == 16) si = 4;
            else si = 3;

            Boolean klaar = false;
            List<int> rij = new List<int>();
            List<int>[] sector = new List<int>[max];
            List<int>[] kolom = new List<int>[max];
            List<int>[] hulplist = new List<int>[max];

            for(int b=0;b<max;b++)
            {
                sector[b] = new List<int>();
                kolom[b] = new List<int>();
                hulplist[b] = new List<int>();
            }

             for (int i = 0; i < max; i++)
             {
                 if (i % si == 0 && i != 0) sectorindex += 3;
                 rij.Clear();
                 for (int a = 0; a < max; a++)
                 {
                     klaar=false;
                     while (!klaar)
                     {
                         getal = r.Next(1, max + 1);
                         if (a < si)
                         {
                             if (!kolom[a].Contains(getal) && !rij.Contains(getal) && !sector[sectorindex+0].Contains(getal))
                             {
                                 hulplist[i].Add(getal);
                                 rij.Add(getal);
                                 kolom[a].Add(getal);
                                 sector[sectorindex + 0].Add(getal);
                                 klaar = true;
                             }
                         }
                         else if (a >= si && a < (si + si))
                         {
                             if (!kolom[a].Contains(getal) && !rij.Contains(getal) && !sector[sectorindex + 1].Contains(getal))
                             {
                                 hulplist[i].Add(getal);
                                 rij.Add(getal);
                                 kolom[a].Add(getal);
                                 sector[sectorindex + 1].Add(getal);
                                 klaar = true;
                             }
                         }
                         else if (a >= (si + si))
                         {
                             if (!kolom[a].Contains(getal) && !rij.Contains(getal) && !sector[sectorindex + 2].Contains(getal))
                             {
                                 hulplist[i].Add(getal);
                                 rij.Add(getal);
                                 kolom[a].Add(getal);
                                 sector[sectorindex + 2].Add(getal);
                                 klaar = true;
                             }
                         }
                     }
                 }
             }

             for (int i = 0; i < max; i++)
             {
                 for (int a = 0; a < max; a++)
                 {
                     blok[i, a].plaats = hulplist[i][a];
                 }
             }
        }
    }
}
