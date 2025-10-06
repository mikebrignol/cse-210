// Tweaked my Reflection Activity so that a question is not asked more than once per run.

using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") new BreathingActivity().Run();
            else if (choice == "2") new ReflectionActivity().Run();
            else if (choice == "3") new ListingActivity().Run();
            else if (choice == "4") break;
        }
    }
}