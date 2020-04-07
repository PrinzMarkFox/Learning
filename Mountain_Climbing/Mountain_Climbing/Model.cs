using System;
using System.Collections.Generic;
using System.Text;

namespace Mountain_Climbing
{
    class Model
    {
        private const int columns = 5;
        private const int rows = 5;
        public int[,] ModelOfMountain { get; set; }

        public Model()
        {
            int[,] mountain = new int[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    mountain[i,j] = new Random().Next(100);
                }
            }

            ModelOfMountain = mountain;
        }
    }
}
