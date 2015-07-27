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

        public void Quit()
        {
            var command = "quit";
            SendCommand(command);
        }

        private void SendCommand(string command)
        {
            _process?.StandardInput.WriteLine(command);
        }

        public string[] CollectOutPut()
        {
            _process.StandardInput.Close();

            var outputString = _process.StandardOutput.ReadToEnd();
            return outputString
                .Replace("}",string.Empty)
                .Split(new[] {"\r\n"},StringSplitOptions.RemoveEmptyEntries);
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

        public void UserFollowsUser(string follower, string followed)
        {
            var command = $"{follower} follows {followed}";
            SendCommand(command);
        }

        public void UserWall(string user)
        {
            var command = $"{user} wall";
            SendCommand(command);
        }
    }
}