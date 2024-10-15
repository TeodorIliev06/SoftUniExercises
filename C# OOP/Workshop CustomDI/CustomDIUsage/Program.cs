using CustomDIUsage.Core;
using IServiceProvider = CustomDI.Modules.Contracts.IServiceProvider;

namespace CustomDIUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DIContainer.BuildServiceProvider();
            Engine engine = serviceProvider.GetService<Engine>();

            engine.Something();
        }
    }
}
