using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public class BookingCancelledDomainEvent : IDomainEvent
{
    public BookingCancelledDomainEvent(Guid id)
    {
        throw new NotImplementedException();
    }
}