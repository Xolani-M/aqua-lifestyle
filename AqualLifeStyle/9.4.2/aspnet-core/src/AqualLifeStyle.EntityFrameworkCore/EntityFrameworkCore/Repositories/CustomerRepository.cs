using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using AqualLifeStyle.Domain.Customers;

namespace AqualLifeStyle.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : AqualLifeStyleRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<AqualLifeStyleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return GetAsync(id);
        }

        public Task AddAsync(Customer customer)
        {
            return InsertAsync(customer);
        }
    }
}
