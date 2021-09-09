using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Validation
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T obj);
    }
}
