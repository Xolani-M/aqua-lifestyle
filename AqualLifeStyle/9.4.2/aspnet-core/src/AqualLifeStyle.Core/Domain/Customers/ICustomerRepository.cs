using System.Threading.Tasks;

namespace AqualLifeStyle.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
    }
}
