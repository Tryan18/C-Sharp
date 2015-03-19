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
using Sokoban;
using Sokoban.Utils;
using Sokoban.Events;

namespace Sokoban
{
    public interface ISokobanGame
    {
        /// <summary>
        /// Laadt een spel
        /// </summary>
        /// <param name="loadPath">De locatie van het bestand</param>
        bool loadGame(string loadPath);

        /// <summary>
        /// Sla het huidige spel op
        /// </summary>
        /// <param name="savePath">De locatie van het (nieuwe) bestand</param>
        void saveGame(string savePath);

        /// <summary>
        /// Plaats een SokobanType op het veld
        /// </summary>
        /// <param name="type">Het SokobanType</param>
        /// <param name="position">De positie van het SokobanType</param>
        bool addSokobanObject(SokobanType type, IPoint position);

        /// <summary>
        /// Verplaats de speler in een richting en geef aan of dit gelukt is.
        /// </summary>
        /// <param name="direction">De richting</param>
        bool movePlayer(SokobanDirection direction);

        /// <summary>
        /// Geef een grid terug van het type IGrid met daarop alle SokobanTypen terug.
        /// Of bepaal de situatie van het veld door een grid van het type IGrid mee
        /// te geven.
        /// </summary>
        IGrid<SokobanType> grid { get; set; }

        /// <summary>
        /// Los de puzzel op en geef een lijst van richtingen terug die de gemaakte
        /// stappen aangeven.
        /// </summary>
        List<SokobanDirection> solve();

        /// <summary>
        /// Geeft aan of de puzzel opgelost is
        /// </summary>
        bool isSolved();

        /// <summary>
        /// Leeg het veld
        /// </summary>
        void clear();

        /// <summary>
        /// Geeft of zet de breedte van de puzzel
        /// </summary>
        uint width { get; set; }

        /// <summary>
        /// Geeft of zet de hoogte van de puzzel
        /// </summary>
        uint height { get; set; }

        /// <summary>
        /// Wordt aangeroepen zodra het spel opgelost heeft
        /// </summary>
        event SokobanEvent.SokobanEventHandler onSolve;

        /// <summary>
        /// Wordt aangeroepen zodra de speler verplaatst is
        /// </summary>
        event SokobanEvent.SokobanEventHandler onMovePlayer;
    }
}
