using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Reversi
{
    class Tabla
    {
        public char[,] t { get; set; }

        public Tabla(string filename)
        {
            t = ReadFile(filename);
        }

        private char[,] ReadFile(string filename)
        {
            var lines = File.ReadAllLines("allas.txt");
            var result = new char[8, 8];

            for (int i = 0; i < lines.Length; i++)
            {
                int j = 0;
                foreach (var character in GetCharacters(lines[i]))
                {
                    result[i, j++] = character;
                }
            }

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    for (int j = 0; j < lines[i].Length; j++)
            //    {
            //        result[i, j] = lines[i][j];
            //    }
            //}
            return result;
        }

        private IEnumerable<char> GetCharacters(string line)
        {
            foreach (var character in line)
            {
                yield return character;
            }
        }

        public void Megjelenit()
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    Console.Write(t[i,j]);
                }

                Console.WriteLine("");
            }
        }

        public int Megszamol(char c)
        {
            int result = 0;

            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (t[i,j] == c)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public bool VanForditas(char jatekos, int sor, int oszlop, int iranySor, int iranyOszlop)
        {
            int aktSor = sor + iranySor;
            int aktOszlop = oszlop + iranyOszlop;
            char ellenfel = jatekos == 'K' ? 'F' : 'K';
            bool nincsEllenfel = true;

            while (aktSor > 0 && aktSor < 8 && aktOszlop > 0 && aktOszlop < 8 && t[aktOszlop,aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;
            }

            if (nincsEllenfel || aktSor < 0 || aktSor > 7 ||aktOszlop < 0 || aktOszlop > 7 || 
                t[aktSor,aktOszlop] != jatekos)
            {
                return false;
            }

            return true;
        }

        public bool Task8(string parameters)
        {
            var parameter = parameters.Split(';');
            return VanForditas(char.Parse(parameter[0]), int.Parse(parameter[1]), int.Parse(parameter[2]), int.Parse(parameter[3]), int.Parse(parameter[4]));
        }

        public bool Task9(string parameter)
        {
            var directions = new List<Coordinate>()
            {
                new Coordinate(-1,-1),
                new Coordinate(-1,-0),
                new Coordinate(-1,1),
                new Coordinate(0,-1),
                new Coordinate(0,1),
                new Coordinate(1,-1),
                new Coordinate(1,0),
                new Coordinate(1,1),
            };

            foreach (var direction in directions)
            {
                string p = parameter + ";" + direction.X + ";" + direction.Y;
                if (Task8(p))
                {
                    return true;
                }
            }

            return false;

        }
    }
}
