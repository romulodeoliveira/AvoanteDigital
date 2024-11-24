using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Infra.Data.Context;
using AvoanteDigital.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvoanteDigital.Domain.Infra.Data.Repository;

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