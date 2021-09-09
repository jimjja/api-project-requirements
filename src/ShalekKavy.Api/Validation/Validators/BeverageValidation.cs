using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Validation.Validators
{
    public class BeverageValidation : IBeverageValidation
    {
        public ValidationResult Validate(Beverage obj)
        {
            var validator = new BeverageValidation();
            return validator.Validate(obj);

        }
    }
}
