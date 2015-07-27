using System;
using System.Collections.Generic;
using Craftman.Commands;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DecribeWallCommand
    {
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
                "Hello! (1 second ago)"
            };
            
            //w
            var actual = command.GetTheWallUsing(messages, userToFollowed);
            
            //t
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}