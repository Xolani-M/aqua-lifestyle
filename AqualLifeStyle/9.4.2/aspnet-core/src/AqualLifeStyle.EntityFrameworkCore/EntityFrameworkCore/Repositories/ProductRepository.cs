using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using AqualLifeStyle.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace AqualLifeStyle.EntityFrameworkCore.Repositories
{
    public class ProductRepository : AqualLifeStyleRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<AqualLifeStyleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Set<Product>().AnyAsync(p => p.Name == name);
        }
    }
}
