using System;

namespace EternalQuest;

public abstract class BaseGoal
{
    private string _name;
    private string _description;
    private int _points;

    protected BaseGoal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetSaveString();

    protected string GetBasicSaveData()
    {
        return $"{_name}|{_description}|{_points}";
    }

    protected static string Clean(string value)
    {
        return value.Replace("|", "/").Replace("~", "-");
    }
}
