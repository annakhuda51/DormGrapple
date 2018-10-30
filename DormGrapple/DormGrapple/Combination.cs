using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class Combination
    {
        public List<Position> combination;

        public Combination()
        {
            combination = new List<Position>();
        }

        public Combination(List<Position> newCombination)
        {
            combination = new List<Position>();

            foreach(var position in newCombination)
            {
                combination.Add(new Position(position.Row, position.Column));
            }
        }
    }
}
