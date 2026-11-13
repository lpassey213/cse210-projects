using System;

class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();
        Journal myJournal = new Journal();

        int response = 0;

        while (response != 6)
        {
            response = myMenu.ProcessMenu();

            if (response == 1)
            {
                JournalEntry entry = new JournalEntry();
                entry.CreateJournalEntry();
                myJournal.AddEntry(entry);
            }
            else if (response == 2)
            {
                myJournal.DisplayJournal();
            }
            else if (response == 3)
            {
                myJournal.SaveJournal();
            }
            else if (response == 4)
            {
                myJournal.LoadJournal();
            }
            else if (response == 5)
            {
                Console.WriteLine("Journal Statistics");

                Console.WriteLine($"Total entries: {myJournal._entries.Count}");

                int entriesToday = 0;
                int totalWords = 0;

                foreach (JournalEntry entry in myJournal._entries)
                {
                    if (entry._date == DateTime.Now.ToShortDateString())
                    {
                        entriesToday++;
                    }

                    string[] words = entry._response.Split(
                        ' ', StringSplitOptions.RemoveEmptyEntries);

                    totalWords = totalWords + words.Length;
                }

                Console.WriteLine($"Entries written today: {entriesToday}");

                if (myJournal._entries.Count > 0)
                {
                    double averageWords = (double)totalWords / myJournal._entries.Count;
                    Console.WriteLine($"Average words per entry: {averageWords:F1}");
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