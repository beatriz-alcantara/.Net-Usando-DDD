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
            RuleFor(cliente => cliente.LojaId).GreaterThan(0);
            RuleFor(cliente => cliente.Pets).NotEmpty();
        }
        public IList<ValidationFailure> Validacao(Cliente cliente) {
            var result = base.Validate(cliente).Errors;
            return result;
        }
    }
}