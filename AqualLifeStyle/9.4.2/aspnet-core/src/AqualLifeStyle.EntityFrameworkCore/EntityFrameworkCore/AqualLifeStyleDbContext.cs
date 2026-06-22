using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AqualLifeStyle.Authorization.Roles;
using AqualLifeStyle.Authorization.Users;
using AqualLifeStyle.MultiTenancy;

namespace AqualLifeStyle.EntityFrameworkCore
{
    public class AqualLifeStyleDbContext : AbpZeroDbContext<Tenant, Role, User, AqualLifeStyleDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AqualLifeStyleDbContext(DbContextOptions<AqualLifeStyleDbContext> options)
            : base(options)
        {
        }
    }
}
