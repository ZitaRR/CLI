using CLI.Commands;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CLI.Processes
{
    public sealed class ProcessExecutor : IProcessExecutor
    {
        public Task<string> ExecuteAsync(ICommand command)
        {
            Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = command.Shell.ToString(),
                Arguments = $"{command.TerminationFlag} {command.Name} {command.Arguments}",
                RedirectStandardOutput = true
            });

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return Task.FromResult(output);
        }
    }
}
