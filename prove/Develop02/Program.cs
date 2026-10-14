using System;
using System.Collections.Generic;
using System.IO;
// Creativity addition: Journal statistics show the user their total
// entries, how many they wrote today, and their average words per entry.
// This helps users track their journaling habits and progress.
class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();
        List<JournalEntry> journalEntries = new List<JournalEntry>();

        int response = 0;

        while (response != 7)
        {
            response = myMenu.ProcessMenu();

            if (response == 1)
            {
                JournalEntry entry = new JournalEntry();
                entry.CreateJournalEntry();
                journalEntries.Add(entry);
            }
            else if (response == 2)
            {
                foreach (JournalEntry entry in journalEntries)
                {
                    entry.DisplayEntry();
                    Console.WriteLine();
                }
            }
            else if (response == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (JournalEntry entry in journalEntries)
                    {
                        outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                    }
                }

                Console.WriteLine("Journal saved.");
            }
            else if (response == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                string[] lines = File.ReadAllLines(filename);

                journalEntries.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    JournalEntry entry = new JournalEntry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];

                    journalEntries.Add(entry);
                }

                Console.WriteLine("Journal loaded.");
            }
            else if (response == 5) 
            {
                Console.WriteLine("Journal Statistics");

                Console.WriteLine($"Total entries: {journalEntries.Count}");

                int entriesToday = 0;
                int totalWords = 0;

                foreach (JournalEntry entry in journalEntries)
                {
                    if (entry._date == DateTime.Now.ToShortDateString())
                    {
                        entriesToday++;
                    }

                    string[] words = entry._response.Split(
                            ' ', StringSplitOptions.RemoveEmptyEntries);

                    totalWords += words.Length;
                }

                Console.WriteLine($"Entries written today: {entriesToday}");

                if (journalEntries.Count > 0)
                {
                    double averageWords = (double)totalWords / journalEntries.Count;
                    Console.WriteLine($"Average words per entry: {averageWords:F11}");
                }
                else
                {
                    Console.WriteLine("Average words per entry: 0");
                }
            }
            else if (response == 6)
            {
                Console.WriteLine("Bye!");
            }
        }
    }
}