using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    class NumberPoint
    {
        public NumberPoint(int x, int y, int value)
        {
            X = x;
            Y = y;
            this.value = value;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int value { get; set; }
    }
}
