namespace Craftman.Commands
{
    public class ReadCommand : ICommand
    {
        public ReadCommand(string useraNme)
        {
            UserName = useraNme;
        }
        public string UserName { get; }
    }
}