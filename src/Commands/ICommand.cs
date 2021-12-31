namespace CLI.Commands
{
    public interface ICommand
    {
        public string Name { get; }
        public string Arguments { get; }
    }
}
