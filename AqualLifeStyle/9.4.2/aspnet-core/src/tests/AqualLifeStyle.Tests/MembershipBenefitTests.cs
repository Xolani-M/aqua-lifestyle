using AqualLifeStyle.Domain.Enums;
using AqualLifeStyle.Domain.Memberships;
using Xunit;

namespace AqualLifeStyle.Tests
{
    public class MembershipBenefitTests
    {
        [Fact]
        public void Create_DefaultsToActiveBenefit()
        {
            var benefit = MembershipBenefit.Create(
                MembershipType.Premium,
                "20% Discount",
                "Get 20% off on all purchases"
            );

            Assert.True(benefit.IsActive);
            Assert.Equal("20% Discount", benefit.BenefitName);
            Assert.Equal(MembershipType.Premium, benefit.MembershipType);
        }

        [Fact]
        public void Create_WithBenefitValue()
        {
            var benefit = MembershipBenefit.Create(
                MembershipType.Vip,
                "Point Multiplier",
                "Earn 2x points on every purchase",
                benefitValue: 2m
            );

            Assert.Equal(2m, benefit.BenefitValue);
        }

        [Fact]
        public void UpdateBenefit_ModifiesProperties()
        {
            var benefit = MembershipBenefit.Create(
                MembershipType.Standard,
                "Free Shipping",
                "Free shipping on orders over $50"
            );

            benefit.UpdateBenefit(
                "Free Shipping Tier",
                "Free shipping on all orders for members",
                null
            );

            Assert.Equal("Free Shipping Tier", benefit.BenefitName);
        }

        [Fact]
        public void ActivateAndDeactivate_ChangeLifecycleState()
        {
            var benefit = MembershipBenefit.Create(
                MembershipType.Premium,
                "Birthday Bonus",
                "Extra 500 points on your birthday"
            );

            benefit.Deactivate();
            Assert.False(benefit.IsActive);

            benefit.Activate();
            Assert.True(benefit.IsActive);
        }

        [Fact]
        public void Create_WithNullBenefitName_Throws()
        {
            Assert.Throws<System.ArgumentException>(
                () => MembershipBenefit.Create(
                    MembershipType.Standard,
                    null,
                    "Description"
                )
            );
        }
    }
}
