using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;


/// <summary>
/// Repository interface for managing booking entities.
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// Retrieves a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>The booking if found; otherwise, null.</returns>
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if there are any overlapping bookings for the specified apartment during the given date range.
    /// </summary>
    /// <param name="apartment">The apartment to check for booking overlaps.</param>
    /// <param name="duration">The date range to check for overlaps.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>True if there is an overlap with existing bookings; otherwise, false.</returns>
    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new booking to the repository.
    /// </summary>
    /// <param name="booking">The booking to add.</param>
    void Add(Booking booking);
}