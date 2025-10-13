using System;

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
      
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        return $"[~] {GetTitle()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
       
        return $"Eternal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}";
    }

    private string Escape(string s) => s.Replace("|", "¦");
}