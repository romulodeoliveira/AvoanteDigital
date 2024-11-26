using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AvoanteDigital.Infra.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public void Insert(TEntity obj)
    {
        _context.Set<TEntity>().Add(obj);
        _context.SaveChanges();
    }

    public void Update(TEntity obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public void Delete(Guid id)
    {
        _context.Set<TEntity>().Remove(Select(id));
        _context.SaveChanges();
    }

    public IList<TEntity> Select() =>
        _context.Set<TEntity>().ToList();

    public TEntity Select(Guid id) =>
        _context.Set<TEntity>().Find(id);
}