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
            RuleFor(beverage => beverage.Id).NotNull().WithMessage("Empty id");
            RuleFor(beverage => beverage.Description).NotNull().WithMessage("Empty id");
            RuleFor(beverage => beverage.Ingredients).NotNull().WithMessage("Empty id");
            RuleFor(beverage => beverage.Price).NotNull().GreaterThan(0).WithMessage("Please enter a price above 0");
        }
    }
}
