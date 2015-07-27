using System.Collections.Generic;

namespace Craftman.Commands
{
    public class VoidCommand : ICommand
    {
        public VoidCommand()
        {
            UserName = string.Empty;
        }

        public string UserName { get; }
        public void ExecuteUsing(List<Message> messages, Dictionary<string, List<string>> userNameToFollowed)
        {
            
        }
    }
}