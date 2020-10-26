using Domain.Model;
using FluentValidation;

namespace Domain.Validators {
    public class LojaValidator : AbstractValidator<Loja> {
        public LojaValidator ()
        {
            RuleFor(loja => loja.Nome).NotEmpty();
            RuleFor(loja => loja.Descricao).NotEmpty();
        }
    }

}
