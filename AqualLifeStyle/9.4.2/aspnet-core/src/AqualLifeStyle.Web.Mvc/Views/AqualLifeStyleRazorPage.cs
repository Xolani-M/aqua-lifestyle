using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AqualLifeStyle.Web.Views
{
    public abstract class AqualLifeStyleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AqualLifeStyleRazorPage()
        {
            LocalizationSourceName = AqualLifeStyleConsts.LocalizationSourceName;
        }
    }
}
