using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace egyszamjatek_console
{
    class Solver
    {
        List<Player> players;
        int number;

        public Solver()
        {
            players = Reader.GetPlayer();
        }

        public int Task3()
        {
            return players.Count;
        }

        public void Task4()
        {
            number = int.Parse(Console.ReadLine());

        }

        public double Task5()
        {
            double result = players.Average(p => p.Tips[number - 1]);
            return Math.Round(result, 2);
        }
    }
}
