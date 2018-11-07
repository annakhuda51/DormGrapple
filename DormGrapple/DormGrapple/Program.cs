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

            for (int i = 0; i < 20; i++)
            {
                Field field = new Field();
                field.SetField();
                field.Show();
                var countDictionary = field.CountEachTypeCell();

                var own0 = countDictionary.Where(pair => pair.Key.Own == 0).Sum(pair => pair.Value);
                var own1 = countDictionary.Where(pair => pair.Key.Own == 1).Sum(pair => pair.Value);
                var all = countDictionary.Sum(pair => pair.Value);

                foreach (var pair in countDictionary)
                {
                    if (pair.Key.Own == 0)
                    {
                        Console.WriteLine(pair.Key.Type + ": " + pair.Value + " - " +
                                          ((double) pair.Value / own0).ToString("F") + "%");
                    }

                    if (pair.Key.Own == 1)
                    {
                        Console.WriteLine(pair.Key.Type + ": " + pair.Value + " - " +
                                          ((double) pair.Value / own1).ToString("F") + "%");
                    }
                }


                Console.WriteLine(all + " " + own0);
                Console.WriteLine(all + " " + own1);
                Console.WriteLine();
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
