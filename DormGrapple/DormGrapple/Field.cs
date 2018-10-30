using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class Field
    {
        public List<List<ICell>> cells;

        public Field(int size = 9)
        {
            cells = new List<List<ICell>>(size);

            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                cells.Add(new List<ICell>(size));

                for (int j = 0; j < size; j++)
                {
                    int type = rand.Next(0, 6);

                    if(type == 0)
                    {
                        cells[i].Add(new Apple());
                    }

                    if (type == 1)
                    {
                        cells[i].Add(new Chip());
                    }

                    if (type == 2)
                    {
                        cells[i].Add(new Bacterium());
                    }

                    if (type == 3)
                    {
                        cells[i].Add(new Slipper());
                    }

                    if (type == 4)
                    {
                        cells[i].Add(new CockroachTrap());
                    }

                    if (type == 5)
                    {
                        cells[i].Add(new Poison());
                    }
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if(cells[i][j] is Apple)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if (cells[i][j] is Chip)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }

                    if (cells[i][j] is Bacterium)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    if (cells[i][j] is Slipper)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    if (cells[i][j] is CockroachTrap)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }

                    if (cells[i][j] is Poison)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }
    }
}
