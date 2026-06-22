using System.Threading.Tasks;
using AqualLifeStyle.Configuration.Dto;

namespace AqualLifeStyle.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
