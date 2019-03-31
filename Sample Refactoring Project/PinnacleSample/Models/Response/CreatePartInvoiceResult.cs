namespace PinnacleSample.Models.Response
{
    public class CreatePartInvoiceResult
    {
        public CreatePartInvoiceResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
