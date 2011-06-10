using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasyPass
{
    internal class AddPasswordCommand : PasswordCommand
    {
        public override void Execute()
        {
            if (CommandArgs.Count != 2)
            {
                throw new ArgumentException("Missing arguments, usage: EasyPass -a <project name> <password>");
            }
            var projectName = CommandArgs[0];
            var password = CommandArgs[1];
            var newPasswordSetting = new PasswordSetting() { ProjectName = projectName, Password = password };
            _passwordSettingRepository.AddUpdatePasswordSetting(newPasswordSetting);
        }
    }
}