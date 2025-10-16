using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 10, 5), 30, 4.8),
            new Cycling(new DateTime(2025, 10, 4), 45, 20.0),
            new Swimming(new DateTime(2025, 10, 3), 25, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}