using System;

public class EternalGoal : BaseGoal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"You earned {GetPoints()} points!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetConsoleString()
    {
        return $"[ ] Eternal Goal: {GetName()}, " +
               $"Description: {GetDescription()}, Points: {GetPoints()}";
    }
}