using System;
using System.Collections.Generic;
using AgendaBuilder.Models;
using AgendaBuilder.Services;
using AgendaBuilder.Utils;

namespace AgendaBuilder
{
    class Program
    {
        static void Main()
        {
            // Sample data (we will later replace with input parsing)
            var venues = new Dictionary<string, Venue>
            {
                { "A", new Venue { Id = "A", x = 0, y = 0 } },
                { "B", new Venue { Id = "B", x = 6, y = 0 } }
            };

            var sessions = new Dictionary<string, Session>
            {
                { "S1", new Session { Id="S1", Start=540, End=600, VenueId="A", Capacity=1 } },
                { "S2", new Session { Id="S2", Start=600, End=660, VenueId="B", Capacity=1 } },
                { "S3", new Session { Id="S3", Start=540, End=630, VenueId="A", Capacity=1 } },
                { "S4", new Session { Id="S4", Start=660, End=720, VenueId="B", Capacity=1 } }
            };

            var delegates = new Dictionary<string, ConferenceDelegate>
            {
                { "D1", new ConferenceDelegate  { Id="D1" } },
                { "D2", new ConferenceDelegate  { Id="D2" } }
            };

            var preferences = new List<Preference>
            {
                new Preference { DelegateId="D1", SessionId="S1", Score=10 },
                new Preference { DelegateId="D1", SessionId="S2", Score=8 },
                new Preference { DelegateId="D1", SessionId="S4", Score=7 },
                new Preference { DelegateId="D2", SessionId="S3", Score=9 },
                new Preference { DelegateId="D2", SessionId="S2", Score=6 },
                new Preference { DelegateId="D2", SessionId="S4", Score=10 }
            };

            int T = 8;

            var planner = new AgendaPlanner();
            planner.AssignSessions(preferences, sessions, delegates, venues, T);

            // Print result
            foreach (var del in delegates.Values)
            {
                del.AssignedSessions.Sort((a, b) => a.Start.CompareTo(b.Start));
                Console.Write(del.Id + ": ");
                foreach (var s in del.AssignedSessions)
                    Console.Write(s.Id + " ");
                Console.WriteLine();
            }

            int totalScore = 0;

            foreach (var pref in preferences)
            {
                if (delegates[pref.DelegateId]
                    .AssignedSessions
                    .Any(s => s.Id == pref.SessionId))
                {
                    totalScore += pref.Score;
                }
            }
            double totalWalkTime = 0;

            foreach (var del in delegates.Values)
            {
            // Sort sessions by start time
                var ordered = del.AssignedSessions
                     .OrderBy(s => s.Start)
                     .ToList();

                for (int i = 1; i < ordered.Count; i++)
                {
                    var prev = ordered[i - 1];
                    var curr = ordered[i];

                    Venue v1 = venues[prev.VenueId];
                    Venue v2 = venues[curr.VenueId];

                    totalWalkTime += Helper.Distance(v1, v2);
                }
            }

            foreach (var del in delegates.Values)
            {
                Console.Write($"{del.Id}: ");
                foreach (var s in del.AssignedSessions.OrderBy(s => s.Start))
                    Console.Write($"{s.Id} ");
                Console.WriteLine();
            }

            Console.WriteLine($"total_score={totalScore}");
            Console.WriteLine($"total_walk_time={totalWalkTime}");



        }
    }
}
