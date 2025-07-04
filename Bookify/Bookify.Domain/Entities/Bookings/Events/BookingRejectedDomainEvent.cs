using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Bookings.Events;

public class BookingRejectedDomainEvent : IDomainEvent
{
    public BookingRejectedDomainEvent(Guid id)
    {
        throw new NotImplementedException();
    }
}