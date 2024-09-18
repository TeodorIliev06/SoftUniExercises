using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Interpreters;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] elements = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string commandName = $"{elements[0]}Command";
        string[] commandArgs = elements.Skip(1).ToArray();

        Assembly assembly = Assembly.GetEntryAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName);

        if (type == null)
        {
            throw new ArgumentException("Invalid type!");
        }

        //ICommand instance = (ICommand)Activator.CreateInstance(type);
        //return instance?.Execute(commandArgs);

        MethodInfo executeMethodInfo = type.GetMethods((BindingFlags)20)
            .FirstOrDefault(m => m.Name == "Execute");

        Object instance = Activator.CreateInstance(type);
        string result = (string)executeMethodInfo
            .Invoke(instance, new object[] { commandArgs });

        return result;
    }
}
