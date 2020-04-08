using System;
using System.Collections.Generic;
using System.Text;

namespace Tesztverseny
{
    class Competitor
    {
        public string Id { get; set; }
        public string Answers { get; set; }

        public Competitor(string line)
        {
            var splittedValues = line.Split(' ');

            Id = splittedValues[0];
            Answers = splittedValues[1];
        }
    }
}
