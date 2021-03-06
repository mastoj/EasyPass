﻿using System.Collections.Generic;
using EasyPass.Storage;

namespace EasyPass.Commands
{
    public abstract class PasswordCommand : ICommand
    {
        protected IPasswordSettingRespository _passwordSettingRepository;

        public PasswordCommand() : this(IoCContainer.Resolve<IPasswordSettingRespository>())
        {
        }

        public PasswordCommand(IPasswordSettingRespository repository)
        {
            _passwordSettingRepository = repository;
        }

        public List<string> CommandArgs { get; set; }
        public abstract void Execute();
    }
}