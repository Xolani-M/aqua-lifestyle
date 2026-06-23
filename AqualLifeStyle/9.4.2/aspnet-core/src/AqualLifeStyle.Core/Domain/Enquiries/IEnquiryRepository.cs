using System.Threading.Tasks;

namespace AqualLifeStyle.Domain.Enquiries
{
    public interface IEnquiryRepository
    {
        Task<Enquiry> GetByIdAsync(int id);
        Task AddAsync(Enquiry enquiry);
    }
}
