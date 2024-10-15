using CustomDI.Modules.Contracts;
using IServiceProvider = CustomDI.Modules.Contracts.IServiceProvider;
namespace CustomDI.Modules
{
    public class ServiceCollection : IServiceCollection
    {
        internal IDictionary<Type, Type> TransientMappings { get; set; }
        internal IDictionary<Type, Func<IServiceProvider, object>> TransientMappingsWithFactories { get; set; }

        public ServiceCollection()
        {
            TransientMappings = new Dictionary<Type, Type>();
            TransientMappingsWithFactories = new Dictionary<Type, Func<IServiceProvider, object>>();
        }

        public void AddTransient<TInterface, TImpl>()
        {
            TransientMappings.Add(typeof(TInterface), typeof(TImpl));
        }

        public void AddTransient<TInterface, TImpl>(Func<IServiceProvider, object> factory)
        {
            TransientMappingsWithFactories.Add(typeof(TInterface), factory);
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(this);
        }
    }
}
