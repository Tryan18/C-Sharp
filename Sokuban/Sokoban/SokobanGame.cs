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
using Grid;
using Sokoban.Utils;
using Sokoban.Events;
using System.IO;
using System.IO.Compression;
using System.Collections;

namespace Sokoban
{
    public class SokobanGame : ISokobanGame
    {
        private IGrid<SokobanType> m_walls;
        private IGrid<SokobanType> m_boxes;
        private IGrid<SokobanType> m_goals;

        private IPoint m_player;
        private Hashtable m_states;

        public SokobanGame()
        {
            m_walls = new Grid<SokobanType>();
            m_boxes = new Grid<SokobanType>();
            m_goals = new Grid<SokobanType>();
            m_player = new Point(-1, -1);
        }

        public bool loadGame(string loadPath)
        {
            FileInfo fileInfo = new FileInfo(loadPath);
            if (!fileInfo.Exists) return false;

            StreamReader reader = fileInfo.OpenText();

            //Lees ascii
            string data = reader.ReadToEnd();
            string size = data.Split('-')[0];
            string player = data.Split('-')[1];
            string[] walls = data.Split('-')[2].Split(' ');
            string[] boxes = data.Split('-')[3].Split(' ');
            string[] goals = data.Split('-')[4].Split(' ');

            //Leeg het veld
            clear();

            //Zet de breedte en hoogte
            width = UInt32.Parse(size.Split(',')[0]);
            height = UInt32.Parse(size.Split(',')[0]);

            //Plaats de speler
            m_player = new Point(Int32.Parse(player.Split(',')[0]), Int32.Parse(player.Split(',')[1]));

            //Plaats de muren
            for (int index = 0; index < walls.Length && walls[0] != ""; index++)
            {
                string wall = walls[index];
                IPoint p = new Point(Int32.Parse(wall.Split(',')[0]), Int32.Parse(wall.Split(',')[1]));
                m_walls.addElement(SokobanType.Wall, p);
            }

            //Plaats de dozen
            for (int index = 0; index < boxes.Length && boxes[0] != ""; index++)
            {
                string box = boxes[index];
                IPoint p = new Point(Int32.Parse(box.Split(',')[0]), Int32.Parse(box.Split(',')[1]));
                m_boxes.addElement(SokobanType.Box, p);
            }

            //Plaats de doelen
            for (int index = 0; index < goals.Length && goals[0] != ""; index++)
            {
                string goal = goals[index];
                IPoint p = new Point(Int32.Parse(goal.Split(',')[0]), Int32.Parse(goal.Split(',')[1]));
                m_goals.addElement(SokobanType.Goal, p);
            }

            return true;
        }

        public void saveGame(string savePath)
        {
            FileInfo fileInfo = new FileInfo(savePath);
            FileStream stream = fileInfo.Create();
            stream.Close();

            StreamWriter writer = fileInfo.AppendText();

            writer.Write(width + "," + height);

            writer.Write("-");

            //Schrijf de speler weg
            writer.Write(m_player.x + "," + m_player.y);

            List<IPoint> walls = m_walls.getElementPositions(SokobanType.Wall);
            List<IPoint> boxes = m_boxes.getElementPositions(SokobanType.Box);
            List<IPoint> goals = m_goals.getElementPositions(SokobanType.Goal);

            writer.Write("-");

            //Schrijf de muren weg
            for (int index = 0; index < walls.Count; index++)
            {
                if (index > 0) writer.Write(" ");
                IPoint p = walls[index];
                writer.Write(p.x + "," + p.y);
            }

            writer.Write("-");

            //Schrijf de dozen weg
            for (int index = 0; index < boxes.Count; index++)
            {
                if (index > 0) writer.Write(" ");
                IPoint p = boxes[index];
                writer.Write(p.x + "," + p.y);
            }

            writer.Write("-");

            //Schrijf de doelen weg
            for (int index = 0; index < goals.Count; index++)
            {
                if (index > 0) writer.Write(" ");
                IPoint p = goals[index];
                writer.Write(p.x + "," + p.y);
            }

            writer.Close();
        }

