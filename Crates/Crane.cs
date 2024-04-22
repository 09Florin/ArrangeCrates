using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crates
{
    internal class Crane
    {
        public static void MoveCrate(Dictionary<int, List<string>> stacks, int stacksNumber, int currentStack, int nextStack)
        {
            if (currentStack > stacksNumber || nextStack > stacksNumber || currentStack == nextStack)
            {
                Console.WriteLine("\nPlease insert a valid operation\n");
                return;
            }


            if (stacks[currentStack].Count == 0)
            {
                Console.WriteLine("\nThe source stack is empty. There are no crates to move.\n");
                return;
            }

            string crate = stacks[currentStack][stacks[currentStack].Count - 1];
            stacks[currentStack].RemoveAt(stacks[currentStack].Count - 1);
            stacks[nextStack].Add(crate);
        }
    }
}
