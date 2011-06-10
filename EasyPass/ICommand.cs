using System.Collections.Generic;

namespace EasyPass
{
    interface ICommand
    {
        List<string> CommandArgs { get; set; }
        void Execute();
    }
}