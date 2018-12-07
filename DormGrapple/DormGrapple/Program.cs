using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            field.SetField();

            RandomBot randomBot1 = new RandomBot(currentHealth: 1000, maxHealth: 1000, owner: Owner.Player);
            RandomBot randomBot2 = new RandomBot(currentHealth: 1020, maxHealth: 1020, owner: Owner.Enemy);
            Game game = new Game(randomBot1, randomBot2, field);
            var player = game.Gaming();
            Console.WriteLine("Someone lose");
            Console.ReadKey();
        }
    }
}
