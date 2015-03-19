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
using IBatisNet.Common;
using IBatisNet.DataMapper;

namespace Pakketo
{
    public class Thema
    {
        #region Fields
        private int thema_id;
        private string thema_naam;
        private string thema_patroon;
        #endregion

        #region Prop
        public int ID
        {
            get { return thema_id; }
            set { thema_id = value; }
        }

        public string Naam
        {
            get { return thema_naam; }
            set { thema_naam = value; }
        }

        public string Patroon
        {
            get { return thema_patroon; }
            set { thema_patroon = value; }
        }

        #endregion

        public Thema()
        {

        }

        public static Thema getThema(int id)
        {
            return Mapper.Instance().QueryForObject<Thema>("Thema.selectThema", id);
        }

        public static void newThema(Thema t)
        {
            Mapper.Instance().Insert("Thema.NewThema", t);
        }
    }
}
