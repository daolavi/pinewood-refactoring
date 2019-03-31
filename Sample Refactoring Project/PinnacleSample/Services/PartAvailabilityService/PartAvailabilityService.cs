namespace PinnacleSample.Services.PartAvailabilityService
{
    public class PartAvailabilityService : IPartAvailabilityService
    {
        public PartAvailabilityService()
        {

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
