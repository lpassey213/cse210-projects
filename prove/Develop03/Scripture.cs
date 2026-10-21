class Scripture
{
    List<Word> _words;

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        // TODO
        _words = ConvertToWords(text);
    }
    public Scripture(string bookName, int chapter, int startVerse, int endVerse, string Text)
    {
        // TODO 
    }

    public void ShowScripture()
    {
        
        foreach(Word word in _words)
        {
            word.Display();
        }
    }
    
    private List<Word> ConvertToWords(string text)
    {
        List<Word> tempwords = new List<Word>();

        string[] words = text.Split(' ');
        foreach(string word in words)
        {
            Word tempWord = new Word(word);
            tempwords.Add(tempWord);
        }

        return tempwords;
    }
}