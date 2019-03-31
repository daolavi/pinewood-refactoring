using PinnacleSample.Entities;
using PinnacleSample.Infrastructure.ServiceLocator;
using PinnacleSample.Models.Response;
using PinnacleSample.Repositories.CustomerRepository;
using PinnacleSample.Repositories.PartInvoiceRepository;

namespace PinnacleSample.Controllers.PartInvoiceController
{
    public class PartInvoiceController : IPartInvoiceController
    {
        private readonly ICustomerRepositoryDB __CustomerRepositoryDB;

        private readonly IPartInvoiceRepositoryDB __PartInvoiceRepositoryDB;

        public PartInvoiceController()
        {
            __CustomerRepositoryDB = ServiceLocator.Resolver().Resolve<ICustomerRepositoryDB>();
            __PartInvoiceRepositoryDB = ServiceLocator.Resolver().Resolve<IPartInvoiceRepositoryDB>();
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            if (string.IsNullOrEmpty(stockCode))
            {
                return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }
            
            Customer _Customer = __CustomerRepositoryDB.GetByName(customerName);
            if (_Customer.ID <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            int _Availability = GetAvailability(stockCode);
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

        public int GetAvailability(string stockCode)
        {
            using (PartAvailabilityServiceClient _PartAvailabilityService = new PartAvailabilityServiceClient())
            {
                return _PartAvailabilityService.GetAvailability(stockCode);
            }
        }
    }
}
