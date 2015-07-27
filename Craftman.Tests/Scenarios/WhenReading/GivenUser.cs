using Craftman.Tests.Scenarios.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenReading
{
    [TestFixture]
    public class GivenUser
    {
        private TheApplication _theApp;

        [SetUp]
        public void Setup()
        {
            _theApp = new TheApplication();
        }

        [Test]
        public void ItShouldShowTheMessage_GiveUserInputAMessage()
        {
            //g
            _theApp.UserPosts("Alice","I love the weather today");

            //w
            _theApp.TimelineFor("Alice");

            //t
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            output.Should().Contain("I love the weather today (1 second ago)");
        }

        [Test]
        public void ItShouldShowTheMessagesFromLastToFirst_GiveUserInputSomeMessages()
        {
            //g
            var expected = new[]
            {
                "Good game though. (1 second ago)",
                "Damn! We lost! (1 second ago)"
            };

            _theApp.UserPosts("Bob", "Damn! We lost!");
            _theApp.UserPosts("Bob", "Good game though.");

            //w
            _theApp.TimelineFor("Bob");

            //t
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            CollectionAssert.AreEqual(expected, output);
        }
    }
}