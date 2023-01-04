if (args[0] is null)
{
    throw new Exception("Arg 0 was null, need words");
}

Console.WriteLine($"There are {args[0].Split(' ').Count()} words in the data");