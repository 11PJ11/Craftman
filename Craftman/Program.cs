using System;
using System.Collections.Generic;

namespace Craftman
{
    class Program
    {
        private static bool _quit; 

        static void Main()
        {
            var command = string.Empty;
            while (!_quit)
            {
                command = Console.ReadLine();
                
            }
        }
    }

    public class CommandParser
    {
        public ICommand Parse(string command)
        {
            return new VoidCommand();
        }
    }

    public interface ICommand
    {
        
    }

    public class VoidCommand : ICommand
    {
        
    }
}
