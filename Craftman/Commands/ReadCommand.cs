using System;
using System.Collections.Generic;
using System.Linq;

namespace Craftman.Commands
{
    public class ReadCommand : ICommand
    {
        public ReadCommand(string useraNme)
        {
            UserName = useraNme;
        }
        public string UserName { get; }
        public void ExecuteUsing(List<Message> messages, Dictionary<string, List<string>> userToFollowed)
        {
            var timeline = GetTheUserTimeline(messages);
            
            timeline.ForEach(Console.WriteLine);
        }

        public List<string> GetTheUserTimeline(List<Message> messages)
        {
            var timeline = messages
                .Where(m => m.UserName == UserName)
                .Select(m => m.ToString())
                .DefaultIfEmpty($"No user {UserName}")
                .Reverse()
                .ToList();

            return timeline;
        }
    }
}