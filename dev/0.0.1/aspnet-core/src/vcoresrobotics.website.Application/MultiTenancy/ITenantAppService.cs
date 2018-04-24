using Abp.Application.Services;
using Abp.Application.Services.Dto;
using vcoresrobotics.website.MultiTenancy.Dto;

namespace vcoresrobotics.website.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
