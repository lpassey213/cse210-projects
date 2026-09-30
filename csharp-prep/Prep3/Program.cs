using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number: ");
        string magic = Console.ReadLine();

        int magicNum = int.Parse(magic);
        int guessNum = 0;

        while (guessNum != magicNum)
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();

            guessNum = int.Parse(guess);

            if (magicNum > guessNum)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNum < guessNum)
            {
                Console.WriteLine("Lower"); 
            }
            else
            {
                Console.WriteLine("You Guessed It");
            }
        }
    }
}