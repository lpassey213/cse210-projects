using System;

namespace EternalQuest;

public class Program
{
    public static void Main()
    {
        Goals goals = new();
        bool running = true;

        // Creativity: the program displays the player's level and gives a title
        // based on the score, making progress feel more like a game.
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {goals.Score} points.");
            Console.WriteLine($"Level: {GetLevel(goals.Score)} - {GetTitle(goals.Score)}");
            Console.WriteLine("Menu options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    goals.DisplayGoals();
                    break;
                case "3":
                    Console.Write("Enter a filename: ");
                    goals.Save(Console.ReadLine() ?? "goals.txt");
                    Console.WriteLine("Goals saved.");
                    break;
                case "4":
                    Console.Write("Enter a filename: ");
                    goals.Load(Console.ReadLine() ?? "goals.txt");
                    Console.WriteLine("Goals loaded.");
                    break;
                case "5":
                    goals.DisplayGoals();
                    Console.Write("Which goal did you accomplish? ");
                    if (int.TryParse(Console.ReadLine(), out int goalNumber))
                    {
                        goals.RecordEvent(goalNumber);
                    }
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    private static void CreateGoal(Goals goals)
    {
        Console.WriteLine("Goal types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Select a goal type: ");
        string type = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "Unnamed goal";
        Console.Write("What is a short description? ");
        string description = Console.ReadLine() ?? "";
        int points = ReadInt("What is the amount of points for this goal? ");

        switch (type)
        {
            case "1":
                goals.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = ReadInt("How many times must this goal be completed? ");
                int bonus = ReadInt("What is the bonus for completing it? ");
                goals.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;