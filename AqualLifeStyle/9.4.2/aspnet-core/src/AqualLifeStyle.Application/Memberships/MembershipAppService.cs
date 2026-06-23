using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using AqualLifeStyle.Application.Memberships.Dto;
using AqualLifeStyle.Domain.Memberships;

namespace AqualLifeStyle.Application.Memberships
{
    public class MembershipAppService : AqualLifeStyleAppServiceBase, IMembershipAppService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipAppService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IReadOnlyList<MembershipDto>> GetAllAsync()
        {
            var memberships = await _membershipRepository.GetAllListAsync();
            return memberships.Select(m => new MembershipDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                IsActive = m.IsActive
            }).ToList();
        }

        public async Task<MembershipDto> GetAsync(int id)
        {
            var membership = await _membershipRepository.GetAsync(id);
            return new MembershipDto
            {
                Id = membership.Id,
                Name = membership.Name,
                Description = membership.Description,
                IsActive = membership.IsActive
            };
        }

        public async Task CreateAsync(CreateMembershipDto input)
        {
            var membership = Membership.Create(input.Name, input.Description);
            await _membershipRepository.InsertAsync(membership);
        }
    }
}
