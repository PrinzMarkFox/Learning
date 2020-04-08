using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tesztverseny
{
    class Solver
    {
        List<Competitor> competitors;
        Reader reader = new Reader();
        string selectedCompAnswer;
        List<Result> result = new List<Result>();
        public double validAnswers { get; set; } //Kiiratásnál 0 értéket ad vissza...

        public Solver()
        {
            competitors = reader.GetCompetitors();
        }

        public int Task2()
        {
            return competitors.Count;
        }

        public string Task3()
        {
            var compId = Console.ReadLine();
            var selectedComp = competitors.Where(c => c.Id == compId).Single();

            selectedCompAnswer = selectedComp.Answers;
            return selectedCompAnswer + "\t(a versenyző válasza)";
        }

        public string Task4()
        {
            Console.WriteLine($"{reader.Solution} \t(a helyes megoldás)");
            //StringBuilder sb = new StringBuilder();
            //sb.Append("+");
            char[] result = new char[14];
            
            for (int i = 0; i < selectedCompAnswer.Length; i++)
            {
                if (selectedCompAnswer[i] == reader.Solution[i])
                {
                    result[i] = '+';
                }
                else
                {
                    result[i] = ' ';
                }
            }

            return new string(result) + "\t(a versenyző helyes válaszai)";
        }

        public double Task5(int taskNumber)
        {
            var taskNum = taskNumber - 1;
            validAnswers = (double)competitors.Count(c => c.Answers[taskNum] == reader.Solution[taskNum]);

            return Math.Round((validAnswers / competitors.Count) * 100, 2);
        }

        public void Task6()
        {
            foreach (var competitor in competitors)
            {
                result.Add(CalculatePoints(competitor));
            }

            File.WriteAllLines("pontok.txt", result.Select(r => $"{r.Id} {r.Points}"));
        }

        private Result CalculatePoints(Competitor competitor)
        {
            int sumPoints = 0;
            for (int i = 0; i < competitor.Answers.Length; i++)
            {
                if (competitor.Answers[i] == reader.Solution[i])
                {
                    sumPoints += GetPoints(i + 1);
                }
            }

            return new Result() { Id = competitor.Id, Points = sumPoints };
        }

        private int GetPoints(int taskNum)
        {
            int[,] table = new int[,]
            {
                { 1,  5,  3 },
                { 6,  10, 4 },
                { 11, 13, 5 }, 
                { 14, 14, 6 }
            };

            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (taskNum >= table[i,0] && taskNum <= table[i,1])
                {
                    return table[i, 2];
                }
            }
            return 0;
        }

        public List<Winner> Task7()
        {
            result = result.OrderByDescending(r => r.Points).ToList();
            var winners = new List<Winner>();

            int place = 1;
            winners.Add(new Winner(result[0].Id, result[0].Points, place)); //Use while instead of for loop
            for (int i = 1; i < result.Count && place < 3; i++)
            {
                if (result[i].Points != result[i - 1].Points)
                    place++;
                
                winners.Add(new Winner(result[i].Id, result[i].Points, place));
            }
            
            return winners;
        }
    }
}
