# dotnet key

`dotnet-key` is a command-line tool for hashing and verifying strings with BCrypt.

Installation
To install `dotnet-key`, you must have the .NET Core SDK installed on your machine. You can download the SDK from the Microsoft website: <https://dotnet.microsoft.com/en-us/download>.

Once you have the SDK installed, you can install dotnet-key using the following command:

```powershell
dotnet tool install -g dotnet-key
```

This will install `dotnet-key` globally on your machine.

Usage
To use `dotnet-key`, open a command prompt or terminal window and run the following command:

```
dotnet key <command> [options]
```

Replace `<command>` with the name of the command you want to run. Available commands are:

- `hash`: Hash a string with bcrypt.
- `verify`: Verify a string with bcrypt.

Available options depend on the command you are running. To see the available options for a command, run the command with the `--help` flag. For example:

```
dotnet key hash --help
```

This will display the help message for the `hash` command.

Examples
Here are some examples of how to use `dotnet-key`:

Generate a random password and hash:

```
dotnet key hash
```

Hash a string:

```
dotnet key hash -i "my secret password"
```

Verify a string against a hash:

```
dotnet key verify -i "my secret password" -H "$2a$10$J8vLXJ5ZJt5vJ0LJZJz5OuJvJf9zJzJzJzJzJzJzJzJzJzJzJzJzK"
```

Contributing
Feel free to buy me a coffee! <https://www.buymeacoffee.com/RobinLen>

Contact
If you have any questions or issues, please contact the maintainer at <contact@robinlenaerts.dev>.
