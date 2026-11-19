using System;

// This is the base class for all types of goals.
public class BaseGoal
{
    // Private fields store the shared goal information.
    private string _name;
    private string _description;
    private int _points;

    // This constructor collects goal information from the user.
    public BaseGoal()
    {
        SetName();
        SetDescription();
        SetPoints();
    }

    // This constructor allows child classes to provide goal information.
    protected BaseGoal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Gets the name of the goal from the user.
    private void SetName()
    {
        Console.Write("What is the name of your goal: ");
        _name = Console.ReadLine();
    }

    // Gets the description of the goal from the user.
    private void SetDescription()
    {
        Console.Write($"What is the description of {_name} goal: ");
        _description = Console.ReadLine();
    }

    // Gets the number of points for the goal from the user.
    private void SetPoints()
    {
        Console.Write($"What are the points for {_name} goal: ");
        _points = int.Parse(Console.ReadLine());
    }

    // Returns the goal's name.
    public string GetName()
    {
        return _name;
    }

    // Returns the goal's description.
    public string GetDescription()
    {
        return _description;
    }

    // Returns the number of points for the goal.
    public int GetPoints()
    {
        return _points;
    }

    // This method can be overridden by child classes.
    public virtual void RecordEvent()
    {
    }

    // This method checks whether the goal is complete.
    public virtual bool IsComplete()
    {
        return false;
    }

    // Returns the goal information for display.
    public virtual string GetConsoleString()
    {
        return $"[ ] Goal Name: {_name}, Description: {_description}, Points: {_points}";
    }
}