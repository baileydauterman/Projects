
var list = new List<int>
{
    0, 1,
};

var ptr = 1;

if (args[0] is not null)
{
    if (int.TryParse(args[0], out var temp))
    {
        RunUntilHit(temp);
    }
}

void RunUntilHit(int highest)
{
    int temp;
    while ((temp = list[ptr - 1] + list[ptr]) < highest)
    {
        list.Add(temp);
        ptr++;
    }

    Console.WriteLine(string.Join(", ", list));
}