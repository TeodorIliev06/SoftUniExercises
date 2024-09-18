using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Commands;

public class ExitCommand : ICommand
{
    private const int exitCode = 0;
    public string Execute(string[] args)
    {
        Environment.Exit(exitCode);
        return null;
    }
}
