var rootCommand = new RootCommand("CLI Tool to generate and verify bcrypt hashes.")
{
    Name = "dotnet-key"
};
string[] helpFlag = new string[] { "-h" };
try
{
    var hashCommand = new Command("hash", "Hash a string with bcrypt.");
    var stringToHash = new Option<string>(
        aliases: new string[] { "-i", "--input" },
        description: "The input string to be hashed");
    hashCommand.AddOption(stringToHash);

    hashCommand.SetHandler(async (input) =>
        {
            if (Commands.Hash(input) == 1)
            {
                await hashCommand.InvokeAsync(helpFlag);
            }
        },
        stringToHash);

    var verifyCommand = new Command("verify", "Verify a string with bcrypt.");
    var inputOption = new Option<string>(
        aliases: new string[] { "-i", "--input" },
        description: "The string to be verified")
    {
        IsRequired = true
    };
    var hashOption = new Option<string>(
        aliases: new string[] { "-H", "--hash" },
        description: "The hash to be verified against. To avoid escaping issues, use single quotes around the hash.")
    {
        IsRequired = true
    };
    verifyCommand.AddOption(inputOption);
    verifyCommand.AddOption(hashOption);

    verifyCommand.SetHandler(async (input, hash) =>
    {
        if (Commands.Verify(input, hash) == 1)
        {
            await verifyCommand.InvokeAsync(helpFlag);
        }
    },
    inputOption, hashOption);
    rootCommand.AddCommand(hashCommand);
    rootCommand.AddCommand(verifyCommand);
    var res = await rootCommand.InvokeAsync(args);

    return res;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    await rootCommand.InvokeAsync(helpFlag);
    return 1;
}
