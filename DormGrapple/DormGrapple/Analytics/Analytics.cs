using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public static class Analytics
    {
        public static bool HasMoves(List<List<ICell>> cells)
        {
            int size = cells.Count;
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
                        if (j > 1)
                        {
                            if (i > 0 && cells[j - 2][i - 1].Type == previous) return true;
                            if (i < size - 1 && cells[j - 2][i + 1].Type == previous) return true;
                            if (j > 2 && cells[j - 3][i].Type == previous) return true;
                        }

                        if (j < size - 1)
                        {
                            if (i > 0 && cells[j + 1][i - 1].Type == previous) return true;
                            if (i < size - 1 && cells[j + 1][i + 1].Type == previous) return true;
                            if (j < size - 2 && cells[j + 2][i].Type == previous) return true;
                        }
                    }
                }

                previous = CellType.Default;
                for (int j = 0; j < size - 1; j++)
                {
                    if (cells[i][j + 1].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count == 2)
                    {
                        if (i > 0 && cells[i - 1][j].Type == previous) return true;
                        if (i < size - 1 && cells[i + 1][j].Type == previous) return true;
                    }

                    previous = cells[i][j].Type;
                }

                previous = CellType.Default;
                for (int j = 0; j < size - 1; j++)
                {
                    if (cells[j + 1][i].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count == 2)
                    {
                        if (i > 0 && cells[j][i - 1].Type == previous) return true;
                        if (i < size - 1 && cells[j][i + 1].Type == previous) return true;
                    }

                    previous = cells[j][i].Type;
                }
            }

            return false;
        }

        public static List<Combination> AllMoves(List<List<ICell>> cells)
        {
            List<Combination> moves = new List<Combination>();
            int size = cells.Count;
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
                            if (i > 0 && cells[i - 1][j - 2].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i - 1, j - 2));
                                currentMove.combination.Add(new Position(i, j - 2));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (i < size - 1 && cells[i + 1][j - 2].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i + 1, j - 2));
                                currentMove.combination.Add(new Position(i, j - 2));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (j > 2 && cells[i][j - 3].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i, j - 3));
                                currentMove.combination.Add(new Position(i, j - 2));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }
                        }

                        if (j < size - 1)
                        {
                            if (i > 0 && cells[i - 1][j + 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i - 1, j + 1));
                                currentMove.combination.Add(new Position(i, j + 1));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (i < size - 1 && cells[i + 1][j + 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i + 1, j + 1));
                                currentMove.combination.Add(new Position(i, j + 1));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (j < size - 2 && cells[i][j + 2].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(i, j + 2));
                                currentMove.combination.Add(new Position(i, j + 1));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }
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

                        if (j > 1)
                        {
                            if (i > 0 && cells[j - 2][i - 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j - 2, i - 1));
                                currentMove.combination.Add(new Position(j - 2, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (i < size - 1 && cells[j - 2][i + 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j - 2, i + 1));
                                currentMove.combination.Add(new Position(j - 2, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (j > 2 && cells[j - 3][i].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j - 3, i));
                                currentMove.combination.Add(new Position(j - 2, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }
                        }

                        if (j < size - 1)
                        {
                            if (i > 0 && cells[j + 1][i - 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j + 1, i - 1));
                                currentMove.combination.Add(new Position(j + 1, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (i < size - 1 && cells[j + 1][i + 1].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j + 1, i + 1));
                                currentMove.combination.Add(new Position(j + 1, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }

                            if (j < size - 2 && cells[j + 2][i].Type == previous)
                            {
                                Combination currentMove = new Combination();

                                currentMove.combination.Add(new Position(j + 2, i));
                                currentMove.combination.Add(new Position(j + 1, i));

                                if (!moves.Contains(currentMove)) moves.Add(currentMove);
                            }
                        }
                    }
                }

                previous = CellType.Default;
                for (int j = 0; j < size - 1; j++)
                {
                    if (cells[i][j + 1].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count == 2)
                    {
                        if (i > 0 && cells[i - 1][j].Type == previous)
                        {
                            Combination currentMove = new Combination();

                            currentMove.combination.Add(new Position(i - 1, j));
                            currentMove.combination.Add(new Position(i, j));

                            if (!moves.Contains(currentMove)) moves.Add(currentMove);
                        }

                        if (i < size - 1 && cells[i + 1][j].Type == previous)
                        {
                            Combination currentMove = new Combination();

                            currentMove.combination.Add(new Position(i + 1, j));
                            currentMove.combination.Add(new Position(i, j));

                            if (!moves.Contains(currentMove)) moves.Add(currentMove);
                        }
                    }

                    previous = cells[i][j].Type;
                }

                previous = CellType.Default;
                for (int j = 0; j < size - 1; j++)
                {
                    if (cells[j + 1][i].Type == previous)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count == 2)
                    {
                        if (i > 0 && cells[j][i - 1].Type == previous)
                        {
                            Combination currentMove = new Combination();

                            currentMove.combination.Add(new Position(j, i - 1));
                            currentMove.combination.Add(new Position(j, i));

                            if (!moves.Contains(currentMove)) moves.Add(currentMove);
                        }

                        if (i < size - 1 && cells[j][i + 1].Type == previous)
                        {
                            Combination currentMove = new Combination();

                            currentMove.combination.Add(new Position(j, i + 1));
                            currentMove.combination.Add(new Position(j, i));

                            if (!moves.Contains(currentMove)) moves.Add(currentMove);
                        }
                    }

                    previous = cells[j][i].Type;
                }
            }

            return moves;
        }

        public static bool HasCombinations(List<List<ICell>> cells)
        {
            int size = cells.Count;
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

        public static List<Combination> AllCombinations(List<List<ICell>> cells)
        {
            int size = cells.Count;
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

            return ConcatCombinations(combinations, cells);
        }

        public static List<Combination> ConcatCombinations(List<Combination> combinations, List<List<ICell>> cells)
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
    }
}
