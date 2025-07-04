using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Bookings;

public record PricingDetails (
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice
);