        public bool addSokobanObject(SokobanType type, IPoint position)
        {
            //Kijk of de plaats beschibkaar is
            if (m_walls.isAvailable(position) && m_goals.isAvailable(position) && m_boxes.isAvailable(position) && !(m_player.x == position.x && m_player.y == position.y))
            {
                if (type == SokobanType.Player)
                {
                    m_player = new Point(position.x, position.y);
                }
                else if (type == SokobanType.Wall)
                {
                    m_walls.addElement(type, position);
                }
                else if (type == SokobanType.Box)
                {
                    m_boxes.addElement(type, position);
                }
                else if (type == SokobanType.Goal)
                {
                    m_goals.addElement(type, position);
                }

                return true;
            }

            return false;
        }

        //Solve begin

        public List<SokobanDirection> solve()
        {
            //Verkrijg de huidige toestand (begin toestand)
            string startState = getState(m_boxes, m_player);

            //Maak een lege HashTable aan met een begin capaciteit voor 400.000 toestanden
            m_states = new Hashtable(400000);

            //Voeg de huidige toestand toe
            addState(startState);

            //Het aantal toestanden (Debug)
            int statesCount = 1;

            //De eerste 4 stappen die genomen gaan worden
            List<string> children = new List<string>();
            children.Add(startState + "-u");
            children.Add(startState + "-d");
            children.Add(startState + "-l");
            children.Add(startState + "-r");

            //Ga door alle paden die overgebleven zijn van de vorige cyclus
            for (int steps = 1; children.Count > 0; steps++)
            {
                //Zal de kinderen van de vorige cyclus gaan bevatten
                List<string> paths = new List<string>();

                //Voeg de kinderen toe
                for (int index = 0; index < children.Count; index++)
                {
                    paths.Add(children[index]);
                }

                //Debug
                Console.WriteLine("Stap: " + steps + " (paden: " + paths.Count + ", toestanden: " + statesCount + ")");

                //Leeg
                children.Clear();

                //Ga door alle paden
                for (int index = 0; index < paths.Count; index++)
                {
                    //Geef het grid de toestand van het huidige pad
                    applyState(paths[index].Split('-')[0]);

                    //String van richtingen
                    string path = paths[index].Split('-')[1];

                    //Verkrijg de laatste richting (De nu uit te voere stap)
                    char lastDirection = path[path.Length - 1];

                    //De positie van een mogelijk verplaatste doos
                    IPoint boxPosition = null;

                    //Verplaats de speler in de richting
                    if (movePlayer(charToDirection(lastDirection), m_boxes, out boxPosition))
                    {
                        //Kijk of het spel opgelost is
                        if (isSolved())
                        {
                            //Ga terug na de start situatie
                            m_states.Clear();
                            applyState(startState);
                            return stringToDirections(path);
                        }

                        //De huidige status in string vorm
                        string newState = getState(m_boxes, m_player);

                        //Zal aangeven of de mogelijk verplaatste doos vast zit
                        bool stuck = false;

                        //Als een doos verplaats is, controleer de doos
                        if (boxPosition != null)
                        {
                            stuck = isStuck(boxPosition);
                        }

                        //Kijk of de huidige toestand al bestaat
                        if (!containsState(newState) && !stuck)
                        {
                            //Voeg de huidige toestand toe
                            addState(newState);

                            //Debug
                            statesCount++;

                            //Maak 3 nieuwe kinderen aan
                            if (lastDirection != 'u' || boxPosition != null)
                            {
                                children.Add(newState + "-" + path + "d");
                            }

                            if (lastDirection != 'd' || boxPosition != null)
                            {
                                children.Add(newState + "-" + path + "u");
                            }

                            if (lastDirection != 'r' || boxPosition != null)
                            {
                                children.Add(newState + "-" + path + "l");
                            }

                            if (lastDirection != 'l' || boxPosition != null)
                            {
                                children.Add(newState + "-" + path + "r");
                            }
                        }
                    }
                }
            }

            //Ga terug na de start situatie
            m_states.Clear();
            applyState(startState);
            return new List<SokobanDirection>();
        }

        //Voeg een toestand toe aan de HashTable
        private void addState(string state)
        {
            m_states.Add(state, null);
        }

        //Kijkt of een toestand al bestaat
        private bool containsState(string state)
        {
            return m_states.ContainsKey(state);
        }

        //Geeft een lijst van SokobanDirection terug (resultaat van solve())
        private List<SokobanDirection> stringToDirections(string route)
        {
            List<SokobanDirection> result = new List<SokobanDirection>();

            for (int index = 0; index < route.Length; index++)
            {
                result.Add(charToDirection(route[index]));
            }

            return result;
        }

