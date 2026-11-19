using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest;

public class Goals
{
    private readonly List<BaseGoal> _goals = new();
    private int _score;
    public int Score => _score;
    public void AddGoal(BaseGoal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int goalNumber)
    {
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("That goal number is not valid.");
            return;
        }

        int earned = _goals[goalNumber - 1].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points. Your score is now {_score}.");
    }

    public void Save(string filename)
    {
        using StreamWriter output = new(filename);
        output.WriteLine(_score);

        foreach (BaseGoal goal in _goals)
        {
            output.WriteLine(goal.GetSaveString());
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("The save file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            BaseGoal? goal = CreateGoalFromString(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
    }

    private static BaseGoal? CreateGoalFromString(string line)
    {
        string[] parts = line.Split('~');
        if (parts.Length < 2)
        {
            return null;
        }

        string type = parts[0];
        string[] data = parts[1].Split('|');

        try
        {
