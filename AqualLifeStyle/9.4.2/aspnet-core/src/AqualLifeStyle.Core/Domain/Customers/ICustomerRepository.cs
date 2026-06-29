using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace AqualLifeStyle.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Task<bool> ExistsByEmailAsync(string email);
    }
}
