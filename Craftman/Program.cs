using System;
using System.Collections.Generic;
using Craftman.Commands;

namespace Craftman
{
    public class Program
    {
        private static ICommand _command;
        private static CommandParser _parser;
        private static Dictionary<string, List<string>> _userToMessages;
         
        public static void Main()

        {
            _userToMessages = new Dictionary<string, List<string>>();
            _parser = new CommandParser();

            while (ShouldNotQuit())
            {
                var userInput = Console.ReadLine();
                _command = _parser.Parse(userInput);
                Execute(_command);
            }
        }

        private static bool ShouldNotQuit()
        {
            return !(_command is QuitCommand);
        }

        internal static void Execute(ICommand command)
        {
            var postCommand = command as PostCommand;
            if (postCommand != null)
            {
                var userName = postCommand.UserName;
                if (!_userToMessages.ContainsKey(userName))
                {
                    _userToMessages.Add(userName, new List<string>());
                }
                _userToMessages[userName].Add(postCommand.Message);
            }

            var readCommand = command as ReadCommand;
            if (readCommand != null)
            {
                var userName = readCommand.UserName;
                if (!_userToMessages.ContainsKey(userName))
                {
                    Console.WriteLine($"No user {userName}");
                }
                else
                {
                    var messages = _userToMessages[userName];
                    messages.ForEach(Console.WriteLine);
                }
            }
        }
    }
}