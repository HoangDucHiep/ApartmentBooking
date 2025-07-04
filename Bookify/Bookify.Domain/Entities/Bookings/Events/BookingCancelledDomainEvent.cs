using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Bookings.Events;

public class BookingCancelledDomainEvent : IDomainEvent
{
    public BookingCancelledDomainEvent(Guid id)
    {
        throw new NotImplementedException();
    }
}