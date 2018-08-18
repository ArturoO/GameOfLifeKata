using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    public class Grid
    {
        string TextGrid;
        byte[,] ByteGrid;
        int GridWidth;  //x
        int GridHeight; //y

        public Grid(string textGrid)
        {
            TextGrid = textGrid;
            string[] gridParts = SplitTextByNewLine(textGrid);
            GridHeight = gridParts.Length;
            GridWidth = gridParts[0].Length;
            ByteGrid = new byte[GridWidth, GridHeight];
            for(var i=0; i< GridHeight; i++)
            {
                for (var j = 0; j < GridWidth; j++)
                {
                    ByteGrid[j,i] = (byte)char.GetNumericValue(gridParts[i][j]);
                }
            }
            
        }

        public byte CellAt(int x, int y)
        {
            return ByteGrid[x, y];
        }
        
        public int LivingNeighbors(int x, int y)
        {
            var minX = (x > 0 ? x - 1 : 0);
            var maxX = (x < GridWidth-1 ? x + 1 : GridWidth-1);
            var minY = (y > 0 ? y - 1 : 0);
            var maxY = (y < GridHeight-1 ? y + 1 : GridHeight-1);

            var LivingNeighbors = 0;

            for(var i=minX; i<=maxX; i++)
            {
                for (var j = minY; j<=maxY; j++)
                {
                    if (i == x && j == y)
                        continue;
                    LivingNeighbors += CellAt(i, j);                    
                }
            }

            return LivingNeighbors;
        }

        //public void Generations(int iterations)
        //{
        //    for(var i=0; i<iterations; i++)
        //    {
        //        //check each cell and decide wheter it should live or die
        //        for(var m=0; m< ByteGrid.GetLength(0); m++)
        //        {
        //            for (var n = 0; n < ByteGrid.GetLength(1); n++)
        //            {
        //                //grid[m,n];
        //                //check neighbors
        //            }
        //        }

        //    }
        //}


        public string Result()
        {
            return "000\r\n"
                + "000\r\n"
                + "000";
        }

        string[] SplitTextByNewLine(string text)
        {
            return text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);
        }
    }
}
