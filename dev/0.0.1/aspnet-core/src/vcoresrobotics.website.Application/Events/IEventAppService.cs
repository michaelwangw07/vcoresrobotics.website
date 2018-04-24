using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;
using vcoresrobotics.website.Events.Dtos;

namespace vcoresrobotics.website.Events
{
    public interface IEventAppService:IApplicationService
    {
        Task<ListResultDto<EventListDto>> GetListAsync(GetEventListInput input);

        Task<EventDetailOutput> GetDetailAsync(EntityDto<Guid> input);

        Task CreateAsync(CreateEventInput input);

        Task CancelAsync(EntityDto<Guid> input);

        Task<EventRegisterOutput> RegisterAsync(EntityDto<Guid> input);

        Task CancelRegistrationAsync(EntityDto<Guid> input);
    }
}
