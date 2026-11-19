using System;

// This class represents a goal that must be completed a certain number of times.
public class ChecklistGoal : BaseGoal
{
    // Stores how many times the goal has been completed.
    private int _amountCompleted;

    // Stores the number of completions required.
    private int _targetAmount;

    // Stores the extra points awarded when the goal is finished.
    private int _bonus;

    // Creates a checklist goal and collects its additional information.
    public ChecklistGoal() : base()
    {
        Console.Write("How many times must this goal be completed? ");
        _targetAmount = int.Parse(Console.ReadLine());

        Console.Write("What is the bonus for completing the goal? ");
        _bonus = int.Parse(Console.ReadLine());
    }

    // Records one completion of the checklist goal.
    public override void RecordEvent()
    {
        // Only record progress if the goal is not complete.
        if (!IsComplete())
        {
            _amountCompleted++;

            // Start with the regular goal points.
            int totalPoints = GetPoints();

            // Add the bonus when the target is reached.
            if (IsComplete())
            {
                totalPoints += _bonus;
                Console.WriteLine(
                    $"You completed the checklist goal and earned {totalPoints} points!");
            }
            else
            {
                Console.WriteLine($"You earned {totalPoints} points!");
            }
        }
        else
        {
            // Prevent additional completions after the goal is finished.
            Console.WriteLine("This checklist goal is already complete.");
        }
    }

    // Checks whether the goal has reached its target amount.
    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    // Displays the checklist goal and its completion progress.
    public override string GetConsoleString()
    {
        string mark = IsComplete() ? "X" : " ";

        return $"[{mark}] Checklist Goal: {GetName()}, " +
               $"Description: {GetDescription()}, " +
               $"Completed {_amountCompleted}/{_targetAmount} times, " +
               $"Points: {GetPoints()}, Bonus: {_bonus}";
    }
}