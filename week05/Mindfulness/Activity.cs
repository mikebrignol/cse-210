using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;


    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.Write("\nGreat Job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
    }

    public int GetDuration() => _duration;

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b\b");
            i ++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }

    public abstract void Run();
}