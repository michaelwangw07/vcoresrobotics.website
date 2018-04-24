using System.Threading.Tasks;
using vcoresrobotics.website.Configuration.Dto;

namespace vcoresrobotics.website.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
