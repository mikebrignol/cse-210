using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();


    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment c)
    {
        comments.Add(c);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"\nAuthor: {Author}");
        Console.WriteLine($"\nLength: {LengthSeconds} seconds");
        Console.WriteLine($"\nComments: {GetCommentCount()}");

        foreach (Comment c in comments)
        {
            c.Display();
        }
    }
}
