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
            Field field = new Field(10);
            
            field.Show();
            Console.WriteLine(field.HasCombinations());
            var list = field.AllCombinations();
            foreach (var elem in list)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();
        }
    }
}
