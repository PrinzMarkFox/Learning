using System;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(ToUpper2(" aaaaezaegyatesztasZöVeGaaag"));
            Console.ReadKey();
        }

        private static bool isSeparator(char character)
        {
            return (new HashSet<char>() { ' ', 'a', ',' }).Contains(character);
        }

        private static string toUpperCase(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException();
            }

            string result = "";
            bool toUpper = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (toUpper && !isSeparator(text[i]))
                {
                    result += char.ToUpper(text[i]);
                    toUpper = false;
                }
                else
                {
                    if (isSeparator(text[i]))
                    {
                        result += text[i];
                        toUpper = true;
                    }
                    else
                    {
                        result += text[i];
                    }
                }
            }

            return result;
        }

        static string ToUpper2(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException();

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0 && !isSeparator(text[i]) || i > 0 && isSeparator(text[i - 1]) && !isSeparator(text[i]))
                    result += char.ToUpper(text[i]);
                else
                    result += text[i];
            }

            return result;
        }
    }
}
