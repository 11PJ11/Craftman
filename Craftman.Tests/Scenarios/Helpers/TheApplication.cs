using System;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public void Quit()
        {
            var command = "quit";
            SendCommand(command);
        }

        private void SendCommand(string command)
        {
            _process?.StandardInput.WriteLine(command);
        }

        public async Task<string> CollectOutPutAsync()
        {
            _process.StandardInput.Close();

            var outputString = await _process.StandardOutput.ReadToEndAsync();
            return outputString;
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