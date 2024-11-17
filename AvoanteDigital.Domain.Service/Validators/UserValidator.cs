using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Service.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
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
            .IsInEnum().WithMessage("O papel do usuário deve ser válido.");

        RuleFor(u => u.Password)
            .NotNull().WithMessage("A senha é obrigatória.")
            .DependentRules(() =>
            {
                RuleFor(u => u.Password.PasswordLiteral)
                    .NotEmpty().WithMessage("A senha não pode ser vazia.")
                    .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres.")
                    .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                    .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                    .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                    .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial.");
            });
    }
}