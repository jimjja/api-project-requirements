using FluentValidation;
using ShalekKavy.Api.Models;

namespace ShalekKavy.Api.Validation
{
    public class AddOnsValidator : AbstractValidator<AddOns>
    {
        public AddOnsValidator()
        {
            RuleFor(addOn => addOn.Id).NotEmpty();
            RuleFor(addOn => addOn.BeverageId).NotEmpty();
            RuleFor(addOn => addOn.Name).NotEmpty();
            RuleFor(addOn => addOn.Availability).IsInEnum();
            RuleFor(addOn => addOn.Type).IsInEnum();
            RuleFor(addOn => addOn.Price).GreaterThan(0);
        }
    }
}
