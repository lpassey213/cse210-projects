using System;

class JournalEntry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }

    public void CreateJournalEntry()
    {
        _date = DateTime.Now.ToShortDateString();

        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "Who was the most interesting person I talked to today?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I could do one thing over today, what would it be?",
            "What is one thing I learned today?",
            "What is something I am grateful for today?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        _prompt = prompts[index];

        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();
    }
}