using System;
using System.Collections.Generic;

namespace QuickPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(toUpperCaseEveryFirstLetter("ez egy teszt szöveg"));
            Console.WriteLine();

            int[] testArray = { 1, 3, 2, 2, 0, 7, 6, 9 };
            Console.WriteLine(secondBiggestNumber(testArray)); 
        }

        private static string toUpperCaseEveryFirstLetter(string text)
        {
            const char separator = ' ';
            var lowerCasewords = text.Split(separator);
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
    }
}
