using System.Threading.Tasks;
using CLI.Commands;

namespace CLI.Processes
{
    public interface IProcessExecutor
    {
        public Task<string> ExecuteAsync(ICommand command);
    }
}
