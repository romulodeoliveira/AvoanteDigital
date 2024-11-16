using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Service.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Por favor, insira o nome")
            .NotNull().WithMessage("Por favor, insira o nome");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Por favor, insira o e-mail")
            .NotNull().WithMessage("Por favor, insira o e-mail")
            .Matches(@"@").WithMessage("O e-mail deve conter o caractere '@'");
        
        RuleFor(c => c.TelephoneNumber)
            .NotEmpty().WithMessage("Por favor, insira o telefone")
            .NotNull().WithMessage("Por favor, insira o telefone")
            .Must(t => !t.Contains(" ")).WithMessage("O telefone não pode conter espaços em branco")
            .Length(11).WithMessage("O número de telefone deve ter exatamente 11 caracteres");
    }
}