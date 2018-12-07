using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DormGrapple
{

    public class Field
    {
        private List<List<ICell>> cells;
        private int size;
        public List<List<ICell>> Cells { get => cells; }
        CellsFactory factory = new CellsFactory();

        public Field(int size = 9)
        {
            cells = new List<List<ICell>>(size);

            for (int i = 0; i < size; i++)
            {
                cells.Add(new List<ICell>(size));
                for (int j = 0; j < size; j++)
                {
                    cells[i].Add(new Cell());
                }
            }

            this.size = size;
        }

        public void Show()
        {
            Console.WriteLine("  1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < cells.Count; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write((i + 1) + " ");
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (cells[i][j] is Apple)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }

                    if (cells[i][j] is Chip)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    if (cells[i][j] is Bacterium)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }

                    if (cells[i][j] is Slipper)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }

                    if (cells[i][j] is CockroachTrap)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }

                    if (cells[i][j] is Poison)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }

                    if (cells[i][j] is Cell)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.Write("  ");
                }

                Console.WriteLine();

            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void SetField()
        {
            do
            {
                for (int i = 1; i <= size / 2; i++)
                {
                    for (int j = i - 1; j < size - i + 1; j++)
                    {
                        ICell cell = factory.createCell(CheckCell(i - 1, j), CountEachTypeCell());
                        cells[i - 1][j] = cell;
                    }

                    for (int j = i; j < size - i + 1; j++)
                    {
                        ICell cell = factory.createCell(CheckCell(j, size - i), CountEachTypeCell());
                        cells[j][size - i] = cell;
                    }

                    for (int j = size - i - 1; j >= i - 1; --j)
                    {
                        ICell cell = factory.createCell(CheckCell(size - i, j), CountEachTypeCell());
                        cells[size - i][j] = cell;
                    }

                    for (int j = size - i - 1; j >= i; j--)
                    {
                        ICell cell = factory.createCell(CheckCell(j, i - 1), CountEachTypeCell());
                        cells[j][i - 1] = cell;
                    }
                }

                if (size % 2 == 1)
                    cells[size / 2][size / 2] = factory.createCell(CheckCell(size / 2, size / 2), CountEachTypeCell());
            } while (!Analytics.HasMoves(cells));
        }

        public List<CellType> CheckCell(int i, int j)
        {
            List<CellType> list = new List<CellType>();

            if (i > 1 && cells[i - 1][j].Type != CellType.Default && cells[i - 2][j].Type != CellType.Default &&
                cells[i - 1][j].Type == cells[i - 2][j].Type)
            {
                list.Add(cells[i - 1][j].Type);
            }

            if (j > 1 && cells[i][j - 1].Type != CellType.Default && cells[i][j - 2].Type != CellType.Default &&
                cells[i][j - 1].Type == cells[i][j - 2].Type)
            {
                list.Add(cells[i][j - 1].Type);
            }

            if (i < size - 2 && cells[i + 1][j].Type != CellType.Default && cells[i + 2][j].Type != CellType.Default &&
                cells[i + 1][j].Type == cells[i + 2][j].Type)
            {
                list.Add(cells[i + 1][j].Type);
            }

            if (j < size - 2 && cells[i][j + 1].Type != CellType.Default && cells[i][j + 2].Type != CellType.Default &&
                cells[i][j + 1].Type == cells[i][j + 2].Type)
            {
                list.Add(cells[i][j + 1].Type);
            }

            if (i < size - 1 && i > 0 && cells[i - 1][j].Type != CellType.Default &&
                cells[i + 1][j].Type != CellType.Default &&
                cells[i - 1][j].Type == cells[i + 1][j].Type)
            {
                list.Add(cells[i + 1][j].Type);
            }

            if (j < size - 1 && j > 0 && cells[i][j - 1].Type != CellType.Default &&
                cells[i][j + 1].Type != CellType.Default &&
                cells[i][j - 1].Type == cells[i][j + 1].Type)
            {
                list.Add(cells[i][j + 1].Type);
            }

            return list;
        }

        public Dictionary<ICell, int> CountEachTypeCell()
        {
            var dictionary = new Dictionary<ICell, int>();

            var apple = new Apple();
            var chip = new Chip();
            var bacterium = new Bacterium();
            var slipper = new Slipper();
            var cockroachTrap = new CockroachTrap();
            var poison = new Poison();

            dictionary[apple] = 0;
            dictionary[chip] = 0;
            dictionary[bacterium] = 0;
            dictionary[slipper] = 0;
            dictionary[cockroachTrap] = 0;
            dictionary[poison] = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i][j] is Apple)
                    {
                        dictionary[apple]++;
                    }

                    if (cells[i][j] is Chip)
                    {
                        dictionary[chip]++;
                    }

                    if (cells[i][j] is Bacterium)
                    {
                        dictionary[bacterium]++;
                    }

                    if (cells[i][j] is Slipper)
                    {
                        dictionary[slipper]++;
                    }

                    if (cells[i][j] is CockroachTrap)
                    {
                        dictionary[cockroachTrap]++;
                    }

                    if (cells[i][j] is Poison)
                    {
                        dictionary[poison]++;
                    }
                }
            }

            return dictionary;
        }

        public Dictionary<Owner, double> Move(Position p1, Position p2, Owner owner)
        {
            var mem = cells[p1.Row][p1.Column];
            var damageDictionary = new Dictionary<Owner, double>();
            cells[p1.Row][p1.Column] = cells[p2.Row][p2.Column];
            cells[p2.Row][p2.Column] = mem;

            if (!Analytics.HasCombinations(cells))
            {
                mem = cells[p1.Row][p1.Column];
                cells[p1.Row][p1.Column] = cells[p2.Row][p2.Column];
                cells[p2.Row][p2.Column] = mem;
            }
            else do
                {
                    var dictionary = RemoveAndFill(owner);
                    foreach(var pair in dictionary)
                    {
                        if (!damageDictionary.ContainsKey(pair.Key))
                            damageDictionary[pair.Key] = 0;
                        damageDictionary[pair.Key] += pair.Value;
                    }
                }
                while (Analytics.HasCombinations(cells));

            if (!Analytics.HasMoves(cells))
            {
                //Console.WriteLine("No moves");
                SetField();
            }

            return damageDictionary;
        }

        public Dictionary<Owner, double> RemoveAndFill(Owner owner)
        {
            var allCombo = Analytics.AllCombinations(cells);
            // count of damage that person produce
            var damageDict = new Dictionary<Owner, double>();
            var deleteList = new List<Position>();

            foreach (var combo in allCombo)
            {
                //Console.WriteLine("Combo: " + combo + " " + cells[combo.combination[0].Row][combo.combination[0].Column].Type);
                if (!damageDict.ContainsKey(cells[combo.combination[0].Row][combo.combination[0].Column].Owner))
                    damageDict[cells[combo.combination[0].Row][combo.combination[0].Column].Owner] = 0;
                if (owner == cells[combo.combination[0].Row][combo.combination[0].Column].Owner)
                {
                    damageDict[cells[combo.combination[0].Row][combo.combination[0].Column].Owner]
                        += combo.Length * cells[combo.combination[0].Row][combo.combination[0].Column].Damage;
                }
                else
                {
                    damageDict[cells[combo.combination[0].Row][combo.combination[0].Column].Owner] +=
                        (combo.Length * cells[combo.combination[0].Row][combo.combination[0].Column].Damage / 2.0);
                }

                deleteList.AddRange(combo.combination);
            }

            deleteList.Sort();

            foreach (var deletePosition in deleteList)
            {
                for (var rowIndex = deletePosition.Row; rowIndex > 0; rowIndex--)
                {
                    cells[rowIndex][deletePosition.Column] = cells[rowIndex - 1][deletePosition.Column];
                }

                cells[0][deletePosition.Column] =
                    factory.createCell(CheckCell(0, deletePosition.Column), CountEachTypeCell());
            }

            return damageDict;
        }

        public void CreateFullRandomField()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i][j] = factory.createCell(new List<CellType>(), new Dictionary<ICell, int>());
                }
            }

        }
    }
}
