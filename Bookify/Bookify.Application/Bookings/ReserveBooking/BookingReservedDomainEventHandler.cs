using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

public class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{

    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository, 
        IUserRepository userRepository, 
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        if (booking is null)
        {
            return; // Booking not found, nothing to do
        }

        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user is null)
        {
            return; // User not found, nothing to do
        }

        var subject = "Booking reserved!";
        var body = $"Your booking for {booking.Apartment.Name} has been confirmed from {booking.StartDate} to {booking.EndDate}.";
        await _emailService.SendAsync(user.Email, subject, body);
    }
}