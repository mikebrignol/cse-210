using System;

public class Word
{
    private string value;
    private bool hidden;

    public Word(string text)
    {
        value = text;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public string GetDisplayText()
    {
        return hidden ? new string('_', value.Length) : value;
    }
}