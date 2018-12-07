using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class Game
    {
        private IPlayer player1;
        private IPlayer player2;
        private Field field;

        public Game(IPlayer player1, IPlayer player2, Field field)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.field = field;
        }

        public IPlayer Gaming()
        {
            while (true)
            {
                field.Show();
                Console.WriteLine();

                var positions = player1.Move(field.Cells);
                Console.WriteLine((positions.Item1.Row +1)+ ", " + (positions.Item1.Column + 1) + "; " + (positions.Item2.Row + 1) + ", " + (positions.Item2.Column + 1));
                var damageDict = field.Move(positions.Item1, positions.Item2, player2.Enemy);
                player1.CurrentHealth -= damageDict.ContainsKey(player1.Enemy) ? damageDict[player1.Enemy] : 0;
                player2.CurrentHealth -= damageDict.ContainsKey(player2.Enemy) ? damageDict[player2.Enemy] : 0;
                if (player1.CurrentHealth <= 0)
                    return player2;
                if (player2.CurrentHealth <= 0)
                    return player1;
                Console.WriteLine("Player1: " + player1.CurrentHealth + "/" + player1.MaxHealth);
                Console.WriteLine("Player2: " + player2.CurrentHealth + "/" + player2.MaxHealth);

                field.Show();
                Console.WriteLine();

                positions = player2.Move(field.Cells);
                Console.WriteLine((positions.Item1.Row + 1) + ", " + (positions.Item1.Column + 1) + "; " + (positions.Item2.Row + 1) + ", " + (positions.Item2.Column + 1));
                damageDict = field.Move(positions.Item1, positions.Item2, player1.Enemy);
                player1.CurrentHealth -= damageDict.ContainsKey(player1.Enemy) ? damageDict[player1.Enemy] : 0;
                player2.CurrentHealth -= damageDict.ContainsKey(player2.Enemy) ? damageDict[player2.Enemy] : 0;
                if (player1.CurrentHealth <= 0)
                    return player2;
                if (player2.CurrentHealth <= 0)
                    return player1;
                Console.WriteLine("Player1: " + player1.CurrentHealth + "/" + player1.MaxHealth);
                Console.WriteLine("Player2: " + player2.CurrentHealth + "/" + player2.MaxHealth);

                Console.WriteLine("\nPress any key for next move...");
                //Console.ReadKey();
            }
        }
    }
}
