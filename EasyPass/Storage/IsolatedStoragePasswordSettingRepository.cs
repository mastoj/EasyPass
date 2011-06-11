using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasyPass.Storage
{
    class IsolatedStoragePasswordSettingRepository : IPasswordSettingRespository
    {
        private IsolatedStorageFile _isoStorageFile;
        private const string PasswordSettingFileName = "GetPasswordProjects.xml";

        public IsolatedStoragePasswordSettingRepository()
        {
            _isoStorageFile = IsolatedStorageFile.GetUserStoreForAssembly();
        }

        public void AddUpdatePasswordSetting(PasswordSetting passwordSetting)
        {
            var existing = GetPasswordSetting(passwordSetting.ProjectName);
            var passwords = GetAll().ToList();
            if (existing != null)
            {
                passwords.First(y => y.ProjectName == passwordSetting.ProjectName).Password = passwordSetting.Password;
            }
            else
            {
                passwords.Add(passwordSetting);
            }
            SaveList(passwords);
        }

        public PasswordSetting GetPasswordSetting(string projectName)
        {
            var existing = GetAll().FirstOrDefault(y => y.ProjectName == projectName);
            return existing;
        }

        public void DeletePasswordSetting(string projectName)
        {
            var password = GetPasswordSetting(projectName);
            if (password != null)
            {
                var passwords = GetAll().ToList();
                passwords.Remove(password);
                SaveList(passwords);
            }
        }

        public void DeleteAll()
        {
            if (_isoStorageFile.FileExists(PasswordSettingFileName))
            {
                _isoStorageFile.DeleteFile(PasswordSettingFileName);
            }
        }

        private void SaveList(List<PasswordSetting> passwordSettings)
        {
            using (var fileStream = _isoStorageFile.OpenFile(PasswordSettingFileName, FileMode.Create, FileAccess.Write))
            {
                var xmlSerializer = new XmlSerializer(passwordSettings.GetType());
                xmlSerializer.Serialize(fileStream, passwordSettings);
            }
        }

        public IEnumerable<PasswordSetting> GetAll()
        {
            var passwords = new List<PasswordSetting>();
            if (_isoStorageFile.FileExists(PasswordSettingFileName))
            {
                using (var fileStream = _isoStorageFile.OpenFile(PasswordSettingFileName, FileMode.Open,
                                                            FileAccess.Read))
                {
                    var xmlDoc = XDocument.Load(fileStream);
                    return from xmlNode in xmlDoc.Descendants("PasswordSetting")
                           select new PasswordSetting
                           {
                               ProjectName = xmlNode.Element("ProjectName").Value,
                               EncryptedPassword = xmlNode.Element("EncryptedPassword").Value
                           };
                }
            }
            return passwords;
        }

        public void Dispose()
        {
            _isoStorageFile.Dispose();
        }

        public override bool Equals(object obj)
        {
            var other = obj as IsolatedStoragePasswordSettingRepository;
            return other != null;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
}
