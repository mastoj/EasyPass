using System;
using System.Collections.Generic;

namespace EasyPass.Storage
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
