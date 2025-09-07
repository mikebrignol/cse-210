using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string input = Console.ReadLine();

        if (double.TryParse(input, out double grade))
        {
            char letterGrade;

            if (grade >= 90)
                letterGrade = 'A';
            else if (grade >= 80)
                letterGrade = 'B';
            else if (grade >= 70)
                letterGrade = 'C';
            else if (grade >= 60)
                letterGrade = 'D';
            else
                letterGrade = 'F';

            Console.WriteLine($"Your letter grade is: {letterGrade}");
        }
        else
        {
            Console.WriteLine("Invalid input, Please enter a number.");
        }
    }
}