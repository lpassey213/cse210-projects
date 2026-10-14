class Menu
{
    public int ProcessMenu()
    {
        int response = 0;

        while (response < 1 || response > 5)
        {
            Console.WriteLine("Welcome to the Journaling Program!");
            Console.WriteLine("Create, Display, Save, and Read Journal Entries");
            Console.WriteLine("1. Create new Journal entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save journal file");
            Console.WriteLine("4. Read Journal from file");
            Console.WriteLine("5. View Journal Statistics");
            Console.WriteLine("6. Quit");
            Console.Write("> ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out response))
            {
                response = 0;
            }

            if (response < 1 || response > 5)
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
            }
        }

        return response;
    }
}