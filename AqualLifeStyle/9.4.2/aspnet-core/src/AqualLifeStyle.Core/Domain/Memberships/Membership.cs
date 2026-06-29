using System;
using Abp.Domain.Entities;
using AqualLifeStyle.Domain.Enums;

namespace AqualLifeStyle.Domain.Memberships
{
    public class Membership : Entity<int>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public MembershipType MembershipType { get; private set; }

        protected Membership()
        {
        }

        private Membership(string name, string description, MembershipType membershipType, bool isActive = true)
        {
            SetName(name);
            Description = description?.Trim();
            MembershipType = membershipType;
            IsActive = isActive;
        }

        public static Membership Create(string name, string description, MembershipType membershipType = MembershipType.Standard)
        {
            return new Membership(name, description, membershipType, true);
        }

        public void Rename(string name)
        {
            SetName(name);
        }

        public void UpdateDescription(string description)
        {
            Description = description?.Trim();
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void ChangeType(MembershipType membershipType)
        {
            MembershipType = membershipType;
        }

        public void EnsureCanBeAssignedToCustomer()
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("Inactive memberships cannot be assigned to new customers.");
            }
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Membership name is required.", nameof(name));
            }

            Name = name.Trim();
        }
    }
}
