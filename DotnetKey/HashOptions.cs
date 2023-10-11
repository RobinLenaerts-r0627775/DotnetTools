namespace DotnetKey;


[Verb("Hash", HelpText = "Hash a string with bcrypt.")]
public class HashOptions
{

    [Option('i', "input", Required = false, HelpText = "string to hash. If not specified, a random string will be made.")]
    public string StringToHash { get; set; }
}
