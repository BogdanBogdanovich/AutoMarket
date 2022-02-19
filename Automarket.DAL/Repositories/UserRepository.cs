using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Create(User entity)
    {
        try
        {
            await _db.User.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            return false;
        }
        
        
    }

    public async Task<User> Get(int idUser)
    {
        return await _db.User.FirstOrDefaultAsync(x => x.idUser == idUser);
    }

    public async Task<List<User>> Select()
    {
        return await _db.User.ToListAsync();
    }

    public async Task<bool> Delete(User entity)
    {
        _db.User.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<User?> GetByName(string name)
    {
        return await _db.User.FirstOrDefaultAsync(x => x.Name == name);
    }
}