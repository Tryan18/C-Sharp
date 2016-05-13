using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC
{
    public class Test
    {
        private int getal = 0;
        //Custom Event Handler
        public event Update UpdateHandler = null;
        //Custom Delegate
        public delegate void Update(int getal);

        public Test()
        {

        }

        public void Modify()
        {
            getal++;
            if(getal % 10 == 0)
            {
               if(UpdateHandler != null)
                {
                    UpdateHandler(getal);
                }
            }
        }

        public int Modify(int dummy)
        {
            return 0;
        }
    }
}
