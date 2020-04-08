using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tesztverseny
{
    class Reader
    {
        public string Solution { get => solution; }

        private string solution;

        public List<Competitor> GetCompetitors()
        {
            var lines = File.ReadAllLines("valaszok.txt");
            var competiors = new List<Competitor>();
            solution = lines[0];

            foreach (var line in lines.Skip(1))
            {
                competiors.Add(new Competitor(line));
            }

            return competiors;
        }
    }
}
