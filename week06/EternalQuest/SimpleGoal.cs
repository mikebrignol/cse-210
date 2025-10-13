using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string title, string description, int points, bool isComplete = false)
        : base(title, description, points)
    {
        _isComplete = isComplete;
    }
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        else
        {
            return 0;
        }
    }

    public override string GetDetailsString()
    {
        string mark = _isComplete ? "X" : " ";
        return $"[{mark}] {GetTitle()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
       
        return $"Simple|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{(_isComplete ? 1 : 0)}";
    }

    private string Escape(string s) => s.Replace("|", "¦");
          
}