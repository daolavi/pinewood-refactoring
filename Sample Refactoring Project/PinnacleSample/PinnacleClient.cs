using PinnacleSample.Controllers.PartInvoiceController;
using PinnacleSample.Infrastructure.ServiceLocator;
using PinnacleSample.Models.Response;

namespace PinnacleSample
{
    public class PinnacleClient
    {
        private IPartInvoiceController __Controller;

        public PinnacleClient()
        {
            __Controller = ServiceLocator.Resolver().Resolve<IPartInvoiceController>();
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return __Controller.CreatePartInvoice(stockCode, quantity, customerName);
        }
    }
}
