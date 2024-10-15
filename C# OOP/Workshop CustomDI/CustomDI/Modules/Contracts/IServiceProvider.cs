namespace CustomDI.Modules.Contracts
{
    public interface IServiceProvider
    {
        T GetService<T>();
    }
}
