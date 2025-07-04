using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Apartments;
using Bookify.Domain.Entities.Bookings.Events;
using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Bookings;

public sealed class Booking(Guid id, Guid apartmentId, Guid userId, DateRange duration, Money priceForPeriod, Money cleaningFee, Money amenitiesUpCharge, Money totalPrice, BookingStatus status, DateTime createdOnUtc) : Entity(id)
{
    public Guid ApartmentId { get; private set; } = apartmentId;
    public Guid UserId { get; private set; } = userId;
    public DateRange Duration { get; private set; } = duration;
    public Money PriceForPeriod { get; private set; } = priceForPeriod;
    public Money CleaningFee { get; private set; } = cleaningFee;
    public Money AmenitiesUpCharge { get; private set; } = amenitiesUpCharge;
    public Money TotalPrice { get; private set; } = totalPrice;
    public BookingStatus Status { get; private set; } = status;
    public DateTime CreatedOnUtc { get; private set; } = createdOnUtc;
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Apartment apartment,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(apartment, duration);
        var booking = new Booking(
            Guid.NewGuid(),
            apartment.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow);

        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

        apartment.LastBookedOnUtc = utcNow;

        return booking;
    }
}