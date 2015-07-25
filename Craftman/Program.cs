using System;
using System.Collections.Generic;
using Craftman.Commands;

namespace Craftman
{
    class Program
    {
        private static ICommand _command;
        private static CommandParser _parser;
        private static Dictionary<string, List<string>> _userToMessages;
         
        static void Main()

        {
            _userToMessages = new Dictionary<string, List<string>>();
            _parser = new CommandParser();

            while (_command is QuitCommand)
            {
                var userInput = Console.ReadLine();
                _command = _parser.Parse(userInput);
                Execute(_command);
            }
        }

        internal static void Execute(ICommand command)
        {
            var postCommand = command as PostCommand;
            if (postCommand != null)
            {
                if (!_userToMessages.ContainsKey(postCommand.UserName))
                {
                    _userToMessages.Add(postCommand.UserName, new List<string>());
                }
                _userToMessages[postCommand.UserName].Add(postCommand.Message);
            }
        }
    }
}