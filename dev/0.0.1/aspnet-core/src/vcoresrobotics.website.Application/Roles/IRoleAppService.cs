using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using vcoresrobotics.website.Roles.Dto;

namespace vcoresrobotics.website.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
