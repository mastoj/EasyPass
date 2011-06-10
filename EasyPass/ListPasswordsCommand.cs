using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPass
{
    class ListPasswordsCommand : PasswordCommand
    {
        public override void Execute()
        {
            var passwords = _passwordSettingRepository.GetAll();
            foreach (var passwordSetting in passwords)
            {
                Console.WriteLine("Project name: {0}", passwordSetting.ProjectName);
                Console.WriteLine("Password: {0}", passwordSetting.Password);
                Console.WriteLine("Encrypted password: {0}", passwordSetting.EncryptedPassword);
            }
        }
    }
}
