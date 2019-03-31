using System;
using System.Collections.Generic;

namespace PinnacleSample.Infrastructure.IoC
{
    /**
     * The implementation for services in original project coupled tightly. So, it was difficult to have unit tests.
     * PinnacleSample.Infrastructure.IoC is a simple implementation, following Dependency Inversion Principle to decouple services.
     * **/
    public class IoC : IIoC
    {
        private static IDictionary<object, object> __Container;

        public IoC()
        {
            if (__Container == null)
            {
                __Container = new Dictionary<object, object>();
            }
        }

        public IIoC Register<T>() where T : class
        {
            if (!__Container.ContainsKey(typeof(T)))
            {
                var instance = Activator.CreateInstance<T>();
                __Container.Add(typeof(T), instance);
            }

            return this;
        }

        public T Resolve<T>()
        {
            try
            {
                return (T)__Container[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("The requested service is not registered");
            }
        }
    }
}
