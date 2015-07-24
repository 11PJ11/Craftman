namespace Craftman.Commands
{
    public class VoidCommand : ICommand
    {
        public VoidCommand()
        {
            UserName = string.Empty;
            Message = string.Empty;
        }

        public string UserName { get; }
        public string Message { get; }
    }
}