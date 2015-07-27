using Craftman.Tests.Scenarios.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenFollowing
{
    [TestFixture]
    public class GivenOneUserOnly
    {
        private TheApplication _theApp;

        [SetUp]
        public void Setup()
        {
            _theApp = new TheApplication();
        }

        [Test]
        public void ItShouldShowTheUserTimeline()
        {
            //g
            _theApp.UserPosts("Charlie", "I’m in New York today! Anyone want to have a coffee?");
            
            //w
            _theApp.UserFollowsUser("Charlie", "Alice");
            
            //t
            _theApp.UserWall("Charlie");
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            output.Should().Contain("I’m in New York today!Anyone want to have a coffee ? (1 second ago)");
        }
    }
}
