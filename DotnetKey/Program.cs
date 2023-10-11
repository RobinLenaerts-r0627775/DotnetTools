return Parser.Default.ParseArguments<HashOptions>(args)
            .MapResult(
                Hash,
                errors => 1);

static int Hash(HashOptions options)
{
    var stringToHash = options.StringToHash;

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
    return 0;
}

[Verb("hash", HelpText = "Hash a string with bcrypt.")]
class HashOptions
{
    [Value(0, Required = false, HelpText = "The string to hash. If not specified, a random string will be generated.")]
    public string StringToHash { get; set; }

    [Option('h', "help", Required = false, HelpText = "Show this help message and exit.")]
    public bool Help { get; set; }
}

class ProgramOptions
{
    [Option('v', "verbose", Required = false, HelpText = "Enable verbose output")]
    public bool Verbose { get; set; }

    [Option('i', "input", Required = false, HelpText = "Input file path")]
    public string InputFile { get; set; }

    [Option('o', "output", Required = false, HelpText = "Output file path")]
    public string OutputFile { get; set; }
}