using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using AqualLifeStyle.Domain.Enquiries;

namespace AqualLifeStyle.EntityFrameworkCore.Repositories
{
    public class EnquiryRepository : AqualLifeStyleRepositoryBase<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(IDbContextProvider<AqualLifeStyleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
