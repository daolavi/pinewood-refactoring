﻿using PinnacleSample.Infrastructure.IoC;
using PinnacleSample.Repositories.CustomerRepository;
using PinnacleSample.Repositories.PartInvoiceRepository;

namespace PinnacleSample.Extensions
{
    public static class IoCExtension
    {
        /**
         * Register services to IOC
         * **/
        public static void RegisterApplicationServices(this IIoC ioc)
        {
            ioc.Register<ICustomerRepositoryDB>()
                .Register<IPartInvoiceRepositoryDB>()
                .Register<Services.PartAvailabilityService.IPartAvailabilityService>();
        }
    }
}
