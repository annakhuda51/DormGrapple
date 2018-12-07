using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class RandomBot : IPlayer
    {
        public double CurrentHealth { get; set; }
        public double MaxHealth { get; set; }
        public Owner Owner { get; set; }
        private Random rand = new Random();

        public RandomBot(double currentHealth = 200, double maxHealth = 200, Owner owner = Owner.Enemy)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            Owner = owner;
        }

        public Tuple<Position, Position> Move(List<List<ICell>> cells)
        {
            var moves = Analytics.AllMoves(cells);
            moves.RemoveAll(move => cells[move.combination[0].Row][move.combination[0].Column].Owner != Owner);
            if(moves.Count ==0)
                moves = Analytics.AllMoves(cells);
            int randomIndex = rand.Next(0, moves.Count);
            return new Tuple<Position, Position>(moves[randomIndex].combination[0], moves[randomIndex].combination[1]);

        }
    }
}
