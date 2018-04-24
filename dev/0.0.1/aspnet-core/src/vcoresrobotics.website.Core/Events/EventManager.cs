using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Events
{
    public class EventManager : IEventManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IEventRegistrationPolicy _eventRegistrationPolicy;
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;
        private readonly IRepository<Event, Guid> _eventRepository;

        public EventManager(
            IEventRegistrationPolicy eventRegistrationPolicy,
            IRepository<EventRegistration> eventRegistrationRepository,
            IRepository<Event, Guid> eventRepository
            )
        {
            _eventRegistrationPolicy = eventRegistrationPolicy;
            _eventRegistrationRepository = eventRegistrationRepository;
            _eventRepository = eventRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Event> GetAsync(Guid id)
        {
            var @event = await _eventRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not find the event, maybe it's deleted!");
            }

            return @event;
        }

        public async Task CreateAsync(Event @event)
        {
            await _eventRepository.InsertAsync(@event);
        }

        public void Cancel(Event @event)
        {
            @event.Cancel();
            EventBus.Trigger(new EventCancelledEvent(@event));
        }

        public async Task<EventRegistration> RegisterAsync(Event @event, User user )
        {
            return await _eventRegistrationRepository.InsertAsync(
                await EventRegistration.CreateAsync(@event, user, _eventRegistrationPolicy));
        }

        public async Task CancelRegistrationAsync(Event @event, User user)
        {
            var registration = await _eventRegistrationRepository.FirstOrDefaultAsync(r=>r.EventId==@event.Id && r.UserId==user.Id);
            if (registration==null)
            {
                
                return;
            }

            await registration.CancelAsync(_eventRegistrationRepository);
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Event @event)
        {
            return await _eventRegistrationRepository
                .GetAll()
                .Include(registration=>registration.User)
                .Where(registration => registration.EventId==@event.Id)
                .Select(registration=>registration.User)
                .ToListAsync();
        }

    }
}
