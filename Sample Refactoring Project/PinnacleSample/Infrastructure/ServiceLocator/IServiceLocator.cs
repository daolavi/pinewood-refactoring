namespace PinnacleSample.Infrastructure.ServiceLocator
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
