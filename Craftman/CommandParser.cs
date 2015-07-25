using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Craftman.Commands;

namespace Craftman
{
    public class CommandParser
    {
        private const string QuitPattern = @"[Q|q]uit";
        private const string PostMessagePattern = @"(?<userName>\w+) -> (?<message>.*)";

        public ICommand Parse(string command)
        {
            var quitReg = new Regex(QuitPattern);
            var quitMatch = quitReg.Match(command);
            if (quitMatch.Success)
            {
                return new QuitCommand();
            }

            var postMessageReg = new Regex(PostMessagePattern);
            var postMessageMatch = postMessageReg.Match(command);
            if (postMessageMatch.Success)
            {
                var userName = postMessageMatch.Groups["userName"].Value;
                var message = postMessageMatch.Groups["message"].Value;
                return new PostCommand(userName, message);
            }
            return new VoidCommand();
        }

        
    }
}