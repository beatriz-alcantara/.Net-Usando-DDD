using FluentValidation.Results;
using FluentValidation;
using System.Collections.Generic;

namespace Domain.ResultValidations {
    public class ResultValidation : ValidationResult {
        public ResultValidation(IEnumerable<ValidationFailure> failures) : base (failures)
        {
            
        }
    }
}