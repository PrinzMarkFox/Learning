using System;

namespace Tesztverseny
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver();
            //Kiiratás
            Console.WriteLine($"1. feladat: Az adatok beolvasása{Environment.NewLine}");

            Console.WriteLine($"2. feladat: A vetélkedőn {solver.Task2()} versenyző indult.{Environment.NewLine}");

            Console.Write("3. feladat: A versenyző azonosítója = ");
            Console.WriteLine(solver.Task3() + Environment.NewLine);

            Console.WriteLine("4. feladat:");
            Console.WriteLine(solver.Task4() + Environment.NewLine);

            Console.Write("5. feladat: A feladat sorszáma = ");
            int taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"A feladatra {solver.validAnswers} fő, a versenyzők {solver.Task5(taskNumber)}%-a adott helyes választ.{Environment.NewLine}");

            Console.WriteLine("6. feladat: A versenyzők pontszámának meghatározása");
            solver.Task6();
            Console.WriteLine("");

            Console.WriteLine("7. feladat: A verseny legjobbjai:");
            var winners = solver.Task7();
            for (int i = 0; i < winners.Count; i++)
            {
                Console.WriteLine($"{winners[i].Place}. díj ({winners[i].Points} pont): {winners[i].Id}");
            }
        }
    }
}
