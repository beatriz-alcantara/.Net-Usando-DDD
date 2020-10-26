using System.Collections.Generic;
using Domain.Model;
using Domain.ResultValidations;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Validators {
    public class ClienteValidator : AbstractValidator<Cliente> {
        public ClienteValidator() {
            RuleFor(cliente => cliente.Nome).NotEmpty().MaximumLength(60);
            RuleFor(cliente => cliente.DataNascimento).NotNull();
            RuleFor(cliente => cliente.LojaId).NotEmpty().NotNull();
            RuleFor(cliente => cliente.Pets).NotEmpty();
        }
    }
}