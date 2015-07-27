using System;
using System.Collections.Generic;
using System.Linq;
using Craftman.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribePostCommand
    {
        [Test]
        public void ItShouldStoreTheMessageTimeStamp_WhenPosting()
        {
            //g
            var userName = "Alice";
            var text = "I love the weather";
            var timeStamp = new DateTime(2015, 7, 26, 15, 37, 30);
            var expectedMessage = new Message(userName, text, timeStamp);
            var command = new PostCommand(userName, text, timeStamp);
            var messages = new List<Message>();
            var userToFollowed = new Dictionary<string, List<string>>();
            
            //w
            command.ExecuteUsing(messages, userToFollowed);
            
            //t
            messages
                .Where(m=>m.UserName == "Alice")
                .Should()
                .Contain(expectedMessage);
        }
    }
}
