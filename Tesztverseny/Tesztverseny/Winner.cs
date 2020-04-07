using System;
using System.Collections.Generic;
using System.Text;

namespace Tesztverseny
{
    class Winner
    {
        public string Id { get; set; }
        public int Points { get; set; }
        public int Place { get; set; }

        public Winner(string id, int points, int place)
        {
            Id = id;
            Points = points;
            Place = place;
        }
    }
}
