using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[3,4];

            Console.WriteLine($"Length of first dimension: {grid.GetLength(0)}");
            Console.WriteLine($"Length of second dimension: {grid.GetLength(1)}");

        }
    }
}
