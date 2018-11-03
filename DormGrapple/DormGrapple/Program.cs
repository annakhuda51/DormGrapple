using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormGrapple
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            field.SetField();
            field.Show();

            Console.ReadKey();
        }
    }
}
