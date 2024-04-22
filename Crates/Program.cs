using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stacksNumber;

            Console.WriteLine("Hello! So how many stacks of crates are we talking about today?");
            stacksNumber = Convert.ToInt32(Console.ReadLine());

            if (stacksNumber > 1)
            {
                Dictionary<int, List<string>> stacks = new Dictionary<int, List<string>>();
                int cratesNumberPerStack;

                for (int i = 1; i <= stacksNumber; i++)
                {
                    stacks.Add(i, new List<string>());
                    Console.WriteLine("Now tell me the how many crates there are in the stack number " + i);
                    cratesNumberPerStack = Convert.ToInt32(Console.ReadLine());
                    string crateLetter;

                    if (cratesNumberPerStack > 0)
                    {
                        Console.WriteLine("Insert from the bottom to the top of the stack each crate. Remember that each crate is represented by only one letter");

                        for (int j = 1; j <= cratesNumberPerStack; j++)
                        {
                            crateLetter = Console.ReadLine();
                            if (crateLetter.Length == 1)
                            {
                                stacks[i].Add(crateLetter);
                            }
                            else
                            {
                                Console.WriteLine("Please insert a single letter for each crate");
                                j--;
                            }
                        }
                    }
                    else
                    {
                        stacks[i] = new List<string>(); // Initialize an empty list to represent an empty stack
                    }
                }

                DisplayCrates.DisplayStacksAndCrates(stacks, stacksNumber);

                bool stopRearranging = false;

                Console.WriteLine("\nOperate the crane and switch the crates as you wish! But take care, you can move only one crate at a time and that is the top crate of a stack.");
                Console.WriteLine("\nTo move a crate simply insert the stack the crate is in right now, then the stack where the crate will be moved");
                Console.WriteLine("For example 1 4 will move the first crate from stack 1 to stack 4");
                Console.WriteLine("You can stop rearranging the crates whenever you want, just press X");

                while (!stopRearranging)
                {
                    string input = Console.ReadLine().Trim();


                    switch (input.ToUpper())
                    {
                        case "X":
                            stopRearranging = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            DisplayCrates.DisplayStacksAndCrates(stacks, stacksNumber);
                            Console.WriteLine("\nMessage for elves! Available crates:\n");
                            DisplayCrates.DisplayCratesToElves(stacks, stacksNumber);
                            Console.WriteLine("\nPress Enter to exit...");
                            Console.ReadLine(); // Wait for user to press Enter
                            break;
                        default:
                            string[] inputParts = input.Split(',');
                            if (inputParts.Length == 2)
                            {
                                int fromStack, toStack;
                                if (int.TryParse(inputParts[0], out fromStack) && int.TryParse(inputParts[1], out toStack))
                                {
                                    Crane.MoveCrate(stacks, stacksNumber, fromStack, toStack);
                                    DisplayCrates.DisplayStacksAndCrates(stacks, stacksNumber);
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input format. Please enter stack numbers separated by a comma.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input format. Please enter 2 numbers separated by a comma.\n");
                                break;
                            }
                            break;
                    }
                }

            }

            else if (stacksNumber == 0)
            {
                Console.WriteLine("Why did you even bother me if there are no stacks of crates to move?");
            }

            else if (stacksNumber == 1) 
            {
                Console.WriteLine("I think you can handle just 1 stack by yourself this time.");
            }
        }
    }
}
