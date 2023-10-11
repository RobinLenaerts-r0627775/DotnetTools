namespace DotnetKey;

class ProgramOptions
{
    [Option('h', "help", Required = false, HelpText = "Show this help message and exit.")]
    public bool ShowHelp { get; set; }
}