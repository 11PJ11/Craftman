using System;
using System.Collections.Generic;
using Craftman.Commands;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribeReadCommand
    {
        [Test]
        public void ItShouldShowAnErrorMessage_GivenTheUserIsMissing()
        {
            //g
            var userName = "Alice";
            var command = new ReadCommand(userName);
            var expected = new List<string>
            {
                "No user Alice"
            };

            //w
            var charliesMessage = new Message("Charlie", "Hello!", DateTime.Now);
            var messages = new List<Message> {charliesMessage};
            var actual = command.GetTheUserTimeline(messages);

            //t
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ItShouldShowTheUserMessages()
        {
            //g
            var userName = "Alice";
            var message1 = new Message(userName, "Good day", DateTime.Now.AddSeconds(-5));
            var message2 = new Message(userName, "I feel great", DateTime.Now);
            var messages = new List<Message> { message1, message2 };
            var command = new ReadCommand(userName);
            var expected = new List<string>
            {
                "I feel great (1 second ago)",
                "Good day (5 seconds ago)"
            };
            //w
            var actual = command.GetTheUserTimeline(messages);

            //t
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}