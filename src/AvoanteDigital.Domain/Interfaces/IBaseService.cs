using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Interfaces;

public interface IBaseService<TEntity> where TEntity : Entity
{
    Task<TOutputModel> AddAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class;

    Task DeleteAsync(Guid id);

    Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class;

    Task<TOutputModel> GetByIdAsync<TOutputModel>(Guid id) where TOutputModel : class;

    Task<TOutputModel> UpdateAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class;
}