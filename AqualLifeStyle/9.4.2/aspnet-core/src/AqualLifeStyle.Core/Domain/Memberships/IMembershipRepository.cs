using System.Threading.Tasks;

namespace AqualLifeStyle.Domain.Memberships
{
    public interface IMembershipRepository
    {
        Task<bool> ExistsByNameAsync(string name);
        Task<Membership?> GetByIdAsync(int id);
        Task AddAsync(Membership membership);
    }
}
using Abp.Domain.Repositories;

namespace AqualLifeStyle.Domain.Memberships
{
    public interface IMembershipRepository : IRepository<Membership, int>
    {
    }
}
