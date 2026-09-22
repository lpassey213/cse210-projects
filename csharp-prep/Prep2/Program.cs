using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string userGrade = Console.ReadLine();

        int grade = int.Parse(userGrade);

        string letter = "";
        
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade <= 90 && grade >= 80)
        {
            letter = "B";
        }
        else if (grade <= 80 && grade >= 70)
        {
            letter = "C";
        }
        else if (grade <= 70 && grade >= 60)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }
        else
        {
            Console.WriteLine("Error");
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("You passed the class!");
        }
        else
        {
            Console.WriteLine("Do better... you're trash.");
        }
    }
}