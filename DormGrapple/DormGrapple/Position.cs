using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position()
        {
            Row = 0;
            Column = 0;
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
