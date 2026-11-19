using System;

// This class represents a goal that can only be completed once.
public class SimpleGoal : BaseGoal
{
    // Keeps track of whether the goal has been completed.
    private bool _complete = false;

    // Records the goal as complete and gives the user points.
    public override void RecordEvent()
    {
        if (!_complete)
        {
            _complete = true;
            Console.WriteLine($"You earned {GetPoints()} points!");
        }
        else
        {
            // Prevents the user from earning points more than once.
            Console.WriteLine("This goal has already been completed.");
        }
    }

    // Returns whether the goal has been completed.
    public override bool IsComplete()
    {
        return _complete;
    }

    // Displays the goal with an X if it is complete.
    public override string GetConsoleString()
    {
        string mark = _complete ? "X" : " ";

        return $"[{mark}] Simple Goal: {GetName()}, " +
               $"Description: {GetDescription()}, Points: {GetPoints()}";
    }
}