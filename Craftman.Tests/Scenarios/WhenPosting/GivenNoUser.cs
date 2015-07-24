using Craftman.Tests.Scenarios.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenPosting
{
    [TestFixture]
    public class GivenNoUser
    {
        private TheApplication _theApp;

        [SetUp]
        public void Setup()
        {
            _theApp = new TheApplication();
        }
         
        [Test]
        public void ItShouldCreateTheUserAndTheMessageToTheTimeline()
        {
            //g

            //w
            _theApp.UserPosts("Alice","I Love the weather today");
            
            //t
            _theApp.TimelineFor("Alice");
            var output = _theApp.OutPut;
            output.Should().Contain("I Love the weather today");
        }
    }
}
