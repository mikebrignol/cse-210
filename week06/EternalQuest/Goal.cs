using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;
    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }


    public string GetTitle() => _title;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public abstract int RecordEvent();

    public abstract string GetStringRepresentation();
    public virtual string GetDetailsString()
    {
        return $"{_title} ({_description})";
    }

}