using CLI.Processes;

namespace CLI.Commands
{
    public interface ICommand
    {
        public Shell Shell { get; }
        public string Name { get; }
        public string Arguments { get; }
        public string TerminationFlag => Shell switch
        {
            Shell.Cmd => "/c",
            Shell.Bash => "-c",
            _ => ""
        };
    }
}