        //Zet een char om in een SokobanDirection type
        private SokobanDirection charToDirection(char direction)
        {
            if (direction == 'u')
            {
                return SokobanDirection.Up;
            }

            if (direction == 'd')
            {
                return SokobanDirection.Down;
            }

            if (direction == 'r')
            {
                return SokobanDirection.Right;
            }

            return SokobanDirection.Left;
        }

        //Verkrijgt de toestand string van de huidige situatie
        private string getState(IGrid<SokobanType> boxes, IPoint player)
        {
            string state = player.x + "," + player.y;
            List<IPoint> positions = boxes.getElementPositions(SokobanType.Box);

            for(int index = 0; index < positions.Count; index++)
            {
                state += " " + positions[index].x + "," + positions[index].y;
            }

            return state;
        }

        //Past de toestand string toe op het spel
        private void applyState(string state)
        {
            //Scheidt de elementen
            string[] elements = state.Split(' ');

            //Plaats de speler
            m_player.x = Int32.Parse(elements[0].Split(',')[0]);
            m_player.y = Int32.Parse(elements[0].Split(',')[1]);

            //Dozen grid
            m_boxes = new Grid<SokobanType>();
            m_boxes.xSections = m_walls.xSections;
            m_boxes.ySections = m_walls.ySections;

            //Plaats de dozen
            for (int index = 1; index < elements.Length; index++)
            {
                m_boxes.addElement(SokobanType.Box, new Point(Int32.Parse(elements[index].Split(',')[0]), Int32.Parse(elements[index].Split(',')[1])));
            }
        }

        //Kijkt of een doos nog te verplaatsen is
        private bool isStuck(IPoint boxPosition)
        {
            if (!m_goals.isAvailable(boxPosition))
            {
                return false;
            }

            //LT
            if (!isWalkable(new Point(boxPosition.x - 1, boxPosition.y)) && !isWalkable(new Point(boxPosition.x - 1, boxPosition.y - 1)) && !isWalkable(new Point(boxPosition.x, boxPosition.y - 1)))
            {
                return true;
            }

            //RT
            if (!isWalkable(new Point(boxPosition.x + 1, boxPosition.y)) && !isWalkable(new Point(boxPosition.x + 1, boxPosition.y - 1)) && !isWalkable(new Point(boxPosition.x, boxPosition.y - 1)))
            {
                return true;
            }

            //RB
            if (!isWalkable(new Point(boxPosition.x + 1, boxPosition.y)) && !isWalkable(new Point(boxPosition.x + 1, boxPosition.y + 1)) && !isWalkable(new Point(boxPosition.x, boxPosition.y + 1)))
            {
                return true;
            }

            //LB
            if (!isWalkable(new Point(boxPosition.x - 1, boxPosition.y)) && !isWalkable(new Point(boxPosition.x - 1, boxPosition.y -+1)) && !isWalkable(new Point(boxPosition.x, boxPosition.y + 1)))
            {
                return true;
            }

            return false;
        }

        //Geeft aan of een plek te belopen is
        private bool isWalkable(IPoint position)
        {
            return m_walls.isInBounds(position) && m_walls.isAvailable(position);
        }

        //Solve einde

        public bool isSolved()
        {
            List<IPoint> boxPositions = m_boxes.getElementPositions(SokobanType.Box);

            for (int index = 0; index < boxPositions.Count; index++)
            {
                if (m_goals.isAvailable(boxPositions[index]))
                {
                    return false;
                }
            }

            return true;
        }

        public void clear()
        {
            uint w = m_walls.xSections;
            uint h = m_walls.ySections;

            m_walls = new Grid<SokobanType>();
            m_walls.xSections = w;
            m_walls.ySections = h;
            m_boxes = new Grid<SokobanType>();
            m_boxes.xSections = w;
            m_boxes.ySections = h;
            m_goals = new Grid<SokobanType>();
            m_goals.xSections = w;
            m_goals.ySections = h;

            m_player = new Point(-1, -1);
        }

        public bool movePlayer(SokobanDirection direction)
        {
            IPoint boxPosition = null;

            if (movePlayer(direction, m_boxes, out boxPosition))
            {
                onMovePlayer(new SokobanEvent());

                if (isSolved())
                {
                    onSolve(new SokobanEvent());
                }

                return true;
            }

            return false;
        }

        public uint width
        {
            get
            {
                return m_walls.xSections;
            }

            set
            {
                m_walls.xSections = value;
                m_goals.xSections = value;
                m_boxes.xSections = value;
            }
        }

