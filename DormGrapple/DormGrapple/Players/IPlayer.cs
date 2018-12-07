using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public interface IPlayer
    {
        Tuple<Position, Position> Move(List<List<ICell>> cells);
        double CurrentHealth { get; set; }
        double MaxHealth { get; set; }
        Owner Owner { get; set; }
    }
}
