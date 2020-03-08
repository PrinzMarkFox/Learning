using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Forgórács
{
    class Fracs
    {
        public char[,] Kodlemez { get; set; }
        public char[,] Titkositott { get; set; }
        public string Titkositando { get; private set; }

        public Fracs(string filename, string titkositando)
        {
            Kodlemez = GetCode(filename);
            Titkositott = new char[8, 8];
            Titkositando = titkositando;
        }

        public char[,] GetCode(string filename)
        {
            var lines = File.ReadAllLines(filename);
            char[,] result = new char[8, 8];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    result[i, j] = lines[i][j];
                }
            }
            return result;
        }

        public void Atalakit()
        {
            string result = "";
            var chars = new HashSet<char>() { '.', ',', ' ' };

            for (int i = 0; i < Titkositando.Length; i++)
            {
                if (!chars.Contains(Titkositando[i]))
                {
                    result += Titkositando[i];
                }
            }

            if (result.Length >= 64)
            {
                throw new Exception("Túl hosszú a titkosítandó szöveg!");
            }

            Titkositando = result.PadRight(64, 'X');
        }

        public void KiirKodlemez()
        {
            for (int i = 0; i < Kodlemez.GetLength(0); i++)
            {
                for (int j = 0; j < Kodlemez.GetLength(1); j++)
                {
                    Console.Write(Kodlemez[i,j]);
                }
                Console.WriteLine("");
            } 
        }

        public char[,] ForgatKodlemez()
        {
            var ujKodlemez = new char[8, 8];
            for (int i = 0; i < ujKodlemez.GetLength(0); i++)
            {
                for (int j = 0; j < ujKodlemez.GetLength(1); j++)
                {
                    ujKodlemez[7 - j, i] = Kodlemez[i, j];
                }
            }
            return ujKodlemez;
        }

        public void Titkosit()
        {
            int i = 0;

            while (i < 64)
            {
                foreach (var coord in GetCoordinates())
                {
                    Titkositott[coord.I, coord.J] = Titkositando[i++];
                }
                Kodlemez = ForgatKodlemez();
            }
        }

        private IEnumerable<Coordinate> GetCoordinates()
        {
            for (int j = 0; j < Kodlemez.GetLength(1); j++)
            {
                for (int i = 0; i < Kodlemez.GetLength(0); i++)
                {
                    if (Kodlemez[i,j] == 'A')
                    {
                        yield return new Coordinate(i, j);
                    }
                }
            }
        }

        public void KiirEredmeny()
        {
            for (int i = 0; i < Titkositott.GetLength(0); i++)
            {
                for (int j = 0; j < Titkositott.GetLength(1); j++)
                {
                    Console.Write(Titkositott[i,j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
