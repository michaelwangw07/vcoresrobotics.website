using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using vcoresrobotics.website.Configuration.Dto;

namespace vcoresrobotics.website.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : websiteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
