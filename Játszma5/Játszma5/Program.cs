using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Játszma5
{
    class Program
    {
        static void Main(string[] args)
        {
            int IsnerWinCount = 0;
            int MalhutWinCount = 0;

            var rallies = new List<string>(File.ReadAllLines("labdamenetek5.txt"));

            Console.WriteLine($"3. feladat: Labdamenetek száma: {rallies.Count}");
            Console.WriteLine($"4. feladat: {((double)rallies.Count(r => r == "A") / rallies.Count) * 100}%-ban nyerte meg a labdameneteket.");

            int longestWinningStreak = 0;
            int actualStreak = 0;
            foreach (var r in rallies) //Maximum kiválasztás tétel
            {
                if (r == "A")
                {
                    actualStreak++;
                }
                else
                {
                    if (longestWinningStreak < actualStreak )
                    {
                        longestWinningStreak = actualStreak;
                        actualStreak = 0;
                    }
                }
            }
            //Ha az utolsó sorozat lenne a leghosszabb
            if (longestWinningStreak < actualStreak)
                longestWinningStreak = actualStreak;

            Console.WriteLine($"5. feladat: A leghosszabb sorozat: {longestWinningStreak}");

            //7. feladat
            var PróbaJáték = new Játék("Mahut", "Isner", "FAFAA");
            PróbaJáték.Hozzáad('A');

            Console.WriteLine("7. feladat: A próba játék");
            Console.WriteLine($"\tÁllás: {PróbaJáték.Score}");
            Console.WriteLine($"\tBefejeződött a játék: {(PróbaJáték.JátékVége() ? "igen" : "nem")}");

            var játékok = new List<Játék>();
            int rallieIndex = 0;

            Játék játék = null;

            string fogadó = "Mahut";
            string adogató = "Isner";
            string segédVált = "";

            while (rallieIndex < rallies.Count)
            {
                játék = new Játék(adogató, fogadó, "");

                while (!játék.JátékVége())
                {
                    játék.Hozzáad(char.Parse(rallies[rallieIndex++]));
                }

                játékok.Add(játék);

                segédVált = fogadó;
                fogadó = adogató;
                adogató = segédVált;
            }

            foreach (var j in játékok)
            {
                ProcessGame(j, ref IsnerWinCount, ref MalhutWinCount);
            }

            Console.WriteLine("9. feladat: Az 5. játszma végeredménye:");
            Console.WriteLine($"\tMahut: {MalhutWinCount}");
            Console.WriteLine($"\tIsner: {IsnerWinCount}");
        }

        static void ProcessGame(Játék játék, ref int IsnerWinCount, ref int MalhutWinCount)
        {
            int adogatóNyert = játék.Score.Count(s => s == 'A');
            int fogadóNyert = játék.Score.Count(s => s == 'F');

            if (adogatóNyert > fogadóNyert)
            {
                if (játék.ServerName == "Isner")
                {
                    IsnerWinCount++;
                }
                else
                {
                    MalhutWinCount++;
                }
            }
            else
            {
                if (játék.ReceiverName == "Isner")
                {
                    IsnerWinCount++;
                }
                else
                {
                    MalhutWinCount++;
                }
            }
        }
    }
}
