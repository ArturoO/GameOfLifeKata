﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    public class Grid
    {
        byte[,] ByteGrid = null;
        int GridWidth = 0;  //x
        int GridHeight = 0; //y

        public Grid(string textGrid)
        {
            if (!ValidateInputGrid(textGrid))
                return;

            ByteGrid = ParseTextGrid(textGrid);
            GridWidth = ByteGrid.GetLength(0);
            GridHeight = ByteGrid.GetLength(1);            
        }

        bool ValidateInputGrid(string textGrid)
        {
            //string may contain only 0,1 and new line characters
            Regex rgx = new Regex(@"^[01(\n|\r|\r\n)]+$");
            bool result = rgx.IsMatch(textGrid);
            if (!result)
                return false;

            //split by new line and check if each row has the same number of columns
            string[] gridParts = SplitTextByNewLine(textGrid);
            int gridHeight = gridParts.Length;
            int colCount = 0;
            for (var i = 0; i < gridHeight; i++)
            {
                if(colCount==0)
                    colCount = gridParts[i].Length;
                else
                {
                    if (colCount != gridParts[i].Length)
                        return false;
                }
            }

            return true;
        }

        public byte[,] GetByteGrid()
        {
            return ByteGrid;
        }

        byte[,] ParseTextGrid(string textGrid)
        {
            byte[,] byteGrid;
            string[] gridParts = SplitTextByNewLine(textGrid);
            int gridHeight = gridParts.Length;
            int gridWidth = gridParts[0].Length;

            byteGrid = new byte[gridWidth, gridHeight];
            for (var i = 0; i < gridHeight; i++)
            {
                for (var j = 0; j < gridWidth; j++)
                {
                    byteGrid[j, i] = (byte)char.GetNumericValue(gridParts[i][j]);
                }
            }
            return byteGrid;
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

        /// <summary>
        /// Returns cell status at given position in next generation.
        /// 0 represents dead cell, 1 is for living cell. 
        /// </summary>
        /// <param name="x">Horizontal position of the cell.</param>
        /// <param name="y">Vertical position of the cell.</param>
        /// <returns></returns>
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
            byte[,] NextByteGrid = new byte[GridWidth, GridHeight];

            for (var i = 0; i < iterations; i++)
            {
                for (var m = 0; m < GridWidth; m++)
                {
                    for (var n = 0; n < GridHeight; n++)
                    {
                        NextByteGrid[m,n] = CellNextState(m, n);
                    }
                }
                ByteGrid = (byte[,])NextByteGrid.Clone();
            }
        }
        public string Result()
        {
            StringBuilder textGrid = new StringBuilder("");

            for (var n = 0; n < GridHeight; n++)                
            {
                for (var m = 0; m < GridWidth; m++)
                {
                    textGrid.Append(ByteGrid[m, n]);
                }
                if( n < GridHeight - 1)
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

        public int GetWidth()
        {
            return GridWidth;
        }

        public int GetHeight()
        {
            return GridHeight;
        }
    }
}
