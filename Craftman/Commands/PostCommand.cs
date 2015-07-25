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
        public string Message { get; }
    }
}