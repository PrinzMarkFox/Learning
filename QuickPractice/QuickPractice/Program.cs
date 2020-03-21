using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuickPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(toUpperCaseEveryFirstLetter("ez___itt_egy__teszt_______szöveg!"));
            Console.WriteLine();

            int[] numbers = { 9,4,9 };
            Console.WriteLine("Your second largest number is: " + secondLargestNumber(numbers)); 
        }

        private static string toUpperCaseEveryFirstLetter(string text)
        {
            TextInfo textInfo = new CultureInfo("hu-HU", false).TextInfo;
            string result = textInfo.ToTitleCase(text);

            return result;
        }

        private static int secondLargestNumber(int[] numbers)
        {
            if (numbers == null)
                throw new Exception("Your array is not initialized");
            else if (numbers.Length == 0)
                throw new Exception("Your array is empty. Does not contains any value.");
            else if (numbers.Length == 1)
                throw new Exception("Your array does contain only one value. Can not select the second largest value");

            int helper = 0;
            int result = 0;
            int maximum = 0;

            foreach (var num in numbers)
            {
                if (num > maximum)
                {
                    result = maximum;
                    maximum = num;
                }
                else if (num > result)
                {
                    helper = result;
                    result = num;
                    if (result == maximum)
                    {
                        result = helper;
                    }
                }
            }

            if (result == maximum)
                throw new Exception("There is no second largest number.");

            return result;
        }
    }
}
