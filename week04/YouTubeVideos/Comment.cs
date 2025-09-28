using System;


public class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
    
    public void Display()
    {
        Console.WriteLine($"  {Commenter}: {Text}");
    }
}