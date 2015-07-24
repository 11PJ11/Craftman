using System;
using System.Diagnostics;

namespace Craftman.Tests.Scenarios.Helpers
{
    public class TheApplication : IDisposable
    {
        private readonly Process _process;
        private const string AppPath = @"..\..\..\Craftman\bin\Debug\Craftman.exe";

        public TheApplication()
        {
            var processStartInfo = new ProcessStartInfo(AppPath)
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            _process = Process.Start(processStartInfo);
        }

        public void UserPosts(string username, string message)
        {
            var command = $"{username} -> {message}}}";

            SendCommand(command);
        }
        private void SendCommand(string command)
        {
            if (_process == null)
                return;
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.WriteLine("mkdir testDir");
            _process.StandardInput.WriteLine("echo hello");
        }

        public string OutPut
        {
            get
            {
                _process.StandardInput.Close(); 
                var outputString = _process.StandardOutput.ReadToEnd();
                return outputString;
            }
        }

        public void Dispose()
        {
            _process.Close();
        }

        public void TimelineFor(string user)
        {
            var command = $"{user}";
            SendCommand(command);
        }
    }
}