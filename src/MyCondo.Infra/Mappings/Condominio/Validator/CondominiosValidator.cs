using FluentValidation;
using MyCondo.Domain.Entities.Condominio;

namespace MyCondo.Infra.Mappings.Condominio.Validator;

public class CondominiosValidator : AbstractValidator<Condominios>
{
    public CondominiosValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MaximumLength(150)
            .WithMessage("Nome é obrigatório e não pode ser maior que 150 caracteres");
    }
}
