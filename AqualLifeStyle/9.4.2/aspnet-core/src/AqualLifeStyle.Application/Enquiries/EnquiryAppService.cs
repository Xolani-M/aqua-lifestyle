using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AqualLifeStyle.Application.Enquiries.Dto;
using AqualLifeStyle.Domain.Enquiries;

namespace AqualLifeStyle.Application.Enquiries
{
    public class EnquiryAppService : AqualLifeStyleAppServiceBase, IEnquiryAppService
    {
        private readonly IEnquiryRepository _enquiryRepository;

        public EnquiryAppService(IEnquiryRepository enquiryRepository)
        {
            _enquiryRepository = enquiryRepository;
        }

        public async Task<IReadOnlyList<EnquiryDto>> GetAllAsync()
        {
            var enquiries = await _enquiryRepository.GetAllListAsync();
            return enquiries.Select(e => new EnquiryDto
            {
                Id = e.Id,
                CustomerId = e.CustomerId,
                ProductId = e.ProductId,
                Message = e.Message,
                Status = e.Status
            }).ToList();
        }

        public async Task<EnquiryDto> GetAsync(int id)
        {
            var enquiry = await _enquiryRepository.GetAsync(id);
            return new EnquiryDto
            {
                Id = enquiry.Id,
                CustomerId = enquiry.CustomerId,
                ProductId = enquiry.ProductId,
                Message = enquiry.Message,
                Status = enquiry.Status
            };
        }

        public async Task CreateAsync(CreateEnquiryDto input)
        {
            var enquiry = Enquiry.Create(input.CustomerId, input.ProductId, input.Message);
            await _enquiryRepository.InsertAsync(enquiry);
        }
    }
}
