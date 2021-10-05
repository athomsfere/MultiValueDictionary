using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiValueDictionary<string, string> multiValueDictionary = new MultiValueDictionary<string, string>();
            Console.WriteLine(CommandConstants.Help);
            while (true)
            {
                var consoleInput = Console.ReadLine();
                if (consoleInput.ToUpperInvariant() == "EXIT")
                {
                    Environment.Exit(0);
                }

                if (consoleInput.ToUpperInvariant() == "-H")
                {
                    Console.WriteLine(CommandConstants.Help);
                    continue;
                }

                var commandParts = consoleInput.Split(' ');

                var command = new DictionaryCommand()
                {
                    Command = commandParts.Length >= 1 ? commandParts[0].ToUpperInvariant() : null,
                    KeyName = commandParts.Length >= 2 ? commandParts[1] : null,
                    Value = commandParts.Length >= 3 ? commandParts[2] : null
                };
                var processor = new CommandProcessor();
                try
                {
                    processor.Process(command, multiValueDictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
