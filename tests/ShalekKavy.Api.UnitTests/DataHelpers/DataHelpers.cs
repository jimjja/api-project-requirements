using ShalekKavy.Api.Models.Enums;
using System;
using System.Collections.Generic;

namespace ShalekKavy.Api.UnitTests.DataHelpers
{
    public static class DataHelpers
    {
        public static Beverage GetBeverageById()
        {
            return new Beverage
            {
                Id = "1",
                Name = "latte",
                Description = "Blend espresso with steamed milk for a smooth and creamy coffee.",
                BeverageType = BeverageType.Others,
                Allergens = new List<string>() { "milk" },
                Ingredients = new List<string>() { "milk", "sugar", "coffee" },
                Price = 1,
                Availability = 0,
                Size = BeverageSize.Regular,
                AddOns = new List<Models.AddOns>
                {
                    new Models.AddOns
                    {
                        Id = "1",
                        Name = "caramel syrup",
                        Price = 0.4,
                        Availability = 0,
                        BeverageId = "1",
                        Type = AddOnType.Flavour,
                        DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                        DateModified = new DateTime(2021, 01, 01, 08, 24, 17),
                    }
                },
                DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                DateModified = new DateTime(2021, 01, 01, 08, 24, 17)
            };
        }

        public static Beverage GetBeverage()
        {
            return new Beverage
            {
                Id = "1",
                Name = "latte",
                Description = "Blend espresso with steamed milk for a smooth and creamy coffee.",
                BeverageType = BeverageType.Others,
                Allergens = new List<string>() { "milk" },
                Ingredients = new List<string>() { "milk", "sugar", "coffee" },
                Price = 1,
                Availability = 0,
                Size = BeverageSize.Regular,
                AddOns = new List<Models.AddOns>
                {
                    new Models.AddOns
                    {
                        Id = "1",
                        Name = "caramel syrup",
                        Price = 0.4,
                        Availability = 0,
                        BeverageId = "1",
                        Type = AddOnType.Flavour,
                        DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                        DateModified = new DateTime(2021, 01, 01, 08, 24, 17),
                    }
                },
                DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                DateModified = new DateTime(2021, 01, 01, 08, 24, 17)
            };
        }

        public static Beverage GetExistingBeverage()
        {
            return new Beverage
            {
                Id = "2",
                Name = "hot chocolate",
                Description = "We only use the best cocoa for this indulgent drink. Perfect for days when you need a hug in a cup.",
                BeverageType = BeverageType.Others,
                Ingredients = new List<string> { "cocoa powder", "milk", "sugar" },
                Allergens = new List<string>() { "milk" },
                Price = 1,
                Availability = 0,
                Size = BeverageSize.Regular,
                AddOns = new List<Models.AddOns>
                {
                    new Models.AddOns
                    {
                        Id = "2",
                        Name = "chocolate shavings",
                        Price = 0.45,
                        Availability = 0,
                        BeverageId = "2",
                        Type = AddOnType.Flavour,
                        DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                        DateModified = new DateTime(2021, 01, 01, 08, 24, 17),
                    }
                },
                DateCreated = new DateTime(2021, 01, 01, 08, 24, 17),
                DateModified = new DateTime(2021, 01, 01, 08, 24, 17)
            };

        }
    }
}
