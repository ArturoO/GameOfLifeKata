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
            string inital =
                "000\r\n"
            +   "010\r\n"
            +   "000";

            string[] result = inital.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None);

            //Console.WriteLine(result.Length);

            foreach (string item in result)
                Console.WriteLine(item);
        }
    }
}
