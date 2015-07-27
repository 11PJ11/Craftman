using System;
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
            var wall = GetTheWallUsing(messages, userToFollowed);
            wall.ForEach(Console.WriteLine);
        }

        internal List<string> GetTheWallUsing(List<Message> messages, Dictionary<string, List<string>> userToFollowed)
        {
            var wall = messages
                .Where(message => 
                    MessageBelongsToUser(message) ||
                    MessageBelongsToFollowedByUser(message, userToFollowed))
                .OrderByDescending(m => m.TimeStamp)
                .Select(m => $"{m.UserName} - {m.ToString()}")
                .DefaultIfEmpty($"No user {UserName}")
                .ToList();

            return wall;
        }

        private bool MessageBelongsToFollowedByUser(Message message, Dictionary<string, List<string>> userToFollowed)
        {
            return (userToFollowed.ContainsKey(UserName) &&
                    userToFollowed[UserName].Contains(message.UserName));
        }

        private bool MessageBelongsToUser(Message message)
        {
            return message.UserName == UserName;
        }
    }
}