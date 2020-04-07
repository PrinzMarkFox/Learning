using System;
using System.Collections;

namespace Mountain_Climbing
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Model();

            for (int i = 0; i < model.ModelOfMountain.GetLength(0); i++)
            {
                for (int j = 0; j < model.ModelOfMountain.GetLength(1); j++)
                {
                    Console.Write(model.ModelOfMountain[i,j] + " ");
                }
                Console.WriteLine("");
            }
        }

    }
}
