using System;
using CommandLine;

var result = Parser.Default.ParseArguments<Options>(args);
result.WithParsed(options =>
{
    if (options.Help)
    {
        Help();
    }
    else
    {
        Hash();
    }
});

void Help()
{
    Console.WriteLine("Usage: dotnet key [options] [command]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  --help                Show this help message and exit.");
    Console.WriteLine();
    Console.WriteLine("Commands:");
    Console.WriteLine("  hash                  Hash a string with bcrypt.");
}

void Hash()
{
    //get the second option
    var stringToHash = Environment.GetCommandLineArgs()[2];

    if (string.IsNullOrWhiteSpace(stringToHash))
    {
        //generate random string of 32 characters
        stringToHash = Guid.NewGuid().ToString();
    }

    //hash with bcrypt
    var hashedString = BCrypt.Net.BCrypt.HashPassword(stringToHash);

    //print to console
    Console.ResetColor();
    Console.Write($"unhashed:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(stringToHash);
    Console.ResetColor();
    Console.Write($"hashed:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(hashedString);
    Console.ResetColor();
}

class Options
{
    [Option('h', "help", Required = false, HelpText = "Show this help message and exit.")]
    public bool Help { get; set; }
}