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
    
    public async Task<TOutputModel> AddAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class
    {
        TEntity entity = _mapper.Map<TEntity>(inputModel);
        
        await Validate(entity, Activator.CreateInstance<TValidator>());
        await _repository.InsertAsync(entity);
        
        TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
        
        return outputModel;
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<TOutputModel>> GetAsync<TOutputModel>() where TOutputModel : class
    {
        var entities = await _repository.SelectAsync();
        
        var outputModel = entities.Select(entity => _mapper.Map<TOutputModel>(entity)).ToList();

        return outputModel;
    }

    public async Task<TOutputModel> GetByIdAsync<TOutputModel>(Guid id) where TOutputModel : class
    {
        var entity = await _repository.SelectAsync(id);
        
        var outputModel = _mapper.Map<TOutputModel>(entity);

        return outputModel;
    }

    public async Task<TOutputModel> UpdateAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<TEntity>
        where TInputModel : class
        where TOutputModel : class
    {
        TEntity entity = _mapper.Map<TEntity>(inputModel);

        await Validate(entity, Activator.CreateInstance<TValidator>());
        await _repository.UpdateAsync(entity);

        TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

        return outputModel;
    }

    private async Task Validate(TEntity obj, AbstractValidator<TEntity> validator)
    {
        if (obj == null)
            throw new Exception("Registros não detectados!");

        validator.ValidateAndThrow(obj);
    }
}