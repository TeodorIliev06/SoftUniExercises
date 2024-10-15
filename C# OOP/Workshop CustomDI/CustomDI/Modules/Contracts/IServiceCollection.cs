namespace CustomDI.Modules.Contracts
{
    public interface IServiceCollection
    {
        void AddTransient<TInterface, TImpl>();
        void AddTransient<TInterface, TImpl>(Func<IServiceProvider, object> factory);

        IServiceProvider BuildServiceProvider();
    }
}
