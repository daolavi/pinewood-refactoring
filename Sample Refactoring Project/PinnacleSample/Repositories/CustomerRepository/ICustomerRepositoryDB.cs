using PinnacleSample.Entities;

namespace PinnacleSample.Repositories.CustomerRepository
{
    public interface ICustomerRepositoryDB
    {
        Customer GetByName(string name);
    }
}
