using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using FluentValidation;

namespace AvoanteDigital.Service.Validators;

public class UpdateProfileValidator : AbstractValidator<User>
{
    public UpdateProfileValidator()
    {
        RuleFor(u => u.Firstname)
            .NotEmpty().WithMessage("Por favor, insira o primeiro nome.")
            .MaximumLength(50).WithMessage("O primeiro nome não pode ter mais que 50 caracteres.");
        
        RuleFor(u => u.Lastname)
            .NotEmpty().WithMessage("Por favor, insira o sobrenome.")
            .MaximumLength(50).WithMessage("O sobrenome não pode ter mais que 50 caracteres.");
        
        RuleFor(u => u.IsActive)
            .NotNull().WithMessage("O status de atividade do usuário não pode ser nulo.");
    }
}