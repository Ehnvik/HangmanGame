namespace HangmanGame;

internal class GameLogic
{
    private string _word;
    private readonly Words _words;
    private int _lives = 5;
    private char _guessedLetter;
    private List<char> _guessedLetters = [];



    public GameLogic(Words words)
    {
        _words = words;
    }


    private void GameField()
    {
        Console.WriteLine("Welcome to Hangman game!");
        Console.WriteLine("To win the game you have to guess the correct letters to complete the word before your 5 lives runs out. Write 'quit' to exit the game.");


        while (true)
        {
            if (_guessedLetters.Count > 0)
            {
                string letters = string.Join(",", _guessedLetters);

                Console.WriteLine($"Guessed letters: {letters.ToUpper()}");
            }

            IEnumerable<char> currentWord = _word.Select((c) => _guessedLetters.Contains(c) ? c : '_');

            if (!currentWord.Contains('_'))
            {
                Console.WriteLine($"Congratulations you won! The correct word is '{_word}'");
                break;
            }

            Console.WriteLine($"WORD: {string.Join("", currentWord).ToUpper()}");

            Console.WriteLine($"You have {_lives} lives left. Please choose a letter.");
            string inputValue = Console.ReadLine().ToLower();

            if (inputValue == "quit") return;

            if (ValidateInput(inputValue))
            {
                Console.WriteLine("");
                CheckIfLetterExistsInWord();

            }

            Console.WriteLine("");

            if (_lives == 0)
            {
                Console.WriteLine($"Game Over! You have {_lives} lives left. The correct word was {_word}");
                break;
            }
        }

        Console.WriteLine("Rematch? Write 'restart' to start a new game or any other character to exit");
        string input = Console.ReadLine().ToLower();
        if (input == "restart")
        {
            StartGame();
        }
    }

    private void CheckIfLetterExistsInWord()
    {
        if (_guessedLetters.Contains(_guessedLetter))
        {
            Console.WriteLine($"Letter '{_guessedLetter}' has already been chosen before. Please try again.");
            _guessedLetters.Add(_guessedLetter);

            return;
        }

        if (_word.Contains(_guessedLetter))
        {
            Console.WriteLine($"Correct! Letter '{_guessedLetter}' exists in the word.");
            _guessedLetters.Add(_guessedLetter);
        }
        else
        {
            Console.WriteLine($"Wrong! Letter '{_guessedLetter}' does not exist in the word. Please try again.");
            _guessedLetters.Add(_guessedLetter);

            if (_lives > 0)
            {
                _lives--;
            }
        }
    }


    private bool ValidateInput(string inputValue)
    {
        if (inputValue.Length != 1)
        {
            Console.WriteLine("Please enter exactly one letter.");
            return false;
        }

        char letter = inputValue[0];

        if (char.IsDigit(letter))
        {
            Console.WriteLine("Please enter a valid letter, not a digit.");
            return false;
        }

        _guessedLetter = letter;
        return true;
    }

    public void StartGame()
    {
        _word = _words.GetRandomWord();
        _lives = 5;
        _guessedLetters.Clear();
        GameField();
    }

}

