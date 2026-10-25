using System;

class Program
{
    static void Main(string[] args)
    {
        Word myWord = new Word("Bubba");
        myWord.Display();
        Console.WriteLine();
        myWord.Hide();
        myWord.Display();
        
        Console.WriteLine();

        // Create a scripture
        Scripture myScripture = new Scripture(
            "John", 3, 16,
            "For God so loved the world that he gave his only begotten Son"
        );

        // Display the scripture
        myScripture.ShowScripture();

        Console.WriteLine();

        // TODO: Add code to hide words randomly
        // TODO: Add code to show the progress tracker
    }
}