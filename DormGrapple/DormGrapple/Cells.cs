﻿using System;
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

        public int Damage
        {
            get => 0;
        }

        public double Percentage
        {
            get => 0;
        }

        public int Own
        {
            get => 0;
        }
    }

    public class Apple : ICell
    {
        public CellType Type
        {
            get => CellType.Apple;
        }

        public int Damage
        {
            get => 3;
        }

        public double Percentage
        {
            get => 0.4;
        }

        public int Own
        {
            get => 0;
        }
    }

    public class Chip : ICell
    {
        public CellType Type
        {
            get => CellType.Chip;
        }

        public int Damage
        {
            get => 5;
        }

        public double Percentage
        {
            get => 0.35;
        }

        public int Own
        {
            get => 0;
        }
    }

    public class Bacterium : ICell
    {
        public CellType Type
        {
            get => CellType.Bacterium;
        }

        public int Damage
        {
            get => 7;
        }

        public double Percentage
        {
            get => 0.25;
        }

        public int Own
        {
            get => 0;
        }
    }

    public class Slipper : ICell
    {
        public CellType Type
        {
            get => CellType.Slipper;
        }

        public int Damage
        {
            get => 3;
        }

        public double Percentage
        {
            get => 0.4;
        }

        public int Own
        {
            get => 1;
        }
    }

    public class CockroachTrap : ICell
    {
        public CellType Type
        {
            get => CellType.CockroachTrap;
        }

        public int Damage
        {
            get => 5;
        }

        public double Percentage
        {
            get => 0.35;
        }

        public int Own
        {
            get => 1;
        }
    }

    public class Poison : ICell
    {
        public CellType Type
        {
            get => CellType.Poison;
        }

        public int Damage
        {
            get => 7;
        }

        public double Percentage
        {
            get => 0.25;
        }

        public int Own
        {
            get => 1;
        }
    }

    public class CellsFactory
    {

        Random rand = new Random();

        public ICell createCell(List<CellType> disables, Dictionary<ICell, int> countDictionary)
        {
            var own0 = countDictionary.Where(pair => pair.Key.Own == 0).Sum(pair => pair.Value);
            var own1 = countDictionary.Where(pair => pair.Key.Own == 1).Sum(pair => pair.Value);
            var all = countDictionary.Sum(pair => pair.Value);
            if (all == 0)
                all = 1;
            List<Tuple<ICell, double>> defaultPercentageList = new List<Tuple<ICell, double>>();

            List<Tuple<ICell, double>> currentPercentageList = new List<Tuple<ICell, double>>();

            defaultPercentageList.Add(new Tuple<ICell, double>(new Apple(), new Apple().Percentage));
            defaultPercentageList.Add(new Tuple<ICell, double>(new Chip(), new Chip().Percentage));
            defaultPercentageList.Add(new Tuple<ICell, double>(new Bacterium(), new Bacterium().Percentage));
            defaultPercentageList.Add(new Tuple<ICell, double>(new Slipper(), new Slipper().Percentage));
            defaultPercentageList.Add(new Tuple<ICell, double>(new CockroachTrap(), new CockroachTrap().Percentage));
            defaultPercentageList.Add(new Tuple<ICell, double>(new Poison(), new Poison().Percentage));

            foreach (var elem in defaultPercentageList)
            {
                switch (elem.Item1.Own)
                {
                    case 0:
                        currentPercentageList.Add(new Tuple<ICell, double>(elem.Item1, elem.Item2 * Math.Pow(
                                                                                           (1.0 + (all * elem.Item2 / defaultPercentageList.Sum(tuple => tuple.Item2)
                                                                                                   - countDictionary.Where(pair => pair.Key.Type == elem.Item1.Type)
                                                                                                       .Sum(pair => pair.Value)) / all * 4), 5) *
                                                                                       Math.Pow((1.0 + ((double)all / 2 - own0) / all * 3), 2)));
                        break;
                    case 1:
                        currentPercentageList.Add(new Tuple<ICell, double>(elem.Item1,elem.Item2 * Math.Pow(
                                                                                          (1.0 + (all * elem.Item2 / defaultPercentageList.Sum(tuple => tuple.Item2)
                                                                                                  - countDictionary.Where(pair => pair.Key.Type == elem.Item1.Type)
                                                                                                      .Sum(pair => pair.Value)) / all * 4), 5) *
                                                                                      Math.Pow((1.0 + ((double)all / 2 - own1) / all * 3), 2)));
                        break;
                }
            }

            ICell cell = new Cell();
            do

            {
                double something = (rand.NextDouble() * currentPercentageList.Sum(elem => elem.Item2));
                double lowerBound = 0;
                int type = 0;
                for (int i = 0; i < currentPercentageList.Count; i++)
                {
                    if (something > lowerBound && something < (lowerBound + currentPercentageList[i].Item2))
                    {
                        type = i;
                        cell = currentPercentageList[i].Item1;
                        break;
                    }

                    lowerBound += currentPercentageList[i].Item2;
                }

            } while (disables.Contains(cell.Type));

            return cell;
        }
    }
}