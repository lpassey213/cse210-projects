using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<JournalEntry> _entries = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }

        foreach (JournalEntry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        List<string> lines = new List<string>();

        foreach (JournalEntry entry in _entries)
        {
            lines.Add($"{entry._date}|{entry._prompt}|{entry._response}");
        }

        File.WriteAllLines(filename, lines);

        Console.WriteLine("Journal saved!");
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            JournalEntry entry = new JournalEntry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];

            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded!");
    }
}