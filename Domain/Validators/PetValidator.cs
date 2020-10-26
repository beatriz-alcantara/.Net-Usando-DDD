using Domain.Model;
using FluentValidation;

namespace Domain.Validators {
    public class PetValidator : AbstractValidator<Pet> { 
        public PetValidator()
        {
            RuleFor(pet => pet.Nome).NotEmpty();
            RuleFor(pet => pet.Raca).NotEmpty();
            RuleFor(pet => pet.Especie).NotEmpty();
            RuleFor(pet => pet.ClienteId).NotNull();
        }
    }
}
