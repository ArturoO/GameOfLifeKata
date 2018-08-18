using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeKata;

namespace GameOfLifeKataTests
{
    public class GridTests
    {

        [Test]
        public void grid3x3_single_cell_after_one_generation()
        {
            string inital = 
                "000\r\n"
            +   "010\r\n"
            +   "000";

            string expected = 
                "000\r\n"
            +   "000\r\n"
            +   "000";

            Grid grid = new Grid(inital);

            //grid.Generations(1);

            Assert.That(grid.Result(), Is.EqualTo(expected));
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(2, 0, 1)]
        [TestCase(3, 0, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 1, 0)]
        [TestCase(3, 1, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(1, 2, 0)]
        [TestCase(2, 2, 0)]
        [TestCase(3, 2, 1)]
        [TestCase(0, 3, 1)]
        [TestCase(1, 3, 0)]
        [TestCase(2, 3, 1)]
        [TestCase(3, 3, 0)]
        [TestCase(0, 4, 0)]
        [TestCase(1, 4, 1)]
        [TestCase(2, 4, 1)]
        [TestCase(3, 4, 0)]
        [TestCase(-1, 10, 255)]
        [TestCase(2, 6, 255)]
        [TestCase(7, 3, 255)]
        public void text_grid4x5_was_correctly_parsed(int x, int y, byte expected)
        {
            string inital =
                "0011\r\n"
            +   "0101\r\n"
            +   "1001\r\n"
            +   "1010\r\n"
            +   "0110";

            Grid grid = new Grid(inital);
            
            Assert.That(grid.CellAt(x,y), Is.EqualTo(expected));
        }

        [TestCase(0, 0, 1)]
        [TestCase(3, 0, 2)]
        [TestCase(0, 4, 2)]
        [TestCase(3, 4, 2)]
        [TestCase(1, 3, 5)]
        [TestCase(2, 1, 5)]
        [TestCase(3, 3, 3)]
        public void grid4x5_count_living_neighbours(int x, int y, int livingNeighbours)
        {
            string inital =
                "0011\r\n"
            +   "0101\r\n"
            +   "1001\r\n"
            +   "1010\r\n"
            +   "0110";

            Grid grid = new Grid(inital);

            Assert.That(grid.CellLivingNeighbors(x, y), Is.EqualTo(livingNeighbours));
        }

        [TestCase(0, 0, 1)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 4, 0)]
        [TestCase(1, 4, 1)]
        [TestCase(3, 1, 0)]
        public void grid4x5_check_cell_next_state(int x, int y, byte cellState)
        {
            string inital =
                "1101\r\n"
            +   "1010\r\n"
            +   "0000\r\n"
            +   "0111\r\n"
            +   "0110";

            Grid grid = new Grid(inital);

            Assert.That(grid.CellNextState(x, y), Is.EqualTo(cellState));
        }

        //[Test]
        //public void grid3x3_three_cells_resurrect_dead_cell()
        //{
        //    string inital = 
        //        "000\r\n"
        //    +   "011\r\n"
        //    +   "001";

        //    string expected = 
        //        "000\r\n"
        //    +   "011\r\n"
        //    +   "011";

        //    Grid grid = new Grid(inital);

        //    grid.Generations(1);

        //    Assert.That(grid.Result(), Is.EqualTo(expected));
        //}


    }
}
