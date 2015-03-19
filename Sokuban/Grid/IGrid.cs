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
    public interface IGrid <T>
    {
        /// <summary>
        /// Voeg een element toe aan het grid
        /// </summary>
        /// <param name="element">Het toe te voegen element</param>
        /// <param name="p">De locatie van het element</param>
        void addElement(T element, IPoint p);

        /// <summary>
        /// Verwijderen een element doormiddel van een waarde of referentie
        /// </summary>
        /// <param name="element">Het te verwijderen element</param>
        void removeElement(T element);

        /// <summary>
        /// Verwijderen een element doormiddel van een locatie
        /// </summary>
        /// <param name="p">De locatie van het te verwijderen element</param>
        void removeElementAt(IPoint p);

        /// <summary>
        /// Kijk of een locatie beschikbaar is
        /// </summary>
        /// <param name="p">De locatie</param>
        bool isAvailable(IPoint p);

        /// <summary>
        /// Kijk of een locatie binnen het grid valt
        /// </summary>
        /// <param name="p">De locatie</param>
        bool isInBounds(IPoint p);

        /// <summary>
        /// Geeft het element op de ingevoerde locatie terug.
        /// </summary>
        /// <param name="p">De locatie van het element</param>
        T getElementAt(IPoint p);

        /// <summary>
        /// Geeft de posities van het element terug
        /// </summary>
        /// <param name="p">De locatie van het element</param>
        List<IPoint> getElementPositions(T element);

        /// <summary>
        /// Alle elementen op het grid
        /// </summary>
        List<T> elements { get; }

        /// <summary>
        /// Geeft op bepaald het aantal kolommen in het grid
        /// </summary>
        uint xSections { get; set; }

        /// <summary>
        /// Geeft op bepaald het aantal rijen in het grid
        /// </summary>
        uint ySections { get; set; }
    }
}
