using IServiceProvider = CustomDI.Modules.Contracts.IServiceProvider;

namespace CustomDI.Modules
{
    internal class ServiceProvider : IServiceProvider
    {
        private ServiceCollection serviceCollection;

        public ServiceProvider(ServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type interfaceType)
        {
            if (serviceCollection.TransientMappingsWithFactories.ContainsKey(interfaceType))
            {
                return serviceCollection.TransientMappingsWithFactories[interfaceType](this);
            }

            var implementationType = serviceCollection.TransientMappings[interfaceType];

            var ctor = implementationType.GetConstructors().First();
            var parameters = ctor.GetParameters();
            var parameterObjects = new object[parameters.Length];
            int i = 0;

            foreach (var parameter in parameters)
            {
                parameterObjects[i++] = GetService(parameter.ParameterType);
            }

            return Activator.CreateInstance(implementationType, parameterObjects);
        }
    }
}
