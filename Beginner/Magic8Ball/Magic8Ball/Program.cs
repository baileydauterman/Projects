var intro = """
 _____ ______   ________  ________  ___  ________          ________          ________  ________  ___       ___          
|\   _ \  _   \|\   __  \|\   ____\|\  \|\   ____\        |\   __  \        |\   __  \|\   __  \|\  \     |\  \         
\ \  \\\__\ \  \ \  \|\  \ \  \___|\ \  \ \  \___|        \ \  \|\  \       \ \  \|\ /\ \  \|\  \ \  \    \ \  \        
 \ \  \\|__| \  \ \   __  \ \  \  __\ \  \ \  \            \ \   __  \       \ \   __  \ \   __  \ \  \    \ \  \       
  \ \  \    \ \  \ \  \ \  \ \  \|\  \ \  \ \  \____        \ \  \|\  \       \ \  \|\  \ \  \ \  \ \  \____\ \  \____  
   \ \__\    \ \__\ \__\ \__\ \_______\ \__\ \_______\       \ \_______\       \ \_______\ \__\ \__\ \_______\ \_______\
    \|__|     \|__|\|__|\|__|\|_______|\|__|\|_______|        \|_______|        \|_______|\|__|\|__|\|_______|\|_______|
""";

var responses = new List<string>()
{
    "It is certain.",
    "It is decidedly so.",
    "Without a doubt.",
    "Yes definitely.",
    "You may rely on it.",
    "As I see it, yes.",
    "Most likely.",
    "Outlook good.",
    "Yes.",
    "Signs point to yes.",
    "Reply hazy, try again.",
    "Ask again later.",
    "Better not tell you now.",
    "Cannot predict now.",
    "Concentrate and ask again.",
    "Don't count on it.",
    "My reply is no.",
    "My sources say no.",
    "Outlook not so good.",
    "Very doubtful.",
};

var answer = "y";

while (!string.IsNullOrEmpty(answer) && char.ToLowerInvariant(answer[0]) == 'y')
{
    Run();

    Console.WriteLine("\n\nWould you like to ask another? (y/n)");
    answer = Console.ReadLine();
}

Console.WriteLine("\n\nThank you for consulting the Magic 8 Ball on your lifes journey");


void Run()
{
    Console.Clear();
    var rand = new Random().Next(responses.Count);

    Console.WriteLine($"{intro}\n");
    Console.WriteLine("\nWhat is your question?");

    Console.ReadLine();

    Console.WriteLine("The 8 Ball says:");
    Console.WriteLine("\t" + responses[rand]);
}
