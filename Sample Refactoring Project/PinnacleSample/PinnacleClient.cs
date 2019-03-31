using PinnacleSample.Controllers.PartInvoiceController;
using PinnacleSample.Extensions;
using PinnacleSample.Infrastructure.IoC;
using PinnacleSample.Models.Response;

namespace PinnacleSample
{
    public class PinnacleClient
    {
        private IPartInvoiceController __Controller;

        public PinnacleClient()
        {
            var _Ioc = new IoC();
            _Ioc.RegisterApplicationServices();

            __Controller = new PartInvoiceController(_Ioc);
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return __Controller.CreatePartInvoice(stockCode, quantity, customerName);
        }
    }
}
