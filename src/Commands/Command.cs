using System;

namespace CLI.Commands
{
    public readonly struct Command : ICommand
    {
        public string Name { get; }
        public string Arguments { get; }

        public Command(string name, params string[] arguments)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Cannot be empty or null.", nameof(name));
            }

            Name = name;
            Arguments = string.Join(" ", arguments);
        }
    }
}
