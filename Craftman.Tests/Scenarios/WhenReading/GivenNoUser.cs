using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftman.Tests.Scenarios.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Scenarios.WhenReading
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
            _theApp.TimelineFor("Alice");

            //t
            _theApp.Quit();
            var output =  _theApp.CollectOutPut();
            output.Should().Be("No user Alice");
        }
    }
}
