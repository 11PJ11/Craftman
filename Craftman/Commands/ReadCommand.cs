using System;
using System.Collections.Generic;

namespace Craftman.Commands
{
    public class ReadCommand : ICommand
    {
        public ReadCommand(string useraNme)
        {
            UserName = useraNme;
        }
        public string UserName { get; }
        public void ExecuteUsing(Dictionary<string, List<string>> userToMessages)
        {
            if (!userToMessages.ContainsKey(UserName))
            {
                Console.WriteLine($"No user {UserName}");
            }
            else
            {
                var messages = userToMessages[UserName];
                messages.Reverse();
                messages.ForEach(Console.WriteLine);
            }
        }
    }
}