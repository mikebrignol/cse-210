using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn Python in 2hrs", "Mike", 7200);
        Video video2 = new Video("How to make Haitian Pate", "Chef Edeline", 734);
        Video video3 = new Video("Thank You Ronaldo", "Real Madrid", 320);

        video1.AddComment(new Comment("Tharmara", "Three years ago, I viewed this video,and now,I hold the position of Sr.Python developer. Gratitude to Mosh for the guidance."));
        video1.AddComment(new Comment("Codingmadeclear", "This guy, sat for 2 hours and talked about python, and then released it for free. legend"));
        video1.AddComment(new Comment("Albolvo", "I have decided to learn coding so I can improve my status in life.  I'm tired of being a laborer, unskilled and uneducated.  Today I take control of my life.  Thank you!"));

        video2.AddComment(new Comment("Gonaives", "Thank you very much!! Seems easy enough, m’pral boule Kay la till I get it right."));
        video2.AddComment(new Comment("Celstany", "How long do you keep it in the oven? Thanks for sharing."));
        video2.AddComment(new Comment("Samanta", "What degree do you put it inside the oven ?"));

        video3.AddComment(new Comment("Kmz", "LaLiga will never be the same. Thank you Cristiano and Leo."));
        video3.AddComment(new Comment("Robi", "There should be a statue of him at the bernabeu"));
        video3.AddComment(new Comment("Overpowered", "After 7 years still breaks heart 💔"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}