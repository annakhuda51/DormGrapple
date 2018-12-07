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
            Field field = new Field(9);
            field.SetField();

            RandomBot randomBot1 = new RandomBot(currentHealth: 2000, maxHealth: 2000, enemy: Owner.Player);
            MaxBot randomBot2 = new MaxBot(currentHealth: 2000, maxHealth: 2000, enemy: Owner.Enemy);
            Game game = new Game(randomBot1, randomBot2, field);
            var player = game.Gaming();
            Console.WriteLine("Someone lose");
            Console.ReadKey();
        }
    }
}
