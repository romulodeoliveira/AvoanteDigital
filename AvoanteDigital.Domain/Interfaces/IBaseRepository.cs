using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    void Insert(TEntity obj);

    void Update(TEntity obj);

    void Delete(int id);

    IList<TEntity> Select();

    TEntity Select(int id);
}