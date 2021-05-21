using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Validation
{
    public class BeverageValidator : AbstractValidator<Beverage>
    {
        public BeverageValidator()
        {
            RuleFor(beverage => beverage.Id).NotEmpty();
            RuleFor(beverage => beverage.Description).NotEmpty();
            RuleFor(beverage => beverage.BeverageType).IsInEnum();
            RuleFor(beverage => beverage.Ingredients).NotEmpty();
            RuleFor(beverage => beverage.Price).NotNull().GreaterThan(0);
            RuleFor(beverage => beverage.Availability).IsInEnum();
            RuleFor(beverage => beverage.Size).IsInEnum();
            RuleForEach(beverage => beverage.AddOns).SetValidator(new AddOnsValidator());
        }
    }
}
