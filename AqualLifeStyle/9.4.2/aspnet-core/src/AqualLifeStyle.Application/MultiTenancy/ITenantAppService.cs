using Abp.Application.Services;
using AqualLifeStyle.MultiTenancy.Dto;

namespace AqualLifeStyle.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

