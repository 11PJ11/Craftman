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
        public void ExecuteUsing(Dictionary<string, List<string>> userToMessages)
        {
            
        }
    }
}