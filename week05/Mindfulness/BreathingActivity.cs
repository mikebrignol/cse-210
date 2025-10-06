class BreathingActivity : Activity

{
    public BreathingActivity()
    : base("Breathing Activity",
    "This activity will help you relax by walking you through slow breathing") {}

    public override void Run()
    {
        StartMessage();
        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(4);
            Console.Write("\nBreathe out...");
            ShowCountdown(6);
        }

        EndMessage();
    }

}