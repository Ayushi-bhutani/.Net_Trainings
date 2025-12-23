using System;

class GuessingGame
{
    static void Main()
    {
        /*
         * User guesses until correct
         */

        int secret = 7, guess;

        do
        {
            Console.Write("Guess the number: ");
            guess = int.Parse(Console.ReadLine());
        } while (guess != secret);

        Console.WriteLine("Correct Guess!");
    }
}
