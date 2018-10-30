﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public interface Cell
    {
        int Damage { get; }
        double Percentage { get; }
        int Own { get; }
    }

    public class Apple : Cell
    {
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public int Own { get => 0; }
    }

    public class Chip : Cell
    {
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public int Own { get => 0; }
    }

    public class Bacterium : Cell
    {
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public int Own { get => 0; }
    }

    public class Slipper : Cell
    {
        public int Damage { get => 3; }
        public double Percentage { get => 0.4; }
        public int Own { get => 1; }
    }

    public class CockroachTrap : Cell
    {
        public int Damage { get => 5; }
        public double Percentage { get => 0.35; }
        public int Own { get => 1; }
    }

    public class Poison : Cell
    {
        public int Damage { get => 7; }
        public double Percentage { get => 0.25; }
        public int Own { get => 1; }
    }
}