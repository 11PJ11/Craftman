using System.Collections.Generic;

namespace Craftman.Commands
{
    public interface ICommand
    {
        string UserName { get; }
        void ExecuteUsing(Dictionary<string, List<string>> userToMessages);
    }
}