using System.Collections.Generic;

namespace EasyPass.Commands
{
    interface ICommand
    {
        List<string> CommandArgs { get; set; }
        void Execute();
    }
}