using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using FluentValidation;

namespace AvoanteDigital.Service.Validators;

public class RegisterUserValidator : AbstractValidator<User>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Firstname)
            .NotEmpty().WithMessage("Por favor, insira o primeiro nome.")
            .MaximumLength(50).WithMessage("O primeiro nome não pode ter mais que 50 caracteres.");
        
        RuleFor(u => u.Lastname)
            .NotEmpty().WithMessage("Por favor, insira o sobrenome.")
            .MaximumLength(50).WithMessage("O sobrenome não pode ter mais que 50 caracteres.");
        
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Por favor, insira o e-mail.")
            .MaximumLength(100).WithMessage("O e-mail não pode ter mais que 100 caracteres.");
        
        RuleFor(u => u.Role)
            .Must(role => role == UserRole.Admin || role == UserRole.User)
            .WithMessage("O papel do usuário deve ser válido. Valores aceitos: 1 (Admin) ou 2 (User).");

        RuleFor(u => u.Password)
            .NotNull().WithMessage("A senha é obrigatória.")
            .DependentRules(() =>
            {
                RuleFor(u => u.Password.PasswordLiteral)
                    .NotEmpty().WithMessage("A senha não pode ser vazia")
                    .MaximumLength(20).WithMessage("A senha deve ter, no máximo, 20 caracteres")
                    .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres")
                    .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                    .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                    .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número")
                    .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial");
            });
    }
}