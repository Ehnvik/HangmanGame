namespace HangmanGame;

internal class Words
{

    private string[] _words = [];


    public Words()
    {
        LoadWords();
    }

    private void LoadWords()
    {
        string fileName = "Resources/words.txt";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        _words = File.ReadAllLines(filePath);
    }

    public string GetRandomWord()
    {
        int word = new Random().Next(_words.Length);

        return _words[word];
    }


}