using System.CommandLine.Builder;
using BCrypt.Net;

namespace DotnetKey;

public class Commands
{

    internal static int Hash(string stringToHash)
    {

        if (string.IsNullOrWhiteSpace(stringToHash))
        {
            //generate random string of 32 characters
            stringToHash = Guid.NewGuid().ToString();
        }

        //hash with bcrypt without salt
        var hashedString = BCrypt.Net.BCrypt.HashPassword(stringToHash);

        //print to console
        Console.ResetColor();
        Console.Write($"unhashed: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(stringToHash);
        Console.ResetColor();
        Console.Write($"hashed: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(hashedString);
        Console.ResetColor();
        return 0;
    }

    internal static int Verify(string input, string hash)
    {
        bool res;
        try
        {
            res = BCrypt.Net.BCrypt.Verify(input, hash);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: ");
            Console.WriteLine(e.Message);
            Console.ResetColor();
            return 1;
        }
        if (res)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Match!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No match!");
        }
        Console.ResetColor();
        return 0;
    }
}
