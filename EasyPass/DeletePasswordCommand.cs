using System;

namespace EasyPass
{
    internal class DeletePasswordCommand : PasswordCommand
    {
        public override void Execute()
        {
            if (CommandArgs.Count == 0)
            {
                _passwordSettingRepository.DeleteAll();
            }
            else if (CommandArgs.Count == 1)
            {
                _passwordSettingRepository.DeletePasswordSetting(CommandArgs[0]);
            }
            else
            {
                throw new ArgumentException("Missing arguments, usage: EasyPass -d [<project name>] (if no project name is provided all will be deleted)");
            }
        }
    }
}