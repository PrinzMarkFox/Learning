using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace egyszamjatek_console
{
    static class Reader
    {
        public static List<Player> GetPlayer()
        {
            const string filename = "egyszamjatek1.txt";
            var lines = File.ReadAllLines(filename);
            var players = new List<Player>();

            foreach (var line in lines)
            {
                players.Add(new Player(line));
            }

            return players;
        }
    }
}
