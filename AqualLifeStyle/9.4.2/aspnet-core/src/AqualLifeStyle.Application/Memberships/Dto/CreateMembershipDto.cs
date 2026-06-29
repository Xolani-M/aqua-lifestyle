using AqualLifeStyle.Domain.Enums;

namespace AqualLifeStyle.Application.Memberships.Dto
{
    public class CreateMembershipDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MembershipType MembershipType { get; set; } = MembershipType.Standard;
    }
}
