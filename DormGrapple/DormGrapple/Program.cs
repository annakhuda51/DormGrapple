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
            Field field = new Field(20);
            bool test = false;
            for (int i = 0; i < 10000; i++)
            {
                field.SetField();
                if (field.HasCombinations())
                {
                    test = true;
                }
            }

            Field field1 = new Field(3);
            field1.Show();
            Console.WriteLine(field1.HasCombinations());
            Console.WriteLine(test);
            Console.ReadKey();
        }
    }
}
