using System.Collections.Generic;
using System.Threading;
using Craftman.Tests.Scenarios.Helpers;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenFollowing
{
    [TestFixture]
    public class GivenManyUsers
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
            Thread.Sleep(50);

            _theApp.UserPosts("Bob", "Damn! We lost!");
            Thread.Sleep(50);
            _theApp.UserPosts("Bob", "Good game though.");
            Thread.Sleep(50);

            _theApp.UserPosts("Charlie", "I’m in New York today! Anyone want to have a coffee?");

            var expected = new List<string>
            {
                "Charlie - I’m in New York today! Anyone want to have a coffee? (1 second ago)",
                "Bob - Good game though. (1 second ago)",
                "Bob - Damn! We lost! (1 second ago)",
                "Alice - I love the weather today (1 second ago)"
            };
            _theApp.UserFollowsUser("Charlie", "Alice");
            
            //w
            _theApp.UserFollowsUser("Charlie", "Bob");

            //t
            _theApp.UserWall("Charlie");
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            CollectionAssert.AreEqual(expected, output);
        }
    }
}