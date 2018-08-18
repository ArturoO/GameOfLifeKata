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

        /// <summary>
        /// Returns cell status at given position. 
        /// 0 represents dead cell, 1 is for living cell. 
        /// If provided position is incorrect then 255 is returned
        /// </summary>
        /// <param name="x">Horizontal position of the cell.</param>
        /// <param name="y">Vertical position of the cell.</param>
        /// <returns></returns>
        public byte CellAt(int x, int y)
        {
            if ((x >= 0 && x <= GridWidth-1)
                && (y >= 0 && y <= GridHeight-1))
                return ByteGrid[x, y]; 
            else
                return 255;
        }

        /// <summary>
        /// Return the number of living neighbors for provided position.
        /// Returns -1 if given position is out of range.
        /// </summary>
        /// <param name="x">Horizontal position of the cell.</param>
        /// <param name="y">Vertical position of the cell.</param>
        /// <returns></returns>
        public int CellLivingNeighbors(int x, int y)
        {
            if(CellAt(x,y)==255)            
                return -1;

            var minX = (x > 0 ? x - 1 : 0);
            var maxX = (x < GridWidth-1 ? x + 1 : GridWidth-1);
            var minY = (y > 0 ? y - 1 : 0);
            var maxY = (y < GridHeight-1 ? y + 1 : GridHeight-1);

            var CellLivingNeighbors = 0;

            for(var i=minX; i<=maxX; i++)
            {
                for (var j = minY; j<=maxY; j++)
                {
                    if (i == x && j == y)
                        continue;
                    CellLivingNeighbors += CellAt(i, j);
                }
            }

            return CellLivingNeighbors;
        }

        public byte CellNextState(int x, int y)
        {
            byte cellStatus = CellAt(x, y);
            byte cellNextStatus = 255;
            int livingNeighbors = CellLivingNeighbors(x, y);

            if (cellStatus == 255 || livingNeighbors == -1)
                return cellNextStatus;

            if(cellStatus==1)
            {
                if (livingNeighbors < 2 || livingNeighbors > 3)
                    cellNextStatus = 0;
                else
                    cellNextStatus = 1;
            }
            else if(cellStatus==0)
            {
                if(livingNeighbors==3)
                    cellNextStatus = 1;
                else
                    cellNextStatus = 0;
            }

            return cellNextStatus;
        }

        public void Generations(int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                for (var m = 0; m < GridWidth; m++)
                {
                    for (var n = 0; n < GridHeight; n++)
                    {
                        ByteGrid[m,n] = CellNextState(m, n);
                    }
                }

            }
        }


        public string Result()
        {
            StringBuilder textGrid = new StringBuilder();

            for (var m = 0; m < GridWidth; m++)
            {
                for (var n = 0; n < GridHeight; n++)
                {
                    textGrid.Append(ByteGrid[m, n]);
                }
                if(m< GridWidth-1)
                    textGrid.Append(Environment.NewLine);
            }

            return textGrid.ToString();
        }

        string[] SplitTextByNewLine(string text)
        {
            return text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);
        }
    }
}
