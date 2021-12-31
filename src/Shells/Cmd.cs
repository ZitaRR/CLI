using CLI.Commands;
using CLI.Processes;
using System.Threading.Tasks;

namespace CLI.Shells
{
    public sealed class Cmd : ProcessExecutor, ISession
    {
        public event ISession.Output OnOutput;

        public Cmd() : base(default)
        {

        }

        public async Task WriteAsync(ICommand command)
        {
            string output = await ExecuteAsync(command);
            OnOutput?.Invoke(default, output);
        }

        public async Task WriteAsync(string input)
        {
            await WriteAsync(new Command(input));
        }
    }
}
