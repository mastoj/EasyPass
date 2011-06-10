using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPass
{
    public interface IPasswordSettingRespository : IDisposable
    {
        void AddUpdatePasswordSetting(PasswordSetting passwordSetting);
        PasswordSetting GetPasswordSetting(string projectName);
        void DeletePasswordSetting(string projectName);
        void DeleteAll();
        IEnumerable<PasswordSetting> GetAll();
    }
}
