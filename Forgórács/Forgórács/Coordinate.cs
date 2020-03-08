using System;
using System.Collections.Generic;
using System.Text;

namespace Forgórács
{
    struct Coordinate
    {
        public int I { get; set; }
        public int J { get; set; }

        public Coordinate(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
