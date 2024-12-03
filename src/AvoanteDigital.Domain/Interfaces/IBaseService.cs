using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Interfaces;

public interface IBaseService<TEntity> where TEntity : Entity
{
    Task<bool> AddAsync<TInputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class;

    Task DeleteAsync(Guid id);

    Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class;

    Task<TOutputModel> GetByIdAsync<TOutputModel>(Guid id) where TOutputModel : class;

    Task<bool> UpdateAsync<TInputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class;
}