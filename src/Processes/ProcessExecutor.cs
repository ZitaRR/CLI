using CLI.Commands;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CLI.Processes
{
    public abstract class ProcessExecutor : IProcessExecutor
    {
        private readonly Shell shell;
        private readonly string terminator;

        public ProcessExecutor(Shell shell)
        {
            this.shell = shell;
            terminator = shell switch
            {
                Shell.Cmd => "/c",
                Shell.Bash => "-c",
                _ => ""
            };
        }

        public Task<string> ExecuteAsync(ICommand command)
        {
            Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = shell.ToString(),
                Arguments = $"{terminator} {command.Name} {command.Arguments}",
                RedirectStandardOutput = true
            });

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return Task.FromResult(output);
        }
    }
}
