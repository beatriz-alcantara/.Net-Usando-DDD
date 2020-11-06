using Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{
    public class VeterinarioValidator : AbstractValidator<Veterinario>
    {
        public VeterinarioValidator()
        {
            RuleFor(veterinario => veterinario.Nome).NotEmpty().MaximumLength(60);
            RuleFor(veterinario => veterinario.Formacao).NotEmpty().MinimumLength(15).MaximumLength(100);
            RuleFor(veterinario => veterinario.Descricao).NotEmpty().MinimumLength(20).MaximumLength(150);
        }
    }
}
