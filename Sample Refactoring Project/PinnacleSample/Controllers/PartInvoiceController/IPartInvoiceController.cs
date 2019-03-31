using PinnacleSample.Models.Response;

namespace PinnacleSample.Controllers.PartInvoiceController
{
    public interface IPartInvoiceController
    {
        CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName);

        int GetAvailability(string stockCode);
    }
}
