using System;

public class Program
{
    public static void Main()
    {
        // Create an object to manage all of the user's goals and score.
        Goals goals = new Goals();

        // This controls whether the menu continues to display.
        bool running = true;

        while (running)
        {
            // Display the user's current score.
            Console.WriteLine();
            Console.WriteLine($"You have {goals.GetScore()} points.");

            // Display the menu options.
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            // Run the action selected by the user.
            switch (choice)
            {
                case "1":
                    // Create a new goal.
                    goals.CreateGoal();
                    break;

                case "2":
                    // Display all existing goals.
                    goals.DisplayGoals();
                    break;

                case "3":
                    // Record progress on a goal and add points.
                    goals.RecordEvent();
                    break;

                case "4":
                    // Stop the program.
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    // Handle an invalid menu selection.
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}