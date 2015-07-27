using System;
using System.Collections.Generic;

namespace Craftman.Commands
{
    public class PostCommand : ICommand
    {
        public PostCommand(
            string userName, string text, DateTime timeStamp = default(DateTime))
        {
            TimeStamp = timeStamp == default (DateTime) ? DateTime.Now : timeStamp;
            UserName = userName;
            Text = text;
        }

        public string UserName {get;}
        public string Text { get; }
        public DateTime TimeStamp { get; }

        public void ExecuteUsing(List<Message> messages, Dictionary<string, List<string>> userToFollowed)
        {
            messages.Add(new Message(UserName, Text, TimeStamp));
        }
    }
}