        public uint height
        {
            get
            {
                return m_walls.ySections;
            }

            set
            {
                m_walls.ySections = value;
                m_goals.ySections = value;
                m_boxes.ySections = value;
            }
        }

        public IGrid<SokobanType> grid
        {
            get
            {
                IGrid<SokobanType> result = new Grid<SokobanType>();
                result.xSections = m_walls.xSections;
                result.ySections = m_walls.ySections;

                for (int x = 0; x < m_walls.xSections; x++)
                {
                    for (int y = 0; y < m_walls.ySections; y++)
                    {
                        IPoint p = new Point(x, y);

                        if (!m_boxes.isAvailable(p))
                        {
                            if (!m_goals.isAvailable(p))
                            {
                                result.addElement(SokobanType.BoxGoal, p);
                            }
                            else
                            {
                                result.addElement(SokobanType.Box, p);
                            }
                        }
                        else if(!m_walls.isAvailable(p))
                        {
                            result.addElement(SokobanType.Wall, p);
                        }
                        else if (!m_goals.isAvailable(p))
                        {
                            if (m_player.x == x && m_player.y == y)
                            {
                                result.addElement(SokobanType.PlayerGoal, p);
                            }
                            else
                            {
                                result.addElement(SokobanType.Goal, p);
                            }
                        }
                        else if (m_player.x == x && m_player.y == y)
                        {
                            result.addElement(SokobanType.Player, p);
                        }
                    }
                }

                return result;
            }

            set
            {
                clear();
                width = value.xSections;
                height = value.ySections;

                for (int x = 0; x < value.xSections; x++)
                {
                    for (int y = 0; y < value.ySections; y++)
                    {
                        if (!value.isAvailable(new Point(x, y)))
                        {
                            SokobanType type = value.getElementAt(new Point(x, y));

                            switch (type)
                            {
                                case SokobanType.Box:
                                    m_boxes.addElement(SokobanType.Box, new Point(x, y));
                                    break;
                                case SokobanType.Goal:
                                    m_goals.addElement(SokobanType.Goal, new Point(x, y));
                                    break;
                                case SokobanType.Player:
                                    m_player = new Point(x, y);
                                    break;
                                case SokobanType.Wall:
                                    m_walls.addElement(SokobanType.Wall, new Point(x, y));
                                    break;
                                case SokobanType.BoxGoal:
                                    m_goals.addElement(SokobanType.Goal, new Point(x, y));
                                    m_boxes.addElement(SokobanType.Box, new Point(x, y));
                                    break;
                                case SokobanType.PlayerGoal:
                                    m_goals.addElement(SokobanType.Goal, new Point(x, y));
                                    m_player = new Point(x, y);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public event SokobanEvent.SokobanEventHandler onSolve;
        public event SokobanEvent.SokobanEventHandler onMovePlayer;

        static internal IPoint directionToPoint(SokobanDirection direction)
        {
            switch (direction)
            {

                case SokobanDirection.Up:
                    return new Point(0, -1);
                case SokobanDirection.Down:
                    return new Point(0, 1);
                case SokobanDirection.Left:
                    return new Point(-1, 0);
            }

            return new Point(1, 0);
        }

        private bool movePlayer(SokobanDirection direction, IGrid<SokobanType> boxes, out IPoint boxPosition)
        {
            IPoint translate = directionToPoint(direction);
            IPoint newPlayerPosition = new Point(m_player.x + translate.x, m_player.y + translate.y);
            IPoint newBoxPosition = new Point(newPlayerPosition.x + translate.x, newPlayerPosition.y + translate.y);

            boxPosition = null;

            //Kijk of er geen muren aanwezig zijn
            if (m_walls.isInBounds(newPlayerPosition) && m_walls.isAvailable(newPlayerPosition))
            {
                //Kijk of er geen dozen aanwezig zijn
                if (boxes.isAvailable(newPlayerPosition))
                {
                    m_player = newPlayerPosition;
                    return true;
                }
                else if (boxes.isInBounds(newBoxPosition) && boxes.isAvailable(newBoxPosition) && m_walls.isAvailable(newBoxPosition))
                {
                    m_player = newPlayerPosition;
                    boxes.removeElementAt(newPlayerPosition);
                    boxes.addElement(SokobanType.Box, newBoxPosition);

                    //Geef de nieuwe positie van de doos mee terug
                    boxPosition = new Point(newBoxPosition.x, newBoxPosition.y);

                    return true;
                }
            }

            return false;
        }
    }
}
