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
            messages = messages
                .Where(m => m.UserName == UserName)
                .Reverse()
                .ToList();
            
            if(messages.Any())
                messages.ForEach(Console.WriteLine);
            else
                Console.WriteLine($"No user {UserName}");
        }
    }
}