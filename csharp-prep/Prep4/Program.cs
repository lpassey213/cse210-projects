using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = 1;

        while (userNumber != 0)
        {
            Console.Write("Enter a list of numbers, type 0 to stop: ");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }


        int sum = numbers.Sum();
        
        Console.WriteLine($"Sum = {sum}");

        double avg = numbers.Average();

        Console.WriteLine($"Average = {avg}");

        int max = numbers.Max();
        
        Console.WriteLine($"Max = {max}");
    }

}