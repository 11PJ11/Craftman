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

        public static ICommand CreateFollowCommnad(Match followMatch)
        {
            var userName = followMatch.Groups["userName"].Value;
            var followed = followMatch.Groups["followed"].Value;
            return new FollowCommand(userName, followed);
        }
    }
}