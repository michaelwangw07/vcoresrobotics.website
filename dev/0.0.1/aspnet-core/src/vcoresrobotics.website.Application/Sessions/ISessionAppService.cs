using System.Threading.Tasks;
using Abp.Application.Services;
using vcoresrobotics.website.Sessions.Dto;

namespace vcoresrobotics.website.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
