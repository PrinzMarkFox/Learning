using System;

namespace Reversi
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new Tabla("allas.txt");
            table.Megjelenit();
            Console.WriteLine("");
            Console.WriteLine("6. feladat: Összegzés");
            Console.WriteLine(table.Megszamol('K'));
            Console.WriteLine(table.Megszamol('F'));
            Console.WriteLine(table.Megszamol('#'));
            Console.WriteLine("");
            Console.WriteLine(table.Task8("F;4;1;0;1"));
            Console.WriteLine("");
            Console.WriteLine(table.Task9("K;1;3"));
        }
    }
}
