using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Start
    {
        static void Main(string[] args)
        {
            StratProject();

        }
        private static void StratProject()
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //
            Stack<int> bottle = new Stack<int>(filledBottle);
            Queue<int> cups = new Queue<int>(cupsCapacity);

            var countIterate = bottle.Count > cups.Count ? cups.Count : bottle.Count;
            var sum = 0;

            for (int i = 0; i < countIterate; i++)
            {
                var tempB = bottle.Pop();
                var tempC = cups.Dequeue();
                if (tempB > tempC)
                {
                    sum += (tempB - tempC);
                }
            }

            var check = bottle.Count > 0 ? 0 : 1;
            if (check == 0)
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottle));
            }
            else
            {
                Console.WriteLine("Cups: " + string.Join(" ", cups));

            }
            Console.WriteLine("Wasted litters of water: " + sum);
        }
    }
}
