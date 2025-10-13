using System;

public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string title, string description, int points, int requiredCount, int currentCount, int bonusPoints)
        : base(title, description, points)
    {
        _requiredCount = requiredCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _requiredCount)
        {
         
            return 0;
        }

        _currentCount++;
        int earned = GetPoints();

        if (_currentCount == _requiredCount)
        {
           
            earned += _bonusPoints;
        }

        return earned;
    }

    public override string GetDetailsString()
    {
        string mark = (_currentCount >= _requiredCount) ? "X" : " ";
        return $"[{mark}] {GetTitle()} ({GetDescription()}) -- Completed {_currentCount}/{_requiredCount}";
    }

    public override string GetStringRepresentation()
    {
       
        return $"Checklist|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_requiredCount}|{_currentCount}|{_bonusPoints}";
    }

    private string Escape(string s) => s.Replace("|", "¦");
}