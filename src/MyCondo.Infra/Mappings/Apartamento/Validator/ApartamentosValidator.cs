using FluentValidation;
using MyCondo.Domain.Entities.Apartamento;

namespace MyCondo.Infra.Mappings.Apartamento.Validator;

public class ApartamentosValidator : AbstractValidator<Apartamentos>
{
    public ApartamentosValidator()
    {
        RuleFor(p => p.Numero)
            .NotEmpty()
            .MaximumLength(150)
            .WithMessage("Número do Apartamento é obrigatório");
    }
}
