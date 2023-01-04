if (string.IsNullOrEmpty(args[0]))
{
    throw new Exception("Not a word");
}

var vowels = new List<char>
{
    'a', 'e', 'i', 'o', 'u', 'y'
};

var count = args[0].Length - args[0].Except(vowels).Count();

Console.WriteLine($"{args[0]} contains {count} vowels");