using AutoMapper;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using FluentValidation;

namespace AvoanteDigital.Service.Services;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
{
    private readonly IBaseRepository<TEntity> _repository;

    private readonly IMapper _mapper;
    
    public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class
    {
        TEntity entity = _mapper.Map<TEntity>(inputModel);
        
        Validate(entity, Activator.CreateInstance<TValidator>());
        _repository.Insert(entity);
        
        TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
        
        return outputModel;
    }

    public void Delete(Guid id) => _repository.Delete(id);

    public IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class
    {
        var entities = _repository.Select();
        
        var outputModel = entities.Select(entity => _mapper.Map<TOutputModel>(entity)).ToList();

        return outputModel;
    }

    public TOutputModel GetById<TOutputModel>(Guid id) where TOutputModel : class
    {
        var entity = _repository.Select(id);
        
        var outputModel = _mapper.Map<TOutputModel>(entity);

        return outputModel;
    }

    public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class
    {
        TEntity entity = _mapper.Map<TEntity>(inputModel);

        Validate(entity, Activator.CreateInstance<TValidator>());
        _repository.Update(entity);

        TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

        return outputModel;
    }

    private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
    {
        if (obj == null)
            throw new Exception("Registros não detectados!");

        validator.ValidateAndThrow(obj);
    }
}