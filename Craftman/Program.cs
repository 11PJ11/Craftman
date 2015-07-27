using System;
using System.Collections.Generic;
using Craftman.Commands;

namespace Craftman
{
    public class Program
    {
        private static ICommand _command;
        private static CommandParser _parser;
        private static List<Message> _messages;
         
        public static void Main()

        {
            _messages = new List<Message>();
            _parser = new CommandParser();

            while (ShouldNotQuit())
            {
                var userInput = Console.ReadLine();
                _command = _parser.Parse(userInput);
                _command.ExecuteUsing(_messages);
            }
        }

        private static bool ShouldNotQuit()
        {
            return !(_command is QuitCommand);
        }

    }
}