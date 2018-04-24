using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using vcoresrobotics.website.Roles.Dto;
using vcoresrobotics.website.Users.Dto;

namespace vcoresrobotics.website.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
