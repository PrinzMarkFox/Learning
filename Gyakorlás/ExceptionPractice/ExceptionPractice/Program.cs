using System;

namespace ExceptionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = GetNumber();
            Console.ReadKey();
        }

        private static int[] GetNumber()
        {
            int[] numbers = new int[5];
            int i = 0;
            while (i < 5)
            {
                try
                {
                    numbers[i] = ReadNumber();
                    i++;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                }
            }

            return numbers;
        }

        private static int ReadNumber()
        {
            Console.Write("Enter a number (10-100): ");
            int num = int.Parse(Console.ReadLine());

            if (num < 10 || num > 100)
            {
                throw new ArgumentOutOfRangeException("Number must between 10 and 100");
            }

            return num;
        }
    }
}
