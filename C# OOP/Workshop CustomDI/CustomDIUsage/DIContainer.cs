using CustomDI.Modules;
using CustomDIUsage.Core;
using CustomDIUsage.Modules;
using CustomDIUsage.Modules.Contracts;
using IServiceProvider = CustomDI.Modules.Contracts.IServiceProvider;

namespace CustomDIUsage
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            services.AddTransient<Engine, Engine>();
            services.AddTransient<DateTime, DateTime>((sp) =>
            {
                return DateTime.Now.AddDays(365);
            });

            return services.BuildServiceProvider();
        }
    }
}
