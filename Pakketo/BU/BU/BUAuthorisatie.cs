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
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;

namespace BU
{
    [ActiveRecord]
    public class BUAuthorisatie : ActiveRecordBase<BUAuthorisatie>
    {
        public BUAuthorisatie() 
        {

        }

        #region Fields

        private int id;
        private bool actief;
        private string login;
        private string pass;
        private string status;

        #endregion

        #region Properties

        [PrimaryKey]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Property]
        public bool Actief
        {
            get { return actief; }
            set { actief = value; }
        }

        [Property]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        [Property]
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        [Property]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion

        #region Methods

        public static BUAuthorisatie[] getAuthorisaties()
        {
             return BUAuthorisatie.FindAllByProperty("Actief", true);
        }

        #endregion
    }
}
