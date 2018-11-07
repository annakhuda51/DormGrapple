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
        public List<List<ICell>> cells;
        private int size;
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
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (cells[i][j] is Apple)
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

                    if (cells[i][j] is Cell)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write("  ");
                }

                Console.WriteLine();

            }

            Console.BackgroundColor = ConsoleColor.Black;
            //Console.ReadKey();
            //Console.Clear();
        }

        public void SetField()
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

            if (size % 2 == 1) cells[size / 2][size / 2] = factory.createCell(CheckCell(size / 2, size / 2), CountEachTypeCell());
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

        public bool HasMoves()
        {
            for (int i = 0; i < size; i++)
            {
                int count = 0;
                CellType previous = CellType.Default;
                for (int j = 0; j < size; j++)
                {
                    if (cells[i][j].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    previous = cells[i][j].Type;

                    if (count == 2)
                    {
                        if (j > 1)
                        {
                            if (i > 0 && cells[i - 1][j - 2].Type == previous) return true;
                            if (i < size - 1 && cells[i + 1][j - 2].Type == previous) return true;
                            if (j > 2 && cells[i][j - 3].Type == previous) return true;
                        }

                        if (j < size - 1)
                        {
                            if (i > 0 && cells[i - 1][j + 1].Type == previous) return true;
                            if (i < size - 1 && cells[i + 1][j + 1].Type == previous) return true;
                            if (j < size - 2 && cells[i][j + 2].Type == previous) return true;
                        }
                    }
                }

                previous = CellType.Default;
                for (int j = 0; j < size; j++)
                {
                    if (cells[j][i].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    previous = cells[j][i].Type;

                    if (count == 2)
                    {
                        if (i > 1)
                        {
                            if (j > 0 && cells[j - 1][i - 2].Type == previous) return true;
                            if (j < size - 1 && cells[j + 1][i - 2].Type == previous) return true;
                            if (i > 2 && cells[j][i - 3].Type == previous) return true;
                        }

                        if (i < size - 1)
                        {
                            if (j > 0 && cells[j - 1][i + 1].Type == previous) return true;
                            if (j < size - 1 && cells[j + 1][i + 1].Type == previous) return true;
                            if (i < size - 2 && cells[j][i + 2].Type == previous) return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool HasCombinations()
        {
            int index = 0;
            CellType previous = CellType.Default;
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    index = i;
                    previous = cells[i][j].Type;
                    count = 1;
                    while (++index < size && previous == cells[index][j].Type)
                    {
                        count++;
                        if (count > 2)
                        {
                            return true;
                        }
                    }

                    index = i;
                    previous = cells[i][j].Type;
                    count = 1;
                    while (--index > -1 && previous == cells[index][j].Type)
                    {
                        count++;
                        if (count > 2)
                        {
                            return true;
                        }
                    }

                    index = j;
                    previous = cells[i][j].Type;
                    count = 1;
                    while (++index < size && previous == cells[i][index].Type)
                    {
                        count++;
                        if (count > 2)
                        {
                            return true;
                        }
                    }

                    index = j;
                    previous = cells[i][j].Type;
                    count = 1;
                    while (--index > -1 && previous == cells[i][index].Type)
                    {
                        count++;
                        if (count > 2)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public List<Combination> AllCombinations()
        {
            List<Combination> combinations = new List<Combination>();
            int index = 0;
            CellType previous = CellType.Default;
            int count = 0;
            Combination currCombination = new Combination();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    index = i;
                    previous = cells[i][j].Type;
                    count = 1;
                    currCombination = new Combination();
                    currCombination.combination.Add(new Position(i, j));

                    while (++index < size && previous == cells[index][j].Type)
                    {
                        currCombination.combination.Add(new Position(index, j));
                        count++;
                    }

                    if (count > 2 && !combinations.Contains(currCombination))
                    {
                        combinations.Add(currCombination);
                    }

                    index = i;
                    previous = cells[i][j].Type;
                    count = 1;
                    currCombination = new Combination();
                    currCombination.combination.Add(new Position(i, j));

                    while (--index > -1 && previous == cells[index][j].Type)
                    {
                        currCombination.combination.Add(new Position(index, j));
                        count++;
                    }

                    if (count > 2 && !combinations.Contains(currCombination))
                    {
                        combinations.Add(currCombination);
                    }

                    index = j;
                    previous = cells[i][j].Type;
                    count = 1;
                    currCombination = new Combination();
                    currCombination.combination.Add(new Position(i, j));

                    while (++index < size && previous == cells[i][index].Type)
                    {
                        currCombination.combination.Add(new Position(i, index));
                        count++;
                    }

                    if (count > 2 && !combinations.Contains(currCombination))
                    {
                        combinations.Add(currCombination);
                    }

                    index = j;
                    previous = cells[i][j].Type;
                    count = 1;
                    currCombination = new Combination();
                    currCombination.combination.Add(new Position(i, j));

                    while (--index > -1 && previous == cells[i][index].Type)
                    {
                        currCombination.combination.Add(new Position(i, index));
                        count++;
                    }

                    if (count > 2 && !combinations.Contains(currCombination))
                    {
                        combinations.Add(currCombination);
                    }
                }
            }

            return ConcatCombinations(combinations);
        }

        public List<Combination> ConcatCombinations(List<Combination> combinations)
        {
            for (int i = 0; i < combinations.Count; i++)
            {
                for (int j = 0; j < combinations.Count; j++)
                {
                    if (combinations[i].combination.Intersect(combinations[j].combination).Count() != 0 && i != j)
                    {
                        combinations[i].combination = combinations[i].combination.Concat(combinations[j].combination)
                            .Distinct().ToList();
                        combinations[j].combination = new List<Position>();
                    }
                }
            }

            for (int i = 0; i < combinations.Count;)
            {
                if (combinations[i].Length == 0)
                {
                    combinations.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            return combinations;
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

        public void Move(Position p1, Position p2)
        {
            var mem = cells[p1.Row][p1.Column];
            cells[p1.Row][p1.Column] = cells[p2.Row][p2.Column];
            cells[p2.Row][p2.Column] = mem;

            if (!HasCombinations())
            {
                mem = cells[p1.Row][p1.Column];
                cells[p1.Row][p1.Column] = cells[p2.Row][p2.Column];
                cells[p2.Row][p2.Column] = mem;
            }
            else do
                {
                    var allCombo = AllCombinations();
                    
                    foreach(var combo in allCombo)
                    {
                        int score = RemoveAndFill(combo);
                    }
                }
                while (HasCombinations());
        }

        private int RemoveAndFill(Combination combo)
        {
            int score = combo.Length * cells[combo.combination[0].Row][combo.combination[0].Column].Damage;

            List<Position> empty = new List<Position>();

            if (combo.Length < 5)
            {
                if (combo.combination[0].Column == combo.combination[1].Column)
                {
                    int index = 0;
                    foreach (var element in combo.combination)
                    {
                        if (element.Column > index) index = element.Row;
                    }

                    for (int i = index; i > combo.Length-1; i--)
                    {
                        cells[i][combo.combination[1].Column] = cells[i- combo.Length][combo.combination[1].Column];
                    }

                    for (int i = combo.Length - 1; i>=0; i--)
                    {
                        cells[i][combo.combination[1].Column] = factory.createCell(new List<CellType>());
                    }
                } else
                {
                    int index = 0;
                    foreach (var element in combo.combination)
                    {
                        if (element.Row > index) index = element.Row;
                    }

                    for (int i = index; i > combo.Length - 1; i--)
                    {
                        cells[combo.combination[1].Row][i] = cells[combo.combination[1].Row][i - combo.Length];
                    }

                    for (int i = combo.Length - 1; i >= 0; i--)
                    {
                        cells[combo.combination[1].Row][1] = factory.createCell(new List<CellType>());
                    }
                }
            } else
            {

            }
            return score;
        }
    }
}
