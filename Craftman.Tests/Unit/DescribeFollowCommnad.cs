using System.Collections.Generic;
using Craftman.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribeFollowCommnad
    {
        [Test]
        public void ItShouldCreateTheFollower_GivenWasMissing()
        {
            //g
            var messages = new List<Message>();
            var userToFollowed = new Dictionary<string, List<string>>();
            var command = new FollowCommand("Charlie", "Alice");
            
            //w
            command.ExecuteUsing(messages, userToFollowed);
            
            //t  
            userToFollowed.Should().ContainKey("Charlie");
            userToFollowed["Charlie"].Should().Contain("Alice");
        }

        [Test]
        public void ItShouldStoreTheFollowedUser()
        {
            //g
            var messages = new List<Message>();
            var userToFollowed = new Dictionary<string, List<string>> { {"Charlie", new List<string>()} };
            var command = new FollowCommand("Charlie", "Alice");

            //w
            command.ExecuteUsing(messages, userToFollowed);

            //t  
            userToFollowed["Charlie"].Should().Contain("Alice");
        }
    }
}