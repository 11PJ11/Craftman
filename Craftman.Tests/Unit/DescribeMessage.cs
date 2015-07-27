using System;
using FluentAssertions;
using NUnit.Framework;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribeMessage
    {
        [Test]
        public void ItShouldShowElpsedSeconds_GivenLessThanOneMinuteHasPassed()
        {
            //g
            var tenSecondsAgo = DateTime.Now.AddSeconds(-10);
            var message = new Message("Alice", "I love the weather today",tenSecondsAgo);
            
            //w
            var text = message.ToString();

            //t
            text.Should().Be("I love the weather today (10 seconds ago)");
        }

        [TestCase(-0.5, "1 second")]
        [TestCase(-1, "1 second")]
        [TestCase(-2, "2 seconds")]
        [TestCase(-59, "59 seconds")]
        [TestCase(-60, "1 minute")]
        [TestCase(-119, "1 minute")]
        [TestCase(-120, "2 minutes")]
        [TestCase(-3599, "59 minutes")]
        [TestCase(-3600, "1 hour")]
        [TestCase(-7199, "1 hour")]
        [TestCase(-7200, "2 hours")]
        [TestCase(-86399, "23 hours")]
        [TestCase(-86400, "1 day")]
        [TestCase(-172799, "1 day")]
        [TestCase(-172800, "2 days")]
        public void ItShouldGenerateTheElapsedTimeString(
            double secondsAgo, string expected)
        {
            //g
            var timeStamp = DateTime.Now.AddSeconds(secondsAgo);
            var messageAge = DateTime.Now - timeStamp;

            //w
            var elapsed = Message.GetElapsedTime(messageAge);
            
            //t
            elapsed.Should().Be(expected);
        }
    }
}