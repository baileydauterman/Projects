if (args[0] is null)
{
    throw new ArgumentNullException(nameof(args));
}

var saveString = args[0].ToLower();

var isPalidrome = saveString.Equals(ReverseString(saveString)) ? string.Empty : "not ";

Console.WriteLine($"{args[0]} is {isPalidrome}a palidrome");

string ReverseString(string str)
{
    var chars = str.ToLower().ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}