using System;
using System.Collections.Generic;
using System.Configuration;

namespace EasyPass
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupIoCContainer();
            if (args.Length == 0)
            {
                var getPasswordCommand = new GetPasswordCommand() { CommandArgs = new List<string>() };
                getPasswordCommand.Execute();
            }
            else
            {
                var parser = new ArgumentParser();
                var commands = parser.ParseArgs(args);
                foreach (var command in commands)
                {
                    command.Execute();
                }
            }
            CleanUp();
        }

        private static void CleanUp()
        {
            IoCContainer.Resolve<IPasswordSettingRespository>().Dispose();
        }

        private static void SetupIoCContainer()
        {
            IoCContainer.Register<IPasswordSettingRespository>(new IsolatedStoragePasswordSettingRepository());
            IoCContainer.Register<IEncryptor>(new DPAPIEncryptor());
        }
    }
}
