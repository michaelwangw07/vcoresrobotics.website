using Abp.Domain.Services;
using System.Threading.Tasks;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Events
{
    public interface IEventRegistrationPolicy: IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@event"/> and throws exception if can not.
        /// </summary>
        Task CheckRegistrationAttemptAsync(Event @event, User user);
    }
}
