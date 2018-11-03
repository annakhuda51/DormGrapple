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
        private int size;

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

        public void SetField()
        {
            CellsFactory factory = new CellsFactory();

            for (int i = 1; i < size/2; i++)
            {
                for (int j = i-1; j < size-i+1; j++)
                {
                    ICell cell = factory.createCell(checkSell(i-1, j));
                    cells[i - 1][j] = cell;
                }
                for (int j = i; j < size-i+1; j++)
                {
                    ICell cell = factory.createCell(checkSell(j, size-i));
                    cells[j][size-i] = cell;
                }
                for (int j = size-i-1; j>=i-1; --j)
                {
                    ICell cell = factory.createCell(checkSell(size-i, j));
                    cells[size-i][j] = cell;
                }
                for (int j = size-i-1; j>=i; j--)
                {
                    ICell cell = factory.createCell(checkSell(j, i-1));
                    cells[j][i-1] = cell;
                }
            }
        }

        public List<CellType> checkSell(int i, int j)
        {
            List<CellType> list = new List<CellType>();

            if (i > 2 && cells[i - 1][j].type != CellType.Default && cells[i - 2][j].type != CellType.Default && cells[i - 1][j].type == cells[i - 2][j].type) list.Add(cells[i - 1][j].type);
            if (j > 2 && cells[i][j - 1].type != CellType.Default && cells[i][j-2].type != CellType.Default && cells[i][j - 1].type == cells[i][j-2].type) list.Add(cells[i][j - 1].type);
            if (i < size - 2 && cells[i + 1][j].type!= CellType.Default && cells[i + 2][j].type != CellType.Default && cells[i + 1][j].type == cells[i + 2][j].type) list.Add(cells[i + 1][j].type);
            if (j < size - 2 && cells[i][j + 1].type!= CellType.Default && cells[i][j + 2].type != CellType.Default && cells[i][j + 1].type == cells[i][j + 2].type) list.Add(cells[i][j + 1].type);
            return list;
        }
        
    }
}
