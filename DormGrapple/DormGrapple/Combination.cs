using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    public class Combination : IEquatable<Combination>
    {
        public List<Position> combination;

        public int Length
        {
            get => combination.Count;
        }

        public Combination()
        {
            combination = new List<Position>();
        }

        public Combination(List<Position> newCombination)
        {
            combination = new List<Position>();

            foreach (var position in newCombination)
            {
                combination.Add(new Position(position.Row, position.Column));
            }
        }

        public bool Equals(Combination other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var lengthComparison = Length.Equals(other.Length);
            if (!lengthComparison) return lengthComparison;
            for (int i = 0; i < Length; i++)
            {
                var elementComparison = combination[i].Equals(other.combination[i]);
                if (!elementComparison) return elementComparison;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Combination) obj);
        }

        public override int GetHashCode()
        {
            return (combination != null ? combination.GetHashCode() : 0);
        }

        public override string ToString()
        {
            var result = "";
            foreach (var elem in combination)
            {
                result += "(" + (elem.Row+1) + ", " + (elem.Column+1) + ") ";
            }
            return result;
        }
    }
}
