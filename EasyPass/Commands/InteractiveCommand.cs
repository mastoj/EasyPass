using System;
using System.Collections.Generic;

namespace EasyPass.Commands
{
    class InteractiveCommand : ICommand
    {
        private ArgumentParser _parser = new ArgumentParser();

        public List<string> CommandArgs
        {
            get;
            set;
        }

        public void Execute()
        {
            string[] args = null;
            while (args == null || (args[0] != "q" && args[0] != string.Empty))
            {
                Console.WriteLine("Enter arguments: ");
                var argsString = Console.ReadLine();
                args = argsString.Split(new char[] {' '});
                var commands = _parser.ParseArgs(args);
                foreach (var command in commands)
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
