// I gave the user the possibility to wipe the file where his goals are saved

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine();
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals to file");
            Console.WriteLine("4. Load goals from file");
            Console.WriteLine("5. Record event (complete a goal)");
            Console.WriteLine("6. Show score");
            Console.WriteLine("7. Wipe goals file");
            Console.WriteLine("q. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "q") break;

            switch (choice)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    ListGoals();
                    Pause();
                    break;
                case "3":
                    SaveGoals();
                    Pause();
                    break;
                case "4":
                    LoadGoals();
                    Pause();
                    break;
                case "5":
                    RecordEvent();
                    Pause();
                    break;
                case "6":
                    Console.WriteLine($"Your current score is: {_score}");
                    Pause();
                    break;
                case "7":
                    DeleteGoalsFromFile();
                    Pause();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoalMenu()
    {
        Console.Clear();
        Console.WriteLine("Create a new goal:");
        Console.WriteLine("1. Simple goal (one-time)");
        Console.WriteLine("2. Eternal goal (repeatable)");
        Console.WriteLine("3. Checklist goal (complete N times)");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine()?.Trim();

        Console.Write("Title: ");
        string title = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Description: ");
        string desc = Console.ReadLine()?.Trim() ?? "";

        int points = ReadInt("Points awarded:");

        if (type == "1")
        {
            var g = new SimpleGoal(title, desc, points, false);
            _goals.Add(g);
            Console.WriteLine("Simple goal created.");
        }
        else if (type == "2")
        {
            var g = new EternalGoal(title, desc, points);
            _goals.Add(g);
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == "3")
        {
            int required = ReadInt("How many times required to complete?");
            int bonus = ReadInt("Bonus points when completed:");
            var g = new ChecklistGoal(title, desc, points, required, 0, bonus);
            _goals.Add(g);
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown type.");
        }
    }

    static void ListGoals()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save to (e.g. mygoals.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
            
                writer.WriteLine($"Score:{_score}");
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine("Saved.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error saving file: " + e.Message);
        }
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g. mygoals.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = 0;

            foreach (string line in lines)
            {
                if (line.StartsWith("Score:"))
                {
                    var part = line.Substring(6);
                    if (int.TryParse(part, out int s)) _score = s;
                    continue;
                }

                var goal = ParseGoalFromString(line);
                if (goal != null) _goals.Add(goal);
            }

            Console.WriteLine("Loaded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading file: " + e.Message);
        }
    }

    static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoals();
        int index = ReadInt("Enter the number of the goal you completed: ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        var g = _goals[index];
        int gained = g.RecordEvent();
        if (gained > 0)
        {
            _score += gained;
        }
        else
        {
            Console.WriteLine("No points awarded (goal may already be complete).");
        }
    }

    static Goal ParseGoalFromString(string line)
    {

        string[] parts = line.Split('|');
        for (int i = 0; i < parts.Length; i++)
            parts[i] = parts[i].Replace("¦", "|");

        if (parts.Length == 0) return null;

        string type = parts[0];
        try
        {
            if (type == "Simple" && parts.Length >= 5)
            {
                string title = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = parts[4] == "1";
                return new SimpleGoal(title, desc, points, isComplete);
            }
            else if (type == "Eternal" && parts.Length >= 4)
            {
                string title = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                return new EternalGoal(title, desc, points);
            }
            else if (type == "Checklist" && parts.Length >= 7)
            {
                string title = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int required = int.Parse(parts[4]);
                int current = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);
                return new ChecklistGoal(title, desc, points, required, current, bonus);
            }
        }
        catch
        {

        }
        return null;
    }

    static void DeleteGoalsFromFile()
    {
        Console.Write("Enter the filename to delete goals from (e.g. mygoals.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Console.WriteLine("Are you sure you want to delete all saved goals in this file? (y/n)");
        string confirm = Console.ReadLine()?.Trim().ToLower();

        if (confirm == "y")
        {
            try
            {
                File.WriteAllText(filename, "");  // Clears the file contents
                Console.WriteLine("All goals have been deleted from the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting goals: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Deletion cancelled.");
        }
    }

  
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int val)) return val;
            Console.WriteLine("Please enter a valid number.");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

}