using System;

var states = new Dictionary<int, string>
{
    {0,"""
_________
|       |
|
|
|
|
|
----------
"""},
    {1,
    """
_________
|       |
|       O
|
|
|
|
----------
"""},
    {2,
    """
_________
|       |
|       O
|       |
|
|
|
----------
"""},
    {3,
    """
_________
|       |
|       O
|      /|
|
|
|
----------
"""},
    {4,
    """
_________
|       |
|       O
|      /|\
|
|
|
----------
"""},
    {5,
    """
_________
|       |
|       O
|      /|\
|      /
|
|
----------
"""},
    {6,
    """
_________
|       |
|       O
|      /|\
|      / \
|
|
----------
"""}

};

var words = File.ReadAllLines(Path.Combine(".", "Words.txt"));
var wordCount = words.Count() - 1;
string word = string.Empty;

var wrongAnswers = 0;
var guesses = new List<char>();

var exitString = "y";

while (!string.IsNullOrEmpty(exitString)  && char.ToLowerInvariant(exitString[0]) != 'n')
{
    WriteStartGame();

    var result = RunGame();

    Console.WriteLine(result ? "Nice! You won! Want to play again??" : $"Ooops, didn't quite get it, maybe next round. (The word was {word})");

    Console.WriteLine("Would you like to play again? (y/n)");
    Console.Read();
    exitString = Console.ReadLine();
}


void WriteStartGame()
{
    Console.WriteLine("Welcome to Hangman");
    Console.WriteLine("You have 6 guesses to get the correct word");

    Console.WriteLine("\nPress <ENTER> key to start");
    Console.ReadLine();

    word = words[new Random().Next(wordCount)];
    wrongAnswers = 0;
    guesses.Clear();
}

void WriteWord()
{
    Console.WriteLine("Current Word:");

    if (word is null || guesses is null)
    {
        return;
    }

    foreach (var c in word)
    {
        if (guesses.Contains(c))
        {
            Console.Write($" {c} ");
            continue;
        }

        Console.Write(" _ ");
    }

    Console.Write("\n");
}

void WriteCurrentScore()
{
    if (states is null || guesses is null)
    {
        return;
    }

    Console.WriteLine("\nHangman State:");

    Console.WriteLine(states[wrongAnswers]);

    Console.WriteLine("\nGuessed Letters");

    Console.WriteLine(string.Join(" ", guesses));
}

void WriteStuff()
{
    Console.Clear();
    WriteWord();
    WriteCurrentScore();
}

bool RunGame()
{
    while (wrongAnswers != 6)
    {
        WriteStuff();

        Console.WriteLine("Guess a letter");
        var letter = GetInput();

        guesses.Add(letter);

        if (!word.Contains(letter))
        {
            wrongAnswers++;
        }
        else
        {
            if (!word.Except(guesses).Any())
            {
                WriteStuff();
                return true;
            }
        }
    }

    return false;
}

char GetInput()
{
    char letter;

    while (true)
    {
        letter = (char)Console.Read();

        if (char.IsWhiteSpace(letter))
        {
            continue;
        }
        else if (guesses.Contains(letter))
        {
            Console.WriteLine("You already guessed that letter, try another");
            continue;
        }
        else
        {
            return letter;
        }
    }
}