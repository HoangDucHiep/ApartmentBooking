using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public class BookingRejectedDomainEvent : IDomainEvent
{
    public BookingRejectedDomainEvent(Guid id)
    {
        throw new NotImplementedException();
    }
}