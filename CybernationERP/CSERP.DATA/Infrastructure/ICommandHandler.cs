namespace CSERP.DATA.Infrastructure
{
    public interface ICommandHandler<Command> where Command : ICommand
    {
        void Execute(Command command);
    }
}
