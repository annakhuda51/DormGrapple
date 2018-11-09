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
            var damageDictionary = new Dictionary<Owner, double>();

            for (int i = 0; i < 10; i++)
            {
                field.Show();
                Console.WriteLine();               

                ShowCellsForEachOwner();

                Owner owner = Owner.Player;
                if (i % 2 == 1)
                {
                    owner = Owner.Enemy;
                }

                Console.WriteLine(owner + " move!\nIndexes from 1");

                InputPositions(out int i1, out int j1, out int i2, out int j2);

                Console.WriteLine("\nCombo list:");
                var dict = field.Move(new Position(i1 - 1, j1 - 1), new Position(i2 - 1, j2 - 1), owner);

                foreach (var pair in dict)
                {
                    if (!damageDictionary.ContainsKey(pair.Key))
                        damageDictionary[pair.Key] = 0;
                    damageDictionary[pair.Key] += pair.Value;
                }

                Console.WriteLine("\nDamage list:");
                foreach (var pair in damageDictionary)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value.ToString("F") + " damage points");
                }

                Console.WriteLine();
            }


            Console.WriteLine(damageDictionary.FirstOrDefault(pair1 => pair1.Value == damageDictionary.Max(pair => pair.Value)).Key + " is WINNER!!!\n\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ShowCellsForEachOwner()
        {
            Console.WriteLine("Player:");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nEnemy:");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        static void ShowCountCellsStatistic(Field field)
        {
            var countDictionary = field.CountEachTypeCell();
            var own0 = countDictionary.Where(pair => pair.Key.Owner == Owner.Player).Sum(pair => pair.Value);
            var own1 = countDictionary.Where(pair => pair.Key.Owner == Owner.Enemy).Sum(pair => pair.Value);
            var all = countDictionary.Sum(pair => pair.Value);
            foreach (var pair in countDictionary)
            {
                if (pair.Key.Owner == Owner.Player)
                {
                    Console.WriteLine(pair.Key.Type + ": " + pair.Value + " - " +
                                      ((double)pair.Value / own0).ToString("F") + "%");
                }
                if (pair.Key.Owner == Owner.Enemy)
                {
                    Console.WriteLine(pair.Key.Type + ": " + pair.Value + " - " +
                                      ((double)pair.Value / own1).ToString("F") + "%");
                }
            }
            Console.WriteLine(all + " " + own0);
            Console.WriteLine(all + " " + own1);
        }

        static void InputPositions(out int i1, out int j1, out int i2, out int j2)
        {
            do
            {

                var str = "";
                var flag = true;
                Console.Write("\nEnter 1st cell row: ");
                do
                {
                    str = Console.ReadLine();
                    flag = !int.TryParse(str, out i1);
                    if (!flag)
                        flag = i1 < 0 || i1 > 9;
                    if (flag)
                        Console.Write("You make mistake, please try again: ");
                } while (flag);

                Console.Write("Enter 1st cell column: ");
                do
                {
                    str = Console.ReadLine();
                    flag = !int.TryParse(str, out j1);
                    if (!flag)
                        flag = j1 < 0 || j1 > 9;
                    if (flag)
                        Console.Write("You make mistake, please try again: ");
                } while (flag);

                Console.Write("Enter 2nd cell row: ");
                do
                {
                    str = Console.ReadLine();
                    flag = !int.TryParse(str, out i2);
                    if (!flag)
                        flag = i2 < 0 || i2 > 9;
                    if (flag)
                        Console.Write("You make mistake, please try again: ");
                } while (flag);

                Console.Write("Enter 2nd cell column: ");
                do
                {
                    str = Console.ReadLine();
                    flag = !int.TryParse(str, out j2);
                    if (!flag)
                        flag = j2 < 0 || j2 > 9;
                    if (flag)
                        Console.Write("You make mistake, please try again: ");
                } while (flag);

                Console.Write("\nEnter 0 to confirm move: ");

            } while (Console.ReadLine() != "0");
        }
    }
}
