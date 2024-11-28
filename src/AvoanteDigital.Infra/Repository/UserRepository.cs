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
        _context.SaveChanges();
    }
    
    public async Task<User> SelectUserAsync(string email) =>
        _context.Users.SingleOrDefault(u => u.Email == email);
}