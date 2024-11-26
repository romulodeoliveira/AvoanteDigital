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

    public void UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }
    
    public User SelectUser(string email) =>
        _context.Users.SingleOrDefault(u => u.Email == email);
}