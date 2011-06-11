using System;
using System.Collections;
using System.Collections.Generic;
using EasyPass.Commands;

namespace EasyPass
{
    internal class ArgumentParser
    {
        public IEnumerable<ICommand> ParseArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                var command = GetCommand(args[i]);
                if (command != null)
                {
                    var commandArgs = new List<string>();
                    for (int j = i + 1; j < args.Length && !args[j].StartsWith("-"); j++)
                    {
                        commandArgs.Add(args[j]);
                        i = j;
                    }
                    command.CommandArgs = commandArgs;
                    yield return command;
                }
            }
            yield break;
        }

        private ICommand GetCommand(string s)
        {
            switch (s)
            {
                case "-i":
                    return new InteractiveCommand();
                case "-a":
                    return new AddPasswordCommand();
                case "-d":
                    return new DeletePasswordCommand();
                case "-l":
                    return new ListPasswordsCommand();
                case "":
                case "-g":
                    return new GetPasswordCommand();
                default:
                    return null;
            }
        }
    }
}