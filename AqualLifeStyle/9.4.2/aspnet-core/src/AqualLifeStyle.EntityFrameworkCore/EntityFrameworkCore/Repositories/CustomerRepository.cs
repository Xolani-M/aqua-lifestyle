using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using AqualLifeStyle.Domain.Customers;

namespace AqualLifeStyle.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : AqualLifeStyleRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<AqualLifeStyleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task<bool> ExistsByEmailAsync(string email)
        {
            return GetAll().AnyAsync(c => c.Email.Value == email.Trim());
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
