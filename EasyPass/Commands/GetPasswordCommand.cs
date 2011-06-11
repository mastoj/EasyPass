using System;

namespace EasyPass.Commands
{
    internal class GetPasswordCommand : PasswordCommand
    {
        public override void Execute()
        {
            if (CommandArgs.Count != 0 && CommandArgs.Count != 1)
            {
                throw new ArgumentException("Invalid arguments, usage: EasyPass -g <project name> or EasyPass (no args will use env variable ProjectName)");
            }
            var projectName = CommandArgs.Count == 1
                                  ? CommandArgs[0]
                                  : Environment.GetEnvironmentVariable("ProjectName");
            var passwordSetting = _passwordSettingRepository.GetPasswordSetting(projectName);
            if (passwordSetting == null)
            {
                throw new ArgumentException("Invalid argument " + projectName + ", the project name doesn't exist");
            }
            Console.WriteLine(passwordSetting.Password);
        }
    }
}