using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Service.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Por favor, insira o nome")
            .NotNull().WithMessage("Por favor, insira o nome")
            .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Por favor, insira o e-mail")
            .NotNull().WithMessage("Por favor, insira o e-mail")
            .Matches(@"@").WithMessage("O e-mail deve conter o caractere '@'")
            .Matches(@"\.").WithMessage("O e-mail deve conter o caractere '.'")
            .MaximumLength(50).WithMessage("O e-mail não pode ter mais que 50 caracteres");
        
        RuleFor(c => c.TelephoneNumber)
            .NotEmpty().WithMessage("Por favor, insira o telefone")
            .NotNull().WithMessage("Por favor, insira o telefone")
            .Must(t => !t.Contains(" ")).WithMessage("O telefone não pode conter espaços em branco")
            .Length(11).WithMessage("O número de telefone deve ter exatamente 11 caracteres");
    }
}