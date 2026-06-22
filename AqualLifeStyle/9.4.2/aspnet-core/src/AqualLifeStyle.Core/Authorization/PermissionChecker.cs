using Abp.Authorization;
using AqualLifeStyle.Authorization.Roles;
using AqualLifeStyle.Authorization.Users;

namespace AqualLifeStyle.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
