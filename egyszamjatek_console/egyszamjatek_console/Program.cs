using System;

namespace egyszamjatek_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver();

            Console.WriteLine($"3. feladat: Játékosok száma: {solver.Task3()} fő");
            Console.Write($"4. feladat: Kérem a forduló sorszámát: ");
            solver.Task4();
            Console.WriteLine($"5. feladat: A megadott forduló tippjeinek átlaga: {solver.Task5()}");
        }
    }
}
