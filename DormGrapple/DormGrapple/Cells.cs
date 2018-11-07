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

    public enum Owner
    {
        Player = 0,
        Enemy
    }

    public interface ICell
    {
        CellType Type { get; }
        int Damage { get; }
        double Percentage { get; }
        Owner Owner { get; }
    }

    public class Cell : ICell
    {
        public CellType Type
        {
            get => CellType.Default;
        }
        public int Damage { get => 0; }
        public double Percentage { get => 0; }
        public Owner Owner { get => Owner.Player; }
    }

    public class Apple : ICell
    {
        public CellType Type
        {
            get => CellType.Apple;
        }
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public Owner Owner { get => Owner.Player; }
    }

    public class Chip : ICell
    {
        public CellType Type
        {
            get => CellType.Chip;
        }
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public Owner Owner { get => Owner.Player; }
    }

    public class Bacterium : ICell
    {
        public CellType Type
        {
            get => CellType.Bacterium;
        }
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public Owner Owner { get => Owner.Player; }
    }

    public class Slipper : ICell
    {
        public CellType Type
        {
            get => CellType.Slipper;
        }
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public Owner Owner { get => Owner.Enemy; }
    }

    public class CockroachTrap : ICell
    {
        public CellType Type
        {
            get => CellType.CockroachTrap;
        }
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public Owner Owner { get => Owner.Enemy; }
    }

    public class Poison : ICell
    {
        public CellType Type
        {
            get => CellType.Poison;
        }
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public Owner Owner { get => Owner.Enemy; }
    }

    public class CellsFactory
    {

        Random rand = new Random();

        public ICell createCell(List<CellType> disables)
        {
            ICell cell;
            do
            {
                int Type = rand.Next(0, 6);
                switch (Type)
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

            } while (disables.Contains(cell.Type));

            return cell;
        }
    }
}
