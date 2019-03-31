namespace PinnacleSample.Infrastructure.IoC
{
    public interface IIoC
    {
        IIoC Register<T>() where T : class;

        T Resolve<T>();
    }
}
