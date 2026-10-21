
class Word
{
    private string _word;

    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;

    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Display()
    {
        Console.Write($"{_word} ");
    }

    public void GetWordString()
    {
        string returnString = "";
        if (_hidden == true);
    }
}