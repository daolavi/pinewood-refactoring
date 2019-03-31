using PinnacleSample.Models.Request;

namespace PinnacleSample.Controllers.PartInvoiceController
{
    public interface IPartInvoiceController
    {
        CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName);
    }
}
