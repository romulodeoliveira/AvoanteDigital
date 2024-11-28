using System.Collections;
using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    Task InsertAsync(TEntity obj);

    Task UpdateAsync(TEntity obj);

    Task DeleteAsync(Guid id);

    Task<IEnumerable<TEntity>> SelectAsync();

    Task<TEntity> SelectAsync(Guid id);
}