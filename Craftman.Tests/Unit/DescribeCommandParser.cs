using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Craftman.Tests.Unit
{
    [TestFixture]
    public class DescribeCommandParser
    {
        private CommandParser _parser = new CommandParser();

        [Test]
        public void ItShouldCreateAnVoidCommand_GivenNoCommand()
        {
            //g
            var command = "";

            //w
            var actual = _parser.Parse(command);

            //t
            actual.Should().BeAssignableTo<VoidCommand>();
        }
    }
}
