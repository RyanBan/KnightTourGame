using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int value { get; set; }

        public Cell()
        {
        }
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Cell(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.value = value;
        }

    }
}
