namespace EternalQuest;

public class ChecklistGoal : BaseGoal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetAmount,
        int bonus,
        int amountCompleted = 0)
        : base(name, description, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        int earned = Points;

        if (IsComplete())
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _targetAmount;

    public override string GetDetailsString()
    {
        string mark = IsComplete() ? "X" : " ";
        return $"[{mark}] {Name} ({Description}) -- Completed {_amountCompleted}/{_targetAmount} times";
    }

    public override string GetSaveString()
    {
        return $"Checklist~{GetBasicSaveData()}|{_targetAmount}|{_bonus}|{_amountCompleted}";
    }
}

