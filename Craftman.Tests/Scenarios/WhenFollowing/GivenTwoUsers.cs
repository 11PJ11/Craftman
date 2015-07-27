using System.Collections.Generic;
using Craftman.Tests.Scenarios.Helpers;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenFollowing
{
    [TestFixture]
    public class GivenTwoUsers
    {
        private TheApplication _theApp;

        [SetUp]
        public void Setup()
        {
            _theApp = new TheApplication();
        }

        [Test]
        public void ItShouldShowTheAggregatedTimelines()
        {
            //g
            _theApp.UserPosts("Alice", "I love the weather today");
            _theApp.UserPosts("Charlie", "I’m in New York today! Anyone want to have a coffee?");
            var expected = new List<string>
            {
                "Charlie - I’m in New York today! Anyone want to have a coffee? (1 second ago)",
                "Alice - I love the weather today (1 second ago)"
            };
            //w
            _theApp.UserFollowsUser("Charlie", "Alice");

            //t
            _theApp.UserWall("Charlie");
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            CollectionAssert.AreEqual(expected, output);
        }
    }
}