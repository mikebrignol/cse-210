class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    public ReflectionActivity()
    : base("Reflection Activity",
    "This activity helps you reflect on moments of strength and resilience.") {}

    public override void Run()
    {
        StartMessage();
        int duration = GetDuration();
        Random rand = new Random();

        Console.WriteLine($"\nPrompt: {_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("Reflect on the following questions...");
        ShowSpinner(3);

        List<string> shuffled = new List<string>(_questions);
        shuffled = shuffled.OrderBy(x => rand.Next()).ToList();

        DateTime end = DateTime.Now.AddSeconds(duration);
        int index = 0;

        while (DateTime.Now < end && index < shuffled.Count)
        {
            Console.WriteLine($"\n> {shuffled[index]}");
            ShowSpinner(5);
            index++;
        }

        EndMessage();
    }
}