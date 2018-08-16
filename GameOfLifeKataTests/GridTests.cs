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

            grid.Generations(1);

            Assert.That(grid.Result(), Is.EqualTo(expected));
        }

        [Test]
        public void grid3x3_three_cells_resurrect_dead_cell()
        {
            string inital = 
                "000\r\n"
            +   "011\r\n"
            +   "001";

            string expected = 
                "000\r\n"
            +   "011\r\n"
            +   "011";

            Grid grid = new Grid(inital);

            grid.Generations(1);

            Assert.That(grid.Result(), Is.EqualTo(expected));
        }


    }
}
