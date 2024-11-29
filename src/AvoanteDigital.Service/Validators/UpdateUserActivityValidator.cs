using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using FluentValidation;

namespace AvoanteDigital.Service.Validators;

public class UpdateUserActivityValidator : AbstractValidator<User>
{
    public UpdateUserActivityValidator()
    {
        RuleFor(u => u.Role)
            .Must(role => role == UserRole.Admin || role == UserRole.Manager)
            .WithMessage("O papel do usuário deve ser válido. Valores aceitos: 0 (Admin) ou 1 (User).");
        
        RuleFor(u => u.IsActive)
            .NotNull().WithMessage("O status de atividade do usuário não pode ser nulo.")
            .Must(isActive => isActive == true || isActive == false).WithMessage("O status de atividade do usuário deve ser um valor booleano.");
    }
}