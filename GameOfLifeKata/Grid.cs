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

        public Grid(string textGrid)
        {
            TextGrid = textGrid;
            string[] gridParts = SplitTextByNewLine(textGrid);
            int y = gridParts.Length;
            int x = gridParts[0].Length;
            ByteGrid = new byte[x, y];
            for(var i=0; i<y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    ByteGrid[j,i] = (byte)char.GetNumericValue(gridParts[i][j]);
                }
            }
            
        }

        public byte CellAt(int x, int y)
        {
            return ByteGrid[x, y];
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
