using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AvoanteDigital.Infra.Repository;

public class UserRepository : IUserRepository
{
    protected readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    public async Task<User> SelectUserAsync(string email) =>
        await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    
    public async Task DeleteAsync(string email)
    {
        _context.Set<User>().Remove(await SelectUserAsync(email));
        await _context.SaveChangesAsync();
    }
}