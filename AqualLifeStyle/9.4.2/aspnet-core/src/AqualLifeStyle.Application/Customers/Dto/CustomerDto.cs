namespace AqualLifeStyle.Application.Customers.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public int MembershipId { get; set; }

        public bool IsActive { get; set; }
    }
}
