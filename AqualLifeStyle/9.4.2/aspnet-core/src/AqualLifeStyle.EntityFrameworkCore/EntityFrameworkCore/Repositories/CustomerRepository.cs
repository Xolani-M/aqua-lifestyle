using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using AqualLifeStyle.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace AqualLifeStyle.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : AqualLifeStyleRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<AqualLifeStyleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Set<Customer>().AnyAsync(c => c.Email.Value == email);
        }
    }
}
