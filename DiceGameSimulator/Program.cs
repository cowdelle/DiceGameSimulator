//Section 3
//Elley Cowdell
//Simulates the rolling of two 6-sided dice. Each * represents 1% of the total rolls.
using System;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");

        if (int.TryParse(Console.ReadLine(), out int numRolls) && numRolls > 0)
        {
            int[] results = DiceRoller.SimulateRolls(numRolls);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numRolls}.\n");

            for (int i = 2; i <= 12; i++)
            {
                int percentage = results[i] * 100 / numRolls;
                string asterisks = new string('*', percentage);
                Console.WriteLine($"{i}: {asterisks} ({percentage}%)");
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of rolls.");
        }
    }
}

class DiceRoller
{
    private static readonly Random random = new Random();

    public static int[] SimulateRolls(int numRolls)
    {
        int[] results = new int[13]; // Indices 2 through 12 represent possible dice combinations

        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);

            results[dice1 + dice2]++;
        }

        return results;
    }
}
