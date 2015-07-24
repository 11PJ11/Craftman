using System.Text.RegularExpressions;
using Craftman.Commands;

namespace Craftman
{
    public class CommandParser
    {
        private const string PostMessagePattern = @"(?<userName>\w+) -> (?<message>.*)";

        public ICommand Parse(string command)
        {
            var postMessageReg = new Regex(PostMessagePattern);
            var match = postMessageReg.Match(command);
            if (match.Success)
            {
                var userName = match.Groups["userName"].Value;
                var message = match.Groups["message"].Value;
                return new PostCommand(userName, message);
            }
            return new VoidCommand();
        }
    }
}