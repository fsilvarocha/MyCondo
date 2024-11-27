using FluentValidation;
using MyCondo.Domain.Entities.Bloco;

namespace MyCondo.Infra.Mappings.Bloco.Validator;

public class BlocosValidator : AbstractValidator<Blocos>
{
    public BlocosValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MaximumLength(150)
            .WithMessage("Nome é obrigatório e não pode ser maior que 150 caracteres");

        RuleFor(p => p.QuantidadeAndar)
            .NotEmpty()
            .WithMessage("Quantidade de Andar é obrigatório");
    }
}
