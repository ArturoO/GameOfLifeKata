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
        [TestCase("")]
        [TestCase("a")]
        [TestCase("00\r\n01\r\n0")]
        [TestCase("0000\r\n020\r\n0001a")]
        public void incorrect_input_grid(string inputGrid)
        {
            Grid grid = new Grid(inputGrid);

            object expected = null;
            Assert.That(grid.GetByteGrid(), Is.EqualTo(expected));

            int expected2 = 255;
            Assert.That(grid.CellAt(0, 0), Is.EqualTo(expected2));

            int expected3 = -1;
            Assert.That(grid.CellLivingNeighbors(0, 0), Is.EqualTo(expected3));

            int expected4 = 255;
            Assert.That(grid.CellNextState(0, 0), Is.EqualTo(expected4));

            string expected5 = "";
            Assert.That(grid.Result(), Is.EqualTo(expected5));
        }

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

            grid.Generations(1);

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
        [TestCase(4, 4, 255)]
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
        [TestCase(-1, -1, -1)]
        [TestCase(4, 2, -1)]
        [TestCase(2, 5, -1)]
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
        [TestCase(3, 5, 255)]
        [TestCase(-1, 3, 255)]
        [TestCase(3, 17, 255)]
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

        public void grid4x5_check_next_generation()
        {
            string inital =
                "1101\r\n"
            +   "1010\r\n"
            +   "0000\r\n"
            +   "0111\r\n"
            +   "0110";

            string expected =
                "1110\r\n"
            +   "1110\r\n"
            +   "0101\r\n"
            +   "0101\r\n"
            +   "0101";

            Grid grid = new Grid(inital);

            Assert.That(grid.Result(), Is.EqualTo(expected));
        }

        [Test]
        public void exploder_grid_after_10_generations()
        {
            //Exploder
            //Source: https://bitstorm.org/gameoflife/
            string inital =
                "0000000000000\r\n"
            +   "0000101010000\r\n"
            +   "0000100010000\r\n"
            +   "0000100010000\r\n"
            +   "0000100010000\r\n"
            +   "0000101010000\r\n"
            +   "0000000000000";

            string expected =
                "0001000001000\r\n"
            +   "0011100011100\r\n"
            +   "0101010101010\r\n"
            +   "1110110110111\r\n"
            +   "0101010101010\r\n"
            +   "0011100011100\r\n"
            +   "0001000001000";

            Grid grid = new Grid(inital);
            grid.Generations(10);
            Assert.That(grid.Result(), Is.EqualTo(expected));            
        }

    }
}
