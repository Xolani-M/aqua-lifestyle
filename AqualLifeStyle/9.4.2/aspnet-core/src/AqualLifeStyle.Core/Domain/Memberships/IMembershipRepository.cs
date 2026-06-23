using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace AqualLifeStyle.Domain.Memberships
{
    public interface IMembershipRepository : IRepository<Membership, int>
    {
        Task<bool> ExistsByNameAsync(string name);
        Task<Membership?> GetByIdAsync(int id);
        Task AddAsync(Membership membership);
    }
}
