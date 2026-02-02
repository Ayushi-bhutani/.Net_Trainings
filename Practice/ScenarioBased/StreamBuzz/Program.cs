using System;
using System.Collections.Generic;

namespace streambuzz
{
    // Model class
    public class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }

    public class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var creator in records)
            {
                int count = 0;

                foreach (var likes in creator.WeeklyLikes)
                {
                    if (likes >= likeThreshold)
                        count++;
                }

                if (count > 0)
                    result.Add(creator.CreatorName, count);
            }

            return result;
        }

        public double CalculateAverageLikes()
        {
            double total = 0;
            int count = 0;

            foreach (var creator in EngagementBoard)
            {
                foreach (var likes in creator.WeeklyLikes)
                {
                    total += likes;
                    count++;
                }
            }

            return count == 0 ? 0 : total / count;
        }

        // Entry point
        public static void Main(string[] args)
        {
            Program program = new Program();
            int choice;

            do
            {
                Console.WriteLine("1. Enter creator name");
                Console.WriteLine("2. Show top performing posts");
                Console.WriteLine("3. Overall Average Weekly Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter choice (1-4)");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter creator's name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter weekly likes:");
                        double[] likes = new double[4];

                        for (int i = 0; i < 4; i++)
                            likes[i] = double.Parse(Console.ReadLine());

                        CreatorStats creator = new CreatorStats
                        {
                            CreatorName = name,
                            WeeklyLikes = likes
                        };

                        program.RegisterCreator(creator);
                        Console.WriteLine("Creator Registered Successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter like threshold:");
                        double likeThreshold = double.Parse(Console.ReadLine());

                        var result = program.GetTopPostCounts(EngagementBoard, likeThreshold);

                        if (result.Count == 0)
                            Console.WriteLine("No top performing posts this week");
                        else
                        {
                            foreach (var entry in result)
                                Console.WriteLine($"{entry.Key} - {entry.Value}");
                        }
                        break;

                    case 3:
                        double avg = program.CalculateAverageLikes();
                        Console.WriteLine($"Overall Average Likes: {avg}");
                        break;

                    case 4:
                        Console.WriteLine("Logging off");
                        break;
                }

            } while (choice != 4);
        }
    }
}
