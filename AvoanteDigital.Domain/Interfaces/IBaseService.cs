using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Interfaces;

public interface IBaseService<TEntity> where TEntity : Entity
{
    TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class;

    void Delete(int id);

    IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;

    TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

    TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class;
}