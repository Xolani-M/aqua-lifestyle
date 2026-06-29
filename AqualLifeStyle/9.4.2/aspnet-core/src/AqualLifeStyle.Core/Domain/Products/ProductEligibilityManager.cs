using System;
using AqualLifeStyle.Domain.Customers;
using AqualLifeStyle.Domain.Enums;
using AqualLifeStyle.Domain.Memberships;

namespace AqualLifeStyle.Domain.Products
{
    public class ProductEligibilityManager
    {
        private readonly IMembershipLookup _membershipLookup;

        public ProductEligibilityManager(IMembershipLookup membershipLookup)
        {
            _membershipLookup = membershipLookup ?? throw new ArgumentNullException(nameof(membershipLookup));
        }

        public bool CanViewProduct(Customer customer, Product product)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!customer.IsActive) return false;
            if (!product.IsActive) return false;
            if (product.MembershipId == null) return true;
            if (!customer.MembershipId.HasValue) return false;

            var membership = _membershipLookup.GetAsync(customer.MembershipId.Value).GetAwaiter().GetResult();
            if (membership == null || !membership.IsActive) return false;

            return IsMembershipEligible(membership.MembershipType, product.MembershipId.Value);
        }

        private static bool IsMembershipEligible(MembershipType membershipType, int requiredMembershipId)
        {
            return membershipType switch
            {
                MembershipType.Premium => requiredMembershipId <= 2,
                MembershipType.Vip => requiredMembershipId <= 3,
                _ => requiredMembershipId == 1
            };
        }
    }
}
