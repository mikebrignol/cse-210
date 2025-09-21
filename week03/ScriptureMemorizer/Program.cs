using System;

class Program
{
    static void Main(string[] args)
    {
        Reference refObj = new Reference("Mormon",1, 6, 7);
        Scripture verse = new Scripture(refObj, "And it came to pass that I, being eleven years old, was carried by my father into the land southward, even to the land of Zarahemla. The whole face of the land had become covered with buildings, and the people were as numerous almost, as it were the sand of the sea.");

        Console.Clear();
        string command = "";

        while (command?.ToLower() != "quit" && !verse.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(verse.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit");
            command = Console.ReadLine();

            if (command?.ToLower() != "quit")
            {
                verse.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(verse.GetDisplayText());
        Console.WriteLine("\nIf all words are hidden or user quit, the program will end.");
    }
}