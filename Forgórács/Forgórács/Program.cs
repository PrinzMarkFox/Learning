using System;
using System.IO;

namespace Forgórács
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = GetText();
            Console.WriteLine(text);

            var fracs = new Fracs("kodlemez.txt", text);
            fracs.KiirKodlemez();
            fracs.Atalakit();
            Console.WriteLine(fracs.Titkositando);

            Console.WriteLine("Titkosított:");
            fracs.Titkosit();
            fracs.KiirEredmeny();
        }
        static string GetText()
        {
            return File.ReadAllText("szoveg.txt");
        }
    }
}
