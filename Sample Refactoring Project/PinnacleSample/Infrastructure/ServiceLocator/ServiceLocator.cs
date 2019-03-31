﻿using PinnacleSample.Controllers.PartInvoiceController;
using PinnacleSample.Repositories.CustomerRepository;
using PinnacleSample.Repositories.PartInvoiceRepository;
using System;
using System.Collections.Generic;

namespace PinnacleSample.Infrastructure.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private static readonly Lazy<ServiceLocator> __Instance = new Lazy<ServiceLocator>(() => new ServiceLocator());

        private readonly IDictionary<object, object> __Container;

        internal ServiceLocator()
        {
            __Container = new Dictionary<object, object>
            {
                { typeof(IPartInvoiceController), new PartInvoiceController() },
                { typeof(ICustomerRepositoryDB), new CustomerRepositoryDB() },
                { typeof(IPartInvoiceRepositoryDB), new PartInvoiceRepositoryDB() }
            };
        }

        public static ServiceLocator Resolver()
        {
            return __Instance.Value;
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
