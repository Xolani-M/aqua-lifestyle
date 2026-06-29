using System;

namespace AqualLifeStyle.Domain.Products
{
    public class ProductEligibilityManager
    {
        public bool CanViewProduct(Customers.Customer customer, Product product)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!customer.IsActive) return false;
            if (!product.IsActive) return false;

            if (product.MembershipId == null) return true; // product available to everyone
            if (!customer.MembershipId.HasValue) return false;

            return product.MembershipId == customer.MembershipId;
        }
    }
}
