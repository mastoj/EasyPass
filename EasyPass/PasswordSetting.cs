using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EasyPass.Encryption;

namespace EasyPass
{
    public class PasswordSetting
    {
        private string _password;
        private string _encryptedPassword;
        private IEncryptor _encryptor;

        public PasswordSetting() : this(IoCContainer.Resolve<IEncryptor>())
        {
                
        }

        private PasswordSetting(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public string ProjectName { get; set; }
        [XmlIgnore]
        public string Password { get { return _password; } 
            set { _password = value;
                _encryptedPassword = _encryptor.Encrypt(_password);
            }
        }
        public string EncryptedPassword { get { return _encryptedPassword; } 
            set { _encryptedPassword = value;
                _password = _encryptor.Decrypt(_encryptedPassword);
            }
        }
        public override bool Equals(object obj)
        {
            var other = obj as PasswordSetting;
            if (other == null)
                return false;
            return other.ProjectName == this.ProjectName;
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }
    }
}
