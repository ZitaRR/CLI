using CLI.Commands;
using System.Threading.Tasks;

namespace CLI.Processes
{
    public interface ISession
    {
        public delegate void Output(Shell shell, string output);
        public event Output OnOutput;
        public Task WriteAsync(ICommand command);
        public Task WriteAsync(string input);
    }
}
