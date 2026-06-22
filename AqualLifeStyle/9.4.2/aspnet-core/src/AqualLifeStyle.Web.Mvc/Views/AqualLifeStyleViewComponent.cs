using Abp.AspNetCore.Mvc.ViewComponents;

namespace AqualLifeStyle.Web.Views
{
    public abstract class AqualLifeStyleViewComponent : AbpViewComponent
    {
        protected AqualLifeStyleViewComponent()
        {
            LocalizationSourceName = AqualLifeStyleConsts.LocalizationSourceName;
        }
    }
}
