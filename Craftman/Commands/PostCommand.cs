using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Craftman.Commands
{
    public class PostCommand : ICommand
    {
        public PostCommand(string userName, string message)
        {
            UserName = userName;
            Message = message;
        }

        public string UserName { get; }

        public void ExecuteUsing(Dictionary<string, List<string>> userToMessages)
        {
            if (!userToMessages.ContainsKey(UserName))
            {
                userToMessages.Add(UserName, new List<string>());
            }
            userToMessages[UserName].Add(Message);
        }

        public string Message { get; }
    }
}