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

namespace Grid
{
    public class Grid<T> : IGrid<T>
    {
        private uint m_xSections = 0;
        private uint m_ySections = 0;

        private List<Container<T>> m_containers;


        public Grid()
        {
            m_containers = new List<Container<T>>();
        }

        public void addElement(T element, IPoint p)
        {
            if (isAvailable(p))
            {
                m_containers[locationToIndex(p)].value = element;
            }
            else
            {
                throw new Exception("addElement.location.invalid");
            }
        }

        public void removeElement(T element)
        {
            for (int index = 0; index < m_containers.Count; index++)
            {
                if(m_containers[index].contains(element))
                {
                    m_containers[index].clear();
                }
            }
        }

        public void removeElementAt(IPoint p)
        {
            if (!isAvailable(p))
            {
                m_containers[locationToIndex(p)].clear();
            } 
            else
            {
                throw new Exception("removeElementAt.location.invalid");
            }
        }

        public bool isAvailable(IPoint p)
        {
            if (isInBounds(p))
            {
                return !m_containers[locationToIndex(p)].isFilled();
            }

            throw new Exception("isAvailable.location.outOfBounds");
        }

        public bool isInBounds(IPoint p)
        {
            return p.x >= 0 && p.x < m_xSections && p.y >= 0 && p.y < m_ySections;
        }

        public T getElementAt(IPoint p)
        {
            Container<T> container = getContainerAt(p);

            //Kijk of de Container gevuld is
            if (container.isFilled())
            {
                return container.value;
            }

            throw new Exception("getElementAt.location.invalid");
        }

        public List<IPoint> getElementPositions(T element)
        {
            List<IPoint> positions = new List<IPoint>();

            for (int index = 0; index < m_containers.Count; index++)
            {
                if (m_containers[index].contains(element))
                {
                    positions.Add(indexToLocation(index));
                }
            }

            return positions;
        }

        public List<T> elements
        {
            get
            {
                //Resultaat
                List<T> result = new List<T>();

                //Ga door alle containers
                for (int index = 0; index < m_containers.Count; index++)
                {
                    //Kijk of de container een element bevat
                    if (m_containers[index].isFilled())
                    {
                        //Voeg element toe aan het resultaat
                        result.Add(m_containers[index].value);
                    }
                }

                return result;
            }
        }

        public uint xSections
        {
            get
            {
                return m_xSections;
            }

            set
            {
                resize(value, ySections);
            }
        }

        public uint ySections
        {
            get
            {
                return m_ySections;
            }

            set
            {
                resize(xSections, value);
            }
        }

        private void resize(uint width, uint height)
        {
            //Zal de posities en waardes van alle elementen bevatten
            List<IPoint> locations = new List<IPoint>();
            List<T> values = new List<T>();

            //Ga door alle containers en voeg element posities en waardes toe
            for (int index = 0; index < m_containers.Count; index++)
            {
                //Kijk of de container een element bevat
                if (m_containers[index].isFilled())
                {
                    //Voeg element toe
                    values.Add(m_containers[index].value);

                    //Voeg positie toe
                    locations.Add(indexToLocation(index));
                }
            }

            //Zet nieuwe dimensies
            m_xSections = width;
            m_ySections = height;

            //Instantieer
            m_containers = new List<Container<T>>();

            //Vul
            for (int index = 0; index < width * height; index++)
            {
                //Voeg een lege container toe
                m_containers.Add(new Container<T>());
            }

            //Ga door alle locaties en kijk of deze binnen het Grid vallen
            for (int index = 0; index < locations.Count; index++)
            {
                //Huidige locatie
                IPoint p = locations[index];

                //Kijk of de locatie in het nieuwe grid valt
                if (isInBounds(p))
                {
                    //Veranderd de index
                    getContainerAt(p).value = values[index];   
                }
            }
        }

        //Geeft een container terug op de positie p
        private Container<T> getContainerAt(IPoint p)
        {
            return m_containers[locationToIndex(p)];
        }

        //Geeft een index terug die gelijk is aan de positie
        private int locationToIndex(IPoint p)
        {
            return (int)(m_xSections * p.y + p.x);
        }

        //Geeft een positie terug die gelijk is aan de index
        private Point indexToLocation(int index)
        {
            return new Point((int)(index % m_xSections), (int)(index / m_xSections));
        }
    }

    class Container<T>
    {
        private T m_value;
        private bool m_isFilled;

        public Container()
        {

        }

        //Leeg de container
        public void clear()
        {
            m_isFilled = false;
        }

        //Geeft aan of de container een bepaald element bevat
        public bool contains(T element)
        {
            return m_isFilled && element.Equals(m_value);
        }

        //Geeft aan of de container gevuld is
        public bool isFilled()
        {
            return m_isFilled;
        }

        //Geeft de waarde terug. Of zet de waarde
        public T value
        {
            get
            {
                return m_value;
            }

            set
            {
                m_value = value;
                m_isFilled = true;
            }
        }
    }
}
