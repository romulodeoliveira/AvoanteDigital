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

    public async Task InsertAsync(TEntity obj)
    {
        await _context.Set<TEntity>().AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        _context.Set<TEntity>().Remove(await SelectAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> SelectAsync() =>
        await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> SelectAsync(Guid id) =>
        await _context.Set<TEntity>().FindAsync(id);
}