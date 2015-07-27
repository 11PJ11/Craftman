using Craftman.Tests.Scenarios.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenFollowing
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
        public void ItShouldNotifyTheUserIsMissing()
        {
            //g

            //w
            _theApp.UserWall("Alice");

            //t
            _theApp.Quit();
            var output = _theApp.CollectOutPut();
            output.Should().Contain("No user Alice");
        }
    }
}