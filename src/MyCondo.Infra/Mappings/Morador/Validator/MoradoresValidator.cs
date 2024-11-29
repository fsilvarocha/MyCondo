using FluentValidation;
using MyCondo.Domain.Entities.Morador;

namespace MyCondo.Infra.Mappings.Morador.Validator;

public class MoradoresValidator : AbstractValidator<Moradores>
{
    public MoradoresValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MaximumLength(150)
            .WithMessage("Nome é obrigatório e não pode ser maior que 150 caracteres");
    }
}
