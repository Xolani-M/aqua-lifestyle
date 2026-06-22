using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AqualLifeStyle.Controllers
{
    public abstract class AqualLifeStyleControllerBase: AbpController
    {
        protected AqualLifeStyleControllerBase()
        {
            LocalizationSourceName = AqualLifeStyleConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
