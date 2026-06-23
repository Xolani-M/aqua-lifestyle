using System.Threading.Tasks;

namespace AqualLifeStyle.Domain.Products
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
    }
}
