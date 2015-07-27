using System.Collections.Generic;

namespace Craftman.Commands
{
    public interface ICommand
    {
        string UserName { get; }
        void ExecuteUsing(List<Message> messages);
    }
}