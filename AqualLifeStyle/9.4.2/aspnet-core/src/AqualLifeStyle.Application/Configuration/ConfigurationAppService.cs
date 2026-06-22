using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AqualLifeStyle.Configuration.Dto;

namespace AqualLifeStyle.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AqualLifeStyleAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
