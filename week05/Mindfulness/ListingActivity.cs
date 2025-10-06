using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt spiritual peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing", "This activity helps you list good things in your life.")
    {
    }

    public override void Run()
    {
        StartMessage();

        Random rand = new Random();
        Console.WriteLine($"\nPrompt: {_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("Prepare to list items...");
        ShowCountdown(5);

        List<string> responses = new List<string>();
        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {responses.Count} items.");
        EndMessage();
    }
}
