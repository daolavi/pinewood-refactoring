using System;
using System.Collections.Generic;

namespace PinnacleSample.Infrastructure.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private static Lazy<ServiceLocator> __Instance = new Lazy<ServiceLocator>(() => new ServiceLocator());

        private IDictionary<object, object> __Services;

        internal ServiceLocator()
        {
            
        }

        public T GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
