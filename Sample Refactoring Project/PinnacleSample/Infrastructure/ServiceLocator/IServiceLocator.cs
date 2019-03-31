namespace PinnacleSample.Infrastructure.ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>();
    }
}
