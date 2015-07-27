using System.Collections.Generic;
using System.Linq;

namespace Craftman.Commands
{
    public class WallCommand : ICommand
    {
        public WallCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
        public void ExecuteUsing(List<Message> messages, Dictionary<string, List<string>> userToFollowed)
        {
            throw new System.NotImplementedException();
        }

        internal List<string> GetTheWallUsing(List<Message> messages, Dictionary<string, List<string>> userToFollowed)
        {
            var wall = messages
                .Where(m => m.UserName == UserName)
                .Select(m => m.ToString())
                .ToList();

            return wall;
        }
    }
}