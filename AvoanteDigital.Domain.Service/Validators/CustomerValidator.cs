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
            .NotNull().WithMessage("Por favor, insira o e-mail");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Por favor, insira o telefone")
            .NotNull().WithMessage("Por favor, insira o telefone");
    }
}