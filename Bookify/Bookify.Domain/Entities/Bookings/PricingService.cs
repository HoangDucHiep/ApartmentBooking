﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Entities.Apartments;
using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Bookings;
public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(
            apartment.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpCharge = 0;

        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m, // 5% upcharge
                Amenity.AirConditioning or Amenity.Parking => 0.01m, // 1% upcharge
                _ => 0 // no upcharge for other amenities
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);

        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero();

        if (apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}