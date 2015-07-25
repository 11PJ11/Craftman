using System;
using System.Collections.Generic;
using Craftman.Commands;

namespace Craftman
{
    class Program
    {
        private static ICommand _command; 

        static void Main()
        {
            var userInput = string.Empty;
            while (_command is QuitCommand)
            {
                userInput = Console.ReadLine();
                
            }
        }
    }
}