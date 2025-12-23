using System;

class RockPaperScissors
{
    static void Main()
    {
        /*
         * Two player Rock Paper Scissors game
         */

        Console.Write("Player 1 choice: ");
        string p1 = Console.ReadLine().ToLower();

        Console.Write("Player 2 choice: ");
        string p2 = Console.ReadLine().ToLower();

        if (p1 == p2)
            Console.WriteLine("Draw");
        else if ((p1 == "rock" && p2 == "scissors") ||
                 (p1 == "paper" && p2 == "rock") ||
                 (p1 == "scissors" && p2 == "paper"))
            Console.WriteLine("Player 1 Wins");
        else
            Console.WriteLine("Player 2 Wins");
    }
}
