namespace Craftman.Commands
{
    public interface ICommand
    {
        string UserName { get; }
        string Message { get; }
    }
}