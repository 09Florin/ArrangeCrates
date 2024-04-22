using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crates
{
    internal class DisplayCrates
    {
        public static void DisplayStacksAndCrates(Dictionary<int, List<string>> stacks, int stacksNumber) {
            int maxStackSize = stacks.Values.Max(s => s?.Count ?? 0);
            for (int row = maxStackSize - 1; row >= 0; row--)
            {
                foreach (var kvp in stacks) // key-value pair in each stack
                {
                    string crate = (kvp.Value != null && kvp.Value.Count > row) ? kvp.Value[row] : " ";
                    Console.Write("[" + crate + "] ");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= stacksNumber; i++)
            {
                Console.Write(" " + i + "  ");
            }
        }

        public static void DisplayCratesToElves(Dictionary<int, List<string>> stacks, int stacksNumber) {
            for (int i = 1; i <= stacksNumber; i++) 
            {
                string crate = stacks[i][stacks[i].Count - 1];
                Console.Write("[" + crate + "] ");
            }
        }
    }
}
