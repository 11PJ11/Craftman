namespace Craftman.Commands
{
    public class VoidCommand : ICommand
    {
        public VoidCommand()
        {
            UserName = string.Empty;
        }

        public string UserName { get; }
    }
}