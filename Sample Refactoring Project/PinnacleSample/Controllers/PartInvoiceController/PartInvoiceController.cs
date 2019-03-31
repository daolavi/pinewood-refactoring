using PinnacleSample.Entities;
using PinnacleSample.Infrastructure.IoC;
using PinnacleSample.Models.Response;
using PinnacleSample.Repositories.CustomerRepository;
using PinnacleSample.Repositories.PartInvoiceRepository;
using System;

namespace PinnacleSample.Controllers.PartInvoiceController
{
    public class PartInvoiceController : IPartInvoiceController
    {
        private readonly ICustomerRepositoryDB __CustomerRepositoryDB;

        private readonly IPartInvoiceRepositoryDB __PartInvoiceRepositoryDB;

        private readonly Services.PartAvailabilityService.IPartAvailabilityService __IPartAvailabilityService;

        public PartInvoiceController(IIoC ioc)
        {
            __CustomerRepositoryDB = ioc.Resolve<ICustomerRepositoryDB>();
            __PartInvoiceRepositoryDB = ioc.Resolve<IPartInvoiceRepositoryDB>();
            __IPartAvailabilityService = ioc.Resolve<Services.PartAvailabilityService.IPartAvailabilityService>();
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            // This method calls to external services (Database, Webservice). It is better to have try catch to handle exceptions.
            try
            {
                // Changed: Add validation for customerName.
                if (string.IsNullOrEmpty(stockCode) || string.IsNullOrEmpty(customerName))
                {
                    return new CreatePartInvoiceResult(false);
                }

                if (quantity <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }

                Customer _Customer = __CustomerRepositoryDB.GetByName(customerName);
                // Changed: Validate Customer in case of customer not found.
                if (_Customer == null || _Customer.ID <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }

                int _Availability = __IPartAvailabilityService.GetAvailability(stockCode);
                if (_Availability <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }

                PartInvoice _PartInvoice = new PartInvoice
                {
                    StockCode = stockCode,
                    Quantity = quantity,
                    CustomerID = _Customer.ID
                };

                __PartInvoiceRepositoryDB.Add(_PartInvoice);

                return new CreatePartInvoiceResult(true);
            }
            catch(Exception)
            {
                // Logging
                return new CreatePartInvoiceResult(false);
            }
        }
    }
}
