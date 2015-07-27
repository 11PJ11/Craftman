using System;
using System.Collections.Generic;
using Craftman.Commands;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribeWallCommand
    {
        [Test]
        public void ItShouldShowAnErrorMessage_GivenTheUserIsMissing()
        {
            //g
            var userName = "Alice";
            var message = new Message("Charlie", "Hello!", DateTime.Now);
            var messages = new List<Message> { message };
            var userToFollowed = new Dictionary<string, List<string>>();
            var command = new WallCommand(userName);
            var expected = new List<string>
            {
                "No user Alice"
            };

            //w
            var actual = command.GetTheWallUsing(messages, userToFollowed);

            //t
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ItShouldShowTheUserMessages_GivenNotFollowingOtherUsers()
        {
            //g
            var userName = "Charlie";
            var message = new Message(userName, "Hello!", DateTime.Now);
            var messages = new List<Message> {message};
            var userToFollowed = new Dictionary<string, List<string>>();
            var command = new WallCommand(userName);
            var expected = new List<string>
            {
                "Charlie - Hello! (1 second ago)"
            };
            
            //w
            var actual = command.GetTheWallUsing(messages, userToFollowed);
            
            //t
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ItShouldShowTheAggregatedTimelines_GivenFollowingAnotherUser()
        {
            //g
            var userName = "Charlie";
            var charliesMessage = new Message(userName, "Hello!", DateTime.Now);
            var aliceMessage = new Message("Alice", "Good day!", DateTime.Now.AddMinutes(-5));
            var messages = new List<Message> { aliceMessage, charliesMessage };
            var userToFollowed = new Dictionary<string, List<string>>
            {
                {userName, new List<string> {"Alice"} }
            };
            var command = new WallCommand(userName);
            var expected = new List<string>
            {
                "Charlie - Hello! (1 second ago)",
                "Alice - Good day! (5 minutes ago)"
            };

            //w
            var actual = command.GetTheWallUsing(messages, userToFollowed);

            //t
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}