using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static double AddNumbers(double x, int y)
    {
        return x + y;
    }

    static void DisplayGreeting(string name)
    {
        Console.WriteLine($"Welcome {name}, please to meet you.");
    }
    static void Main(string[] args)
    {
        DisplayGreeting("Bob");
        double answer = AddNumbers(12.234, 10);
        Console.WriteLine(answer);
        /*int num = 0;
        int sum = 0;
        while(num < 10)
        {
            num = num + 1;
            Console.WriteLine($"{num}");
            sum = sum + num;
        }
        int sumtot = sum;
        Console.WriteLine($"Sum Total: {sumtot}"); */
    }
}