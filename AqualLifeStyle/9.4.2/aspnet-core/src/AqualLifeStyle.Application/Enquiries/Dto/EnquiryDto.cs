using AqualLifeStyle.Domain.Enquiries;
using AqualLifeStyle.Domain.Enums;

namespace AqualLifeStyle.Application.Enquiries.Dto
{
    public class EnquiryDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public string Message { get; set; }

        public EnquiryStatus Status { get; set; }
    }
}
