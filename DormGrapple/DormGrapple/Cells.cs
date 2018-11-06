using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public enum CellType
    {
        Apple = 0,
        Chip,
        Bacterium,
        Slipper,
        CockroachTrap,
        Poison,
        Default 
    }

    public interface ICell
    {
        CellType type { get; }
        int Damage { get; }
        double Percentage { get; }
        int Own { get; }
    }

    public class Cell : ICell
    {
        public CellType type
        {
            get => CellType.Default;
        }
        public int Damage { get => 0; }
        public double Percentage { get => 0; }
        public int Own { get => 0; }
    }

    public class Apple : ICell
    {
        public CellType type
        {
            get => CellType.Apple;
        }
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public int Own { get => 0; }
    }

    public class Chip : ICell
    {
        public CellType type
        {
            get => CellType.Chip;
        }
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public int Own { get => 0; }
    }

    public class Bacterium : ICell
    {
        public CellType type
        {
            get => CellType.Bacterium;
        }
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public int Own { get => 0; }
    }

    public class Slipper : ICell
    {
        public CellType type
        {
            get => CellType.Slipper;
        }
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public int Own { get => 1; }
    }

    public class CockroachTrap : ICell
    {
        public CellType type
        {
            get => CellType.CockroachTrap;
        }
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public int Own { get => 1; }
    }

    public class Poison : ICell
    {
        public CellType type
        {
            get => CellType.Poison;
        }
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public int Own { get => 1; }
    }

    public class CellsFactory
    {

        Random rand = new Random();

        public ICell createCell(List<CellType> disables)
        {
            ICell cell;
            do
            {
                int type = rand.Next(0, 6);
                switch (type)
                {
                    case 0:
                        cell = new Apple();
                        break;
                    case 1:
                        cell = new Chip();
                        break;
                    case 2:
                        cell = new Bacterium();
                        break;
                    case 3:
                        cell = new Slipper();
                        break;
                    case 4:
                        cell = new CockroachTrap();
                        break;
                    case 5: cell = new Poison(); 
                        break;
                    default: cell = new Cell(); 
                        break;
                }

            } while (disables.Contains(cell.type));

            return cell;
        }
    }
}
