using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using AqualLifeStyle.Application.Memberships.Dto;

namespace AqualLifeStyle.Application.Memberships
{
    public interface IMembershipAppService : IApplicationService
    {
        Task<IReadOnlyList<MembershipDto>> GetAllAsync();
        Task<MembershipDto> GetAsync(int id);
        Task CreateAsync(CreateMembershipDto input);
    }
}
