using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Service.Validators;

public class CreateEbookValidator : AbstractValidator<Ebook>
{
    public CreateEbookValidator()
    {
        RuleFor(book => book.Name)
            .NotEmpty().WithMessage("Por favor, insira o nome")
            .MaximumLength(50).WithMessage("O nome não pode ter mais que 50 caracteres");
        
        RuleFor(book => book.Description)
            .NotEmpty().WithMessage("Por favor, insira a descrição")
            .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres");

        RuleFor(book => book.IsActive)
            .NotNull().WithMessage("O status de atividade do usuário não pode ser nulo");

        RuleFor(book => book.PDF)
            .NotNull().WithMessage("O arquivo precisa ser inserido")
            .Must(fileBytes => IsPdf(fileBytes)).WithMessage("O arquivo precisa ser PDF");
    }
    
    bool IsPdf(byte[] fileBytes)
    {
        byte[] pdfSignature = new byte[] { 0x25, 0x50, 0x44, 0x46 };
        return fileBytes.Length > 4 && pdfSignature.SequenceEqual(fileBytes.Take(4));
    }
}
