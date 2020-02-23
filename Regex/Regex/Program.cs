using System;
using System.Text.RegularExpressions;

namespace RegexPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = "^[a-z]+@[a-z]+.[a-z]+$"; Email
            string pattern = @"^\+36(20|30|70){1}[0-9]{7}$";
            Regex r = new Regex(pattern);
            Console.WriteLine(r.IsMatch(Console.ReadLine()));
        }
    }
}
