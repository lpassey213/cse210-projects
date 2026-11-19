using System;
using System.Collections.Generic;

// This class manages the user's goals and total score.
public class Goals
{
    // Stores all goals using the BaseGoal type.
    // This allows SimpleGoal, EternalGoal, and ChecklistGoal
    // to be stored in the same list.
    private List<BaseGoal> _goals = new List<BaseGoal>();

    // Stores the user's total points.
    private int _score = 0;

    // Allows the user to create a new goal.
    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        // Create the type of goal selected by the user.
        if (choice == "1")
        {
            _goals.Add(new SimpleGoal());
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal());
        }
        else if (choice == "3")
        {
            _goals.Add(new ChecklistGoal());
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    // Displays all of the goals in the list.
    public void DisplayGoals()
    {
        // Check whether the user has created any goals.
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        // Display each goal with its number.
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetConsoleString()}");
        }
    }

    // Records an event for one of the user's goals.
    public void RecordEvent()
    {
        // Make sure there is a goal to record.
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            return;
        }

        // Show the goals so the user can select one.
        DisplayGoals();

        Console.Write("Which goal did you complete? ");
        int choice = int.Parse(Console.ReadLine());

        // Check whether the selected goal number is valid.
        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        // Get the selected goal from the list.
        BaseGoal goal = _goals[choice - 1];

        // Add points depending on the type of goal.
        if (goal is SimpleGoal && !goal.IsComplete())
        {
            _score += goal.GetPoints();
        }
        else if (goal is EternalGoal)
        {
            _score += goal.GetPoints();
        }
        else if (goal is ChecklistGoal && !goal.IsComplete())
        {
            _score += goal.GetPoints();
        }

        // Use polymorphism to run the correct RecordEvent method.
        goal.RecordEvent();

        // Display the updated score.
        Console.WriteLine($"Your total score is {_score} points.");
    }

    // Returns the user's current score.
    public int GetScore()
    {
        return _score;
    }
}