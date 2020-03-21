using System;
using System.Collections.Generic;

namespace QuickPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(toUpperCaseEveryFirstLetter());
            Console.WriteLine();
            Console.WriteLine("Your second biggest number is: " + secondBiggestNumber(getNumbers())); 
        }

        private static string toUpperCaseEveryFirstLetter()
        {
            Console.Write("Enter your text: ");
            string text = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter your separator character: ");
            char separator = char.Parse(Console.ReadLine());
            Console.Clear();

            var lowerCasewords = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var upperCaseWords = new List<string>();
            string result = String.Empty;

            foreach (var word in lowerCasewords)
                upperCaseWords.Add(word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1).ToLower());

            foreach (var properWords in upperCaseWords)
                result += properWords + " ";

            return result;
        }

        private static int secondBiggestNumber(int[] numbers)
        {
            if (numbers == null)
                throw new Exception("Your array is not initialized");
            else if (numbers.Length == 0)
                throw new Exception("Your array is empty. Does not contains any value.");
            else if (numbers.Length == 1)
                throw new Exception("Your array does contain only one value. Can not select the second biggest value");

            int result = 0;
            int maximum = 0;

            for (int i = 0; i < numbers.Length; i++)
                if (maximum < numbers[i])
                    maximum = numbers[i];

            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] != maximum && result < numbers[i])
                    result = numbers[i];

            return result;
        }

        private static int[] getNumbers()
        {
            Console.Write("Enter how many numbers you wish to work with: ");
            int lenght = int.Parse(Console.ReadLine());
            Console.Clear();

            int[] numbers = new int[lenght];
            for (int i = 0; i < lenght; i++)
            {
                Console.Write($"Enter the {i}. number: ");
                numbers[i] = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            return numbers;
        }
    }
}
