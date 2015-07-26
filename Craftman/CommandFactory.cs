using System.Text.RegularExpressions;
using Craftman.Commands;

namespace Craftman
{
    public static class CommandFactory
    {
        public static QuitCommand CreateQuitCommand(Match quitMatch)
        {
            return new QuitCommand();
        }

        public static PostCommand CreatePostCommand(Match postMessageMatch)
        {
            var userName = postMessageMatch.Groups["userName"].Value;
            var message = postMessageMatch.Groups["message"].Value;
            return new PostCommand(userName, message);
        }

        public static ReadCommand CreateReadCommand(Match readMatch)
        {
            var userName = readMatch.Groups["userName"].Value;
            return new ReadCommand(userName);
        }
    }
}