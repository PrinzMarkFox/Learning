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

            int[] numbers = { 1, 29, 3, 5, 1, 6, 9, 41, 2 };
            Console.WriteLine("Your second biggest number is: " + secondBiggestNumber(numbers)); 
        }

        private static string toUpperCaseEveryFirstLetter(string text)
        {
            TextInfo textInfo = new CultureInfo("hu-HU", false).TextInfo;
            string result = textInfo.ToTitleCase(text);

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

            foreach (var num in numbers)
            {
                if (num > maximum)
                {
                    result = maximum;
                    maximum = num;
                }
                else if (num > result)
                {
                    result = num;
                }
            }

            return result;
        }
    }
}
