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

using Sokoban;
using Sokoban.Utils;
using Sokoban.Events;

using Grid;
using System.IO;

namespace Implementatie
{
    public class Implementatie
    {

        private ISokobanGame m_sokoban;
        private List<SokobanDirection> m_solution;

        public Implementatie()
        {
            Console.WindowWidth = 70;
            Console.WindowHeight = 50;

            m_sokoban = new SokobanGame();
            m_sokoban.onSolve += new SokobanEvent.SokobanEventHandler(m_sokoban_onSolve);
            m_sokoban.onMovePlayer += new SokobanEvent.SokobanEventHandler(m_player_onMove);

            start();
        }

        private void start()
        {
            Console.Clear();
            Console.WriteLine("w,a,s,d = bewegen");
            Console.WriteLine("o = oplossing zoeken");
            Console.WriteLine("b,l = bewaren en laden");
            Console.WriteLine("r = reset");
            Console.WriteLine("enter = beginnen");
            Console.ReadLine();

                            // 1   2   3   4   5   6   7   8   9  10   11  12  13 14  15  16   17
            char[,] level = {
                             {'w','w','w','w','w','w','w','w','x','w','w','w','x','x','x','x', 'x'}, /* 1 */
                             {'w','x','x','w','x','x','x','w','x','x','w','w','x','x','x','x', 'x'}, /* 2 */
                             {'w','x','x','x','b','x','x','w','x','w','w','w','x','x','x','x', 'x'}, /* 3 */
                             {'w','x','b','w','w','x','w','w','w','w','w','w','w','w','x','x', 'x'}, /* 4 */
                             {'w','w','x','w','g','x','w','w','x','x','w','w','x','w','x','x', 'x'}, /* 5 */
                             {'w','w','x','w','g','x','x','x','b','x','w','w','x','w','x','x', 'x'}, /* 6 */
                             {'w','w','x','w','g','x','w','w','x','x','w','w','x','w','w','w', 'w'}, /* 7 */
                             {'w','w','x','w','g','w','w','w','x','w','w','w','x','x','x','x', 'w'}, /* 8 */
                             {'w','w','p','x','x','x','w','w','x','x','w','w','w','x','x','x', 'w'}, /* 9 */
                             {'w','w','w','x','b','x','x','x','x','x','w','w','w','x','w','w', 'w'}, /* 10 */
                             {'w','w','w','w','w','w','w','w','x','x','w','w','x','x','w','x', 'x'}, /* 11 */
                             {'w','w','w','w','w','w','w','w','w','w','w','w','w','w','w','x', 'x'}, /* 12 */
                             {'w','w','w','w','w','w','w','w','w','w','w','w','x','x','x','x', 'x'}, /* 13 */
                             {'w','w','w','w','w','w','w','w','w','w','w','w','x','x','x','x', 'x'}, /* 14 */
                             {'w','w','w','w','w','w','w','w','w','w','w','w','x','x','x','x', 'x'}, /* 15 */
                             {'w','w','w','w','w','w','w','w','w','w','w','w','x','x','x','x', 'x'}  /* 16 */
                             };

            from2dArray(level);

            draw();
            waitForInput();
        }

        private void m_sokoban_onSolve(SokobanEvent sokobanEvent)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("HOEHOEHOE!");
            Console.ReadKey();
        }

        private void m_player_onMove(SokobanEvent sokobanEvent)
        {
            draw();
        }

        //Verwerk de invoer
        private void waitForInput()
        {
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case 'w':
                    m_sokoban.movePlayer(SokobanDirection.Up);
                    break;
                case 'a':
                    m_sokoban.movePlayer(SokobanDirection.Left);
                    break;
                case 'd':
                    m_sokoban.movePlayer(SokobanDirection.Right);
                    break;
                case 's':
                    m_sokoban.movePlayer(SokobanDirection.Down);
                    break;
                case 'o':
                    solve();
                    break;
                case 'n':
                    showNextStep();
                    break;
                case 'b':
                    save();
                    break;
                case 'l':
                    load();
                    break;
                case 'r':
                    start();
                    break;
            }

            waitForInput();
        }

        //Spel opslaan
        private void save()
        {
            Console.Clear();
            Console.WriteLine("Voer de locatie in");
            string path = Console.ReadLine();
            m_sokoban.saveGame(path);
            draw();
        }

        //Spel laden
        private void load()
        {
            Console.Clear();
            Console.WriteLine("Voer de locatie in");
            string path = Console.ReadLine();

            if (m_sokoban.loadGame(path))
            {
                draw();
            }
            else
            {
                Console.WriteLine("Bestand niet gevonden");
                Console.ReadLine();
                start();
            }
        }

        //Maak een Sokoban speelveld doormiddel van een 2d Array
        private void from2dArray(char [,] level)
        {
            IGrid<SokobanType> grid = new Grid<SokobanType>();
            grid.xSections = (uint)level.GetLength(1);
            grid.ySections = (uint)level.GetLength(0);

            for (int y = 0; y < level.GetLength(0); y++)
            {
                for (int x = 0; x < level.GetLength(1); x++)
                {
                    char c = level[y, x];

                    switch (c)
                    {
                        case 'w':
                            grid.addElement(SokobanType.Wall, new Point(x, y));
                            break;
                        case 'b':
                            grid.addElement(SokobanType.Box, new Point(x, y));
                            break;
                        case 'g':
                            grid.addElement(SokobanType.Goal, new Point(x, y));
                            break;
                        case 'f':
                            grid.addElement(SokobanType.BoxGoal, new Point(x, y));
                            break;
                        case 'o':
                            grid.addElement(SokobanType.PlayerGoal, new Point(x, y));
                            break;
                        case 'p':
                            grid.addElement(SokobanType.Player, new Point(x, y));
                            break;
                    }
                }
            }

            m_sokoban.grid = grid;
        }

        //Los de puzzel op
        private void solve()
        {
            Console.Clear();
            Console.WriteLine("Oplossing zoeken...");
            List<SokobanDirection> route = m_sokoban.solve();

            if (route.Count > 0)
            {
                Console.WriteLine("Oplossing gevonden");
                Console.WriteLine("Druk op de 'n' om de oplossing per stap te laten zien");

                m_solution = route;
            }
            else
            {
                Console.WriteLine("Geen oplossing gevonden");
            }
        }

        //Laat de volgende stap zien in de oplossing
        private void showNextStep()
        {
            if (m_solution != null && m_solution.Count > 0)
            {
                m_sokoban.movePlayer(m_solution[0]);
                m_solution.RemoveAt(0);
            }
        }

        //Teken het speelveld
        private void draw()
        {
            Console.Clear();

            IGrid<SokobanType> grid = m_sokoban.grid;

            for (int y = 0; y < grid.ySections; y++)
            {
                for (int x = 0; x < grid.xSections; x++)
                {
                    if (!grid.isAvailable(new Point(x, y)))
                    {
                        SokobanType type = grid.getElementAt(new Point(x, y));

                        switch (type)
                        {
                            case SokobanType.Wall:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("w");
                                break;
                            case SokobanType.Goal:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("g");
                                break;
                            case SokobanType.Box:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("b");
                                break;
                            case SokobanType.BoxGoal:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("b");
                                break;
                            case SokobanType.Player:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("p");
                                break;
                            case SokobanType.PlayerGoal:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("p");
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("x");
                    }

                    Console.Write("  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
