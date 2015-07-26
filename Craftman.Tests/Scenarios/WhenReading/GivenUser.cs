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
            output.Should().Contain("I love the weather today");
        }
    }
}