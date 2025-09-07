using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int maicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != maicNumber)
        {
            Console.Write("what is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (maicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (maicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You Guessed it");
            }
        }
    }
}